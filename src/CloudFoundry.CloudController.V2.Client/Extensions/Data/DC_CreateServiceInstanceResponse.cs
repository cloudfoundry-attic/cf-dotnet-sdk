namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using Newtonsoft.Json;

    /// <inheritdoc />
    public partial class CreateServiceInstanceResponse
    {
        /// <inheritdoc />
        [JsonProperty("gateway_data", NullValueHandling = NullValueHandling.Ignore)]
        public new dynamic GatewayData
        {
            get;
            set;
        }
    }
}