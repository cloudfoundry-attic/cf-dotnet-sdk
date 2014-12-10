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
public class ServiceInstancesEndpoint: BaseEndpoint
{
public ServiceInstancesEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// Creating a Service Instance
  /// </summary>
    public async Task<CreateServiceInstanceResponse> CreateServiceInstance(CreateServiceInstanceRequest value)
    {
        string route = "/v2/service_instances/";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Post;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<CreateServiceInstanceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Delete a Particular Service Instance
  /// </summary>
    public async Task DeleteServiceInstance(Guid guid)
    {
        string route = string.Format("/v2/service_instances/{0}", guid);
    
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
  /// List all Service Bindings for the Service Instance
  /// </summary>
    public async Task<ListAllServiceBindingsForServiceInstanceResponse[]> ListAllServiceBindingsForServiceInstance(Guid guid)
    {
        string route = string.Format("/v2/service_instances/{0}/service_bindings", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllServiceBindingsForServiceInstanceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Service Instances
  /// </summary>
    public async Task<ListAllServiceInstancesResponse[]> ListAllServiceInstances()
    {
        string route = "/v2/service_instances";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllServiceInstancesResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Migrate Service Instances from one Service Plan to another Service Plan (experimental)
  /// </summary>
        /// Move all Service Instances for the service plan from the URL to the service plan in the request body
    public async Task<MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalResponse> MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimental(Guid service_plan_guid, MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest value)
    {
        string route = string.Format("/v2/service_plans/{0}/service_instances", service_plan_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular Service Instance
  /// </summary>
    public async Task<RetrieveServiceInstanceResponse> RetrieveServiceInstance(Guid guid)
    {
        string route = string.Format("/v2/service_instances/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveServiceInstanceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieving permissions on a Service Instance
  /// </summary>
    public async Task<RetrievingPermissionsOnServiceInstanceResponse> RetrievingPermissionsOnServiceInstance(Guid guid)
    {
        string route = string.Format("/v2/service_instances/{0}/permissions", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrievingPermissionsOnServiceInstanceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Updating the service plan a service instance
  /// </summary>
    public async Task<UpdateServicePlanServiceInstanceResponse> UpdateServicePlanServiceInstance(Guid guid, UpdateServicePlanServiceInstanceRequest value)
    {
        string route = string.Format("/v2/service_instances/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<UpdateServicePlanServiceInstanceResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}