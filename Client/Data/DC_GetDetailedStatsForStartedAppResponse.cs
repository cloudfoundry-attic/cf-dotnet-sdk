using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetDetailedStatsForStartedAppResponse :IResponse
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

    [JsonProperty("stats", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> Stats
    {
    get;
    set;
    }

}
}