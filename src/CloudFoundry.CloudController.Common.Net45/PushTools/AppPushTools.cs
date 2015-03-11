namespace CloudFoundry.CloudController.Common.PushTools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AppPushTools : IAppPushTools
    {
        public Task<Dictionary<string, FileFingerprint>> GetFileFingerprints(string appPath, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<System.IO.Stream> GetZippedPayload(string appPath, string[] files, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
