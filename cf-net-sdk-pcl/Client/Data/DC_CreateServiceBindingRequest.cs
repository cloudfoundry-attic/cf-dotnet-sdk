using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateServiceBindingRequest
{



    [JsonProperty("service_instance_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid ServiceInstanceGuid
    {
    get;
    set;
    }

    [JsonProperty("app_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid AppGuid
    {
    get;
    set;
    }

    [JsonProperty("binding_options", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic BindingOptions
    {
    get;
    set;
    }

}
}