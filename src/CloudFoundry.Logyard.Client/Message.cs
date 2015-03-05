namespace CloudFoundry.Logyard.Client
{
    using System;
    using Newtonsoft.Json;

    public class Message
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonIgnore]
        public MessageValue Value { get; set; }
    }
}