using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class GetUserSummaryResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("organizations", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] Organizations
    {
    get;
    set;
    }

    [JsonProperty("managed_organizations", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] ManagedOrganizations
    {
    get;
    set;
    }

    [JsonProperty("billing_managed_organizations", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] BillingManagedOrganizations
    {
    get;
    set;
    }

    [JsonProperty("audited_organizations", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] AuditedOrganizations
    {
    get;
    set;
    }

    [JsonProperty("spaces", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] Spaces
    {
    get;
    set;
    }

    [JsonProperty("managed_spaces", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] ManagedSpaces
    {
    get;
    set;
    }

    [JsonProperty("audited_spaces", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, dynamic>[] AuditedSpaces
    {
    get;
    set;
    }

}
}