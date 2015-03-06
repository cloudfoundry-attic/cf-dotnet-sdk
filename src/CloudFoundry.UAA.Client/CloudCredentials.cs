namespace CloudFoundry.UAA
{
    /// <summary>
    /// Credentials of the target cloud
    /// </summary>
    public class CloudCredentials
    {
        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password
        {
            get;
            set;
        }
    }
}