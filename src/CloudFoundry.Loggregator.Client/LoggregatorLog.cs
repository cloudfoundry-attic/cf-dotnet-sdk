namespace CloudFoundry.Loggregator.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.DependencyLocation;
    using CloudFoundry.CloudController.Common.Http;

    /// <summary>
    /// This is the Loggregator client. To use it, you need a Loggregator endpoint and an authorization token from UAA.
    /// </summary>
    public class LoggregatorLog : IDisposable
    {
        private bool disposed;
        private ILoggregatorWebSocket webSocket;
        private IProtobufSerializer protobufSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggregatorLog"/> class.
        /// </summary>
        /// <param name="loggregatorEndpoint">The Loggregator endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        public LoggregatorLog(Uri loggregatorEndpoint, string authenticationToken)
        {
            this.LoggregatorEndpoint = loggregatorEndpoint;
            this.AuthenticationToken = authenticationToken;

            this.protobufSerializer = new ProtobufSerializer();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="LoggregatorLog"/> class.
        /// </summary>
        ~LoggregatorLog()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Occurs when an error is received from Loggregator.
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorReceived;

        /// <summary>
        /// Occurs when a message is received from Loggregator.
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;

        /// <summary>
        /// Occurs when the Loggregator stream is closed.
        /// </summary>
        public event EventHandler<EventArgs> StreamClosed;

        /// <summary>
        /// Occurs when the Loggregator stream is opened. 
        /// </summary>
        public event EventHandler<EventArgs> StreamOpened;

        /// <summary>
        /// Gets or sets the Loggregator endpoint.
        /// You can get this using the CloudFoundry.CloudController.V2.Client.Info.GetV1Info method.
        /// </summary>
        public Uri LoggregatorEndpoint
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the UAA authentication token.
        /// </summary>
        public string AuthenticationToken
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the state of the connection to the Loggregator endpoint.
        /// </summary>
        public ConnectionState State
        {
            get
            {
                if (this.webSocket != null)
                {
                    return this.webSocket.State;
                }
                else
                {
                    return ConnectionState.None;
                }
            }
        }

        /// <summary>
        /// Stops the log stream.
        /// </summary>
        public void StopLogStream()
        {
            if (this.webSocket != null)
            {
                this.webSocket.Close();
                this.webSocket.Dispose();
                this.webSocket = null;
            }
        }
            
        /// <summary>
        /// Starts tailing logs from Loggregator for the specified app.
        /// </summary>
        /// <param name="appGuid">The Cloud Foundry app unique identifier.</param>
        /// <exception cref="System.ArgumentNullException">appGuid</exception>
        public void Tail(string appGuid)
        {
            if (appGuid == null)
            {
                throw new ArgumentNullException("appGuid");
            }

            if (this.webSocket != null)
            {
                throw new InvalidOperationException("The log stream has already been started.");
            }

            UriBuilder appLogUri = new UriBuilder(this.LoggregatorEndpoint);
            
            appLogUri.Path = "tail/";
            appLogUri.Query = string.Format(CultureInfo.InvariantCulture, "app={0}", appGuid);

            this.webSocket = new LoggregatorWebSocket();
            
            this.webSocket.DataReceived += this.WebSocketMessageReceived;
            this.webSocket.ErrorReceived += this.WebSocketError;
            this.webSocket.StreamOpened += this.WebSocketOpened;
            this.webSocket.StreamClosed += this.WebSocketClosed;

            this.webSocket.Open(appLogUri.Uri, this.AuthenticationToken);
        }

        /// <summary>
        /// Returns a LogMessage containing recent logs
        /// </summary>
        /// <param name="appGuid">The Cloud Foundry app unique identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">appGuid</exception>
        /// <returns></returns>
        public async Task<ApplicationLog[]> Recent(string appGuid, CancellationToken cancellationToken)
        {
            if (appGuid == null)
            {
                throw new ArgumentNullException("appGuid");
            }

            UriBuilder appLogUri = new UriBuilder(this.LoggregatorEndpoint);

            if (appLogUri.Scheme == "ws")
            {
                appLogUri.Scheme = "http";
            }
            else
            {
                appLogUri.Scheme = "https";
            }

            appLogUri.Path = "recent";
            appLogUri.Query = string.Format(CultureInfo.InvariantCulture, "app={0}", appGuid);

            IHttpAbstractionClient client = new DependencyLocator().Locate<IHttpAbstractionClientFactory>().Create(cancellationToken);
            client.Uri = appLogUri.Uri;
            client.Method = HttpMethod.Get;
            client.Headers.Add("AUTHORIZATION", this.AuthenticationToken);

            IHttpResponseAbstraction response = await client.SendAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new LoggregatorException(string.Format(CultureInfo.InvariantCulture, "Server returned error: {0}", response.StatusCode));
            }

            MultipartMemoryStreamProvider multipart = null;
            try
            {
                multipart = await response.Content.ReadAsMultipartAsync();
            }
            catch (IOException multipartException)
            {
                // There are no recent Logs. We need to investigate a better way for handling this
                if (multipartException.Message.Contains("MIME multipart message is not complete"))
                {
                    return new ApplicationLog[] { new ApplicationLog() { Message = "(Server did not return any recent logs)" } };
                }
                else
                {
                    throw;
                }
            }

            List<ApplicationLog> messages = new List<ApplicationLog>();
            foreach (var msg in multipart.Contents)
            {
                messages.Add(this.protobufSerializer.DeserializeApplicationLog(await msg.ReadAsByteArrayAsync()));
            }

            return messages.ToArray();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (this.webSocket != null)
            {
                this.webSocket.Dispose();
            }

            this.disposed = true;
        }

        private void WebSocketClosed(object sender, EventArgs e)
        {
            if (this.StreamClosed != null)
            {
                this.StreamClosed(this, e);
            }
        }

        private void WebSocketOpened(object sender, EventArgs e)
        {
            if (this.StreamOpened != null)
            {
                this.StreamOpened(this, e);
            }
        }

        private void WebSocketError(object sender, ErrorEventArgs e)
        {
            if (this.ErrorReceived != null)
            {
                this.ErrorReceived(this, new ErrorEventArgs() { Error = e.Error });
            }
        }

        private void WebSocketMessageReceived(object sender, DataEventArgs e)
        {
            if (this.MessageReceived != null)
            {
                MessageEventArgs args = new MessageEventArgs() { LogMessage = e.Data };
                this.MessageReceived(this, args);
            }
        }
    }
}