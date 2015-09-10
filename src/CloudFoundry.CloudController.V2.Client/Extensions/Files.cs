namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.V2.Client.Data;
    
    /// <inheritdoc/>
    public partial class FilesEndpoint
    {
        /// <inheritdoc/>
        public async Task<List<RetrieveFileResponse>> RetrieveFile(Guid? app_guid, int? instance_index, string file_path)
        {
            List<RetrieveFileResponse> callResult = new List<RetrieveFileResponse>();

            UriBuilder uriBuilder = new UriBuilder(this.Client.CloudTarget);
            if (string.IsNullOrWhiteSpace(file_path))
            {
                uriBuilder.Path = string.Format(CultureInfo.InvariantCulture, "/v2/apps/{0}/instances/{1}/files", app_guid, instance_index);
            }
            else
            {
                uriBuilder.Path = string.Format(CultureInfo.InvariantCulture, "/v2/apps/{0}/instances/{1}/files/{2}", app_guid, instance_index, file_path);
            }

            using (SimpleHttpClient httpClient = new SimpleHttpClient(this.Client.CancellationToken, new TimeSpan(0, 5, 0)))
            {
                httpClient.SkipCertificateValidation = Client.SkipCertificateValidation;

                var authHeader = await BuildAuthenticationHeader();
                if (!string.IsNullOrWhiteSpace(authHeader.Key))
                {
                    httpClient.Headers.Add(authHeader);
                }

                httpClient.Uri = uriBuilder.Uri;
                httpClient.Method = HttpMethod.Get;

                var response = await httpClient.SendAsync();

                var responseString = await response.Content.ReadAsStringAsync();

                if (!uriBuilder.Path.EndsWith("/") && !uriBuilder.Path.EndsWith("files"))
                {
                    callResult.Add(new RetrieveFileResponse() { FileContent = responseString });
                }
                else
                {
                    string[] instanceContent = responseString.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string info in instanceContent)
                    {
                        if (string.IsNullOrWhiteSpace(info) == false)
                        {
                            string[] nameAndSize = info.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            callResult.Add(new RetrieveFileResponse() { FileName = nameAndSize[0].Trim(), FileSize = nameAndSize[1].Trim() });
                        }
                    }
                }
            }

            return callResult;
        }
    }
}
