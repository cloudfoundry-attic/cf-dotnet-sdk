namespace CloudFoundry.CloudController.V3.Client
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.UAA;

    /// <summary>
    /// This is the Cloud Foundry client. To use it, you need a Cloud Foundry endpoint.
    /// </summary>
    public sealed class CloudFoundryClient : CloudFoundry.CloudController.Common.CloudFoundryClient, IUAA
    {
                /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient"/> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken)
            : this(cloudTarget, cancellationToken, null, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy)
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
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation) 
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
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl)
            : base(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, authorizationUrl)
        {
        }

        /// <summary>
        /// Gets the apps endpoint.
        /// </summary>
        /// <value>
        /// The apps endpoint.
        /// </value>
        public AppsEndpoint Apps { get; private set; }

        /// <summary>
        /// Gets the app routes endpoint.
        /// </summary>
        /// <value>
        /// The app routes endpoint.
        /// </value>
        public AppRoutesEndpoint AppRoutes { get; private set; }

        /// <summary>
        /// Gets the droplets endpoint.
        /// </summary>
        /// <value>
        /// The droplets endpoint.
        /// </value>
        public DropletsEndpoint Droplets { get; private set; }

        /// <summary>
        /// Gets the packages endpoint.
        /// </summary>
        /// <value>
        /// The packages endpoint.
        /// </value>
        public PackagesEndpoint Packages { get; private set; }

        /// <summary>
        /// Gets the processes endpoint.
        /// </summary>
        /// <value>
        /// The processes endpoint.
        /// </value>
        public ProcessesEndpoint Processes { get; private set; }

        /// <summary>
        /// Gets the authorization token. It returns empty string if the client is not authorized. Also this method does not verify if the current token is expired.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        public string AuthorizationToken
        {
            get
            {
                if (this.UAAClient == null)
                {
                    return string.Empty;
                }

                return this.UAAClient.Context.Token.AccessToken;
            }
        }

        /// <inheritdoc />
        public UAAClient UAAClient { get; private set; }

        /// <summary>
        /// Login using the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Refresh Token</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public async Task<AuthenticationContext> Login(CloudCredentials credentials)
        {
            if (this.AuthorizationEndpoint == null)
            {
                throw new ArgumentNullException("AuthorizationEndpoint");
            }

            var authUrl = new Uri(AuthorizationEndpoint.ToString().TrimEnd('/') + "/oauth/token");
            this.UAAClient = new UAAClient(authUrl, this.HttpProxy, this.SkipCertificateValidation);

            var context = await this.UAAClient.Login(credentials);

            return context;
        }

        /// <summary>
        /// Gets the authorization token. If the client is not authorized, an empty string is returned. If the token is expired, it generates a new one.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        public async Task<string> GenerateAuthorizationToken()
        {
            if (this.UAAClient == null)
            {
                return string.Empty;
            }

            if (this.UAAClient.Context.Token.IsExpired)
            {
                var context = await this.UAAClient.GenerateContext();
            }

            return this.UAAClient.Context.Token.AccessToken;
        }

        /// <summary>
        /// Login using the specified raw token.
        /// </summary>
        /// <param name="refreshToken">A raw token.</param>
        /// <returns>Token Object</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public async Task<AuthenticationContext> Login(string refreshToken)
        {
            if (this.AuthorizationEndpoint == null)
            {
                throw new ArgumentNullException("AuthorizationEndpoint");
            }

            var authUrl = new Uri(AuthorizationEndpoint.ToString().TrimEnd('/') + "/oauth/token");
            this.UAAClient = new UAAClient(authUrl, this.HttpProxy, this.SkipCertificateValidation);

            var context = await this.UAAClient.Login(refreshToken);

            return context;
        }

        /// <summary>
        /// Initializes all API Endpoints
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling",
            Justification = "Developers using the SDK should find it useful to have a 1-to-1 list of all documented Cloud Foundry endpoints.")]
        public override void InitEndpoints()
        {
            this.Apps = new AppsEndpoint(this);
            this.AppRoutes = new AppRoutesEndpoint(this);
            this.Droplets = new DropletsEndpoint(this);
            this.Packages = new PackagesEndpoint(this);
            this.Processes = new ProcessesEndpoint(this);
        }
    }
}