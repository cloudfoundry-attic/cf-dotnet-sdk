using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllPrivateDomainsResponse :IResponse
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

    [JsonProperty("owning_organization_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? OwningOrganizationGuid
    {
    get;
    set;
    }

    [JsonProperty("owning_organization_url", NullValueHandling=NullValueHandling.Ignore)]
    public string OwningOrganizationUrl
    {
    get;
    set;
    }

}
}