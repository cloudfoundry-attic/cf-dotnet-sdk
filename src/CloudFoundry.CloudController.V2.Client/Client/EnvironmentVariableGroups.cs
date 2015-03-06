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
    public partial class EnvironmentVariableGroupsEndpoint : CloudFoundry.CloudController.V2.Client.Base.AbstractEnvironmentVariableGroupsEndpoint
    {
        public EnvironmentVariableGroupsEndpoint(CloudFoundryClient client) : base()
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
    public abstract class AbstractEnvironmentVariableGroupsEndpoint : BaseEndpoint
    {

        /// <summary>
        /// Getting the contents of the running environment variable group
        /// </summary>
        /// returns the set of default environment variables available to running apps
        public async Task<GettingContentsOfRunningEnvironmentVariableGroupResponse> GettingContentsOfRunningEnvironmentVariableGroup()
        {
            string route = "/v2/config/environment_variable_groups/running";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<GettingContentsOfRunningEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Getting the contents of the staging environment variable group
        /// </summary>
        /// returns the set of default environment variables available during staging
        public async Task<GettingContentsOfStagingEnvironmentVariableGroupResponse> GettingContentsOfStagingEnvironmentVariableGroup()
        {
            string route = "/v2/config/environment_variable_groups/staging";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<GettingContentsOfStagingEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Updating the contents of the staging environment variable group
        /// </summary>
        /// Updates the set of environment variables which will be made available during staging
        public async Task<UpdateContentsOfStagingEnvironmentVariableGroupResponse> UpdateContentsOfStagingEnvironmentVariableGroup(UpdateContentsOfStagingEnvironmentVariableGroupRequest value)
        {
            string route = "/v2/config/environment_variable_groups/staging";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Put;
            client.Headers.Add(await BuildAuthenticationHeader());
            client.ContentType = "application/x-www-form-urlencoded";
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<UpdateContentsOfStagingEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
        }

        /// <summary>
        /// Updating the contents of the running environment variable group
        /// </summary>
        /// Updates the set of environment variables which will be made available to all running apps
        public async Task<UpdateContentsOfRunningEnvironmentVariableGroupResponse> UpdateContentsOfRunningEnvironmentVariableGroup(UpdateContentsOfRunningEnvironmentVariableGroupRequest value)
        {
            string route = "/v2/config/environment_variable_groups/running";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Put;
            client.Headers.Add(await BuildAuthenticationHeader());
            client.ContentType = "application/x-www-form-urlencoded";
            client.Content = JsonConvert.SerializeObject(value).ConvertToStream();
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<UpdateContentsOfRunningEnvironmentVariableGroupResponse>(await response.ReadContentAsStringAsync());
        }
    }
}