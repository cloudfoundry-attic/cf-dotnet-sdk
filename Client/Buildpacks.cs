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
public class BuildpacksEndpoint: BaseEndpoint
{
public BuildpacksEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// Change the position of a Buildpack
  /// </summary>
        /// Buildpacks are maintained in an ordered list.  If the target position is already occupied,
        /// the entries will be shifted down the list to make room.  If the target position is beyond
        /// the end of the current list, the buildpack will be positioned at the end of the list.
    public async Task<ChangePositionOfBuildpackResponse> ChangePositionOfBuildpack(Guid guid, ChangePositionOfBuildpackRequest value)
    {
        string route = string.Format("/v2/buildpacks/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<ChangePositionOfBuildpackResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Creates an admin Buildpack
  /// </summary>
    public async Task<CreatesAdminBuildpackResponse> CreatesAdminBuildpack(CreatesAdminBuildpackRequest value)
    {
        string route = "/v2/buildpacks";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Post;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<CreatesAdminBuildpackResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Delete a Particular Buildpack
  /// </summary>
    public async Task DeleteBuildpack(Guid guid)
    {
        string route = string.Format("/v2/buildpacks/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
    }

    /// <summary>
  /// Enable or disable a Buildpack
  /// </summary>
    public async Task<EnableOrDisableBuildpackResponse> EnableOrDisableBuildpack(Guid guid, EnableOrDisableBuildpackRequest value)
    {
        string route = string.Format("/v2/buildpacks/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<EnableOrDisableBuildpackResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Buildpacks
  /// </summary>
    public async Task<ListAllBuildpacksResponse[]> ListAllBuildpacks()
    {
        string route = "/v2/buildpacks";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllBuildpacksResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Lock or unlock a Buildpack
  /// </summary>
    public async Task<LockOrUnlockBuildpackResponse> LockOrUnlockBuildpack(Guid guid, LockOrUnlockBuildpackRequest value)
    {
        string route = string.Format("/v2/buildpacks/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<LockOrUnlockBuildpackResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular Buildpack
  /// </summary>
    public async Task<RetrieveBuildpackResponse> RetrieveBuildpack(Guid guid)
    {
        string route = string.Format("/v2/buildpacks/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveBuildpackResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Upload the bits for an admin Buildpack
  /// </summary>
        /// PUT not shown because it involves putting a large zip file. Right now only zipped admin buildpacks are accepted
}
}