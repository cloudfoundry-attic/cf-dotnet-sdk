namespace CloudFoundry.UAA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CloudFoundry.UAA.Authentication;
    using CloudFoundry.UAA.Exceptions;

    /// <summary>
    /// This is the UAA client. To use it, you need a UAA endpoint.
    /// </summary>
    public class UAAClient
    {
        private IAuthentication authentication;
        private AuthenticationContext context = new AuthenticationContext();
        private Uri targetUri = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UAAClient"/> class.
        /// </summary>
        /// <param name="authenticationUri">The authentication URI.</param>
        public UAAClient(Uri authenticationUri)
            : this(authenticationUri, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UAAClient" /> class.
        /// </summary>
        /// <param name="authenticationUri">The authentication URI.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        public UAAClient(Uri authenticationUri, Uri httpProxy)
            : this(authenticationUri, httpProxy, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UAAClient" /> class.
        /// </summary>
        /// <param name="authenticationUri">The authentication URI.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        public UAAClient(Uri authenticationUri, Uri httpProxy, bool skipCertificateValidation)
        {
            this.authentication = new ThinkTectureAuth(authenticationUri, httpProxy, skipCertificateValidation);
            this.targetUri = authenticationUri;
        }

        /// <summary>
        /// Gets the Authentication Context.
        /// </summary>
        /// <value>
        /// The Authentication Context.
        /// </value>
        public AuthenticationContext Context
        {
            get { return this.context; }
        }

        internal IAuthentication Authentication
        {
            set { this.authentication = value; }
        }

        /// <summary>
        /// Logins the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>A refresh token</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public async Task<AuthenticationContext> Login(CloudCredentials credentials)
        {
            var token = await this.authentication.Authenticate(credentials);
            this.context.Token = token;
            this.context.Uri = this.targetUri;
            this.context.IsLoggedIn = true;
            return this.context;
        }

        /// <summary>
        /// Logins the specified refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>A refresh Token</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
           Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public async Task<AuthenticationContext> Login(string refreshToken)
        {
            var token = await this.authentication.Authenticate(refreshToken);
            this.context.Token = token;
            this.context.Uri = this.targetUri;
            this.context.IsLoggedIn = true;
            return this.context;
        }

        /// <summary>
        /// Generates the Authentication Context.
        /// </summary>
        /// <returns>A valid Authentication Context.</returns>
        /// <exception cref="AuthenticationException">Target not logged in, please login first</exception>
        public async Task<AuthenticationContext> GenerateContext()
        {
            if (!this.context.IsLoggedIn)
            {
                throw new AuthenticationException("Target not logged in, please login first");
            }

            var token = await this.authentication.GetToken();
            this.context.Token = token;
            return this.context;
        }
    }
}