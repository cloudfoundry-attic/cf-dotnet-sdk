namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using Newtonsoft.Json;

    public partial class CreateServiceInstanceResponse
    {
        [JsonProperty("gateway_data", NullValueHandling = NullValueHandling.Ignore)]
        public new dynamic GatewayData
        {
            get;
            set;
        }
    }
}