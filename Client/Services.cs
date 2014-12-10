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
public class ServicesEndpoint: BaseEndpoint
{
public ServicesEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// Creating a Service (deprecated)
  /// </summary>
    public async Task<CreateServiceDeprecatedResponse> CreateServiceDeprecated(CreateServiceDeprecatedRequest value)
    {
        string route = "/v2/services";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Post;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<CreateServiceDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Delete a Particular Service
  /// </summary>
    public async Task DeleteService(Guid guid)
    {
        string route = string.Format("/v2/services/{0}", guid);
    
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
  /// List all Services
  /// </summary>
    public async Task<ListAllServicesResponse[]> ListAllServices()
    {
        string route = "/v2/services";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllServicesResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Service Plans for the Service
  /// </summary>
    public async Task<ListAllServicePlansForServiceResponse[]> ListAllServicePlansForService(Guid guid)
    {
        string route = string.Format("/v2/services/{0}/service_plans", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllServicePlansForServiceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular Service
  /// </summary>
    public async Task<RetrieveServiceResponse> RetrieveService(Guid guid)
    {
        string route = string.Format("/v2/services/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveServiceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Updating a Service (deprecated)
  /// </summary>
    public async Task<UpdateServiceDeprecatedResponse> UpdateServiceDeprecated(UpdateServiceDeprecatedRequest value)
    {
        string route = "/v2/services";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<UpdateServiceDeprecatedResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}