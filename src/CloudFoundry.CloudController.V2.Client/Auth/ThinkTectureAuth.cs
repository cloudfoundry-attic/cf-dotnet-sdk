namespace CloudFoundry.CloudController.V2.Auth
{
    using System;
    using System.Globalization;
    using CloudFoundry.CloudController.V2.Exceptions;
    using CloudFoundry.CloudController.V2.Interfaces;
    using Thinktecture.IdentityModel.Client;

    internal class ThinkTectureAuth : IAuthentication
    {
        // CF defaults
        private string oauthClient = "cf";

        private string oauthSecret = string.Empty;
        private Uri oauthTarget;
        private TokenResponse tokenResponse;

        public Uri OAuthUrl
        {
            get
            {
                return this.oauthTarget;
            }

            set
            {
                this.oauthTarget = value;
            }
        }

        public string Authenticate(CloudCredentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            var client = new OAuth2Client(this.oauthTarget, this.oauthClient, this.oauthSecret);

            this.tokenResponse = client.RequestResourceOwnerPasswordAsync(credentials.User, credentials.Password).Result;

            if (this.tokenResponse.IsError)
            {
                throw new AuthenticationException(
                    string.Format(
                    CultureInfo.InvariantCulture, 
                    "Unable to connect to target with the provided credentials. Error message: {0}", 
                    this.tokenResponse.Error));
            }

            return this.tokenResponse.RefreshToken;
        }

        public string Authenticate(string refreshToken)
        {
            this.tokenResponse = this.RefreshToken(refreshToken);
            return refreshToken;
        }

        public string GetToken()
        {
            if (this.tokenResponse == null)
            {
                return string.Empty;
            }

            // Check to see if token is about to expire
            if (this.tokenResponse.ExpiresIn < 60)
            {
                this.tokenResponse = this.RefreshToken(this.tokenResponse.RefreshToken);
            }

            return this.tokenResponse.AccessToken;
        }

        private TokenResponse RefreshToken(string refreshToken)
        {
            var client = new OAuth2Client(this.oauthTarget, this.oauthClient, this.oauthSecret);
            var response = client.RequestRefreshTokenAsync(refreshToken).Result;
            return response;
        }
    }
}