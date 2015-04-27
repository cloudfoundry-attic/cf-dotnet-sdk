namespace CloudFoundry.Logyard.Client
{
    using System;
    using System.Globalization;
    using System.Net;

    /// <summary>
    /// This is the Logyard client. To use it, you need a Logyard endpoint and an authorization token from UAA.
    /// </summary>
    public class LogyardLog : IDisposable
    {
        private bool disposed;
        private ILogyardWebSocket webSocket;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogyardLog"/> class.
        /// </summary>
        /// <param name="logyardEndpoint">The logyard endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        public LogyardLog(Uri logyardEndpoint, string authenticationToken)
            : this(logyardEndpoint, authenticationToken, null, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogyardLog"/> class.
        /// </summary>
        /// <param name="logyardEndpoint">The logyard endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        public LogyardLog(Uri logyardEndpoint, string authenticationToken, Uri httpProxy)
            : this(logyardEndpoint, authenticationToken, httpProxy, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogyardLog"/> class.
        /// </summary>
        /// <param name="logyardEndpoint">The logyard endpoint.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        public LogyardLog(Uri logyardEndpoint, string authenticationToken, Uri httpProxy, bool skipCertificateValidation)
        {
            this.LogyardEndpoint = logyardEndpoint;
            this.AuthenticationToken = authenticationToken;
            this.HttpProxy = httpProxy;
            this.SkipCertificateValidation = skipCertificateValidation;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="LogyardLog"/> class.
        /// </summary>
        ~LogyardLog()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Occurs when an error is received from Logyard.
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorReceived;

        /// <summary>
        /// Occurs when a message is received from Logyard.
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;

        /// <summary>
        /// Occurs when the Logyard stream is closed.
        /// </summary>
        public event EventHandler<EventArgs> StreamClosed;

        /// <summary>
        /// Occurs when the Logyard stream is opened. 
        /// </summary>
        public event EventHandler<EventArgs> StreamOpened;

        /// <summary>
        /// Gets or sets the logyard endpoint.
        /// You can get this using the CloudFoundry.CloudController.V2.Client.Info.GetV1Info method.
        /// </summary>
        public Uri LogyardEndpoint
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
        /// Gets the state of the connection to the Logyard endpoint.
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
        /// Starts streaming logs from Logyard for the specified app.
        /// It streams for all instances of the app, without tailing.
        /// </summary>
        /// <param name="appGuid">The Cloud Foundry app unique identifier.</param>
        public void StartLogStream(string appGuid)
        {
            this.StartLogStream(appGuid, -1, false);
        }

        /// <summary>
        /// Starts streaming logs from Logyard for the specified app, without tailing.
        /// </summary>
        /// <param name="appGuid">The Cloud Foundry app unique identifier.</param>
        /// <param name="instanceNumber">The number of the app instance that will be the source of the log stream.</param>
        public void StartLogStream(string appGuid, int instanceNumber)
        {
            this.StartLogStream(appGuid, instanceNumber, false);
        }

        /// <summary>
        /// Starts streaming logs from Logyard for the specified app, without tailing.
        /// </summary>
        /// <param name="appGuid">The Cloud Foundry app unique identifier.</param>
        /// <param name="instanceNumber">The number of the app instance that will be the source of the log stream.</param>
        /// <param name="tail">If set to <c>true</c> the application log files will be tailed.</param>
        /// <exception cref="System.ArgumentNullException">appGuid</exception>
        public void StartLogStream(string appGuid, int instanceNumber, bool tail)
        {
            if (appGuid == null)
            {
                throw new ArgumentNullException("appGuid");
            }

            if (this.webSocket != null)
            {
                throw new InvalidOperationException("The log stream has already been started.");
            }

            UriBuilder appLogUri = new UriBuilder(this.LogyardEndpoint);

            if (tail)
            {
                appLogUri.Path = string.Format(CultureInfo.InvariantCulture, "v2/apps/{0}/tail", appGuid);
            }
            else
            {
                appLogUri.Path = string.Format(CultureInfo.InvariantCulture, "v2/apps/{0}/recent", appGuid);
            }

            if (instanceNumber != -1)
            {
                appLogUri.Query = string.Format(CultureInfo.InvariantCulture, "num={0}", instanceNumber);
            }

            this.webSocket = new LogyardWebSocket();

            this.webSocket.DataReceived += this.WebSocketMessageReceived;
            this.webSocket.ErrorReceived += this.WebSocketError;
            this.webSocket.StreamOpened += this.WebSocketOpened;
            this.webSocket.StreamClosed += this.WebSocketClosed;

            this.webSocket.Open(appLogUri.Uri, this.AuthenticationToken, this.HttpProxy, this.SkipCertificateValidation);
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

        private void WebSocketMessageReceived(object sender, StringEventArgs e)
        {
            Message ms = JsonUtilities.DeserializeLogyardMessage(e.Data);
            if (!string.IsNullOrEmpty(ms.Error))
            {
                if (this.ErrorReceived != null)
                {
                    var error = new LogyardException(ms.Error);
                    this.ErrorReceived(this, new ErrorEventArgs() { Error = error });
                }
            }
            else
            {
                if (this.MessageReceived != null)
                {
                    MessageEventArgs args = new MessageEventArgs() { Message = ms };
                    this.MessageReceived(this, args);
                }
            }
        }
    }
}