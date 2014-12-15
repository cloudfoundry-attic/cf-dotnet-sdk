using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreatesDomainOwnedByGivenOrganizationDeprecatedRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("wildcard", NullValueHandling=NullValueHandling.Ignore)]
    public bool? Wildcard
    {
    get;
    set;
    }

    [JsonProperty("owning_organization_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? OwningOrganizationGuid
    {
    get;
    set;
    }

    [JsonProperty("guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? Guid
    {
    get;
    set;
    }

}
}