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
    public class SharedDomainsEndpoint: BaseEndpoint
    {
        public SharedDomainsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// List all Shared Domains
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllSharedDomainsResponse>> ListAllSharedDomains()
        {
            return await ListAllSharedDomains(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllSharedDomainsResponse>> ListAllSharedDomains(RequestOptions options)
    
        {
            string route = "/v2/shared_domains";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllSharedDomainsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Shared Domain
        /// </summary>
    

    
        public async Task DeleteSharedDomain(Guid? guid)
    
        {
            string route = string.Format("/v2/shared_domains/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
        /// <summary>
        /// Create a Shared Domain
        /// </summary>
    

    
        public async Task<CreateSharedDomainResponse> CreateSharedDomain(CreateSharedDomainRequest value)
    
        {
            string route = "/v2/shared_domains";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateSharedDomainResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Filtering Shared Domains by name
        /// </summary>
    
        
        public async Task<PagedResponse<FilterSharedDomainsByNameResponse>> FilterSharedDomainsByName()
        {
            return await FilterSharedDomainsByName(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<FilterSharedDomainsByNameResponse>> FilterSharedDomainsByName(RequestOptions options)
    
        {
            string route = "/v2/shared_domains";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<FilterSharedDomainsByNameResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Shared Domain
        /// </summary>
    
        
    

    
        public async Task<RetrieveSharedDomainResponse> RetrieveSharedDomain(Guid? guid)
    
        {
            string route = string.Format("/v2/shared_domains/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveSharedDomainResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}