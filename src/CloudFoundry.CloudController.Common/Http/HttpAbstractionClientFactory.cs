using CloudFoundry.Common.Http;
using System;
using System.Threading;

namespace CloudFoundry.CloudController.Common.Http
{
    public class HttpAbstractionClientFactory : IHttpAbstractionClientFactory
    {
        public IHttpAbstractionClient Create()
        {
            return HttpAbstractionClient.Create();
        }

        public IHttpAbstractionClient Create(TimeSpan timeout)
        {
            return HttpAbstractionClient.Create(timeout);
        }

        public IHttpAbstractionClient Create(CancellationToken token)
        {
            return HttpAbstractionClient.Create(token);
        }

        public IHttpAbstractionClient Create(TimeSpan timeout, CancellationToken token)
        {
            return HttpAbstractionClient.Create(token, timeout);
        }
    }
}