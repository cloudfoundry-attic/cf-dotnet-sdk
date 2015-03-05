namespace CloudFoundry.Logyard.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class LogyardLog : IDisposable
    {
        private bool disposed;
        private ILogyardWebSocket webSocket;

        public LogyardLog(Uri logyardEndpoint, string authenticationToken)
        {
            this.LogyardEndpoint = logyardEndpoint;
            this.AuthenticationToken = authenticationToken;
        }

        ~LogyardLog()
        {
            this.Dispose(false);
        }

        public event EventHandler<ErrorEventArgs> ErrorReceived;

        public event EventHandler<MessageEventArgs> MessageReceived;

        public event EventHandler<EventArgs> StreamClosed;

        public event EventHandler<EventArgs> StreamOpened;

        public Uri LogyardEndpoint
        {
            get; 
            set;
        }

        public string AuthenticationToken
        {
            get;
            set;
        }

        public ConnectionState State
        {
            get
            {
                return this.webSocket.State;
            }
        }

        public void StopStream()
        {
            this.webSocket.Close();
        }

        public void StreamLogs(string appGuid)
        {
            this.StreamLogs(appGuid, 0, false);
        }

        public void StreamLogs(string appGuid, int instanceNumber)
        {
            this.StreamLogs(appGuid, instanceNumber, false);
        }

        public void StreamLogs(string appGuid, int instanceNumber, bool tail)
        {
            if (appGuid == null)
            {
                throw new ArgumentNullException("appGuid");
            }

            string appLogEndpoint = string.Format(CultureInfo.InvariantCulture, "{0}/v2/apps/{1}", this.LogyardEndpoint, appGuid.ToString());
            if (tail)
            {
                appLogEndpoint += "/tail";
            }
            else
            {
                appLogEndpoint += "/recent";
            }

            if (instanceNumber != 0)
            {
                appLogEndpoint += string.Format(CultureInfo.InvariantCulture, "?num={0}", instanceNumber);
            }

            this.webSocket = new LogyardWebSocket();
            
            this.webSocket.DataReceived += this.WebSocketMessageReceived;
            this.webSocket.ErrorReceived += this.WebSocketError;
            this.webSocket.StreamOpened += this.WebSocketOpened;
            this.webSocket.StreamClosed += this.WebSocketClosed;

            this.webSocket.Open(new Uri(appLogEndpoint), this.AuthenticationToken);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

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
                if (ms.Error.Contains("CF-InvalidAuthToken"))
                {
                    if (this.ErrorReceived != null)
                    {
                        var error = new LogyardException(ms.Error);
                        this.ErrorReceived(this, new ErrorEventArgs() { Error = error });
                    }
                }
                else
                {
                    if (this.ErrorReceived != null)
                    {
                        var error = new LogyardException(ms.Error);
                        this.ErrorReceived(this, new ErrorEventArgs() { Error = error });
                    }
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