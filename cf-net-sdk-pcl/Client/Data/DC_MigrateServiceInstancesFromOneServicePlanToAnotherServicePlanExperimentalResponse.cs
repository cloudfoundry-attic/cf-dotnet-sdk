using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("changed_count", NullValueHandling=NullValueHandling.Ignore)]
    public double ChangedCount
    {
    get;
    set;
    }

}
}