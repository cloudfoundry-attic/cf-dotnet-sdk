using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetInfoResponse :IResponse
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

    [JsonProperty("build", NullValueHandling=NullValueHandling.Ignore)]
    public string Build
    {
    get;
    set;
    }

    [JsonProperty("support", NullValueHandling=NullValueHandling.Ignore)]
    public string Support
    {
    get;
    set;
    }

    [JsonProperty("version", NullValueHandling=NullValueHandling.Ignore)]
    public int? Version
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

    [JsonProperty("authorization_endpoint", NullValueHandling=NullValueHandling.Ignore)]
    public string AuthorizationEndpoint
    {
    get;
    set;
    }

    [JsonProperty("token_endpoint", NullValueHandling=NullValueHandling.Ignore)]
    public string TokenEndpoint
    {
    get;
    set;
    }

    [JsonProperty("api_version", NullValueHandling=NullValueHandling.Ignore)]
    public string ApiVersion
    {
    get;
    set;
    }

    [JsonProperty("logging_endpoint", NullValueHandling=NullValueHandling.Ignore)]
    public string LoggingEndpoint
    {
    get;
    set;
    }

}
}