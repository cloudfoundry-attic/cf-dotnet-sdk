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
public class UsersEndpoint: BaseEndpoint
{
public UsersEndpoint(CloudfoundryClient client)
{
this.CloudTarget = client.CloudTarget;
this.CancellationToken = client.CancellationToken;
this.ServiceLocator = client.ServiceLocator;
this.auth = client.auth;
}

    /// <summary>
  /// Associate Audited Organization with the User
  /// </summary>
    public async Task<AssociateAuditedOrganizationWithUserResponse> AssociateAuditedOrganizationWithUser(Guid guid, Guid audited_organization_guid)
    {
        string route = string.Format("/v2/users/{0}/audited_organizations/{1}", guid, audited_organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateAuditedOrganizationWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Associate Audited Space with the User
  /// </summary>
    public async Task<AssociateAuditedSpaceWithUserResponse> AssociateAuditedSpaceWithUser(Guid guid, Guid audited_space_guid)
    {
        string route = string.Format("/v2/users/{0}/audited_spaces/{1}", guid, audited_space_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateAuditedSpaceWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Associate Billing Managed Organization with the User
  /// </summary>
    public async Task<AssociateBillingManagedOrganizationWithUserResponse> AssociateBillingManagedOrganizationWithUser(Guid guid, Guid billing_managed_organization_guid)
    {
        string route = string.Format("/v2/users/{0}/billing_managed_organizations/{1}", guid, billing_managed_organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateBillingManagedOrganizationWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Associate Managed Organization with the User
  /// </summary>
    public async Task<AssociateManagedOrganizationWithUserResponse> AssociateManagedOrganizationWithUser(Guid guid, Guid managed_organization_guid)
    {
        string route = string.Format("/v2/users/{0}/managed_organizations/{1}", guid, managed_organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateManagedOrganizationWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Associate Managed Space with the User
  /// </summary>
    public async Task<AssociateManagedSpaceWithUserResponse> AssociateManagedSpaceWithUser(Guid guid, Guid managed_space_guid)
    {
        string route = string.Format("/v2/users/{0}/managed_spaces/{1}", guid, managed_space_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateManagedSpaceWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Associate Organization with the User
  /// </summary>
    public async Task<AssociateOrganizationWithUserResponse> AssociateOrganizationWithUser(Guid guid, Guid organization_guid)
    {
        string route = string.Format("/v2/users/{0}/organizations/{1}", guid, organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateOrganizationWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Associate Space with the User
  /// </summary>
    public async Task<AssociateSpaceWithUserResponse> AssociateSpaceWithUser(Guid guid, Guid space_guid)
    {
        string route = string.Format("/v2/users/{0}/spaces/{1}", guid, space_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<AssociateSpaceWithUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Creating a User
  /// </summary>
    public async Task<CreateUserResponse> CreateUser(CreateUserRequest value)
    {
        string route = "/v2/users/";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Post;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<CreateUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Delete a Particular User
  /// </summary>
    public async Task DeleteUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}", guid);
    
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
  /// Get User summary
  /// </summary>
    public async Task<GetUserSummaryResponse> GetUserSummary(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/summary", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<GetUserSummaryResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Audited Organizations for the User
  /// </summary>
    public async Task<ListAllAuditedOrganizationsForUserResponse[]> ListAllAuditedOrganizationsForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/audited_organizations", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllAuditedOrganizationsForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Audited Spaces for the User
  /// </summary>
    public async Task<ListAllAuditedSpacesForUserResponse[]> ListAllAuditedSpacesForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/audited_spaces", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllAuditedSpacesForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Billing Managed Organizations for the User
  /// </summary>
    public async Task<ListAllBillingManagedOrganizationsForUserResponse[]> ListAllBillingManagedOrganizationsForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/billing_managed_organizations", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllBillingManagedOrganizationsForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Managed Organizations for the User
  /// </summary>
    public async Task<ListAllManagedOrganizationsForUserResponse[]> ListAllManagedOrganizationsForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/managed_organizations", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllManagedOrganizationsForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Managed Spaces for the User
  /// </summary>
    public async Task<ListAllManagedSpacesForUserResponse[]> ListAllManagedSpacesForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/managed_spaces", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllManagedSpacesForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Organizations for the User
  /// </summary>
    public async Task<ListAllOrganizationsForUserResponse[]> ListAllOrganizationsForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/organizations", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllOrganizationsForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Spaces for the User
  /// </summary>
    public async Task<ListAllSpacesForUserResponse[]> ListAllSpacesForUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}/spaces", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllSpacesForUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// List all Users
  /// </summary>
    public async Task<ListAllUsersResponse[]> ListAllUsers()
    {
        string route = "/v2/users";
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJsonArray<ListAllUsersResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Audited Organization from the User
  /// </summary>
    public async Task<RemoveAuditedOrganizationFromUserResponse> RemoveAuditedOrganizationFromUser(Guid guid, Guid audited_organization_guid)
    {
        string route = string.Format("/v2/users/{0}/audited_organizations/{1}", guid, audited_organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveAuditedOrganizationFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Audited Space from the User
  /// </summary>
    public async Task<RemoveAuditedSpaceFromUserResponse> RemoveAuditedSpaceFromUser(Guid guid, Guid audited_space_guid)
    {
        string route = string.Format("/v2/users/{0}/audited_spaces/{1}", guid, audited_space_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveAuditedSpaceFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Billing Managed Organization from the User
  /// </summary>
    public async Task<RemoveBillingManagedOrganizationFromUserResponse> RemoveBillingManagedOrganizationFromUser(Guid guid, Guid billing_managed_organization_guid)
    {
        string route = string.Format("/v2/users/{0}/billing_managed_organizations/{1}", guid, billing_managed_organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveBillingManagedOrganizationFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Managed Organization from the User
  /// </summary>
    public async Task<RemoveManagedOrganizationFromUserResponse> RemoveManagedOrganizationFromUser(Guid guid, Guid managed_organization_guid)
    {
        string route = string.Format("/v2/users/{0}/managed_organizations/{1}", guid, managed_organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveManagedOrganizationFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Managed Space from the User
  /// </summary>
    public async Task<RemoveManagedSpaceFromUserResponse> RemoveManagedSpaceFromUser(Guid guid, Guid managed_space_guid)
    {
        string route = string.Format("/v2/users/{0}/managed_spaces/{1}", guid, managed_space_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveManagedSpaceFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Organization from the User
  /// </summary>
    public async Task<RemoveOrganizationFromUserResponse> RemoveOrganizationFromUser(Guid guid, Guid organization_guid)
    {
        string route = string.Format("/v2/users/{0}/organizations/{1}", guid, organization_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveOrganizationFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Remove Space from the User
  /// </summary>
    public async Task<RemoveSpaceFromUserResponse> RemoveSpaceFromUser(Guid guid, Guid space_guid)
    {
        string route = string.Format("/v2/users/{0}/spaces/{1}", guid, space_guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Delete;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RemoveSpaceFromUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Retrieve a Particular User
  /// </summary>
    public async Task<RetrieveUserResponse> RetrieveUser(Guid guid)
    {
        string route = string.Format("/v2/users/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Get;
    client.Headers.Add(BuildAuthenticationHeader());
    
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<RetrieveUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

    /// <summary>
  /// Updating a User
  /// </summary>
    public async Task<UpdateUserResponse> UpdateUser(Guid guid, UpdateUserRequest value)
    {
        string route = string.Format("/v2/users/{0}", guid);
    
    string endpoint = this.CloudTarget.Value.TrimEnd('/') + route;
    var client = this.GetHttpClient();
    client.Uri = new Uri(endpoint);

    client.Method = HttpMethod.Put;
    client.Headers.Add(BuildAuthenticationHeader());
    
        client.ContentType = "application/x-www-form-urlencoded";
    
    
        client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
    
    // TODO: vladi: Implement serialization

    var response = await client.SendAsync();
    
        
            return Util.DeserializeJson<UpdateUserResponse>(await response.ReadContentAsStringAsync());
        
    
    }

}
}