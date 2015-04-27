namespace CloudFoundry.Loggregator.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal class LoggregatorWebSocket : ILoggregatorWebSocket, IDisposable
    {
        public event EventHandler<ErrorEventArgs> ErrorReceived;

        public event EventHandler<DataEventArgs> DataReceived;

        public event EventHandler<EventArgs> StreamClosed;

        public event EventHandler<EventArgs> StreamOpened;

        public ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }

        public void Open(Uri appLogEndpoint, string authenticationToken, Uri httpProxy, bool skipCertificateValidation)
        {
            // Dummy code to prevent warnings
            if (this.ErrorReceived != null)
            {
                this.ErrorReceived(this, null);
            }

            if (this.DataReceived != null)
            {
                this.DataReceived(this, new DataEventArgs() { Data = null });
            }

            if (this.StreamClosed != null)
            {
                this.StreamClosed(this, null);
            }

            if (this.StreamOpened != null)
            {
                this.StreamOpened(this, null);
            }

            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
