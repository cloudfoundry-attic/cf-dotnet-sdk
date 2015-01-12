using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class CreateOrganizationRequest
{



    [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
    public string Name
    {
    get;
    set;
    }

    [JsonProperty("quota_definition_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid? QuotaDefinitionGuid
    {
    get;
    set;
    }

    [JsonProperty("status", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic Status
    {
    get;
    set;
    }

    [JsonProperty("billing_enabled", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic BillingEnabled
    {
    get;
    set;
    }

}
}