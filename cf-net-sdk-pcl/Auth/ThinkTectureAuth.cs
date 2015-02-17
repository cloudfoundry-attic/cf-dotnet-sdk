using CloudFoundry.CloudController.V2.Exceptions;
using CloudFoundry.CloudController.V2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace CloudFoundry.CloudController.V2.Auth
{
    class ThinkTectureAuth: IAuth
    {

        //CF defaults
        private string oauthClient = "cf";
        private string oauthSecret = "";
        private Uri oauthTarget;
        private TokenResponse tokenResponse;


        public string Authenticate(CloudCredentials credentials)
        {
            var client = new OAuth2Client(this.oauthTarget, oauthClient, oauthSecret);

            this.tokenResponse = client.RequestResourceOwnerPasswordAsync(credentials.User, credentials.Password).Result;

            if (this.tokenResponse.IsError)
                throw new AuthException(string.Format("Unable to connect to target with the provided credentials. Error message: {0}", this.tokenResponse.Error));

            return tokenResponse.RefreshToken;
        }

        public string Authenticate(string refreshToken)
        {
            this.tokenResponse = RefreshToken(refreshToken);
            return refreshToken;
        }

        public string GetToken()
        {
            if (this.tokenResponse == null)
            {
                return string.Empty;
            }
            //Check to see if token is about to expire
            if (this.tokenResponse.ExpiresIn < 60)  {
                this.tokenResponse = RefreshToken(tokenResponse.RefreshToken);
            }

            return this.tokenResponse.AccessToken;
        }

        private TokenResponse RefreshToken(string refreshToken)
        {
            var client = new OAuth2Client(oauthTarget, oauthClient, oauthSecret);
            var response = client.RequestRefreshTokenAsync(refreshToken).Result;
            return response;
        }


        public Uri OauthUrl
        {
            set { this.oauthTarget = value ; }
        }
    }
}
