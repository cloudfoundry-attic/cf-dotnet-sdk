using cf_net_sdk.Client.Data;
using cf_net_sdk.Interfaces;
using CloudFoundry.Common;
using CloudFoundry.Common.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace cf_net_sdk.Client
{
    public class ServicePlansEndpoint: BaseEndpoint
    {
        public ServicePlansEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Creating a Service Plan (deprecated)
        /// </summary>
    

    
        public async Task<CreateServicePlanDeprecatedResponse> CreateServicePlanDeprecated(CreateServicePlanDeprecatedRequest value)
    
        {
            string route = "/v2/service_plans";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateServicePlanDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Service Plans
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServicePlansResponse>> ListAllServicePlans()
        {
            return await ListAllServicePlans(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServicePlansResponse>> ListAllServicePlans(RequestOptions options)
    
        {
            string route = "/v2/service_plans";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServicePlansResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Updating a Service Plan (deprecated)
        /// </summary>
    

    
        public async Task<UpdateServicePlanDeprecatedResponse> UpdateServicePlanDeprecated(UpdateServicePlanDeprecatedRequest value)
    
        {
            string route = "/v2/service_plans";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateServicePlanDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Service Instances for the Service Plan
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServiceInstancesForServicePlanResponse>> ListAllServiceInstancesForServicePlan(Guid? guid)
        {
            return await ListAllServiceInstancesForServicePlan(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServiceInstancesForServicePlanResponse>> ListAllServiceInstancesForServicePlan(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/service_plans/{0}/service_instances", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServiceInstancesForServicePlanResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Service Plan
        /// </summary>
    
        
    

    
        public async Task<RetrieveServicePlanResponse> RetrieveServicePlan(Guid? guid)
    
        {
            string route = string.Format("/v2/service_plans/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveServicePlanResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Service Plans
        /// </summary>
    

    
        public async Task DeleteServicePlans(Guid? guid)
    
        {
            string route = string.Format("/v2/service_plans/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
    }
}