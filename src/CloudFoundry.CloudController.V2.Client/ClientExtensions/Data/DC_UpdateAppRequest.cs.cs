namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using Newtonsoft.Json;

    public partial class UpdateAppRequest
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

        [JsonProperty("space_guid", NullValueHandling = NullValueHandling.Ignore)]
        public new Guid? SpaceGuid
        {
            get;
            set;
        }
    }
}
