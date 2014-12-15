using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateServiceDeprecatedRequest
{



    [JsonProperty("label", NullValueHandling=NullValueHandling.Ignore)]
    public string Label
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

    [JsonProperty("provider", NullValueHandling=NullValueHandling.Ignore)]
    public string Provider
    {
    get;
    set;
    }

    [JsonProperty("version", NullValueHandling=NullValueHandling.Ignore)]
    public string Version
    {
    get;
    set;
    }

    [JsonProperty("url", NullValueHandling=NullValueHandling.Ignore)]
    public string Url
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

    [JsonProperty("long_description", NullValueHandling=NullValueHandling.Ignore)]
    public string LongDescription
    {
    get;
    set;
    }

    [JsonProperty("info_url", NullValueHandling=NullValueHandling.Ignore)]
    public string InfoUrl
    {
    get;
    set;
    }

    [JsonProperty("documentation_url", NullValueHandling=NullValueHandling.Ignore)]
    public string DocumentationUrl
    {
    get;
    set;
    }

    [JsonProperty("timeout", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Timeout
    {
    get;
    set;
    }

    [JsonProperty("active", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Active
    {
    get;
    set;
    }

    [JsonProperty("bindable", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Bindable
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

    [JsonProperty("tags", NullValueHandling=NullValueHandling.Ignore)]
    public string Tags
    {
    get;
    set;
    }

    [JsonProperty("requires", NullValueHandling=NullValueHandling.Ignore)]
    public string Requires
    {
    get;
    set;
    }

    [JsonProperty("service_broker_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? ServiceBrokerGuid
    {
    get;
    set;
    }

}
}