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
        /// Gets the file fingerprints from the application folder
        /// As the sha1 is calculated based on the content of the file, 
        /// there is a possibility that one key can have multiple fingerprints (duplicate files)
        /// </summary>
        /// <param name="appPath">The path to the application folder</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Return a dictionary of file fingerprints, with sha1 as key and a list of file fingerprints as value.</returns>
        public Task<Dictionary<string, List<FileFingerprint>>> GetFileFingerprints(string appPath, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a zip archive containing specific files from the application folder
        /// </summary>
        /// <param name="appPath">The path to the application folder</param>
        /// <param name="files">The files that will be added to the archive.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        public Task<Stream> GetZippedPayload(string appPath, IEnumerable<string> files, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
