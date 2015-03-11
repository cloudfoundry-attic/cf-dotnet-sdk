using CloudFoundry.UAA.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Client.Test.Authentication
{
    internal class TestAuthentication : IAuthentication
    {
        Token token = new Token();

        internal Token TestToken
        {
            get { return token; }
            set { token = value; }
        }


        public Uri OAuthUri
        {
            get { return new Uri("http://oauth.foo.bar"); }
        }

        public async Task<Token> Authenticate(UAA.CloudCredentials credentials)
        {
            var tokenTask = await Task.Run<Token>(new Func<Token>(getToken));
            return tokenTask;

        }

        public async Task<Token> Authenticate(string refreshToken)
        {
            var tokenTask = await Task.Run<Token>(new Func<Token>(getToken));
            return tokenTask;
        }

        public async Task<Token> GetToken()
        {
            var tokenTask = await Task.Run<Token>(new Func<Token>(getToken));
            return tokenTask;
        }

        private Token getToken()
        {
            return token;
        }
    }
}
