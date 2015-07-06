namespace CloudFoundry.CloudController.V3.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class that holds the href of a specific page.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Gets the href of the page
        /// </summary>
        /// <value>
        /// The href of the page
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; internal set; }
    }
}
