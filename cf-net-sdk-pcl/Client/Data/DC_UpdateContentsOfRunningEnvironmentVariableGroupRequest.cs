using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateContentsOfRunningEnvironmentVariableGroupRequest
{



    [JsonProperty("abc", NullValueHandling=NullValueHandling.Ignore)]
    public int? Abc
    {
    get;
    set;
    }

    [JsonProperty("do-re-me", NullValueHandling=NullValueHandling.Ignore)]
    public string Doreme
    {
    get;
    set;
    }

}
}