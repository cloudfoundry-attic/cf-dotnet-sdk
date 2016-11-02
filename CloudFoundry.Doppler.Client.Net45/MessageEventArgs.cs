namespace CloudFoundry.Doppler.Client
{
    using System;
    using DropsondeProtocol;

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
        public Envelope LogMessage
        {
            get;
            internal set;
        }
    }
}