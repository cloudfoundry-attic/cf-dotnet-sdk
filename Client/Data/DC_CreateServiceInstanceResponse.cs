using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateServiceInstanceResponse :IResponse
{

    public Metadata EntityMetadata
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

    [JsonProperty("credentials", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> Credentials
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

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("gateway_data", NullValueHandling=NullValueHandling.Ignore)]
    public string GatewayData
    {
    get;
    set;
    }

    [JsonProperty("dashboard_url", NullValueHandling=NullValueHandling.Ignore)]
    public string DashboardUrl
    {
    get;
    set;
    }

    [JsonProperty("type", NullValueHandling=NullValueHandling.Ignore)]
    public string Type
    {
    get;
    set;
    }

    [JsonProperty("space_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceUrl
    {
    get;
    set;
    }

    [JsonProperty("service_plan_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ServicePlanUrl
    {
    get;
    set;
    }

    [JsonProperty("service_bindings_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ServiceBindingsUrl
    {
    get;
    set;
    }

}
}