namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using CloudFoundry.CloudController.V2.Client.Interfaces;
    using Newtonsoft.Json;

    public partial class GetInfoResponse
    {
        /// <summary> 
        /// <para>The Doppeler Logging Endpoint</para>
        /// </summary>
        [JsonProperty("doppler_logging_endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string DopplerLoggingEndpoint
        {
            get;
            set;
        }
    }
}
