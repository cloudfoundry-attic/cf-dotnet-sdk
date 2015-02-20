using CloudFoundry.CloudController.Common.Http;
using CloudFoundry.CloudController.Common.ServiceLocation;
using CloudFoundry.CloudController.V2.Exceptions;
using CloudFoundry.CloudController.V2.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2
{
    public class BaseEndpoint
    {
        internal Uri CloudTarget;
        internal CancellationToken CancellationToken;
        internal IServiceLocator ServiceLocator;
        internal IAuthentication auth;

        internal IHttpAbstractionClient GetHttpClient()
        {
            return this.ServiceLocator.Locate<IHttpAbstractionClientFactory>().Create(this.CancellationToken);
        }

        internal KeyValuePair<string, string> BuildAuthenticationHeader()
        {
            return new KeyValuePair<string, string>("Authorization", "bearer " + this.auth.GetToken());
        }

        internal async Task<IHttpResponseAbstraction> SendAsync(IHttpAbstractionClient client)
        {
            var result = await client.SendAsync();

            if (!result.IsSuccessStatusCode)
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