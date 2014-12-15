using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetEnvForAppResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("staging_env_json", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> StagingEnvJson
    {
    get;
    set;
    }

    [JsonProperty("running_env_json", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> RunningEnvJson
    {
    get;
    set;
    }

    [JsonProperty("environment_json", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> EnvironmentJson
    {
    get;
    set;
    }

    [JsonProperty("system_env_json", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> SystemEnvJson
    {
    get;
    set;
    }

    [JsonProperty("application_env_json", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> ApplicationEnvJson
    {
    get;
    set;
    }

}
}