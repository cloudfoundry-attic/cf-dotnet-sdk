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
    public class OrganizationQuotaDefinitionsEndpoint: BaseEndpoint
    {
        public OrganizationQuotaDefinitionsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Creating a Organization Quota Definition
        /// </summary>
    

    
        public async Task<CreateOrganizationQuotaDefinitionResponse> CreateOrganizationQuotaDefinition(CreateOrganizationQuotaDefinitionRequest value)
    
        {
            string route = "/v2/quota_definitions";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateOrganizationQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Organization Quota Definitions
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllOrganizationQuotaDefinitionsResponse>> ListAllOrganizationQuotaDefinitions()
        {
            return await ListAllOrganizationQuotaDefinitions(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllOrganizationQuotaDefinitionsResponse>> ListAllOrganizationQuotaDefinitions(RequestOptions options)
    
        {
            string route = "/v2/quota_definitions";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllOrganizationQuotaDefinitionsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Updating a Organization Quota Definition
        /// </summary>
    

    
        public async Task<UpdateOrganizationQuotaDefinitionResponse> UpdateOrganizationQuotaDefinition(Guid? guid, UpdateOrganizationQuotaDefinitionRequest value)
    
        {
            string route = string.Format("/v2/quota_definitions/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateOrganizationQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Organization Quota Definition
        /// </summary>
    
        
    

    
        public async Task<RetrieveOrganizationQuotaDefinitionResponse> RetrieveOrganizationQuotaDefinition(Guid? guid)
    
        {
            string route = string.Format("/v2/quota_definitions/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveOrganizationQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Organization Quota Definition
        /// </summary>
    

    
        public async Task DeleteOrganizationQuotaDefinition(Guid? guid)
    
        {
            string route = string.Format("/v2/quota_definitions/{0}", guid);
        
            
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