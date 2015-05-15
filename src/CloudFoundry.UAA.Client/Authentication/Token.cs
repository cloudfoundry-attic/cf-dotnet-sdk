namespace CloudFoundry.UAA.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that represents a token items from Oauth v2.
    /// </summary>
    public class Token
    {
        private string accessToken = null;

        /// <summary>
        /// Gets the username of the user associated with the token.
        /// </summary>
        /// <value>
        /// A username.
        /// </value>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the email of the user associatedwith the token.
        /// </summary>
        /// <value>
        /// An e-mail address.
        /// </value>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the unique ID of the user associated with the token.
        /// </summary>
        /// <value>
        /// The user's ID.
        /// </value>
        public string UserGuid { get; private set; }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string AccessToken 
        {
            get
            {
                return this.accessToken;
            }

            internal set
            {
                this.accessToken = value;

                dynamic tokenInfo = Token.GetTokenInfo(this.accessToken);

                this.UserName = tokenInfo == null ? null : tokenInfo["user_name"];
                this.Email = tokenInfo == null ? null : tokenInfo["email"];
                this.UserGuid = tokenInfo == null ? null : tokenInfo["user_id"];
            }
        }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        public string RefreshToken { get; internal set; }

        /// <summary>
        /// Gets the expiration time in secounds.
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        public DateTime Expires { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this token is expired.
        /// </summary>
        /// <value>
        /// <c>true</c> if this token is expired; otherwise, <c>false</c>.
        /// </value>
        public bool IsExpired
        {
            get
            {
                if (DateTime.Now > this.Expires)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Decodes a token received from UAA.
        /// Implementation based on https://github.com/cloudfoundry/cli/blob/master/cf/configuration/core_config/access_token.go
        /// </summary>
        /// <returns>A JSON object that contains the decoded information.</returns>
        private static dynamic GetTokenInfo(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return null;
            }

            string[] encodedParts = accessToken.Split('.');

            if (encodedParts.Length < 3)
            {
                return null;
            }

            string encodedTokenJson = encodedParts[1];
            byte[] decodedBytes = Convert.FromBase64String(RestorePadding(encodedTokenJson));
            string decodedJson = Encoding.UTF8.GetString(decodedBytes, 0, decodedBytes.Length);

            return JsonConvert.DeserializeObject(decodedJson);
        }

        /// <summary>
        /// Normalizes padding for a Base64 encoded string
        /// Implementation based on https://github.com/cloudfoundry/cli/blob/master/cf/configuration/core_config/access_token.go
        /// </summary>
        /// <returns>A Base64 encoded string.</returns>
        private static string RestorePadding(string seg)
        {
            switch (seg.Length % 4)
            {
                case 2: 
                    seg = seg + "=="; 
                    break;
                case 3: 
                    seg = seg + "="; 
                    break;
            }

            return seg;
        }
    }
}
