using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateProcessRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("memory", NullValueHandling=NullValueHandling.Ignore)]
    public double Memory
    {
    get;
    set;
    }

    [JsonProperty("instances", NullValueHandling=NullValueHandling.Ignore)]
    public double Instances
    {
    get;
    set;
    }

    [JsonProperty("disk_quota", NullValueHandling=NullValueHandling.Ignore)]
    public double DiskQuota
    {
    get;
    set;
    }

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("stack_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid StackGuid
    {
    get;
    set;
    }

}
}