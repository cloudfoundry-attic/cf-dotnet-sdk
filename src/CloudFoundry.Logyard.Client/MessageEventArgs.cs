namespace CloudFoundry.Logyard.Client
{
    using System;

    public class MessageEventArgs : EventArgs
    {
        public Message Message
        {
            get;
            set;
        }
    }
}