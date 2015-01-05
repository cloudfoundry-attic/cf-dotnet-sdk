using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class RetrieveJobWithUnknownFailureResponse :IResponse
{

    public Metadata EntityMetadata
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

    [JsonProperty("status", NullValueHandling=NullValueHandling.Ignore)]
    public string Status
    {
    get;
    set;
    }

    [JsonProperty("error", NullValueHandling=NullValueHandling.Ignore)]
    public string Error
    {
    get;
    set;
    }

    [JsonProperty("error_details", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic> ErrorDetails
    {
    get;
    set;
    }

}
}