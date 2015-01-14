using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetAppSummaryResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? Guid
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

    [JsonProperty("routes", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] Routes
    {
    get;
    set;
    }

    [JsonProperty("running_instances", NullValueHandling=NullValueHandling.Ignore)]
    public int? RunningInstances
    {
    get;
    set;
    }

    [JsonProperty("services", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] Services
    {
    get;
    set;
    }

    [JsonProperty("available_domains", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] AvailableDomains
    {
    get;
    set;
    }

    [JsonProperty("production", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Production
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

    [JsonProperty("buildpack", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Buildpack
    {
    get;
    set;
    }

    [JsonProperty("detected_buildpack", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic DetectedBuildpack
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

    [JsonProperty("memory", NullValueHandling=NullValueHandling.Ignore)]
    public int? Memory
    {
    get;
    set;
    }

    [JsonProperty("instances", NullValueHandling=NullValueHandling.Ignore)]
    public int? Instances
    {
    get;
    set;
    }

    [JsonProperty("disk_quota", NullValueHandling=NullValueHandling.Ignore)]
    public int? DiskQuota
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

    [JsonProperty("version", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? Version
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

    [JsonProperty("console", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Console
    {
    get;
    set;
    }

    [JsonProperty("debug", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Debug
    {
    get;
    set;
    }

    [JsonProperty("staging_task_id", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic StagingTaskId
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

    [JsonProperty("health_check_timeout", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic HealthCheckTimeout
    {
    get;
    set;
    }

    [JsonProperty("staging_failed_reason", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic StagingFailedReason
    {
    get;
    set;
    }

    [JsonProperty("docker_image", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic DockerImage
    {
    get;
    set;
    }

    [JsonProperty("package_updated_at", NullValueHandling=NullValueHandling.Ignore)]
    public string PackageUpdatedAt
    {
    get;
    set;
    }

    [JsonProperty("detected_start_command", NullValueHandling=NullValueHandling.Ignore)]
    public string DetectedStartCommand
    {
    get;
    set;
    }

}
}