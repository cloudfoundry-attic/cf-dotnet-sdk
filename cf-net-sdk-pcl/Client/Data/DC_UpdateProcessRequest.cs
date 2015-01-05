using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateProcessRequest
{



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

    [JsonProperty("state", NullValueHandling=NullValueHandling.Ignore)]
    public string State
    {
    get;
    set;
    }

    [JsonProperty("command", NullValueHandling=NullValueHandling.Ignore)]
    public string Command
    {
    get;
    set;
    }

    [JsonProperty("buildpack", NullValueHandling=NullValueHandling.Ignore)]
    public string Buildpack
    {
    get;
    set;
    }

    [JsonProperty("health_check_timeout", NullValueHandling=NullValueHandling.Ignore)]
    public double HealthCheckTimeout
    {
    get;
    set;
    }

    [JsonProperty("environment_json", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, string> EnvironmentJson
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

}
}