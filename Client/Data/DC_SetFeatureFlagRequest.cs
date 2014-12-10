using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class SetFeatureFlagRequest
{



    [JsonProperty("enabled", NullValueHandling=NullValueHandling.Ignore)]
    public bool Enabled
    {
    get;
    set;
    }

    [JsonProperty("error_message", NullValueHandling=NullValueHandling.Ignore)]
    public string ErrorMessage
    {
    get;
    set;
    }

}
}