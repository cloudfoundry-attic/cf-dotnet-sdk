namespace CloudFoundry.Loggregator.Client
{
    using System;

    internal interface ILoggregatorWebSocket : IDisposable
    {
        event EventHandler<ErrorEventArgs> ErrorReceived;

        event EventHandler<DataEventArgs> DataReceived;
        
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
