using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateAppRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("memory", NullValueHandling=NullValueHandling.Ignore)]
    public int Memory
    {
    get;
    set;
    }

    [JsonProperty("instances", NullValueHandling=NullValueHandling.Ignore)]
    public int Instances
    {
    get;
    set;
    }

    [JsonProperty("disk_quota", NullValueHandling=NullValueHandling.Ignore)]
    public string DiskQuota
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

    [JsonProperty("stack_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? StackGuid
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

    [JsonProperty("detected_start_command", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic DetectedStartCommand
    {
    get;
    set;
    }

    [JsonProperty("command", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Command
    {
    get;
    set;
    }

    [JsonProperty("buildpack", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Buildpack
    {
    get;
    set;
    }

    [JsonProperty("health_check_timeout", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic HealthCheckTimeout
    {
    get;
    set;
    }

    [JsonProperty("docker_image", NullValueHandling=NullValueHandling.Ignore)]
    public string DockerImage
    {
    get;
    set;
    }

    [JsonProperty("environment_json", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic EnvironmentJson
    {
    get;
    set;
    }

    [JsonProperty("production", NullValueHandling=NullValueHandling.Ignore)]
    public bool? Production
    {
    get;
    set;
    }

    [JsonProperty("console", NullValueHandling=NullValueHandling.Ignore)]
    public bool? Console
    {
    get;
    set;
    }

    [JsonProperty("debug", NullValueHandling=NullValueHandling.Ignore)]
    public bool? Debug
    {
    get;
    set;
    }

}
}