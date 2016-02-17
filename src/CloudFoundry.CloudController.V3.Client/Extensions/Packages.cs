namespace CloudFoundry.CloudController.V3.Client
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
    using CloudFoundry.CloudController.V3.Client.Data;
    using Newtonsoft.Json;

    public partial class PackagesExperimentalEndpoint
    {
        private static readonly TimeSpan DefaultUploadTimeout = new TimeSpan(0, 30, 0);

        /// <summary>
        /// Defines and uploads the package bits.
        /// <remarks>
        /// This method is only available on the .NET 4.5 framework.
        /// Calling this method from a Windows Phone App or a Windows App will throw a <see cref="NotImplementedException" />.
        /// </remarks>
        /// </summary>
        /// <param name="packageGuid">Paclage guid</param>
        /// <param name="zipStream">The zip stream.</param>
        /// <exception cref="CloudFoundryException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UploadBits(Guid packageGuid, Stream zipStream)
        {
            UriBuilder uploadEndpoint = new UriBuilder(this.Client.CloudTarget.AbsoluteUri);
            uploadEndpoint.Path = string.Format(CultureInfo.InvariantCulture, "/v3/packages/{0}/upload", packageGuid.ToString());

            SimpleHttpResponse uploadResult = await this.UploadZip(uploadEndpoint.Uri, zipStream);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var statusCode = uploadResult.StatusCode.ToString("D");

                throw new CloudFoundryException(string.Format(CultureInfo.InvariantCulture, "An error occurred while uploading bits to the server. Status code: {0}", statusCode));
            }
        }

        /// <summary>
        /// Uploads a stream to CloudFoundry via HTTP
        /// </summary>
        /// <param name="uploadUri">Uri to upload to</param>
        /// <param name="zipStream">The compressed stream to upload</param>
        /// <returns></returns>
        private async Task<SimpleHttpResponse> UploadZip(Uri uploadUri, Stream zipStream)
        {
            string boundary = DateTime.Now.Ticks.ToString("x");

            using (SimpleHttpClient httpClient = new SimpleHttpClient(this.Client.CancellationToken, PackagesExperimentalEndpoint.DefaultUploadTimeout))
            {
                // http://apidocs.cloudfoundry.org/212/packages_(experimental)/upload_bits_for_a_package_of_type_bits.html
                httpClient.HttpProxy = Client.HttpProxy;
                httpClient.SkipCertificateValidation = Client.SkipCertificateValidation;

                httpClient.Headers.Add("Authorization", string.Format("bearer {0}", this.Client.AuthorizationToken));

                httpClient.Uri = uploadUri;
                httpClient.Method = HttpMethod.Post;

                List<HttpMultipartFormData> mpd = new List<HttpMultipartFormData>();
                mpd.Add(new HttpMultipartFormData("bits", "application.zip", "application/zip", zipStream));
                SimpleHttpResponse response = await httpClient.SendAsync(mpd);
                return response;
            }
        }
    }
}