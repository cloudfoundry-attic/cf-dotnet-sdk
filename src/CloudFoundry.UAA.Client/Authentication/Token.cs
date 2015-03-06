namespace CloudFoundry.UAA.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that represents a token items from Oauth v2.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string AccessToken { get; internal set; }

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
    }
}
