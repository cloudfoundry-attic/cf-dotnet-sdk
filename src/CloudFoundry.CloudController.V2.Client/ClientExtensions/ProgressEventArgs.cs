namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that holds the progress arguments of the push operation
    /// </summary>
    public class PushProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the percent of the push operation.
        /// </summary>
        /// <value>
        /// The percent of the push operation.
        /// </value>
        public int Percent { get; set; }
    }
}