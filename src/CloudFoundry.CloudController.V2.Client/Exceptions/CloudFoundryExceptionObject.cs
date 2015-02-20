using Newtonsoft.Json;

namespace CloudFoundry.CloudController.V2.Exceptions
{
    public class CloudFoundryExceptionObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}