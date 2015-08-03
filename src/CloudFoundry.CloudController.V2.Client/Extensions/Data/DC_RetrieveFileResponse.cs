namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;

    /// <summary>
    /// Entity used to retrieve file informations
    /// </summary>
    public class RetrieveFileResponse
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>
        /// The size of the file.
        /// </value>
        public string FileSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the content of the file.
        /// </summary>
        /// <value>
        /// The content of the file.
        /// </value>
        public string FileContent
        {
            get;
            set;
        }
    }
}
