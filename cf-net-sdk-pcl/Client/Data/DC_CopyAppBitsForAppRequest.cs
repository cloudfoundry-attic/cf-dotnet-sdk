using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CopyAppBitsForAppRequest
{



    [JsonProperty("source_app_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid SourceAppGuid
    {
    get;
    set;
    }

}
}