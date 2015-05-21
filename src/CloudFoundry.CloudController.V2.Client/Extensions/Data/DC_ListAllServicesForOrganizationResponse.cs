namespace CloudFoundry.CloudController.V2.Client.Data
{
    using Newtonsoft.Json;

    /// <inheritdoc/>
    public partial class ListAllServicesForOrganizationResponse
    {
        /// <inheritdoc/>
        [JsonProperty("unique_id", NullValueHandling = NullValueHandling.Ignore)]
        public new string UniqueId
        {
            get;
            set;
        }
    }
}