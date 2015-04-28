namespace CloudFoundry.CloudController.Common.Http
{
    using System.Net.Http;

    /// <inheritdoc/>
    public class PlatformBaseHttpClientHandler : WebRequestHandler, IPlatformBaseHttpClientHandler
    {
        /// <inheritdoc/>
        public bool SkipCertificateValidation
        {
            get
            {
                return this.ServerCertificateValidationCallback != null;
            }

            set
            {
                if (value)
                {
                    this.ServerCertificateValidationCallback = delegate { return true; };
                }
                else
                {
                    this.ServerCertificateValidationCallback = null;
                }
            }
        }
    }
}
