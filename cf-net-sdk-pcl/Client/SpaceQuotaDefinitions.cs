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
    public class SpaceQuotaDefinitionsEndpoint: BaseEndpoint
    {
        public SpaceQuotaDefinitionsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Remove Space from the Space Quota Definition
        /// </summary>
    

    
        public async Task<RemoveSpaceFromSpaceQuotaDefinitionResponse> RemoveSpaceFromSpaceQuotaDefinition(Guid? guid, Guid? space_guid)
    
        {
            string route = string.Format("/v2/space_quota_definitions/{0}/spaces/{1}", guid, space_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveSpaceFromSpaceQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Associate Space with the Space Quota Definition
        /// </summary>
    

    
        public async Task<AssociateSpaceWithSpaceQuotaDefinitionResponse> AssociateSpaceWithSpaceQuotaDefinition(Guid? guid, Guid? space_guid)
    
        {
            string route = string.Format("/v2/space_quota_definitions/{0}/spaces/{1}", guid, space_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateSpaceWithSpaceQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Space Quota Definition
        /// </summary>
    
        
    

    
        public async Task<RetrieveSpaceQuotaDefinitionResponse> RetrieveSpaceQuotaDefinition(Guid? guid)
    
        {
            string route = string.Format("/v2/space_quota_definitions/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveSpaceQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Creating a Space Quota Definition
        /// </summary>
    

    
        public async Task<CreateSpaceQuotaDefinitionResponse> CreateSpaceQuotaDefinition(CreateSpaceQuotaDefinitionRequest value)
    
        {
            string route = "/v2/space_quota_definitions";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateSpaceQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Updating a Space Quota Definition
        /// </summary>
    

    
        public async Task<UpdateSpaceQuotaDefinitionResponse> UpdateSpaceQuotaDefinition(Guid? guid, UpdateSpaceQuotaDefinitionRequest value)
    
        {
            string route = string.Format("/v2/space_quota_definitions/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateSpaceQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Space Quota Definition
        /// </summary>
    

    
        public async Task DeleteSpaceQuotaDefinition(Guid? guid)
    
        {
            string route = string.Format("/v2/space_quota_definitions/{0}", guid);
        
            
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
        /// List all Spaces for the Space Quota Definition
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllSpacesForSpaceQuotaDefinitionResponse>> ListAllSpacesForSpaceQuotaDefinition(Guid? guid)
        {
            return await ListAllSpacesForSpaceQuotaDefinition(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllSpacesForSpaceQuotaDefinitionResponse>> ListAllSpacesForSpaceQuotaDefinition(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/space_quota_definitions/{0}/spaces", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllSpacesForSpaceQuotaDefinitionResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Space Quota Definitions
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllSpaceQuotaDefinitionsResponse>> ListAllSpaceQuotaDefinitions()
        {
            return await ListAllSpaceQuotaDefinitions(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllSpaceQuotaDefinitionsResponse>> ListAllSpaceQuotaDefinitions(RequestOptions options)
    
        {
            string route = "/v2/space_quota_definitions";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllSpaceQuotaDefinitionsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}