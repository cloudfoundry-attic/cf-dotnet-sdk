using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateUserRequest
{



    [JsonProperty("guid", NullValueHandling=NullValueHandling.Ignore)]
    public string Guid
    {
    get;
    set;
    }

    [JsonProperty("default_space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid DefaultSpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("admin", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Admin
    {
    get;
    set;
    }

}
}