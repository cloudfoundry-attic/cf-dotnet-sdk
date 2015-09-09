namespace CloudFoundry.CloudController.Common
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;

    /// <summary>
    /// This is an abstract class that serves as base for the CloudFoundry clients.
    /// </summary>
    public abstract class CloudFoundryClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient"/> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken)
            : this(cloudTarget, cancellationToken, null, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        protected CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy)
            : this(cloudTarget, cancellationToken, httpProxy, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        protected CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation)
            : this(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        /// <param name="authorizationUrl">Authorization Endpoint</param>
        protected CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl)
            : this(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, authorizationUrl, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        /// <param name="authorizationUrl">Authorization Endpoint</param>
        /// <param name="useStrictStatusCodeChecking">Throw exception if the successful http status code returned from the server does not match the expected code</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This method is implemented by sealed cf clients")]
        protected CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl, bool useStrictStatusCodeChecking)
            : this(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, authorizationUrl, useStrictStatusCodeChecking, SimpleHttpClient.DefaultTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        /// <param name="authorizationUrl">Authorization Endpoint</param>
        /// <param name="useStrictStatusCodeChecking">Throw exception if the successful http status code returned from the server does not match the expected code</param>
        /// <param name="requestTimeout">Http requests timeout</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This method is implemented by sealed cf clients")]
        protected CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl, bool useStrictStatusCodeChecking, TimeSpan requestTimeout)
        {
            this.CloudTarget = cloudTarget;
            this.CancellationToken = cancellationToken;
            this.HttpProxy = httpProxy;
            this.SkipCertificateValidation = skipCertificateValidation;
            this.AuthorizationEndpoint = authorizationUrl;
            this.UseStrictStatusCodeChecking = useStrictStatusCodeChecking;
            this.RequestTimeout = requestTimeout;

            this.InitEndpoints();
        }
        
        /// <summary>
        /// Authorization Endpoint
        /// </summary>
        public Uri AuthorizationEndpoint { get; protected set; }

        /// <summary>
        /// Cancellation Token
        /// </summary>
        public CancellationToken CancellationToken { get; protected set; }

        /// <summary>
        /// Target
        /// </summary>
        public Uri CloudTarget { get; protected set; }

        /// <summary>
        /// Proxy
        /// </summary>
        public Uri HttpProxy { get; protected set; }

        /// <summary>
        /// Skip Validation
        /// </summary>
        public bool SkipCertificateValidation { get; protected set; }

        /// <summary>
        /// Skip Validation
        /// </summary>
        public bool UseStrictStatusCodeChecking { get; protected set; }

        /// <summary>
        /// Http requests timeout
        /// </summary>
        public TimeSpan RequestTimeout { get; protected set; }

        /// <summary>
        /// Initializes all API Endpoints
        /// </summary>
        public abstract void InitEndpoints();
    }
}