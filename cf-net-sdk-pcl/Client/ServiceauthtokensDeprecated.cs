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
    public class ServiceauthtokensDeprecatedEndpoint: BaseEndpoint
    {
        public ServiceauthtokensDeprecatedEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Delete a Particular Service Auth Token (deprecated)
        /// </summary>
    

    
        public async Task DeleteServiceAuthTokenDeprecated(Guid guid)
    
        {
            string route = string.Format("/v2/service_auth_tokens/{0}", guid);
        
            
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
        /// Filtering the result set by label (deprecated)
        /// </summary>
    
        
        public async Task<PagedResponse<FilterResultSetByLabelDeprecatedResponse>> FilterResultSetByLabelDeprecated()
        {
            return await FilterResultSetByLabelDeprecated(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<FilterResultSetByLabelDeprecatedResponse>> FilterResultSetByLabelDeprecated(RequestOptions options)
    
        {
            string route = "/v2/service_auth_tokens";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<FilterResultSetByLabelDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Filtering the result set by provider (deprecated)
        /// </summary>
    
        
        public async Task<PagedResponse<FilterResultSetByProviderDeprecatedResponse>> FilterResultSetByProviderDeprecated()
        {
            return await FilterResultSetByProviderDeprecated(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<FilterResultSetByProviderDeprecatedResponse>> FilterResultSetByProviderDeprecated(RequestOptions options)
    
        {
            string route = "/v2/service_auth_tokens";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<FilterResultSetByProviderDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Service Auth Tokens (deprecated)
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServiceAuthTokensDeprecatedResponse>> ListAllServiceAuthTokensDeprecated()
        {
            return await ListAllServiceAuthTokensDeprecated(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServiceAuthTokensDeprecatedResponse>> ListAllServiceAuthTokensDeprecated(RequestOptions options)
    
        {
            string route = "/v2/service_auth_tokens";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServiceAuthTokensDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Retrieve a Particular Service Auth Token (deprecated)
        /// </summary>
    
        
    

    
        public async Task<RetrieveServiceAuthTokenDeprecatedResponse> RetrieveServiceAuthTokenDeprecated(Guid guid)
    
        {
            string route = string.Format("/v2/service_auth_tokens/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveServiceAuthTokenDeprecatedResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}