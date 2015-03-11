namespace CloudFoundry.CloudController.Common.PushTools
{
    using Newtonsoft.Json;

    public class FileFingerprint
    {
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long Size
        {
            get;
            set;
        }

        [JsonProperty("sha1", NullValueHandling = NullValueHandling.Ignore)]
        public string SHA1
        {
            get;
            set;
        }

        [JsonProperty("fn", NullValueHandling = NullValueHandling.Ignore)]
        public string FileName
        {
            get;
            set;
        }
    }
}
