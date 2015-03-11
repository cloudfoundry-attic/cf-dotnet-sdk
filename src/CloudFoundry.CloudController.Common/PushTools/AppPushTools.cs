namespace CloudFoundry.CloudController.Common.PushTools
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class AppPushTools : IAppPushTools
    {
        public Task<Dictionary<string, List<FileFingerprint>>> GetFileFingerprints(string appPath, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Stream> GetZippedPayload(string appPath, string[] files, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
