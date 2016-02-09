namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Exceptions;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.Common.PushTools;
    using CloudFoundry.CloudController.V2.Client.Data;
    using Newtonsoft.Json;

    public partial class ServiceInstancesEndpoint
    {
        /// <summary>
        /// Delete a Service Instance
        /// <para>For detailed information, see online documentation at: "http://apidocs.cloudfoundry.org/205/service_instances/delete_a_service_instance.html"</para>
        /// </summary>
        public async new Task<DeleteServiceInstanceResponse> DeleteServiceInstance(Guid? guid)
        {
            return await this.DeleteServiceInstance(guid, false);
        }

        /// <summary>
        /// Delete a Service Instance
        /// <para>For detailed information, see online documentation at: "http://apidocs.cloudfoundry.org/205/service_instances/delete_a_service_instance.html"</para>
        /// </summary>
        public async Task<DeleteServiceInstanceResponse> DeleteServiceInstance(Guid? guid, bool acceptsIncomplete)
        {
            UriBuilder uriBuilder = new UriBuilder(this.Client.CloudTarget);
            uriBuilder.Path = string.Format(CultureInfo.InvariantCulture, "/v2/service_instances/{0}", guid);
            uriBuilder.Query = string.Format(CultureInfo.InvariantCulture, "accepts_incomplete={0}", acceptsIncomplete.ToString().ToLowerInvariant());

            var client = this.GetHttpClient();
            client.Uri = uriBuilder.Uri;
            client.Method = HttpMethod.Delete;
            var authHeader = await BuildAuthenticationHeader();
            if (!string.IsNullOrWhiteSpace(authHeader.Key))
            {
                client.Headers.Add(authHeader);
            }

            client.ContentType = "application/x-www-form-urlencoded";
            int[] expectedReturnStatus = new int[] { 202, 204 };
            var response = await this.SendAsync(client, expectedReturnStatus);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return Utilities.DeserializeJson<DeleteServiceInstanceResponse>(await response.ReadContentAsStringAsync());
            }
            else
            {
                return await Task.FromResult<DeleteServiceInstanceResponse>(null);
            }
        }
    }
}
