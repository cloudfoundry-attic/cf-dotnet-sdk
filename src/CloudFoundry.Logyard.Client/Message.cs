namespace CloudFoundry.Logyard.Client
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that represents a message coming from Logyard.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets the error that was included in the message (if any).
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("error")]
        public string Error { get; internal set; }

        /// <summary>
        /// Gets the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonIgnore]
        public MessageValue Value { get; internal set; }
    }
}