using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateServicePlanDeprecatedRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("free", NullValueHandling=NullValueHandling.Ignore)]
    public bool Free
    {
    get;
    set;
    }

    [JsonProperty("description", NullValueHandling=NullValueHandling.Ignore)]
    public string Description
    {
    get;
    set;
    }

    [JsonProperty("service_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid ServiceGuid
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

    [JsonProperty("extra", NullValueHandling=NullValueHandling.Ignore)]
    public string Extra
    {
    get;
    set;
    }

    [JsonProperty("unique_id", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic UniqueId
    {
    get;
    set;
    }

    [JsonProperty("public", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Public
    {
    get;
    set;
    }

    [JsonProperty("active", NullValueHandling=NullValueHandling.Ignore)]
    public bool Active
    {
    get;
    set;
    }

}
}