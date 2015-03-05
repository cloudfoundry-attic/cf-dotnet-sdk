namespace CloudFoundry.Logyard.Client
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Class representing a log message coming from Logyard.
    /// </summary>
    public class MessageValue
    {
        /// <summary>
        /// Gets the name of the file the log message is comming from.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("filename")]
        public string FileName { get; internal set; }

        /// <summary>
        /// Gets the source of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("source")]
        public string Source { get; internal set; }

        /// <summary>
        /// Gets the index of the Cloud Foundry application instance that generated the message.
        /// </summary>
        /// <value>
        /// The index of the instance.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("instance_index")]
        public int InstanceIndex { get; internal set; }

        /// <summary>
        /// Gets the Cloud Foundry app unique identifier.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("app_guid")]
        public Guid AppGuid { get; internal set; }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("app_name")]
        public string AppName { get; internal set; }

        /// <summary>
        /// Gets the Cloud Foundry space the app .
        /// </summary>
        /// <value>
        /// The application space.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("app_space")]
        public string AppSpace { get; internal set; }

        /// <summary>
        /// Gets the text of the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("text")]
        public string Text { get; internal set; }

        /// <summary>
        /// Gets an identifier for the node hosting the application.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("node_id")]
        public string NodeId { get; internal set; }

        /// <summary>
        /// Gets the timestamp of the log message in unix time format.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("unix_time")]
        public long UnixTime { get; internal set; }

        /// <summary>
        /// Gets the timestamp of the log message in human readable time format.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonProperty("human_time")]
        public string HumanTime { get; internal set; }

        /// <summary>
        /// Gets a syslog entry that was included with the log message.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by serialization")]
        [JsonIgnore]
        public ValueSyslog Syslog { get; internal set; }
    }
}