using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetPrivateDomainCreationFeatureFlagResponse :IResponse
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

    [JsonProperty("enabled", NullValueHandling=NullValueHandling.Ignore)]
    public bool Enabled
    {
    get;
    set;
    }

    [JsonProperty("error_message", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic ErrorMessage
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

}
}