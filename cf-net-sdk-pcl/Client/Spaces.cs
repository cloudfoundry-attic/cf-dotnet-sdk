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
    public class SpacesEndpoint: BaseEndpoint
    {
        public SpacesEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Update a Space
        /// </summary>
    

    
        public async Task<UpdateSpaceResponse> UpdateSpace(Guid? guid, UpdateSpaceRequest value)
    
        {
            string route = string.Format("/v2/spaces/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Developers for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllDevelopersForSpaceResponse>> ListAllDevelopersForSpace(Guid? guid)
        {
            return await ListAllDevelopersForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllDevelopersForSpaceResponse>> ListAllDevelopersForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/developers", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllDevelopersForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove Developer from the Space
        /// </summary>
    

    
        public async Task<RemoveDeveloperFromSpaceResponse> RemoveDeveloperFromSpace(Guid? guid, Guid? developer_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/developers/{1}", guid, developer_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveDeveloperFromSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Services for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServicesForSpaceResponse>> ListAllServicesForSpace(Guid? guid)
        {
            return await ListAllServicesForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServicesForSpaceResponse>> ListAllServicesForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/services", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServicesForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Domains for the Space (deprecated)
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllDomainsForSpaceDeprecatedResponse>> ListAllDomainsForSpaceDeprecated(Guid? guid)
        {
            return await ListAllDomainsForSpaceDeprecated(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllDomainsForSpaceDeprecatedResponse>> ListAllDomainsForSpaceDeprecated(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/domains", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllDomainsForSpaceDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove Auditor from the Space
        /// </summary>
    

    
        public async Task<RemoveAuditorFromSpaceResponse> RemoveAuditorFromSpace(Guid? guid, Guid? auditor_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/auditors/{1}", guid, auditor_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveAuditorFromSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Spaces
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllSpacesResponse>> ListAllSpaces()
        {
            return await ListAllSpaces(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllSpacesResponse>> ListAllSpaces(RequestOptions options)
    
        {
            string route = "/v2/spaces";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllSpacesResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Apps for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllAppsForSpaceResponse>> ListAllAppsForSpace(Guid? guid)
        {
            return await ListAllAppsForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllAppsForSpaceResponse>> ListAllAppsForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/apps", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllAppsForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Associate Security Group with the Space
        /// </summary>
    

    
        public async Task<AssociateSecurityGroupWithSpaceResponse> AssociateSecurityGroupWithSpace(Guid? guid, Guid? security_group_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/security_groups/{1}", guid, security_group_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateSecurityGroupWithSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Associate Manager with the Space
        /// </summary>
    

    
        public async Task<AssociateManagerWithSpaceResponse> AssociateManagerWithSpace(Guid? guid, Guid? manager_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/managers/{1}", guid, manager_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateManagerWithSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove Manager from the Space
        /// </summary>
    

    
        public async Task<RemoveManagerFromSpaceResponse> RemoveManagerFromSpace(Guid? guid, Guid? manager_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/managers/{1}", guid, manager_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveManagerFromSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Service Instances for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServiceInstancesForSpaceResponse>> ListAllServiceInstancesForSpace(Guid? guid)
        {
            return await ListAllServiceInstancesForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServiceInstancesForSpaceResponse>> ListAllServiceInstancesForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/service_instances", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServiceInstancesForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Managers for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllManagersForSpaceResponse>> ListAllManagersForSpace(Guid? guid)
        {
            return await ListAllManagersForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllManagersForSpaceResponse>> ListAllManagersForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/managers", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllManagersForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Routes for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllRoutesForSpaceResponse>> ListAllRoutesForSpace(Guid? guid)
        {
            return await ListAllRoutesForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllRoutesForSpaceResponse>> ListAllRoutesForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/routes", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllRoutesForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Associate Developer with the Space
        /// </summary>
    

    
        public async Task<AssociateDeveloperWithSpaceResponse> AssociateDeveloperWithSpace(Guid? guid, Guid? developer_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/developers/{1}", guid, developer_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateDeveloperWithSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Creating a Space
        /// </summary>
    

    
        public async Task<CreateSpaceResponse> CreateSpace(CreateSpaceRequest value)
    
        {
            string route = "/v2/spaces";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Space
        /// </summary>
    

    
        public async Task DeleteSpace(Guid? guid)
    
        {
            string route = string.Format("/v2/spaces/{0}", guid);
        
            
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
        /// List all Events for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllEventsForSpaceResponse>> ListAllEventsForSpace(Guid? guid)
        {
            return await ListAllEventsForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllEventsForSpaceResponse>> ListAllEventsForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/events", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllEventsForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Auditors for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllAuditorsForSpaceResponse>> ListAllAuditorsForSpace(Guid? guid)
        {
            return await ListAllAuditorsForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllAuditorsForSpaceResponse>> ListAllAuditorsForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/auditors", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllAuditorsForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Space
        /// </summary>
    
        
    

    
        public async Task<RetrieveSpaceResponse> RetrieveSpace(Guid? guid)
    
        {
            string route = string.Format("/v2/spaces/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Get Space summary
        /// </summary>
    
        
    

    
        public async Task<GetSpaceSummaryResponse> GetSpaceSummary(Guid? guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/summary", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<GetSpaceSummaryResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Associate Auditor with the Space
        /// </summary>
    

    
        public async Task<AssociateAuditorWithSpaceResponse> AssociateAuditorWithSpace(Guid? guid, Guid? auditor_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/auditors/{1}", guid, auditor_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateAuditorWithSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove Security Group from the Space
        /// </summary>
    

    
        public async Task<RemoveSecurityGroupFromSpaceResponse> RemoveSecurityGroupFromSpace(Guid? guid, Guid? security_group_guid)
    
        {
            string route = string.Format("/v2/spaces/{0}/security_groups/{1}", guid, security_group_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveSecurityGroupFromSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Security Groups for the Space
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllSecurityGroupsForSpaceResponse>> ListAllSecurityGroupsForSpace(Guid? guid)
        {
            return await ListAllSecurityGroupsForSpace(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllSecurityGroupsForSpaceResponse>> ListAllSecurityGroupsForSpace(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/spaces/{0}/security_groups", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllSecurityGroupsForSpaceResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}