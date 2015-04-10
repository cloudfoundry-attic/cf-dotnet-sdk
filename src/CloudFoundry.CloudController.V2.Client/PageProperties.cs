namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that holds the properties of a specific page.
    /// </summary>
    public class PageProperties
    {
        /// <summary>
        /// Gets the next URL.
        /// </summary>
        /// <value>
        /// The next URL.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("next_url", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUrl { get; internal set; }

        /// <summary>
        /// Gets the previous URL.
        /// </summary>
        /// <value>
        /// The previous URL.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("prev_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousUrl { get; internal set; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalPages { get; internal set; }

        /// <summary>
        /// Gets the total results.
        /// </summary>
        /// <value>
        /// The total results.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("total_results", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalResults { get; internal set; }
    }
}