namespace CloudFoundry.Logyard.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using SuperSocket.ClientEngine;
    using WebSocket4Net;

    internal class LogyardWebSocket : ILogyardWebSocket, IDisposable
    {
        private WebSocket webSocket = null;
        private bool disposed;

        ~LogyardWebSocket()
        {
            this.Dispose(false);
        }

        public event EventHandler<ErrorEventArgs> ErrorReceived;

        public event EventHandler<StringEventArgs> DataReceived;

        public event EventHandler<EventArgs> StreamClosed;

        public event EventHandler<EventArgs> StreamOpened;

        public ConnectionState State
        {
            get
            {
                if (this.webSocket != null)
                {
                    switch (this.webSocket.State)
                    {
                        case WebSocketState.Closed:
                            {
                                return ConnectionState.Closed;
                            }

                        case WebSocketState.Closing:
                            {
                                return ConnectionState.Closing;
                            }

                        case WebSocketState.Connecting:
                            {
                                return ConnectionState.Connecting;
                            }

                        case WebSocketState.Open:
                            {
                                return ConnectionState.Open;
                            }

                        default:
                            {
                                return ConnectionState.None;
                            }
                    }
                }
                else
                {
                    return ConnectionState.None;
                }
            }
        }

        public void Open(Uri appLogEndpoint, string authenticationToken)
        {
            if (appLogEndpoint == null)
            {
                throw new ArgumentNullException("appLogEndpoint");
            }

            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            if (authenticationToken != null)
            {
                headers.Add(new KeyValuePair<string, string>("AUTHORIZATION", authenticationToken));
            }

            this.webSocket = new WebSocket(appLogEndpoint.ToString(), string.Empty, null, headers);

            this.webSocket.MessageReceived += (sender, e) => 
                {
                    if (DataReceived != null)
                    {
                        DataReceived(sender, new StringEventArgs() { Data = e.Message });
                    }
                };

            this.webSocket.Error += (sender, e) =>
            {
                if (ErrorReceived != null)
                {
                    ErrorReceived(sender, new ErrorEventArgs() { Error = e.Exception });
                }
            };

            this.webSocket.Opened += (sender, e) =>
            {
                if (StreamOpened != null)
                {
                    StreamOpened(sender, e);
                }
            };

            this.webSocket.Closed += (sender, e) =>
            {
                if (StreamClosed != null)
                {
                    StreamClosed(sender, e);
                }
            };

            this.webSocket.ReceiveBufferSize = 64;
            this.webSocket.Open();
        }

        public void Close()
        {
            if (this.webSocket.State != (WebSocketState.Closed | WebSocketState.Closing | WebSocketState.None))
            {
                this.webSocket.Close();
            }
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
    }
}
