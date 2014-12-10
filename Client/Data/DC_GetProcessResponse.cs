using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetProcessResponse :IResponse
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

}
}