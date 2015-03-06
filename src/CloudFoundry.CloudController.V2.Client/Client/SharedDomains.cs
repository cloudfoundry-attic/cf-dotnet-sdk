//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//
// This source code was auto-generated by cf-sdk-builder
//

using CloudFoundry.CloudController.Common;
using CloudFoundry.CloudController.V2.Client.Data;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace CloudFoundry.CloudController.V2.Client
{
    [GeneratedCodeAttribute("cf-sdk-builder", "1.0.0.0")]
    public partial class SharedDomainsEndpoint : CloudFoundry.CloudController.V2.Client.Base.AbstractSharedDomainsEndpoint
    {
        public SharedDomainsEndpoint(CloudFoundryClient client) : base()
        {
            this.CloudTarget = client.CloudTarget;
            this.CancellationToken = client.CancellationToken;
            this.DependencyLocator = client.DependencyLocator;
            this.UAAClient = client.UAAClient;
        }    
    }
}

namespace CloudFoundry.CloudController.V2.Client.Base
{

    [GeneratedCodeAttribute("cf-sdk-builder", "1.0.0.0")]
    public abstract class AbstractSharedDomainsEndpoint : BaseEndpoint
    {

        /// <summary>
        /// Filtering Shared Domains by name
        /// </summary>
        public async Task<PagedResponseCollection<FilterSharedDomainsByNameResponse>> FilterSharedDomainsByName()
        {
            return await FilterSharedDomainsByName(new RequestOptions());
        }

        public async Task<PagedResponseCollection<FilterSharedDomainsByNameResponse>> FilterSharedDomainsByName(RequestOptions options)
        {
            string route = "/v2/shared_domains";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializePage<FilterSharedDomainsByNameResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Create a Shared Domain
        /// </summary>
        public async Task<CreateSharedDomainResponse> CreateSharedDomain(CreateSharedDomainRequest value)
        {
            string route = "/v2/shared_domains";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Post;
            client.Headers.Add(await BuildAuthenticationHeader());
            client.ContentType = "application/x-www-form-urlencoded";
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
            var expectedReturnStatus = 201;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<CreateSharedDomainResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Delete a Particular Shared Domain
        /// </summary>
        public async Task DeleteSharedDomain(Guid? guid)
        {
            string route = string.Format("/v2/shared_domains/{0}", guid);
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Delete;
            client.Headers.Add(await BuildAuthenticationHeader());
            client.ContentType = "application/x-www-form-urlencoded";
            var expectedReturnStatus = 204;
            var response = await this.SendAsync(client, expectedReturnStatus);
        }

        /// <summary>
        /// List all Shared Domains
        /// </summary>
        public async Task<PagedResponseCollection<ListAllSharedDomainsResponse>> ListAllSharedDomains()
        {
            return await ListAllSharedDomains(new RequestOptions());
        }

        public async Task<PagedResponseCollection<ListAllSharedDomainsResponse>> ListAllSharedDomains(RequestOptions options)
        {
            string route = "/v2/shared_domains";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializePage<ListAllSharedDomainsResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Retrieve a Particular Shared Domain
        /// </summary>
        public async Task<RetrieveSharedDomainResponse> RetrieveSharedDomain(Guid? guid)
        {
            string route = string.Format("/v2/shared_domains/{0}", guid);
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<RetrieveSharedDomainResponse>(await response.ReadContentAsStringAsync());
        }
    }
}