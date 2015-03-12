namespace CloudFoundry.Loggregator.Client
{
    using System;

    internal class DataEventArgs : EventArgs
    {
        public ApplicationLog Data
        {
            get;
            set;
        }
    }
}