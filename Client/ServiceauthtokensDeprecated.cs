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
public class ServiceauthtokensDeprecatedEndpoint: BaseEndpoint
{
public ServiceauthtokensDeprecatedEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// Delete a Particular Service Auth Token (deprecated)
  /// </summary>
    public async Task DeleteServiceAuthTokenDeprecated(Guid guid)
    {
        string route = string.Format("/v2/service_auth_tokens/{0}", guid);
    
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
  /// Filtering the result set by label (deprecated)
  /// </summary>
    public async Task<FilterResultSetByLabelDeprecatedResponse[]> FilterResultSetByLabelDeprecated()
    {
        string route = "/v2/service_auth_tokens";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<FilterResultSetByLabelDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Filtering the result set by provider (deprecated)
  /// </summary>
    public async Task<FilterResultSetByProviderDeprecatedResponse[]> FilterResultSetByProviderDeprecated()
    {
        string route = "/v2/service_auth_tokens";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<FilterResultSetByProviderDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Service Auth Tokens (deprecated)
  /// </summary>
    public async Task<ListAllServiceAuthTokensDeprecatedResponse[]> ListAllServiceAuthTokensDeprecated()
    {
        string route = "/v2/service_auth_tokens";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllServiceAuthTokensDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular Service Auth Token (deprecated)
  /// </summary>
    public async Task<RetrieveServiceAuthTokenDeprecatedResponse> RetrieveServiceAuthTokenDeprecated(Guid guid)
    {
        string route = string.Format("/v2/service_auth_tokens/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveServiceAuthTokenDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}