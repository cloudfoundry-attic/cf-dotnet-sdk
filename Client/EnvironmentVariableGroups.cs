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
    public class EnvironmentVariableGroupsEndpoint: BaseEndpoint
    {
        public EnvironmentVariableGroupsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Updating the contents of the staging environment variable group
        /// </summary>
        /// Updates the set of environment variables which will be made available during staging
    

    
        public async Task<UpdateContentsOfStagingEnvironmentVariableGroupResponse> UpdateContentsOfStagingEnvironmentVariableGroup(UpdateContentsOfStagingEnvironmentVariableGroupRequest value)
    
        {
            string route = "/v2/config/environment_variable_groups/staging";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateContentsOfStagingEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Getting the contents of the staging environment variable group
        /// </summary>
        /// returns the set of default environment variables available during staging
    
        
    

    
        public async Task<GettingContentsOfStagingEnvironmentVariableGroupResponse> GettingContentsOfStagingEnvironmentVariableGroup()
    
        {
            string route = "/v2/config/environment_variable_groups/staging";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<GettingContentsOfStagingEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Getting the contents of the running environment variable group
        /// </summary>
        /// returns the set of default environment variables available to running apps
    
        
    

    
        public async Task<GettingContentsOfRunningEnvironmentVariableGroupResponse> GettingContentsOfRunningEnvironmentVariableGroup()
    
        {
            string route = "/v2/config/environment_variable_groups/running";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<GettingContentsOfRunningEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Updating the contents of the running environment variable group
        /// </summary>
        /// Updates the set of environment variables which will be made available to all running apps
    

    
        public async Task<UpdateContentsOfRunningEnvironmentVariableGroupResponse> UpdateContentsOfRunningEnvironmentVariableGroup(UpdateContentsOfRunningEnvironmentVariableGroupRequest value)
    
        {
            string route = "/v2/config/environment_variable_groups/running";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateContentsOfRunningEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}