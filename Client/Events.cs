using cf_net_sdk.Client.Data;
using cf_net_sdk.Interfaces;
using CloudFoundry.Common;
using CloudFoundry.Common.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace cf_net_sdk.Client
{
public class EventsEndpoint: BaseEndpoint
{
public EventsEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// List all Events
  /// </summary>
    public async Task<ListAllEventsResponse[]> ListAllEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List App Create Events
  /// </summary>
    public async Task<ListAppCreateEventsResponse[]> ListAppCreateEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAppCreateEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List App Delete Events
  /// </summary>
    public async Task<ListAppDeleteEventsResponse[]> ListAppDeleteEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAppDeleteEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List App Exited Events
  /// </summary>
    public async Task<ListAppExitedEventsResponse[]> ListAppExitedEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAppExitedEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List App Update Events
  /// </summary>
    public async Task<ListAppUpdateEventsResponse[]> ListAppUpdateEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAppUpdateEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List events associated with an App since January 1, 2014
  /// </summary>
    public async Task<ListEventsAssociatedWithAppSinceJanuary12014Response[]> ListEventsAssociatedWithAppSinceJanuary12014()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListEventsAssociatedWithAppSinceJanuary12014Response>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List Space Create Events
  /// </summary>
    public async Task<ListSpaceCreateEventsResponse[]> ListSpaceCreateEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListSpaceCreateEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List Space Delete Events
  /// </summary>
    public async Task<ListSpaceDeleteEventsResponse[]> ListSpaceDeleteEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListSpaceDeleteEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List Space Update Events
  /// </summary>
    public async Task<ListSpaceUpdateEventsResponse[]> ListSpaceUpdateEvents()
    {
        string route = "/v2/events";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListSpaceUpdateEventsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular Event
  /// </summary>
    public async Task<RetrieveEventResponse> RetrieveEvent(Guid guid)
    {
        string route = string.Format("/v2/events/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveEventResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}