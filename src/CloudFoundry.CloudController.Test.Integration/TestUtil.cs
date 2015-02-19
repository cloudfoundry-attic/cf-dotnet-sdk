using CloudFoundry.CloudController.V2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    internal static class TestUtil
    {
        internal static string ServerUrl = ConfigurationManager.AppSettings["TestServerUrl"];
        internal static string User = ConfigurationManager.AppSettings["User"];
        internal static string Password = ConfigurationManager.AppSettings["Password"];
        internal static bool IgnoreCertificate = bool.Parse(ConfigurationManager.AppSettings["IgnoreCertificate"]);

        internal static CloudfoundryClient GetClient()
        {
            if (IgnoreCertificate)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            }
            
            CloudfoundryClient client = new CloudfoundryClient(new Uri(ServerUrl), new System.Threading.CancellationToken());
            return client;
        }

    }
}
