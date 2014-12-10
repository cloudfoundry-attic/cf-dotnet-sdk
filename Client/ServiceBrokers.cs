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
    public class ServiceBrokersEndpoint: BaseEndpoint
    {
        public ServiceBrokersEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Update a Service Broker
        /// </summary>
    

    
        public async Task<UpdateServiceBrokerResponse> UpdateServiceBroker(Guid guid, UpdateServiceBrokerRequest value)
    
        {
            string route = string.Format("/v2/service_brokers/{0}", guid);
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateServiceBrokerResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Service Broker
        /// </summary>
    
        
    

    
        public async Task<RetrieveServiceBrokerResponse> RetrieveServiceBroker(Guid guid)
    
        {
            string route = string.Format("/v2/service_brokers/{0}", guid);
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveServiceBrokerResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Create a Service Broker
        /// </summary>
    

    
        public async Task<CreateServiceBrokerResponse> CreateServiceBroker(CreateServiceBrokerRequest value)
    
        {
            string route = "/v2/service_brokers";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateServiceBrokerResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Service Broker
        /// </summary>
    

    
        public async Task DeleteServiceBroker(Guid guid)
    
        {
            string route = string.Format("/v2/service_brokers/{0}", guid);
        
            
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
        /// List all Service Brokers
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServiceBrokersResponse>> ListAllServiceBrokers()
        {
            return await ListAllServiceBrokers(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServiceBrokersResponse>> ListAllServiceBrokers(RequestOptions options)
    
        {
            string route = "/v2/service_brokers";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServiceBrokersResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}