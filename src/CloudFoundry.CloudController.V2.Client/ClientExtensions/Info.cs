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
            string endpoint = this.Client.CloudTarget.ToString().TrimEnd('/') + route;
            var httpClient = this.GetHttpClient();
            httpClient.Uri = new Uri(endpoint);
            httpClient.Method = HttpMethod.Get;
            httpClient.Headers.Add(await BuildAuthenticationHeader());
            var expectedReturnStatus = 200;
            var response = await this.SendAsync(httpClient, expectedReturnStatus);
            return Utilities.DeserializeJson<GetV1InfoResponse>(await response.ReadContentAsStringAsync());
        }
    }
}