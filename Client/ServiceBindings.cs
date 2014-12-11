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
    public class ServiceBindingsEndpoint: BaseEndpoint
    {
        public ServiceBindingsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Delete a Particular Service Binding
        /// </summary>
    

    
        public async Task DeleteServiceBinding(Guid guid)
    
        {
            string route = string.Format("/v2/service_bindings/{0}", guid);
        
            
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
        /// Retrieve a Particular Service Binding
        /// </summary>
    
        
    

    
        public async Task<RetrieveServiceBindingResponse> RetrieveServiceBinding(Guid guid)
    
        {
            string route = string.Format("/v2/service_bindings/{0}", guid);
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveServiceBindingResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Service Bindings
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServiceBindingsResponse>> ListAllServiceBindings()
        {
            return await ListAllServiceBindings(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServiceBindingsResponse>> ListAllServiceBindings(RequestOptions options)
    
        {
            string route = "/v2/service_bindings";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServiceBindingsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Create a Service Binding
        /// </summary>
    

    
        public async Task<CreateServiceBindingResponse> CreateServiceBinding(CreateServiceBindingRequest value)
    
        {
            string route = "/v2/service_bindings";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateServiceBindingResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}