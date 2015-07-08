using CloudFoundry.Logyard.Client;
using CloudFoundry.UAA;
using CCV3 = CloudFoundry.CloudController.V3.Client;
using CloudFoundry.CloudController.V2.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace CloudFoundry.CloudController.Test.Integration
{
    internal static class TestUtil
    {
        internal static string ServerUrl = ConfigurationManager.AppSettings["TestServerUrl"];
        internal static string User = ConfigurationManager.AppSettings["User"];
        internal static string Password = ConfigurationManager.AppSettings["Password"];
        internal static bool IgnoreCertificate = bool.Parse(ConfigurationManager.AppSettings["IgnoreCertificate"]);
     
        internal static string TestAppPath
        {
            get
            {
                string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(assemblyDir, "TestApp");
            }
        }

        internal static string NodeTestApp
        {
            get
            {
                string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(assemblyDir, "node");
            }
        }

        internal static void IngoreGlobalCertificateValidation()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
        }

        internal static CloudFoundryClient GetClient()
        {
            return GetClient(new CancellationToken());
        }

        internal static CloudFoundryClient GetClient(CancellationToken cancellationToken)
        {
            if (IgnoreCertificate)
            {
                IngoreGlobalCertificateValidation();
            }

            CloudFoundryClient client = new CloudFoundryClient(new Uri(ServerUrl), cancellationToken, null, true);
            return client;
        }

        internal static CCV3.CloudFoundryClient GetV3Client()
        {
            return GetV3Client(new CancellationToken());
        }

        internal static CCV3.CloudFoundryClient GetV3Client(CancellationToken cancellationToken)
        {
            if (IgnoreCertificate)
            {
                IngoreGlobalCertificateValidation();
            }

            var cfclient = GetClient(cancellationToken);

            string authEndpoint = cfclient.Info.GetInfo().Result.AuthorizationEndpoint;

            CCV3.CloudFoundryClient client = new CCV3.CloudFoundryClient(new Uri(ServerUrl), cancellationToken, null, true, new Uri(authEndpoint));
            return client;
        }

        internal static UAAClient GetUAAClient()
        {
            var cfclient = GetClient();
            var serverInfo = cfclient.Info.GetInfo().Result;
            var authEndpoint = serverInfo.AuthorizationEndpoint;
            var authUri = new Uri(authEndpoint.TrimEnd('/') + "/oauth/token");

            UAAClient uaaClient = new UAAClient(authUri);

            return uaaClient;
        }

        internal static LogyardLog GetLogyardClient()
        {
            return GetLogyardClient(new CancellationToken());
        }

        internal static LogyardLog GetLogyardClient(CancellationToken cancellationToken)
        {
            var uaaClient = GetUAAClient();
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = User;
            credentials.Password = Password;
            var context = uaaClient.Login(credentials).Result;
            var cfClient = GetClient();
            var logEndpoint = cfClient.Info.GetV1Info().Result.AppLogEndpoint;
            LogyardLog logyardClient = new LogyardLog(new Uri(logEndpoint), context.Token.AccessToken);
            return logyardClient;
        }

    }
}
