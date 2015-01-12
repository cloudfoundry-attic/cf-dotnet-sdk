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
    public class EventsEndpoint: BaseEndpoint
    {
        public EventsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// List events associated with an App since January 1, 2014
        /// </summary>
    
        
        public async Task<PagedResponse<ListEventsAssociatedWithAppSinceJanuary12014Response>> ListEventsAssociatedWithAppSinceJanuary12014()
        {
            return await ListEventsAssociatedWithAppSinceJanuary12014(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListEventsAssociatedWithAppSinceJanuary12014Response>> ListEventsAssociatedWithAppSinceJanuary12014(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListEventsAssociatedWithAppSinceJanuary12014Response>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllEventsResponse>> ListAllEvents()
        {
            return await ListAllEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllEventsResponse>> ListAllEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Space Delete Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListSpaceDeleteEventsResponse>> ListSpaceDeleteEvents()
        {
            return await ListSpaceDeleteEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListSpaceDeleteEventsResponse>> ListSpaceDeleteEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListSpaceDeleteEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Space Update Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListSpaceUpdateEventsResponse>> ListSpaceUpdateEvents()
        {
            return await ListSpaceUpdateEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListSpaceUpdateEventsResponse>> ListSpaceUpdateEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListSpaceUpdateEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List App Exited Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListAppExitedEventsResponse>> ListAppExitedEvents()
        {
            return await ListAppExitedEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAppExitedEventsResponse>> ListAppExitedEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAppExitedEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List App Create Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListAppCreateEventsResponse>> ListAppCreateEvents()
        {
            return await ListAppCreateEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAppCreateEventsResponse>> ListAppCreateEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAppCreateEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Event
        /// </summary>
    
        
    

    
        public async Task<RetrieveEventResponse> RetrieveEvent(Guid? guid)
    
        {
            string route = string.Format("/v2/events/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveEventResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List App Delete Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListAppDeleteEventsResponse>> ListAppDeleteEvents()
        {
            return await ListAppDeleteEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAppDeleteEventsResponse>> ListAppDeleteEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAppDeleteEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Space Create Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListSpaceCreateEventsResponse>> ListSpaceCreateEvents()
        {
            return await ListSpaceCreateEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListSpaceCreateEventsResponse>> ListSpaceCreateEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListSpaceCreateEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List App Update Events
        /// </summary>
    
        
        public async Task<PagedResponse<ListAppUpdateEventsResponse>> ListAppUpdateEvents()
        {
            return await ListAppUpdateEvents(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAppUpdateEventsResponse>> ListAppUpdateEvents(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAppUpdateEventsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}