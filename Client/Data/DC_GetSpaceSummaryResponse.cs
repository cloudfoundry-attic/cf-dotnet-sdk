using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetSpaceSummaryResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid Guid
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

    [JsonProperty("apps", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] Apps
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

}
}