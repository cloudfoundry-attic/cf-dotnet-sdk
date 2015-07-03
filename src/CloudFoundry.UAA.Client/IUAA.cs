namespace CloudFoundry.UAA
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for classes using the UAA Client
    /// </summary>
    public interface IUAA
    {
        /// <summary>
        /// Gets the authorization token. It returns empty string if the client is not authorized. Also this method does not verify if the current token is expired.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        string AuthorizationToken { get; }

        /// <summary>
        /// Authorization Endpoint
        /// </summary>
        Uri AuthorizationEndpoint { get; }

        /// <summary>
        /// UAA Client
        /// </summary>
        UAAClient UAAClient { get; }

        /// <summary>
        /// Gets the authorization token. If the client is not authorized, an empty string is returned. If the token is expired, it generates a new one.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        Task<string> GenerateAuthorizationToken();

        /// <summary>
        /// Login using the specified raw token.
        /// </summary>
        /// <param name="refreshToken">A raw token.</param>
        /// <returns>Token Object</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        Task<AuthenticationContext> Login(string refreshToken);

        /// <summary>
        /// Login using the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Refresh Token</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        Task<AuthenticationContext> Login(CloudCredentials credentials);
    }
}
