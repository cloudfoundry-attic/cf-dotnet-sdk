namespace CloudFoundry.UAA.Authentication
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.UAA;
    using CloudFoundry.UAA.Exceptions;
    using Thinktecture.IdentityModel.Client;

    internal class ThinkTectureAuth : IAuthentication
    {
        // CF defaults
        private string oauthClient = "cf";

        private string oauthSecret = string.Empty;
        private Uri oauthTarget;
        private Uri httpProxy;
        private bool skipCertificateValidation;
        private Token token = new Token();

        internal ThinkTectureAuth(Uri authenticationUri)
            : this(authenticationUri, null)
        {
        }

        internal ThinkTectureAuth(Uri authenticationUri, Uri httpProxy)
            : this(authenticationUri, httpProxy, false)
        {
        }

        internal ThinkTectureAuth(Uri authenticationUri, Uri httpProxy, bool skipCertificateValidation)
        {
            this.oauthTarget = authenticationUri;
            this.httpProxy = httpProxy;
            this.skipCertificateValidation = skipCertificateValidation;
        }

        public Uri OAuthUri
        {
            get
            {
                return this.oauthTarget;
            }
        }

        public async Task<Token> Authenticate(CloudCredentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            using (var httpClientHandler = new AcceptHeaderOverrideHttpClientHandler())
            {
                if (this.httpProxy != null)
                {
                    httpClientHandler.Proxy = new SimpleProxy(this.httpProxy);
                }

                httpClientHandler.OverrideAcceptHeader = "application/json";
                httpClientHandler.SkipCertificateValidation = this.skipCertificateValidation;

                var client = new OAuth2Client(this.oauthTarget, this.oauthClient, this.oauthSecret, httpClientHandler);

                this.token.Expires = DateTime.Now;

                var tokenResponse = await client.RequestResourceOwnerPasswordAsync(credentials.User, credentials.Password);

                CheckTokenResponseError(tokenResponse);

                this.token.AccessToken = tokenResponse.AccessToken;
                this.token.RefreshToken = tokenResponse.RefreshToken;
                this.token.Expires = this.token.Expires.AddSeconds(tokenResponse.ExpiresIn);
            }

            return this.token;
        }

        public async Task<Token> Authenticate(string refreshToken)
        {
            this.token.Expires = DateTime.Now;
            var tokenResponse = await this.RefreshToken(refreshToken);
            this.token.Expires = this.token.Expires.AddSeconds(tokenResponse.ExpiresIn);
            this.token.AccessToken = tokenResponse.AccessToken;
            this.token.RefreshToken = tokenResponse.RefreshToken;

            return this.token;
        }

        public async Task<Token> GetToken()
        {
            if (this.token == null)
            {
                return this.token;
            }

            // Check to see if token is about to expire
            if (this.token.Expires < DateTime.Now)
            {
                this.token.Expires = DateTime.Now;
                var tokenResponse = await this.RefreshToken(this.token.RefreshToken);

                this.token.AccessToken = tokenResponse.AccessToken;
                this.token.RefreshToken = tokenResponse.RefreshToken;
                this.token.Expires = this.token.Expires.AddSeconds(tokenResponse.ExpiresIn);
            }

            return this.token;
        }

        private static void CheckTokenResponseError(TokenResponse tokenResponse)
        {
            if (tokenResponse.IsHttpError)
            {
                throw new AuthenticationException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "Unable to connect to target. HTTP Error: {0}. HTTP Error Code {1}",
                    tokenResponse.HttpErrorReason,
                    tokenResponse.HttpErrorStatusCode));
            }

            if (tokenResponse.IsError)
            {
                throw new AuthenticationException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "Unable to connect to target. Error message: {0}",
                    tokenResponse.Error));
            }
        }

        private async Task<TokenResponse> RefreshToken(string refreshToken)
        {
            using (var httpClientHandler = new AcceptHeaderOverrideHttpClientHandler())
            {
                if (this.httpProxy != null)
                {
                    httpClientHandler.Proxy = new SimpleProxy(this.httpProxy);
                }

                httpClientHandler.OverrideAcceptHeader = "application/json";
                httpClientHandler.SkipCertificateValidation = this.skipCertificateValidation;

                var client = new OAuth2Client(this.oauthTarget, this.oauthClient, this.oauthSecret, httpClientHandler);
                var tokenResponse = await client.RequestRefreshTokenAsync(refreshToken);
                CheckTokenResponseError(tokenResponse);
                return tokenResponse;
            }
        }
    }
}
