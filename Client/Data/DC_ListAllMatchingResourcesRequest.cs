using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllMatchingResourcesRequest
{



    [JsonProperty("sha1", NullValueHandling=NullValueHandling.Ignore)]
    public string Sha1
    {
    get;
    set;
    }

    [JsonProperty("size", NullValueHandling=NullValueHandling.Ignore)]
    public double? Size
    {
    get;
    set;
    }

}
}