using CloudFoundry.Logyard.Client;
using CloudFoundry.UAA;
using CloudFoundry.CloudController.V2.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    internal static class TestUtil
    {
        internal static string ServerUrl = ConfigurationManager.AppSettings["TestServerUrl"];
        internal static string User = ConfigurationManager.AppSettings["User"];
        internal static string Password = ConfigurationManager.AppSettings["Password"];
        internal static bool IgnoreCertificate = bool.Parse(ConfigurationManager.AppSettings["IgnoreCertificate"]);
        internal static string TestAppPath = ConfigurationManager.AppSettings["TestAppPath"];

        internal static CloudFoundryClient GetClient()
        {
            return GetClient(new CancellationToken());
        }

        internal static CloudFoundryClient GetClient(CancellationToken cancellationToken)
        {
            if (IgnoreCertificate)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            }

            CloudFoundryClient client = new CloudFoundryClient(new Uri(ServerUrl), cancellationToken);
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
