namespace CloudFoundry.Logyard.Client
{
    using System;

    public class ErrorEventArgs : EventArgs
    {
        public Exception Error
        {
            get;
            set;
        }
    }
}