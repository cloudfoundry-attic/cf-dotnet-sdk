using Newtonsoft.Json;

namespace CloudFoundry.CloudController.V2
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces",
        Justification = "Keeping Cloud Foundry nomenclature.")]
    public class Metadata
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}