namespace CloudFoundry.CloudController.Common.PushTools
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper tools for application push
    /// </summary>
    public class AppPushTools : IAppPushTools
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppPushTools"/> class.
        /// </summary>
        /// <param name="appPath">The application path.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "appPath", Justification = "Class is not used.")]
        public AppPushTools(string appPath)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the file fingerprints from the application folder
        /// As the sha1 is calculated based on the content of the file, 
        /// there is a possibility that one key can have multiple fingerprints (duplicate files)
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Return a dictionary of file fingerprints, with sha1 as key and a list of file fingerprints as value.</returns>
        public Task<Dictionary<string, List<FileFingerprint>>> GetFileFingerprints(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a zip archive containing specific files from the application folder
        /// </summary>
        /// <param name="files">The files that will be added to the archive.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        public Task<Stream> GetZippedPayload(IEnumerable<string> files, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a zip archive containing the all files from the application folder <see cref="AppPushTools"/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        public Task<Stream> GetZippedPayload(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
