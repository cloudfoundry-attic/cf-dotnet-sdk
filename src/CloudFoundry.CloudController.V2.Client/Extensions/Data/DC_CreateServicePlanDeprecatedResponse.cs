namespace CloudFoundry.CloudController.V2.Client.Data
{
    using Newtonsoft.Json;

    /// <inheritdoc/>
    public partial class CreateServicePlanDeprecatedResponse
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