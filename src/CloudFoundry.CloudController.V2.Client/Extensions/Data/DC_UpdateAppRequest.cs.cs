namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using Newtonsoft.Json;

    /// <inheritdoc />
    public partial class UpdateAppRequest
    {
        /// <inheritdoc />
        [JsonProperty("memory", NullValueHandling = NullValueHandling.Ignore)]
        public new int? Memory
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("instances", NullValueHandling = NullValueHandling.Ignore)]
        public new int? Instances
        {
            get;
            set;
        }

        /// <inheritdoc />
        [JsonProperty("space_guid", NullValueHandling = NullValueHandling.Ignore)]
        public new Guid? SpaceGuid
        {
            get;
            set;
        }
    }
}
