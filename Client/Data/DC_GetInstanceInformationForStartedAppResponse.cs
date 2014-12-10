using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetInstanceInformationForStartedAppResponse :IResponse
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

    [JsonProperty("since", NullValueHandling=NullValueHandling.Ignore)]
    public double Since
    {
    get;
    set;
    }

    [JsonProperty("debug_ip", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic DebugIp
    {
    get;
    set;
    }

    [JsonProperty("debug_port", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic DebugPort
    {
    get;
    set;
    }

    [JsonProperty("console_ip", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic ConsoleIp
    {
    get;
    set;
    }

    [JsonProperty("console_port", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic ConsolePort
    {
    get;
    set;
    }

}
}