using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetOrganizationSummaryResponse :IResponse
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

    [JsonProperty("status", NullValueHandling=NullValueHandling.Ignore)]
    public string Status
    {
    get;
    set;
    }

    [JsonProperty("spaces", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] Spaces
    {
    get;
    set;
    }

}
}