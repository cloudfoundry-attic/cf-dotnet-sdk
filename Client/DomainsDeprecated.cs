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
public class DomainsDeprecatedEndpoint: BaseEndpoint
{
public DomainsDeprecatedEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// creates a domain owned by the given organization (deprecated)
  /// </summary>
    public async Task<CreatesDomainOwnedByGivenOrganizationDeprecatedResponse> CreatesDomainOwnedByGivenOrganizationDeprecated(CreatesDomainOwnedByGivenOrganizationDeprecatedRequest value)
    {
        string route = "/v2/domains";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Post;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<CreatesDomainOwnedByGivenOrganizationDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// creates a shared domain (deprecated)
  /// </summary>
    public async Task<CreatesSharedDomainDeprecatedResponse> CreatesSharedDomainDeprecated(CreatesSharedDomainDeprecatedRequest value)
    {
        string route = "/v2/domains";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Post;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<CreatesSharedDomainDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Delete a Particular Domain (deprecated)
  /// </summary>
    public async Task DeleteDomainDeprecated(Guid guid)
    {
        string route = string.Format("/v2/domains/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
    }

    /// <summary>
  /// List all Domains (deprecated)
  /// </summary>
    public async Task<ListAllDomainsDeprecatedResponse[]> ListAllDomainsDeprecated()
    {
        string route = "/v2/domains";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllDomainsDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Spaces for the Domain (deprecated)
  /// </summary>
    public async Task<ListAllSpacesForDomainDeprecatedResponse[]> ListAllSpacesForDomainDeprecated(Guid guid)
    {
        string route = string.Format("/v2/domains/{0}/spaces", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllSpacesForDomainDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular Domain (deprecated)
  /// </summary>
    public async Task<RetrieveDomainDeprecatedResponse> RetrieveDomainDeprecated(Guid guid)
    {
        string route = string.Format("/v2/domains/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveDomainDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}