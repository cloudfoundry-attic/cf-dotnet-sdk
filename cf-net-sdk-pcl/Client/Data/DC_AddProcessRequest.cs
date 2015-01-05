using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class AddProcessRequest
{



    [JsonProperty("process_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid ProcessGuid
    {
    get;
    set;
    }

}
}