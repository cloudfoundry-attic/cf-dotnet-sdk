using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class UpdateProcessResponse :IResponse
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

    [JsonProperty("type", NullValueHandling=NullValueHandling.Ignore)]
    public string Type
    {
    get;
    set;
    }

}
}