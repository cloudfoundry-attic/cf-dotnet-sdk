using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateOrganizationQuotaDefinitionResponse :IResponse
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
    public bool? NonBasicServicesAllowed
    {
    get;
    set;
    }

    [JsonProperty("total_services", NullValueHandling=NullValueHandling.Ignore)]
    public int? TotalServices
    {
    get;
    set;
    }

    [JsonProperty("total_routes", NullValueHandling=NullValueHandling.Ignore)]
    public int? TotalRoutes
    {
    get;
    set;
    }

    [JsonProperty("memory_limit", NullValueHandling=NullValueHandling.Ignore)]
    public int? MemoryLimit
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
    public int? InstanceMemoryLimit
    {
    get;
    set;
    }

}
}