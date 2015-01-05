using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllSecurityGroupsResponse :IResponse
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
    public dynamic[] Rules
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
    public dynamic StagingDefault
    {
    get;
    set;
    }

    [JsonProperty("spaces_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SpacesUrl
    {
    get;
    set;
    }

}
}