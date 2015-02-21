namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Threading;

    public interface IHttpAbstractionClientFactory
    {
        IHttpAbstractionClient Create();

        IHttpAbstractionClient Create(CancellationToken token);

        IHttpAbstractionClient Create(TimeSpan timeout);

        IHttpAbstractionClient Create(TimeSpan timeout, CancellationToken token);
    }
}