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
    public partial class ServiceUsageEventsExperimentalEndpoint : CloudFoundry.CloudController.V2.Client.Base.AbstractServiceUsageEventsExperimentalEndpoint
    {
        public ServiceUsageEventsExperimentalEndpoint(CloudFoundryClient client) : base()
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
    public abstract class AbstractServiceUsageEventsExperimentalEndpoint : BaseEndpoint
    {

        /// <summary>
        /// List Service Usage Events
        /// </summary>
        /// Events are sorted by internal database IDs. This order may differ from created_at.
        /// 
        /// Events close to the current time should not be processed because other events may still have open
        /// transactions that will change their order in the results.
        public async Task<PagedResponseCollection<ListServiceUsageEventsResponse>> ListServiceUsageEvents()
        {
            return await ListServiceUsageEvents(new RequestOptions());
        }

        public async Task<PagedResponseCollection<ListServiceUsageEventsResponse>> ListServiceUsageEvents(RequestOptions options)
        {
            string route = "/v2/service_usage_events";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route + options.ToString();
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializePage<ListServiceUsageEventsResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Purge and reseed Service Usage Events
        /// </summary>
        /// Destroys all existing events. Populates new usage events, one for each existing service instance.
        /// All populated events will have a created_at value of current time.
        /// 
        /// There is the potential race condition if service instances are currently being created or deleted.
        /// 
        /// The seeded usage events will have the same guid as the service instance.
        public async Task PurgeAndReseedServiceUsageEvents()
        {
            string route = "/v2/service_usage_events/destructively_purge_all_and_reseed_existing_instances";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Post;
            client.Headers.Add(await BuildAuthenticationHeader());
            client.ContentType = "application/x-www-form-urlencoded";
            var expectedReturnStatus = 204;
            var response = await this.SendAsync(client, expectedReturnStatus);
        }

        /// <summary>
        /// Retrieve a Particular Service Usage Event
        /// </summary>
        public async Task<RetrieveServiceUsageEventResponse> RetrieveServiceUsageEvent(Guid? guid)
        {
            string route = string.Format("/v2/service_usage_events/{0}", guid);
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<RetrieveServiceUsageEventResponse>(await response.ReadContentAsStringAsync());
        }
    }
}