namespace CloudFoundry.Logyard.Client
{
    using System;

    /// <summary>
    /// An EventArgs class for message events.
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the message that was received from Logyard.
        /// </summary>
        /// <value>
        /// The message that was received from Logyard.
        /// </value>
        public Message Message
        {
            get;
            internal set;
        }
    }
}