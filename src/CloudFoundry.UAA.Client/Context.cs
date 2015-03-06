namespace CloudFoundry.UAA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CloudFoundry.UAA.Authentication;

    /// <summary>
    /// Class that represents the current authentication context.
    /// </summary>
    public class AuthenticationContext
    {
        private bool isLoggedIn = false;

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public Token Token { get; internal set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        public Uri Uri { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance is logged in.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is logged in; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoggedIn
        {
            get
            {
                return this.isLoggedIn;
            }

            internal set
            {
                this.isLoggedIn = value;
            }
        }
    }
}
