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

    public class BaseEndpoint
    {
        internal UAAClient UAAClient { get; set; }

        internal CancellationToken CancellationToken { get; set; }

        internal Uri CloudTarget { get; set; }

        internal IDependencyLocator DependencyLocator { get; set; }

        internal async Task<KeyValuePair<string, string>> BuildAuthenticationHeader()
        {
            ////Not all methods require authentication
            if (this.UAAClient == null)
            {
                return new KeyValuePair<string, string>("Authorization", "bearer ");
            }

            var context = await this.UAAClient.GenerateContext();
            return new KeyValuePair<string, string>("Authorization", "bearer " + context.Token.AccessToken);
        }

        internal IHttpAbstractionClient GetHttpClient()
        {
            return this.DependencyLocator.Locate<IHttpAbstractionClientFactory>().Create(this.CancellationToken);
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