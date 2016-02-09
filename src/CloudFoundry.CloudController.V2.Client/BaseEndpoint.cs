namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Exceptions;
    using CloudFoundry.CloudController.Common.Http;
    
    using CloudFoundry.UAA;

    /// <summary>
    /// Base class for all the Cloud Foundry endpoints.
    /// </summary>
    public class BaseEndpoint
    {
        internal CloudFoundryClient Client { get; set; }

        internal async Task<KeyValuePair<string, string>> BuildAuthenticationHeader()
        {
            string autorizationToken = await this.Client.GenerateAuthorizationToken();
            if (string.IsNullOrWhiteSpace(autorizationToken))
            {
                return new KeyValuePair<string, string>();
            }
            else
            {
                return new KeyValuePair<string, string>("Authorization", string.Format(CultureInfo.InvariantCulture, "bearer {0}", autorizationToken));
            }
        }

        internal SimpleHttpClient GetHttpClient()
        {
            var httpClient = new SimpleHttpClient(this.Client.CancellationToken, this.Client.RequestTimeout);

            try
            {
                httpClient.HttpProxy = this.Client.HttpProxy;
                httpClient.SkipCertificateValidation = this.Client.SkipCertificateValidation;
            }
            catch
            {
                httpClient.Dispose();
                throw;
            }

            return httpClient;
        }

        internal async Task<SimpleHttpResponse> SendAsync(SimpleHttpClient client, int expectedReturnStatus)
        {
            int[] codes = new int[] { expectedReturnStatus };
            return await this.SendAsync(client, codes);
        }

        internal async Task<SimpleHttpResponse> SendAsync(SimpleHttpClient client, int[] expectedReturnStatus)
        {
            var result = await client.SendAsync();

            bool success = false;
            foreach (int code in expectedReturnStatus)
            {
                if (((int)result.StatusCode) == code)
                {
                    success = true;
                    break;
                }
            }
            
            if (!success && !this.Client.UseStrictStatusCodeChecking)
            {
                success = IsSuccessStatusCode(result.StatusCode);
            }

            if (!success)
            {
                // Check if we can deserialize the response
                CloudFoundryException cloudFoundryException;
                try
                {
                    string response = await result.Content.ReadAsStringAsync();
                    var exceptionObject = Utilities.DeserializeJson<CloudFoundryExceptionObject>(response);
                    cloudFoundryException = new CloudFoundryException(exceptionObject);
                    cloudFoundryException.Response = result;
                    throw cloudFoundryException;
                }
                catch (CloudFoundryException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new CloudFoundryException(string.Format(CultureInfo.InvariantCulture, "An error occurred while talking to the server ({0})", result.StatusCode), ex);
                }
            }

            return result;
        }

        private static bool IsSuccessStatusCode(HttpStatusCode statusCode)
        {
            return statusCode >= HttpStatusCode.OK && statusCode < HttpStatusCode.MultipleChoices;
        }
    }
}