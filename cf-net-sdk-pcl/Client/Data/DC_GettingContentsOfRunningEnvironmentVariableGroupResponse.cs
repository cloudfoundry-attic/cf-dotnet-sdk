using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GettingContentsOfRunningEnvironmentVariableGroupResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("abc", NullValueHandling=NullValueHandling.Ignore)]
    public double? Abc
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