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
    public class AppsEndpoint: BaseEndpoint
    {
        public AppsEndpoint(CloudfoundryClient client)
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.ServiceLocator = client.ServiceLocator;
            this.auth = client.auth;
        }
    
        /// <summary>
        /// Updating an App
        /// </summary>
    

    
        public async Task<UpdateAppResponse> UpdateApp(Guid? guid, UpdateAppRequest value)
    
        {
            string route = string.Format("/v2/apps/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UpdateAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Routes for the App
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllRoutesForAppResponse>> ListAllRoutesForApp(Guid? guid)
        {
            return await ListAllRoutesForApp(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllRoutesForAppResponse>> ListAllRoutesForApp(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/apps/{0}/routes", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllRoutesForAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Creating a Docker App (experimental)
        /// </summary>
    

    
        public async Task<CreateDockerAppExperimentalResponse> CreateDockerAppExperimental(CreateDockerAppExperimentalRequest value)
    
        {
            string route = "/v2/apps/";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CreateDockerAppExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Get the env for an App
        /// </summary>
        /// Get the environment variables for an App using the app guid. Restricted to SpaceDeveloper role.
    
        
    

    
        public async Task<GetEnvForAppResponse> GetEnvForApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}/env", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<GetEnvForAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// List all Service Bindings for the App
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllServiceBindingsForAppResponse>> ListAllServiceBindingsForApp(Guid? guid)
        {
            return await ListAllServiceBindingsForApp(guid, new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllServiceBindingsForAppResponse>> ListAllServiceBindingsForApp(Guid? guid, RequestOptions options)
    
        {
            string route = string.Format("/v2/apps/{0}/service_bindings", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllServiceBindingsForAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Delete a Particular App
        /// </summary>
    

    
        public async Task DeleteApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}", guid);
        
            
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
        /// Associate Route with the App
        /// </summary>
    

    
        public async Task<AssociateRouteWithAppResponse> AssociateRouteWithApp(Guid? guid, Guid? route_guid)
    
        {
            string route = string.Format("/v2/apps/{0}/routes/{1}", guid, route_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<AssociateRouteWithAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Get App summary
        /// </summary>
    
        
    

    
        public async Task<GetAppSummaryResponse> GetAppSummary(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}/summary", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<GetAppSummaryResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Get the instance information for a STARTED App
        /// </summary>
        /// Get status for each instance of an App using the app guid.
    
        
    

    
        public async Task<Dictionary<int?, GetInstanceInformationForStartedAppResponse>> GetInstanceInformationForStartedApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}/instances", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<Dictionary<int?, GetInstanceInformationForStartedAppResponse>>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Creating an App
        /// </summary>
    

    
        public async Task<CreateAppResponse> CreateApp(CreateAppRequest value)
    
        {
            string route = "/v2/apps/";
        
            
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
        /// Remove Route from the App
        /// </summary>
    

    
        public async Task<RemoveRouteFromAppResponse> RemoveRouteFromApp(Guid? guid, Guid? route_guid)
    
        {
            string route = string.Format("/v2/apps/{0}/routes/{1}", guid, route_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveRouteFromAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Downloads the bits for an App
        /// </summary>
        /// When using a remote blobstore, such as AWS, the response is a redirect to the actual location of the bits.
    
        
    

    
        public async Task DownloadsBitsForApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}/download", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
        }
    
        /// <summary>
        /// List all Apps
        /// </summary>
    
        
        public async Task<PagedResponse<ListAllAppsResponse>> ListAllApps()
        {
            return await ListAllApps(new RequestOptions());
        }
        
    

    
        public async Task<PagedResponse<ListAllAppsResponse>> ListAllApps(RequestOptions options)
    
        {
            string route = "/v2/apps";
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializePage<ListAllAppsResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Uploads the bits for an App
        /// </summary>
        /// Defines and uploads the bits (artifacts and dependencies) that this application needs to run, using a multipart PUT request.
        /// Bits that have already been uploaded can be referenced by their resource fingerprint(s).
        /// Bits that have not already been uploaded to Cloud Foundry must be included as a zipped binary file named "application".
    

    
        public async Task<UploadsBitsForAppResponse> UploadsBitsForApp(Guid? guid, dynamic value)
    
        {
            string route = string.Format("/v2/apps/{0}/bits", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Put;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "multipart/form-data; boundary=AaB03x";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<UploadsBitsForAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Restage an App
        /// </summary>
    

    
        public async Task<RestageAppResponse> RestageApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}/restage", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RestageAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Get detailed stats for a STARTED App
        /// </summary>
        /// Get status for each instance of an App using the app guid.
    
        
    

    
        public async Task<Dictionary<int?, GetDetailedStatsForStartedAppResponse>> GetDetailedStatsForStartedApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}/stats", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<Dictionary<int?, GetDetailedStatsForStartedAppResponse>>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Terminate the running App Instance at the given index
        /// </summary>
    

    
        public async Task TerminateRunningAppInstanceAtGivenIndex(Guid? guid, int? index)
    
        {
            string route = string.Format("/v2/apps/{0}/instances/{1}", guid, index);
        
            
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
        /// Retrieve a Particular App
        /// </summary>
    
        
    

    
        public async Task<RetrieveAppResponse> RetrieveApp(Guid? guid)
    
        {
            string route = string.Format("/v2/apps/{0}", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RetrieveAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Copy the app bits for an App (Experimental)
        /// </summary>
        /// This endpoint will copy the package bits in the blobstore from the source app to the destination app.
        /// It will always return a job which you can query for success or failure.
        /// This operation will require the app to restart in order for the changes to take effect.
    

    
        public async Task<CopyAppBitsForAppExperimentalResponse> CopyAppBitsForAppExperimental(Guid? guid, CopyAppBitsForAppExperimentalRequest value)
    
        {
            string route = string.Format("/v2/apps/{0}/copy_bits", guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Post;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<CopyAppBitsForAppExperimentalResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
        /// <summary>
        /// Remove Service Binding from the App
        /// </summary>
    

    
        public async Task<RemoveServiceBindingFromAppResponse> RemoveServiceBindingFromApp(Guid? guid, Guid? service_binding_guid)
    
        {
            string route = string.Format("/v2/apps/{0}/service_bindings/{1}", guid, service_binding_guid);
        
            
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);

            client.Method = HttpMethod.Delete;
            client.Headers.Add(BuildAuthenticationHeader());
        
            client.ContentType = "application/x-www-form-urlencoded";
        
        
            // TODO: vladi: Implement serialization

            var response = await client.SendAsync();
        
            
            return Util.DeserializeJson<RemoveServiceBindingFromAppResponse>(await response.ReadContentAsStringAsync());
            
        
        }
    
    }
}