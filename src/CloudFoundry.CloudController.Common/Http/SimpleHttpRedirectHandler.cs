namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Http handler that manages HTTP redirects
    /// </summary>
    public class SimpleHttpRedirectHandler : PlatformBaseHttpClientHandler
    {
        private int maxRedirects = 5;

        /// <inheritdoc/>
        public SimpleHttpRedirectHandler()
        {
            this.AllowAutoRedirect = false;
        }

        /// <summary>
        /// Gets or sets the maximum HTTP redirects the client will follow
        /// </summary>
        public int MaxRedirects
        {
            get
            {
                return this.maxRedirects;
            }

            set
            {
                this.maxRedirects = value;
            }
        }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            for (int i = 0; i < this.maxRedirects; i++)
            {
                response = await base.SendAsync(request, cancellationToken);

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Moved:
                    case System.Net.HttpStatusCode.Redirect:
                    case System.Net.HttpStatusCode.RedirectMethod:
                    case System.Net.HttpStatusCode.TemporaryRedirect:
                        {
                            request.RequestUri = new System.Uri(response.Headers.GetValues("Location").First());
                        }

                        break;

                    default:
                        return response;
                }
            }

            return response;
        }
    }
}
