namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Metadata Json object of the CloudFoundry response
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces",
        Justification = "Keeping Cloud Foundry nomenclature.")]
    public class Metadata
    {
        /// <summary>
        /// Gets the unique identifier of the enitity.
        /// </summary>
        /// <value>
        /// A guid that is the unique identifier of the entity.
        /// </value>
        [JsonProperty("guid")]
        public EntityGuid Guid { get; internal set; }

        /// <summary>
        /// Gets the API URL of the entity.
        /// </summary>
        /// <value>
        /// A Uri where you can HTTP GET the current entity.
        /// </value>
        [JsonProperty("url")]
        public Uri Url { get; internal set; }

        /// <summary>
        /// Gets the creation time of the entity.
        /// </summary>
        /// <value>
        /// Date/Timestamp the resource was created, e.g. “2012-01-01 13:42:00 -0700”
        /// </value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; internal set; }

        /// <summary>
        /// Gets the last update time of the entity.
        /// </summary>
        /// <value>
        /// Date/Timestamp the resource was updated. null if the resource has not been updated
        /// </value>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; internal set; }
    }
}