namespace CloudFoundry.Loggregator.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Class that represents a message coming from Loggregator.
    /// </summary>
    public class ApplicationLog
    {
        /// <summary>
        /// Gets the text of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public string Message { get; internal set; }

        /// <summary>
        /// Gets the type of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public ApplicationLogMessageType LogMessageType { get; internal set; }

        /// <summary>
        /// Gets the timestamp of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public long Timestamp { get; internal set; }

        /// <summary>
        /// Gets the Cloud Foundry app unique identifier.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public string AppId { get; internal set; }

        /// <summary>
        /// Gets the source id of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public string SourceId { get; internal set; }

        /// <summary>
        /// Gets the drain urls
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public Collection<string> DrainUrls { get; internal set; }

        /// <summary>
        /// Gets the source of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        public string SourceName { get; internal set; }
    }
}
