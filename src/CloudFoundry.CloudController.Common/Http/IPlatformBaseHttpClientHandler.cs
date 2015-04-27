namespace CloudFoundry.CloudController.Common.Http
{
    /// <summary>
    /// Interface for HttpClient options that may not be supported on all platforms.
    /// </summary>
    internal interface IPlatformBaseHttpClientHandler
    {
        /// <summary>
        /// Gets or sets a value indicating whether the HttpClient should skip TLS certificate validation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the HttpClient should skip TLS certificate validation; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.NotSupportedException">Skipping certificate validation cannot be disabled on this platform.</exception>        
        bool SkipCertificateValidation { get; set; }
    }
}
