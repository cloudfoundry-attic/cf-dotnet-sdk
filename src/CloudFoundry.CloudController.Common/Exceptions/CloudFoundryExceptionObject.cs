namespace CloudFoundry.CloudController.Common.Exceptions
{
    using Newtonsoft.Json;

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