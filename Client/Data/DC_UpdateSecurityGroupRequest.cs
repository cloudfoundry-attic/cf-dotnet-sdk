using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateSecurityGroupRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("rules", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic[] Rules
    {
    get;
    set;
    }

    [JsonProperty("space_guids", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic SpaceGuids
    {
    get;
    set;
    }

}
}