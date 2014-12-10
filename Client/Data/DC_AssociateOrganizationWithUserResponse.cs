using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class AssociateOrganizationWithUserResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("admin", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Admin
    {
    get;
    set;
    }

    [JsonProperty("active", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Active
    {
    get;
    set;
    }

    [JsonProperty("default_space_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid DefaultSpaceGuid
    {
    get;
    set;
    }

    [JsonProperty("default_space_url", NullValueHandling=NullValueHandling.Ignore)]
    public string DefaultSpaceUrl
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

    [JsonProperty("organizations_url", NullValueHandling=NullValueHandling.Ignore)]
    public string OrganizationsUrl
    {
    get;
    set;
    }

    [JsonProperty("managed_organizations_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ManagedOrganizationsUrl
    {
    get;
    set;
    }

    [JsonProperty("billing_managed_organizations_url", NullValueHandling=NullValueHandling.Ignore)]
    public string BillingManagedOrganizationsUrl
    {
    get;
    set;
    }

    [JsonProperty("audited_organizations_url", NullValueHandling=NullValueHandling.Ignore)]
    public string AuditedOrganizationsUrl
    {
    get;
    set;
    }

    [JsonProperty("managed_spaces_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ManagedSpacesUrl
    {
    get;
    set;
    }

    [JsonProperty("audited_spaces_url", NullValueHandling=NullValueHandling.Ignore)]
    public string AuditedSpacesUrl
    {
    get;
    set;
    }

}
}