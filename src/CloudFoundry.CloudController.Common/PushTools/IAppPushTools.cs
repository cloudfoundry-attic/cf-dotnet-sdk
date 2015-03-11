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
        Task<Dictionary<string, FileFingerprint>> GetFileFingerprints(string appPath, CancellationToken cancellationToken);

        Task<Stream> GetZippedPayload(string appPath, string[] files, CancellationToken cancellationToken);
    }
}
