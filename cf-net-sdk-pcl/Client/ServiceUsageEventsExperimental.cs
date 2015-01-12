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
    public class ServiceUsageEventsExperimentalEndpoint: BaseEndpoint
    {
        public ServiceUsageEventsExperimentalEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// List Service Usage Events
        /// </summary>
        /// Events are sorted by internal database IDs. This order may differ from created_at.
        /// 
        /// Events close to the current time should not be processed because other events may still have open
        /// transactions that will change their order in the results.
    
        
        public async Task<PagedResponse<ListServiceUsageEventsResponse>> ListServiceUsageEvents()
        {
            return await ListServiceUsageEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceUsageEventsResponse>> ListServiceUsageEvents(RequestOptions options)
    
        {
            string route = "/v2/service_usage_events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceUsageEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Service Usage Event
        /// </summary>
    
        
    

    
        public async Task<RetrieveServiceUsageEventResponse> RetrieveServiceUsageEvent(Guid? guid)
    
        {
            string route = string.Format("/v2/service_usage_events/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveServiceUsageEventResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Purge and reseed Service Usage Events
        /// </summary>
        /// Destroys all existing events. Populates new usage events, one for each existing service instance.
        /// All populated events will have a created_at value of current time.
        /// 
        /// There is the potential race condition if service instances are currently being created or deleted.
        /// 
        /// The seeded usage events will have the same guid as the service instance.
    

    
        public async Task PurgeAndReseedServiceUsageEvents()
    
        {
            string route = "/v2/service_usage_events/destructively_purge_all_and_reseed_existing_instances";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
    }
}