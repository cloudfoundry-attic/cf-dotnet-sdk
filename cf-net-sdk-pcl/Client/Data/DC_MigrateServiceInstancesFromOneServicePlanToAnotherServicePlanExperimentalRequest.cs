using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest
{



    [JsonProperty("service_plan_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? ServicePlanGuid
    {
    get;
    set;
    }

}
}