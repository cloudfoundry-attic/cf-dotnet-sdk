using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class RetrievingOrganizationMemoryUsageResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("memory_usage_in_mb", NullValueHandling=NullValueHandling.Ignore)]
    public double MemoryUsageInMb
    {
    get;
    set;
    }

}
}