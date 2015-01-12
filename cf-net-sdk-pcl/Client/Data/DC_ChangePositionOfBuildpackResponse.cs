using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ChangePositionOfBuildpackResponse :IResponse
{

    public Metadata EntityMetadata
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

    [JsonProperty("position", NullValueHandling=NullValueHandling.Ignore)]
    public double Position
    {
    get;
    set;
    }

    [JsonProperty("enabled", NullValueHandling=NullValueHandling.Ignore)]
    public bool? Enabled
    {
    get;
    set;
    }

    [JsonProperty("locked", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Locked
    {
    get;
    set;
    }

    [JsonProperty("filename", NullValueHandling=NullValueHandling.Ignore)]
    public string Filename
    {
    get;
    set;
    }

}
}