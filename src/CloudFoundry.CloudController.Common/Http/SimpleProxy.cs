namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Net;

    /// <inheritdoc/>
    public class SimpleProxy : IWebProxy
    {
        private readonly Uri proxyUrl;

        /// <inheritdoc/>
        public SimpleProxy(Uri proxyUrl)
        {
            this.proxyUrl = proxyUrl;
        }

        /// <inheritdoc/>
        public ICredentials Credentials
        {
            get;
            set;
        }

        /// <inheritdoc/>
        public Uri GetProxy(Uri destination)
        {
            return this.proxyUrl;
        }

        /// <inheritdoc/>
        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
