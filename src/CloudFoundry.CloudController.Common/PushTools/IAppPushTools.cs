namespace CloudFoundry.CloudController.Common.PushTools
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that must be implemented by providers of push tooling.
    /// </summary>
    public interface IAppPushTools
    {
        /// <summary>
        /// Gets the file fingerprints from the application folder <see cref="AppPushTools"/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Return a dictionary of file fingerprints, with sha1 as key and a list of file fingerprints as value.</returns>
        Task<Dictionary<string, List<FileFingerprint>>> GetFileFingerprints(CancellationToken cancellationToken);

        /// <summary>
        /// Creates a zip archive containing specific files from the application folder <see cref="AppPushTools"/>
        /// </summary>
        /// <param name="files">The files that will be added to the archive.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        Task<Stream> GetZippedPayload(IEnumerable<string> files, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a zip archive containing the all files from the application folder <see cref="AppPushTools"/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        Task<Stream> GetZippedPayload(CancellationToken cancellationToken);
    }
}
