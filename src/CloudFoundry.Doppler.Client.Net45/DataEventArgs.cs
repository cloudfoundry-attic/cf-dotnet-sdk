namespace CloudFoundry.Doppler.Client
{
    using System;
    using DropsondeProtocol;

    internal class DataEventArgs : EventArgs
    {
        public Envelope Data
        {
            get;
            set;
        }
    }
}