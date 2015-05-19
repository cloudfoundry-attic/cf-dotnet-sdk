namespace CloudFoundry.UAA.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;

    internal class AcceptHeaderOverrideHttpClientHandler : PlatformBaseHttpClientHandler
    {
        public string OverrideAcceptHeader { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(this.OverrideAcceptHeader))
            {
                request.Headers.Add("Accept", this.OverrideAcceptHeader);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
