using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateRouteRequest
{



    [JsonProperty("host", NullValueHandling=NullValueHandling.Ignore)]
    public string Host
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

    [JsonProperty("domain_guid", NullValueHandling=NullValueHandling.Ignore)]
    public string DomainGuid
    {
    get;
    set;
    }

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceGuid
    {
    get;
    set;
    }

}
}