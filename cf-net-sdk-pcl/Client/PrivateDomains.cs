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
    public class PrivateDomainsEndpoint: BaseEndpoint
    {
        public PrivateDomainsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Create a Private Domain owned by the given Organization
        /// </summary>
    

    
        public async Task<CreatePrivateDomainOwnedByGivenOrganizationResponse> CreatePrivateDomainOwnedByGivenOrganization(CreatePrivateDomainOwnedByGivenOrganizationRequest value)
    
        {
            string route = "/v2/private_domains";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreatePrivateDomainOwnedByGivenOrganizationResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Private Domain
        /// </summary>
    

    
        public async Task DeletePrivateDomain(Guid guid)
    
        {
            string route = string.Format("/v2/private_domains/{0}", guid);
        
            
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
        /// Filtering Private Domains by name
        /// </summary>
    
        
        public async Task<PagedResponse<FilterPrivateDomainsByNameResponse>> FilterPrivateDomainsByName()
        {
            return await FilterPrivateDomainsByName(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<FilterPrivateDomainsByNameResponse>> FilterPrivateDomainsByName(RequestOptions options)
    
        {
            string route = "/v2/private_domains";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<FilterPrivateDomainsByNameResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Private Domains
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllPrivateDomainsResponse>> ListAllPrivateDomains()
        {
            return await ListAllPrivateDomains(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllPrivateDomainsResponse>> ListAllPrivateDomains(RequestOptions options)
    
        {
            string route = "/v2/private_domains";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllPrivateDomainsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Private Domain
        /// </summary>
    
        
    

    
        public async Task<RetrievePrivateDomainResponse> RetrievePrivateDomain(Guid guid)
    
        {
            string route = string.Format("/v2/private_domains/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrievePrivateDomainResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}