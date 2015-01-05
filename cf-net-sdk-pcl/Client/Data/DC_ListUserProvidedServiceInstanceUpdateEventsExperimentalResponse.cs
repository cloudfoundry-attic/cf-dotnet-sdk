using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListUserProvidedServiceInstanceUpdateEventsExperimentalResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("type", NullValueHandling=NullValueHandling.Ignore)]
    public string Type
    {
    get;
    set;
    }

    [JsonProperty("actor", NullValueHandling=NullValueHandling.Ignore)]
    public string Actor
    {
    get;
    set;
    }

    [JsonProperty("actor_type", NullValueHandling=NullValueHandling.Ignore)]
    public string ActorType
    {
    get;
    set;
    }

    [JsonProperty("actor_name", NullValueHandling=NullValueHandling.Ignore)]
    public string ActorName
    {
    get;
    set;
    }

    [JsonProperty("actee", NullValueHandling=NullValueHandling.Ignore)]
    public Guid Actee
    {
    get;
    set;
    }

    [JsonProperty("actee_type", NullValueHandling=NullValueHandling.Ignore)]
    public string ActeeType
    {
    get;
    set;
    }

    [JsonProperty("actee_name", NullValueHandling=NullValueHandling.Ignore)]
    public string ActeeName
    {
    get;
    set;
    }

    [JsonProperty("timestamp", NullValueHandling=NullValueHandling.Ignore)]
    public string Timestamp
    {
    get;
    set;
    }

    [JsonProperty("metadata", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, Dictionary<string, string>> Metadata
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

    [JsonProperty("organization_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid OrganizationGuid
    {
    get;
    set;
    }

}
}