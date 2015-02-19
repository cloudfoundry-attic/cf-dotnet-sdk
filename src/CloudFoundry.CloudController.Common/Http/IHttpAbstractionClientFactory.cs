using System;
using System.Threading;

namespace CloudFoundry.CloudController.Common.Http
{
    public interface IHttpAbstractionClientFactory
    {
        IHttpAbstractionClient Create();

        IHttpAbstractionClient Create(CancellationToken token);

        IHttpAbstractionClient Create(TimeSpan timeout);

        IHttpAbstractionClient Create(TimeSpan timeout, CancellationToken token);
    }
}
