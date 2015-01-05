using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllOrganizationQuotaDefinitionsResponse :IResponse
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

    [JsonProperty("non_basic_services_allowed", NullValueHandling=NullValueHandling.Ignore)]
    public bool NonBasicServicesAllowed
    {
    get;
    set;
    }

    [JsonProperty("total_services", NullValueHandling=NullValueHandling.Ignore)]
    public double TotalServices
    {
    get;
    set;
    }

    [JsonProperty("total_routes", NullValueHandling=NullValueHandling.Ignore)]
    public double TotalRoutes
    {
    get;
    set;
    }

    [JsonProperty("memory_limit", NullValueHandling=NullValueHandling.Ignore)]
    public double MemoryLimit
    {
    get;
    set;
    }

    [JsonProperty("trial_db_allowed", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic TrialDbAllowed
    {
    get;
    set;
    }

    [JsonProperty("instance_memory_limit", NullValueHandling=NullValueHandling.Ignore)]
    public double InstanceMemoryLimit
    {
    get;
    set;
    }

}
}