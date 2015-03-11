namespace CloudFoundry.CloudController.V2
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.DependencyLocation;
    using CloudFoundry.CloudController.Common.Exceptions;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.V2.Interfaces;
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
            return new KeyValuePair<string, string>("Authorization", "bearer " + autorizationToken);
        }

        internal IHttpAbstractionClient GetHttpClient()
        {
            return this.Client.DependencyLocator.Locate<IHttpAbstractionClientFactory>().Create(this.Client.CancellationToken);
        }

        internal async Task<IHttpResponseAbstraction> SendAsync(IHttpAbstractionClient client, int expectedReturnStatus)
        {
            var result = await client.SendAsync();

            if (((int)result.StatusCode) != expectedReturnStatus)
            {
                // Check if we can deserialize the response
                CloudFoundryException cloudFoundryException;
                try
                {
                    string response = await result.Content.ReadAsStringAsync();
                    var exceptionObject = Utilities.DeserializeJson<CloudFoundryExceptionObject>(response);
                    cloudFoundryException = new CloudFoundryException(exceptionObject);
                    cloudFoundryException.Response = result;
                }
                catch
                {
                    cloudFoundryException = new CloudFoundryException(string.Format("An error occurred while sending the request {0},  {1}", result.RequestMessage, result.StatusCode));
                }

                throw cloudFoundryException;
            }

            return result;
        }
    }
}