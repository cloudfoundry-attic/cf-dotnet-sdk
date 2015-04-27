namespace CloudFoundry.Logyard.Client
{
    using System;

    internal interface ILogyardWebSocket : IDisposable
    {
        event EventHandler<ErrorEventArgs> ErrorReceived;

        event EventHandler<StringEventArgs> DataReceived;
        
        event EventHandler<EventArgs> StreamClosed;
        
        event EventHandler<EventArgs> StreamOpened;

        ConnectionState State
        {
            get;
        }

        void Open(Uri appLogEndpoint, string authenticationToken, Uri httpProxy, bool skipCertificateValidation);

        void Close();
    }
}
