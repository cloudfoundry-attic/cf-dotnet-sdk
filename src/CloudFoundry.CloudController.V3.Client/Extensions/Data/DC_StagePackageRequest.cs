namespace CloudFoundry.CloudController.V3.Client.Data
{
    using Newtonsoft.Json;

    /// <inheritdoc/>
    public partial class StagePackageRequest
    {
        /// <inheritdoc/>
        [JsonProperty("memory_limit", NullValueHandling = NullValueHandling.Ignore)]
        public new int? MemoryLimit
        {
            get;
            set;
        }

        /// <inheritdoc/>
        [JsonProperty("disk_limit", NullValueHandling = NullValueHandling.Ignore)]
        public new int? DiskLimit
        {
            get;
            set;
        }
    }
}