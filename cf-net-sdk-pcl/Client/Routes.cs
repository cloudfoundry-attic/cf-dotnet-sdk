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
    public class RoutesEndpoint: BaseEndpoint
    {
        public RoutesEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// List all Apps for the Route
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllAppsForRouteResponse>> ListAllAppsForRoute(Guid? guid)
        {
            return await ListAllAppsForRoute(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllAppsForRouteResponse>> ListAllAppsForRoute(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/routes/{0}/apps", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllAppsForRouteResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Route
        /// </summary>
    
        
    

    
        public async Task<RetrieveRouteResponse> RetrieveRoute(Guid? guid)
    
        {
            string route = string.Format("/v2/routes/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveRouteResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove App from the Route
        /// </summary>
    

    
        public async Task<RemoveAppFromRouteResponse> RemoveAppFromRoute(Guid? guid, Guid? app_guid)
    
        {
            string route = string.Format("/v2/routes/{0}/apps/{1}", guid, app_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveAppFromRouteResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular Route
        /// </summary>
    

    
        public async Task DeleteRoute(Guid? guid)
    
        {
            string route = string.Format("/v2/routes/{0}", guid);
        
            
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
        /// List all Routes
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllRoutesResponse>> ListAllRoutes()
        {
            return await ListAllRoutes(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllRoutesResponse>> ListAllRoutes(RequestOptions options)
    
        {
            string route = "/v2/routes";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllRoutesResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Check a Route exists
        /// </summary>
    
        
    

    
        public async Task CheckRouteExists(Guid? domain_guid, dynamic host)
    
        {
            string route = string.Format("/v2/routes/reserved/domain/{0}/host/{1}", domain_guid, host);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
        /// <summary>
        /// Update a Route
        /// </summary>
    

    
        public async Task<UpdateRouteResponse> UpdateRoute(Guid? guid, UpdateRouteRequest value)
    
        {
            string route = string.Format("/v2/routes/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateRouteResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Creating a Route
        /// </summary>
    

    
        public async Task<CreateRouteResponse> CreateRoute(CreateRouteRequest value)
    
        {
            string route = "/v2/routes/";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateRouteResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Associate App with the Route
        /// </summary>
    

    
        public async Task<AssociateAppWithRouteResponse> AssociateAppWithRoute(Guid? guid, Guid? app_guid)
    
        {
            string route = string.Format("/v2/routes/{0}/apps/{1}", guid, app_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateAppWithRouteResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}