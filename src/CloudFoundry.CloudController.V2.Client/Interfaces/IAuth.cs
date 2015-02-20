using System;

namespace CloudFoundry.CloudController.V2.Interfaces
{
    public interface IAuthentication
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "Implementations of this method will have side effects (e.g. making an HTTP request to grab a token)")]
        string GetToken();

        /// <summary>
        /// Sets the oauth URL.
        /// </summary>
        /// <value>
        /// The oauth URL.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth",
            Justification = "OAuth is spelled correctly. See http://oauth.net/")]
        Uri OAuthUrl { get; set; }
    }
}