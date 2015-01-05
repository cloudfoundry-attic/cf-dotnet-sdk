using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateUserProvidedServiceInstanceResponse :IResponse
{

    public Metadata EntityMetadata
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

    [JsonProperty("credentials", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, string> Credentials
    {
    get;
    set;
    }

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("type", NullValueHandling=NullValueHandling.Ignore)]
    public string Type
    {
    get;
    set;
    }

    [JsonProperty("syslog_drain_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SyslogDrainUrl
    {
    get;
    set;
    }

    [JsonProperty("space_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceUrl
    {
    get;
    set;
    }

    [JsonProperty("service_bindings_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ServiceBindingsUrl
    {
    get;
    set;
    }

}
}