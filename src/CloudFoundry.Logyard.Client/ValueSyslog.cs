namespace CloudFoundry.Logyard.Client
{
    using System;
    using Newtonsoft.Json;

    public class ValueSyslog
    {
        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}