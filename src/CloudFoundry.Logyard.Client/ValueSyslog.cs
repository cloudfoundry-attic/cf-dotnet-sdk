namespace CloudFoundry.Logyard.Client
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Class representing a syslog value in a Logyard message.
    /// </summary>
    public class ValueSyslog
    {
        /// <summary>
        /// Gets the priority of the message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("priority")]
        public string Priority { get; internal set; }

        /// <summary>
        /// Gets the time of the message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("time")]
        public string Time { get; internal set; }
    }
}