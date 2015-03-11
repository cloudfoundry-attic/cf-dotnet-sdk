namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Threading;
    using CloudFoundry.Common.Http;

    /// <inheritdoc/>
    public class HttpAbstractionClientFactory : IHttpAbstractionClientFactory
    {
        /// <inheritdoc/>
        public IHttpAbstractionClient Create()
        {
            return HttpAbstractionClient.Create();
        }

        /// <inheritdoc/>
        public IHttpAbstractionClient Create(TimeSpan timeout)
        {
            return HttpAbstractionClient.Create(timeout);
        }

        /// <inheritdoc/>
        public IHttpAbstractionClient Create(CancellationToken token)
        {
            return HttpAbstractionClient.Create(token);
        }

        /// <inheritdoc/>
        public IHttpAbstractionClient Create(TimeSpan timeout, CancellationToken token)
        {
            return HttpAbstractionClient.Create(token, timeout);
        }
    }
}