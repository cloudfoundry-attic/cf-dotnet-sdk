namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.V2.Client.Data;

    public partial class InfoEndpoint
    {
        /// <summary>
        /// Get v1 Info
        /// </summary>
        public async Task<GetV1InfoResponse> GetV1Info()
        {
            string route = "/info";
            string endpoint = this.CloudTarget.ToString().TrimEnd('/') + route;
            var client = this.GetHttpClient();
            client.Uri = new Uri(endpoint);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(client, expectedReturnStatus);
            return Utilities.DeserializeJson<GetV1InfoResponse>(await response.ReadContentAsStringAsync());
        }
    }
}