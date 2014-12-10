using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllRoutesForSpaceResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("host", NullValueHandling=NullValueHandling.Ignore)]
    public string Host
    {
    get;
    set;
    }

    [JsonProperty("domain_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid DomainGuid
    {
    get;
    set;
    }

    [JsonProperty("space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid SpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("domain_url", NullValueHandling=NullValueHandling.Ignore)]
    public string DomainUrl
    {
    get;
    set;
    }

    [JsonProperty("space_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceUrl
    {
    get;
    set;
    }

    [JsonProperty("apps_url", NullValueHandling=NullValueHandling.Ignore)]
    public string AppsUrl
    {
    get;
    set;
    }

}
}