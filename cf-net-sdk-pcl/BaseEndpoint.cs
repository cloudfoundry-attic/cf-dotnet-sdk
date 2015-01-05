using cf_net_sdk.Interfaces;
using CloudFoundry.Common.Http;
using CloudFoundry.Common.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cf_net_sdk
{
    public class BaseEndpoint
    {        
        internal Uri CloudTarget;
        internal CancellationToken CancellationToken;
        internal IServiceLocator ServiceLocator;
        internal IAuth auth;

        internal IHttpAbstractionClient GetHttpClient()
        {
            return this.ServiceLocator.Locate<IHttpAbstractionClientFactory>().Create(this.CancellationToken);
        }

        internal KeyValuePair<string, string> BuildAuthenticationHeader()
        {
                return new KeyValuePair<string, string>("Authorization", "bearer " + auth.GetToken());
        }
    }
}
