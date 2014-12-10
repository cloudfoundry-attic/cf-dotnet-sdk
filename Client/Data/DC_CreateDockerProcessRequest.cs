using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateDockerProcessRequest
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

    [JsonProperty("docker_image", NullValueHandling=NullValueHandling.Ignore)]
    public string DockerImage
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

}
}