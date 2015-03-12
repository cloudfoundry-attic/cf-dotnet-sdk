namespace CloudFoundry.CloudController.Common.PushTools
{
    using Newtonsoft.Json;

    /// <summary>
    /// Fingerprint that contains the essential file information for the push job
    /// </summary>
    public class FileFingerprint
    {
        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long Size
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sha1 of the file's content.
        /// </summary>
        [JsonProperty("sha1", NullValueHandling = NullValueHandling.Ignore)]
        public string SHA1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        [JsonProperty("fn", NullValueHandling = NullValueHandling.Ignore)]
        public string FileName
        {
            get;
            set;
        }
    }
}
