using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllAppUsageEventsResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("state", NullValueHandling=NullValueHandling.Ignore)]
    public string State
    {
    get;
    set;
    }

    [JsonProperty("memory_in_mb_per_instance", NullValueHandling=NullValueHandling.Ignore)]
    public double MemoryInMbPerInstance
    {
    get;
    set;
    }

    [JsonProperty("instance_count", NullValueHandling=NullValueHandling.Ignore)]
    public double InstanceCount
    {
    get;
    set;
    }

    [JsonProperty("app_guid", NullValueHandling=NullValueHandling.Ignore)]
    public string AppGuid
    {
    get;
    set;
    }

    [JsonProperty("app_name", NullValueHandling=NullValueHandling.Ignore)]
    public string AppName
    {
    get;
    set;
    }

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("space_name", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceName
    {
    get;
    set;
    }

    [JsonProperty("org_guid", NullValueHandling=NullValueHandling.Ignore)]
    public string OrgGuid
    {
    get;
    set;
    }

    [JsonProperty("buildpack_guid", NullValueHandling=NullValueHandling.Ignore)]
    public string BuildpackGuid
    {
    get;
    set;
    }

    [JsonProperty("buildpack_name", NullValueHandling=NullValueHandling.Ignore)]
    public string BuildpackName
    {
    get;
    set;
    }

    [JsonProperty("package_state", NullValueHandling=NullValueHandling.Ignore)]
    public string PackageState
    {
    get;
    set;
    }

}
}