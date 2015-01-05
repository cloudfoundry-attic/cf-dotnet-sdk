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
    public class AppsExperimentalEndpoint: BaseEndpoint
    {
        public AppsExperimentalEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Add a Process
        /// </summary>
    

    
        public async Task AddProcess(Guid guid, AddProcessRequest value)
    
        {
            string route = string.Format("/v3/apps/{0}/processes", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
        /// <summary>
        /// Create an App
        /// </summary>
    

    
        public async Task<CreateAppResponse> CreateApp(CreateAppRequest value)
    
        {
            string route = "/v3/apps";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete an App
        /// </summary>
    

    
        public async Task DeleteApp(Guid guid)
    
        {
            string route = string.Format("/v3/apps/{0}", guid);
        
            
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
        /// Get an App
        /// </summary>
    
        
    

    
        public async Task<GetAppResponse> GetApp(Guid guid)
    
        {
            string route = string.Format("/v3/apps/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<GetAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List associated processes
        /// </summary>
    
        
        public async Task<PagedResponse<ListAssociatedProcessesResponse>> ListAssociatedProcesses(Guid guid)
        {
            return await ListAssociatedProcesses(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAssociatedProcessesResponse>> ListAssociatedProcesses(Guid guid, RequestOptions options)
    
        {
            string route = string.Format("/v3/apps/{0}/processes", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAssociatedProcessesResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove a Process
        /// </summary>
    

    
        public async Task RemoveProcess(Guid guid, RemoveProcessRequest value)
    
        {
            string route = string.Format("/v3/apps/{0}/processes", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
        /// <summary>
        /// Updating an App
        /// </summary>
    

    
        public async Task<UpdateAppResponse> UpdateApp(Guid guid, UpdateAppRequest value)
    
        {
            string route = string.Format("/v3/apps/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = new HttpMethod("PATCH");
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}