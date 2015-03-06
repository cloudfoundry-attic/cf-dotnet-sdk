namespace CloudFoundry.UAA.Authentication
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using CloudFoundry.UAA;
    using CloudFoundry.UAA.Authentication;
    using CloudFoundry.UAA.Exceptions;
    using Thinktecture.IdentityModel.Client;

    internal class ThinkTectureAuth : IAuthentication
    {
        // CF defaults
        private string oauthClient = "cf";

        private string oauthSecret = string.Empty;
        private Uri oauthTarget;
        private Token token = new Token();

        internal ThinkTectureAuth(Uri authenticationUri)
        {
            this.oauthTarget = authenticationUri;
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

            var client = new OAuth2Client(this.oauthTarget, this.oauthClient, this.oauthSecret);

            this.token.Expires = DateTime.Now;

            var tokenResponse = await client.RequestResourceOwnerPasswordAsync(credentials.User, credentials.Password);

            if (tokenResponse.IsHttpError)
            {
                throw new AuthenticationException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "Unable to connect to target. HTTPError: {0}. HTTPErrorCode",
                    tokenResponse.HttpErrorReason,
                    tokenResponse.HttpErrorStatusCode));
            }

            if (tokenResponse.IsError)
            {
                throw new AuthenticationException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "Unable to connect to target with the provided credentials. Error message: {0}",
                    tokenResponse.Error,
                    tokenResponse.HttpErrorReason));
            }

            this.token.AccessToken = tokenResponse.AccessToken;
            this.token.RefreshToken = tokenResponse.RefreshToken;
            this.token.Expires = this.token.Expires.AddSeconds(tokenResponse.ExpiresIn);

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

        private async Task<TokenResponse> RefreshToken(string refreshToken)
        {
            var client = new OAuth2Client(this.oauthTarget, this.oauthClient, this.oauthSecret);
            var response = await client.RequestRefreshTokenAsync(refreshToken);
            return response;
        }
    }
}