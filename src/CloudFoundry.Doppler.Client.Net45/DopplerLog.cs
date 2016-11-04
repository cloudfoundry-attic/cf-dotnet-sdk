namespace CloudFoundry.Doppler.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;
    using DropsondeProtocol;

    /// <summary>
    /// This is the Doppler client. To use it, you need a Doppler endpoint and an authorization token from UAA.
    /// </summary>
    public class DopplerLog : IDisposable
    {
        private bool disposed;
        private DopplerWebSocket webSocket;
        private ProtobufSerializer protobufSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DopplerLog"/> class.
        /// </summary>
        /// <param name="dopplerEndpoint">The Doppler endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        public DopplerLog(Uri dopplerEndpoint, string authenticationToken)
            : this(dopplerEndpoint, authenticationToken, null, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DopplerLog"/> class.
        /// </summary>
        /// <param name="dopplerEndpoint">The Doppler endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        public DopplerLog(Uri dopplerEndpoint, string authenticationToken, Uri httpProxy)
            : this(dopplerEndpoint, authenticationToken, httpProxy, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DopplerLog"/> class.
        /// </summary>
        /// <param name="dopplerEndpoint">The Doppler endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        public DopplerLog(Uri dopplerEndpoint, string authenticationToken, Uri httpProxy, bool skipCertificateValidation)
        {
            this.DopplerEndpoint = dopplerEndpoint;
            this.AuthenticationToken = authenticationToken;
            this.HttpProxy = httpProxy;
            this.SkipCertificateValidation = skipCertificateValidation;

            this.protobufSerializer = new ProtobufSerializer();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DopplerLog"/> class.
        /// </summary>
        ~DopplerLog()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Occurs when an error is received from Doppler.
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorReceived;

        /// <summary>
        /// Occurs when a message is received from Doppler.
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;

        /// <summary>
        /// Occurs when the Doppler stream is closed.
        /// </summary>
        public event EventHandler<EventArgs> StreamClosed;

        /// <summary>
        /// Occurs when the Doppler stream is opened. 
        /// </summary>
        public event EventHandler<EventArgs> StreamOpened;

        /// <summary>
        /// Gets or sets the Doppler endpoint.
        /// You can get this using the CloudFoundry.CloudController.V2.Client.Info.GetV1Info method.
        /// </summary>
        public Uri DopplerEndpoint
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
        /// The HTTP proxy endpoint. Only HTTP proxy targets are supported.
        /// </summary>
        public Uri HttpProxy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the flag to disable the validation of SSL/TLS certificates. 
        /// WARNING: Set true only in debug environment or on trusted networks.
        /// </summary>
        public bool SkipCertificateValidation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the state of the connection to the Doppler endpoint.
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
        /// Starts tailing logs from Doppler for the specified app.
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

            UriBuilder appLogUri = new UriBuilder(this.DopplerEndpoint);

            appLogUri.Path = string.Format(CultureInfo.InvariantCulture, "/apps/{0}/stream", appGuid); ;

            this.webSocket = new DopplerWebSocket();

            this.webSocket.DataReceived += this.WebSocketMessageReceived;
            this.webSocket.ErrorReceived += this.WebSocketError;
            this.webSocket.StreamOpened += this.WebSocketOpened;
            this.webSocket.StreamClosed += this.WebSocketClosed;

            this.webSocket.Open(appLogUri.Uri, this.AuthenticationToken, this.HttpProxy, this.SkipCertificateValidation);
        }

        /// <summary>
        /// Returns a LogMessage containing recent logs
        /// </summary>
        /// <param name="appGuid">The Cloud Foundry app unique identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">appGuid</exception>
        /// <returns></returns>
        [CLSCompliant(false)]
        public async Task<Envelope[]> Recent(string appGuid, CancellationToken cancellationToken)
        {
            if (appGuid == null)
            {
                throw new ArgumentNullException("appGuid");
            }

            UriBuilder appLogUri = new UriBuilder(this.DopplerEndpoint);

            if (appLogUri.Scheme == "ws")
            {
                appLogUri.Scheme = "http";
            }
            else
            {
                appLogUri.Scheme = "https";
            }

            appLogUri.Path = string.Format(CultureInfo.InvariantCulture, "/apps/{0}/recentlogs", appGuid);

            SimpleHttpClient client = new SimpleHttpClient(cancellationToken);
            client.Uri = appLogUri.Uri;
            client.Method = HttpMethod.Get;
            client.Headers.Add("AUTHORIZATION", this.AuthenticationToken);
            client.HttpProxy = this.HttpProxy;
            client.SkipCertificateValidation = this.SkipCertificateValidation;

            SimpleHttpResponse response = await client.SendAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                string errorMessage = await response.ReadContentAsStringAsync();
                throw new DopplerException(string.Format(CultureInfo.InvariantCulture, "Server returned error code {0} with message: '{1}'", response.StatusCode, errorMessage));
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
                    return new Envelope[] { };
                }
                else
                {
                    throw;
                }
            }

            var messages = new List<Envelope>();
            foreach (var msg in multipart.Contents)
            {
                messages.Add(this.protobufSerializer.DeserializeEnvelope(await msg.ReadAsByteArrayAsync()));
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
