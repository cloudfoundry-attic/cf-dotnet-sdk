namespace CloudFoundry.CloudController.V2.Client.Data
{
    using Newtonsoft.Json;

    /// <inheritdoc />
    public partial class GetV1InfoResponse
    {
        /// <inheritdoc />
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("build", NullValueHandling = NullValueHandling.Ignore)]
        public string Build
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("support", NullValueHandling = NullValueHandling.Ignore)]
        public string Support
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("authorization_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationEndpoint
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("token_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenEndpoint
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("applog_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string AppLogEndpoint
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("allow_debug", NullValueHandling = NullValueHandling.Ignore)]
        public bool AllowDebug
        {
            get;
            set;
        }
    }
}
