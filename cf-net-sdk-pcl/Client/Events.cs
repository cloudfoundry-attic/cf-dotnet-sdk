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
        /// List Service Binding Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceBindingCreateEventsExperimentalResponse>> ListServiceBindingCreateEventsExperimental()
        {
            return await ListServiceBindingCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceBindingCreateEventsExperimentalResponse>> ListServiceBindingCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceBindingCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Binding Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceBindingDeleteEventsExperimentalResponse>> ListServiceBindingDeleteEventsExperimental()
        {
            return await ListServiceBindingDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceBindingDeleteEventsExperimentalResponse>> ListServiceBindingDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceBindingDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Broker Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceBrokerCreateEventsExperimentalResponse>> ListServiceBrokerCreateEventsExperimental()
        {
            return await ListServiceBrokerCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceBrokerCreateEventsExperimentalResponse>> ListServiceBrokerCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceBrokerCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Broker Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceBrokerDeleteEventsExperimentalResponse>> ListServiceBrokerDeleteEventsExperimental()
        {
            return await ListServiceBrokerDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceBrokerDeleteEventsExperimentalResponse>> ListServiceBrokerDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceBrokerDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Broker Update Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceBrokerUpdateEventsExperimentalResponse>> ListServiceBrokerUpdateEventsExperimental()
        {
            return await ListServiceBrokerUpdateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceBrokerUpdateEventsExperimentalResponse>> ListServiceBrokerUpdateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceBrokerUpdateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceCreateEventsExperimentalResponse>> ListServiceCreateEventsExperimental()
        {
            return await ListServiceCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceCreateEventsExperimentalResponse>> ListServiceCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Dashboard Client Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceDashboardClientCreateEventsExperimentalResponse>> ListServiceDashboardClientCreateEventsExperimental()
        {
            return await ListServiceDashboardClientCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceDashboardClientCreateEventsExperimentalResponse>> ListServiceDashboardClientCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceDashboardClientCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Dashboard Client Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceDashboardClientDeleteEventsExperimentalResponse>> ListServiceDashboardClientDeleteEventsExperimental()
        {
            return await ListServiceDashboardClientDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceDashboardClientDeleteEventsExperimentalResponse>> ListServiceDashboardClientDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceDashboardClientDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceDeleteEventsExperimentalResponse>> ListServiceDeleteEventsExperimental()
        {
            return await ListServiceDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceDeleteEventsExperimentalResponse>> ListServiceDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Instance Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceInstanceCreateEventsExperimentalResponse>> ListServiceInstanceCreateEventsExperimental()
        {
            return await ListServiceInstanceCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceInstanceCreateEventsExperimentalResponse>> ListServiceInstanceCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceInstanceCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Instance Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceInstanceDeleteEventsExperimentalResponse>> ListServiceInstanceDeleteEventsExperimental()
        {
            return await ListServiceInstanceDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceInstanceDeleteEventsExperimentalResponse>> ListServiceInstanceDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceInstanceDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Instance Update Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceInstanceUpdateEventsExperimentalResponse>> ListServiceInstanceUpdateEventsExperimental()
        {
            return await ListServiceInstanceUpdateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceInstanceUpdateEventsExperimentalResponse>> ListServiceInstanceUpdateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceInstanceUpdateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Plan Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServicePlanCreateEventsExperimentalResponse>> ListServicePlanCreateEventsExperimental()
        {
            return await ListServicePlanCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServicePlanCreateEventsExperimentalResponse>> ListServicePlanCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServicePlanCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Plan Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServicePlanDeleteEventsExperimentalResponse>> ListServicePlanDeleteEventsExperimental()
        {
            return await ListServicePlanDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServicePlanDeleteEventsExperimentalResponse>> ListServicePlanDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServicePlanDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Plan Update Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServicePlanUpdateEventsExperimentalResponse>> ListServicePlanUpdateEventsExperimental()
        {
            return await ListServicePlanUpdateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServicePlanUpdateEventsExperimentalResponse>> ListServicePlanUpdateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServicePlanUpdateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Plan Visibility Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServicePlanVisibilityCreateEventsExperimentalResponse>> ListServicePlanVisibilityCreateEventsExperimental()
        {
            return await ListServicePlanVisibilityCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServicePlanVisibilityCreateEventsExperimentalResponse>> ListServicePlanVisibilityCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServicePlanVisibilityCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Plan Visibility Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServicePlanVisibilityDeleteEventsExperimentalResponse>> ListServicePlanVisibilityDeleteEventsExperimental()
        {
            return await ListServicePlanVisibilityDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServicePlanVisibilityDeleteEventsExperimentalResponse>> ListServicePlanVisibilityDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServicePlanVisibilityDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Plan Visibility Update Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServicePlanVisibilityUpdateEventsExperimentalResponse>> ListServicePlanVisibilityUpdateEventsExperimental()
        {
            return await ListServicePlanVisibilityUpdateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServicePlanVisibilityUpdateEventsExperimentalResponse>> ListServicePlanVisibilityUpdateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServicePlanVisibilityUpdateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List Service Update Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListServiceUpdateEventsExperimentalResponse>> ListServiceUpdateEventsExperimental()
        {
            return await ListServiceUpdateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListServiceUpdateEventsExperimentalResponse>> ListServiceUpdateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListServiceUpdateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
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
        /// List User Provided Service Instance Create Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListUserProvidedServiceInstanceCreateEventsExperimentalResponse>> ListUserProvidedServiceInstanceCreateEventsExperimental()
        {
            return await ListUserProvidedServiceInstanceCreateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListUserProvidedServiceInstanceCreateEventsExperimentalResponse>> ListUserProvidedServiceInstanceCreateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListUserProvidedServiceInstanceCreateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List User Provided Service Instance Delete Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListUserProvidedServiceInstanceDeleteEventsExperimentalResponse>> ListUserProvidedServiceInstanceDeleteEventsExperimental()
        {
            return await ListUserProvidedServiceInstanceDeleteEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListUserProvidedServiceInstanceDeleteEventsExperimentalResponse>> ListUserProvidedServiceInstanceDeleteEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListUserProvidedServiceInstanceDeleteEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List User Provided Service Instance Update Events (experimental)
        /// </summary>
    
        
        public async Task<PagedResponse<ListUserProvidedServiceInstanceUpdateEventsExperimentalResponse>> ListUserProvidedServiceInstanceUpdateEventsExperimental()
        {
            return await ListUserProvidedServiceInstanceUpdateEventsExperimental(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListUserProvidedServiceInstanceUpdateEventsExperimentalResponse>> ListUserProvidedServiceInstanceUpdateEventsExperimental(RequestOptions options)
    
        {
            string route = "/v2/events";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListUserProvidedServiceInstanceUpdateEventsExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Event
        /// </summary>
    
        
    

    
        public async Task<RetrieveEventResponse> RetrieveEvent(Guid guid)
    
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
    
    }
}