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
public class SecurityGroupRunningDefaultsEndpoint: BaseEndpoint
{
public SecurityGroupRunningDefaultsEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// Removing a Security Group as a default for running Apps
  /// </summary>
    public async Task RemovingSecurityGroupAsDefaultForRunningApps(Guid guid)
    {
        string route = string.Format("/v2/config/running_security_groups/{0}", guid);
    
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
  /// Return the Security Groups used for running Apps
  /// </summary>
    public async Task<ReturnSecurityGroupsUsedForRunningAppsResponse[]> ReturnSecurityGroupsUsedForRunningApps()
    {
        string route = "/v2/config/running_security_groups";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ReturnSecurityGroupsUsedForRunningAppsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Set a Security Group as a default for running Apps
  /// </summary>
    public async Task<SetSecurityGroupAsDefaultForRunningAppsResponse> SetSecurityGroupAsDefaultForRunningApps(Guid guid)
    {
        string route = string.Format("/v2/config/running_security_groups/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<SetSecurityGroupAsDefaultForRunningAppsResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}