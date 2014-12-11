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
    public class AppUsageEventsEndpoint: BaseEndpoint
    {
        public AppUsageEventsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Purge and reseed App Usage Events
        /// </summary>
        /// Destroys all existing events. Populates new usage events, one for each started app.
        /// All populated events will have a created_at value of current time.
        /// 
        /// There is the potential race condition if apps are currently being started, stopped, or scaled.
        /// 
        /// The seeded usage events will have the same guid as the app.
    

    
        public async Task PurgeAndReseedAppUsageEvents()
    
        {
            string route = "/v2/app_usage_events/destructively_purge_all_and_reseed_started_apps";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
        /// <summary>
        /// List all App Usage Events
        /// </summary>
        /// Events are sorted by internal database IDs. This order may differ from created_at.
        /// 
        /// Events close to the current time should not be processed because other events may still have open
        /// transactions that will change their order in the results.
    
        
        public async Task<PagedResponse<ListAllAppUsageEventsResponse>> ListAllAppUsageEvents()
        {
            return await ListAllAppUsageEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllAppUsageEventsResponse>> ListAllAppUsageEvents(RequestOptions options)
    
        {
            string route = "/v2/app_usage_events";
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllAppUsageEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular App Usage Event
        /// </summary>
    
        
    

    
        public async Task<RetrieveAppUsageEventResponse> RetrieveAppUsageEvent(Guid guid)
    
        {
            string route = string.Format("/v2/app_usage_events/{0}", guid);
        
            
            string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveAppUsageEventResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}