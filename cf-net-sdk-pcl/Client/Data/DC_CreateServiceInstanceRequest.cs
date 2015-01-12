using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateServiceInstanceRequest
{



    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("service_plan_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? ServicePlanGuid
    {
    get;
    set;
    }

    [JsonProperty("gateway_data", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic GatewayData
    {
    get;
    set;
    }

}
}