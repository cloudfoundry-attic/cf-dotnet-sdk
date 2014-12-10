using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllServicePlanVisibilitiesResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("service_plan_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid ServicePlanGuid
    {
    get;
    set;
    }

    [JsonProperty("organization_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid OrganizationGuid
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

    [JsonProperty("organization_url", NullValueHandling=NullValueHandling.Ignore)]
    public string OrganizationUrl
    {
    get;
    set;
    }

}
}