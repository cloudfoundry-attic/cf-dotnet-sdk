using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateUserProvidedServiceInstanceRequest
{



    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? SpaceGuid
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
    public Dictionary<string, dynamic> Credentials
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

}
}