namespace CloudFoundry.CloudController.V2.Client.Data
{
    using Newtonsoft.Json;

    public partial class GetV1InfoResponse
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("build", NullValueHandling = NullValueHandling.Ignore)]
        public string Build
        {
            get;
            set;
        }

        [JsonProperty("support", NullValueHandling = NullValueHandling.Ignore)]
        public string Support
        {
            get;
            set;
        }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version
        {
            get;
            set;
        }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description
        {
            get;
            set;
        }

        [JsonProperty("authorization_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationEndpoint
        {
            get;
            set;
        }

        [JsonProperty("token_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenEndpoint
        {
            get;
            set;
        }

        [JsonProperty("applog_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string AppLogEndpoint
        {
            get;
            set;
        }

        [JsonProperty("allow_debug", NullValueHandling = NullValueHandling.Ignore)]
        public bool AllowDebug
        {
            get;
            set;
        }
    }
}
