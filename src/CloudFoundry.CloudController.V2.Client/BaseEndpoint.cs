namespace CloudFoundry.CloudController.V2
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.Common.ServiceLocation;
    using CloudFoundry.CloudController.V2.Exceptions;
    using CloudFoundry.CloudController.V2.Interfaces;

    public class BaseEndpoint
    {
        internal IAuthentication Auth { get; set; }

        internal CancellationToken CancellationToken { get; set; }

        internal Uri CloudTarget { get; set; }

        internal IServiceLocator ServiceLocator { get; set; }

        internal KeyValuePair<string, string> BuildAuthenticationHeader()
        {
            return new KeyValuePair<string, string>("Authorization", "bearer " + this.Auth.GetToken());
        }

        internal IHttpAbstractionClient GetHttpClient()
        {
            return this.ServiceLocator.Locate<IHttpAbstractionClientFactory>().Create(this.CancellationToken);
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