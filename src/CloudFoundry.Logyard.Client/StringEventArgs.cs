namespace CloudFoundry.Logyard.Client
{
    using System;

    internal class StringEventArgs : EventArgs
    {
        public string Data
        {
            get;
            set;
        }
    }
}