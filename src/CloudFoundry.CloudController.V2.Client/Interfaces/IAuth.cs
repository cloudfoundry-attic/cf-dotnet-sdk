using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Interfaces
{
    public interface IAuth
    {
        /// <summary>
        /// Authenticates the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="oatuhTarget">The oatuh target.</param>
        /// <returns>A refresh Token</returns>
        string Authenticate(CloudCredentials credentials);

        /// <summary>
        /// Authenticates the specified refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>A refresh Token</returns>
        string Authenticate(string refreshToken);

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <returns>The access token</returns>
        string GetToken();

        /// <summary>
        /// Sets the oauth URL.
        /// </summary>
        /// <value>
        /// The oauth URL.
        /// </value>
        Uri OauthUrl { set; }

    }
}
