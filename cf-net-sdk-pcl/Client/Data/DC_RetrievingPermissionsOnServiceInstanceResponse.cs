using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class RetrievingPermissionsOnServiceInstanceResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("manage", NullValueHandling=NullValueHandling.Ignore)]
    public bool Manage
    {
    get;
    set;
    }

}
}