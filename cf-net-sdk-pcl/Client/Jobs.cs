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
    public class JobsEndpoint: BaseEndpoint
    {
        public JobsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Retrieve Job that is queued
        /// </summary>
    
        
    

    
        public async Task<RetrieveJobThatIsQueuedResponse> RetrieveJobThatIsQueued(Guid guid)
    
        {
            string route = string.Format("/v2/jobs/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveJobThatIsQueuedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve Job that was successful
        /// </summary>
    
        
    

    
        public async Task<RetrieveJobThatWasSuccessfulResponse> RetrieveJobThatWasSuccessful(Guid guid)
    
        {
            string route = string.Format("/v2/jobs/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveJobThatWasSuccessfulResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve Job with known failure
        /// </summary>
    
        
    

    
        public async Task<RetrieveJobWithKnownFailureResponse> RetrieveJobWithKnownFailure(Guid guid)
    
        {
            string route = string.Format("/v2/jobs/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveJobWithKnownFailureResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve Job with unknown failure
        /// </summary>
    
        
    

    
        public async Task<RetrieveJobWithUnknownFailureResponse> RetrieveJobWithUnknownFailure(Guid guid)
    
        {
            string route = string.Format("/v2/jobs/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveJobWithUnknownFailureResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}