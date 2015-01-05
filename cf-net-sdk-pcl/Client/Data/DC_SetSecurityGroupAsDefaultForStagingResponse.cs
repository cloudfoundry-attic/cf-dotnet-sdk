using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class SetSecurityGroupAsDefaultForStagingResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("rules", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, string>[] Rules
    {
    get;
    set;
    }

    [JsonProperty("running_default", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic RunningDefault
    {
    get;
    set;
    }

    [JsonProperty("staging_default", NullValueHandling=NullValueHandling.Ignore)]
    public bool StagingDefault
    {
    get;
    set;
    }

}
}