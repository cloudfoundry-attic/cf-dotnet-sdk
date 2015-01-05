using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllSpacesForSpaceQuotaDefinitionResponse :IResponse
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

    [JsonProperty("organization_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid OrganizationGuid
    {
    get;
    set;
    }

    [JsonProperty("space_quota_definition_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid SpaceQuotaDefinitionGuid
    {
    get;
    set;
    }

    [JsonProperty("organization_url", NullValueHandling=NullValueHandling.Ignore)]
    public string OrganizationUrl
    {
    get;
    set;
    }

    [JsonProperty("space_quota_definition_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SpaceQuotaDefinitionUrl
    {
    get;
    set;
    }

    [JsonProperty("developers_url", NullValueHandling=NullValueHandling.Ignore)]
    public string DevelopersUrl
    {
    get;
    set;
    }

    [JsonProperty("managers_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ManagersUrl
    {
    get;
    set;
    }

    [JsonProperty("auditors_url", NullValueHandling=NullValueHandling.Ignore)]
    public string AuditorsUrl
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

    [JsonProperty("routes_url", NullValueHandling=NullValueHandling.Ignore)]
    public string RoutesUrl
    {
    get;
    set;
    }

    [JsonProperty("domains_url", NullValueHandling=NullValueHandling.Ignore)]
    public string DomainsUrl
    {
    get;
    set;
    }

    [JsonProperty("service_instances_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ServiceInstancesUrl
    {
    get;
    set;
    }

    [JsonProperty("app_events_url", NullValueHandling=NullValueHandling.Ignore)]
    public string AppEventsUrl
    {
    get;
    set;
    }

    [JsonProperty("events_url", NullValueHandling=NullValueHandling.Ignore)]
    public string EventsUrl
    {
    get;
    set;
    }

    [JsonProperty("security_groups_url", NullValueHandling=NullValueHandling.Ignore)]
    public string SecurityGroupsUrl
    {
    get;
    set;
    }

}
}