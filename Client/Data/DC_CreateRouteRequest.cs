using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateRouteRequest
{



    [JsonProperty("domain_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? DomainGuid
    {
    get;
    set;
    }

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? Guid
    {
    get;
    set;
    }

    [JsonProperty("host", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Host
    {
    get;
    set;
    }

}
}