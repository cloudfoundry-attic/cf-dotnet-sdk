using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateServiceBrokerRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("broker_url", NullValueHandling=NullValueHandling.Ignore)]
    public string BrokerUrl
    {
    get;
    set;
    }

    [JsonProperty("auth_username", NullValueHandling=NullValueHandling.Ignore)]
    public string AuthUsername
    {
    get;
    set;
    }

    [JsonProperty("auth_password", NullValueHandling=NullValueHandling.Ignore)]
    public string AuthPassword
    {
    get;
    set;
    }

}
}