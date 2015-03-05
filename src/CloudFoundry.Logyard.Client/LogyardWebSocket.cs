namespace CloudFoundry.Logyard.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal class LogyardWebSocket : ILogyardWebSocket, IDisposable
    {
        public event EventHandler<ErrorEventArgs> ErrorReceived;

        public event EventHandler<StringEventArgs> DataReceived;

        public event EventHandler<EventArgs> StreamClosed;

        public event EventHandler<EventArgs> StreamOpened;

        public ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }

        public void Open(Uri appLogEndpoint, string authenticationToken)
        {
            // Dummy code to prevent warnings
            if (this.ErrorReceived != null)
            {
                this.ErrorReceived(this, null);
                this.DataReceived(this, new StringEventArgs() { Data = string.Empty });
                this.StreamClosed(this, null);
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
            throw new NotImplementedException();
        }
    }
}
