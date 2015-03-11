namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Threading;

    /// <summary>
    /// This is the http abstraction client factory.
    /// </summary>
    public interface IHttpAbstractionClientFactory
    {
        /// <summary>
        /// Creates a http abstraction client instance.
        /// </summary>
        /// <returns>Abstraction client instance.</returns>
        IHttpAbstractionClient Create();

        /// <summary>
        /// Creates a http abstraction client instance with a specified CancellationToken.
        /// </summary>
        /// <param name="token">The cancelation token.</param>
        /// <returns>Abstraction client instance.</returns>
        IHttpAbstractionClient Create(CancellationToken token);

        /// <summary>
        /// Creates a http abstraction client instance with a specified http timeout.
        /// </summary>
        /// <param name="timeout">The http timeout.</param>
        /// <returns>Abstraction client instance.</returns>
        IHttpAbstractionClient Create(TimeSpan timeout);

        /// <summary>
        /// Creates a http abstraction client instance with a specified http timeout and CancellationToken.
        /// </summary>
        /// <param name="timeout">The http timeout.</param>
        /// <param name="token">The cancelation token.</param>
        /// <returns>Abstraction client instance.</returns>
        IHttpAbstractionClient Create(TimeSpan timeout, CancellationToken token);
    }
}