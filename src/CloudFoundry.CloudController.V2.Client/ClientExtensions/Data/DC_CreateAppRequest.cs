namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using Newtonsoft.Json;
    
    public partial class CreateAppRequest
    {
        [JsonProperty("memory", NullValueHandling = NullValueHandling.Ignore)]
        public new int? Memory
        {
            get;
            set;
        }

        [JsonProperty("instances", NullValueHandling = NullValueHandling.Ignore)]
        public new int? Instances
        {
            get;
            set;
        }
    }
}