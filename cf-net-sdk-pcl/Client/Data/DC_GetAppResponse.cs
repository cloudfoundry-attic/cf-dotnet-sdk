using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetAppResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("guid", NullValueHandling=NullValueHandling.Ignore)]
    public string Guid
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

    [JsonProperty("_links", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, Dictionary<string, string>> Links
    {
    get;
    set;
    }

}
}