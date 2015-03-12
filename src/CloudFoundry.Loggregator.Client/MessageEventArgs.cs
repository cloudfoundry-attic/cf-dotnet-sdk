namespace CloudFoundry.Loggregator.Client
{
    using System;

    /// <summary>
    /// An EventArgs class for message events.
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the message that was received from Loggregator.
        /// </summary>
        /// <value>
        /// The message that was received from Loggregator.
        /// </value>
        public ApplicationLog LogMessage
        {
            get;
            internal set;
        }
    }
}