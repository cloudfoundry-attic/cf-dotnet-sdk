using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.UAA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class CertificateValidationTest
    {
        [TestMethod]
        public void ClientWithoutCertificateValidation_test()
        {
            var client = new CloudFoundryClient(new Uri(TestUtil.ServerUrl), new CancellationToken(), null, true);
            var credentials = new CloudCredentials() { User = TestUtil.User, Password = TestUtil.Password };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = null;

            bool globalValidationInvoked = false;
            object lastSenderValidated = null;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                lastSenderValidated = sender;
                globalValidationInvoked = true;
                return true;
            };

            client.Login(credentials).Wait();

            var response = client.Stacks.ListAllStacks().Result;
            Assert.IsNotNull(response);

            Assert.IsNull(lastSenderValidated);
            Assert.IsFalse(globalValidationInvoked);
        }

        [TestMethod]
        public void ClientWithCertificateValidation_test()
        {
            var client = new CloudFoundryClient(new Uri(TestUtil.ServerUrl), new CancellationToken(), null, false);
            var credentials = new CloudCredentials() { User = TestUtil.User, Password = TestUtil.Password };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = null;

            bool globalValidationInvoked = false;
            object lastSenderValidated = null;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                lastSenderValidated = sender;
                globalValidationInvoked = true;
                return true;
            };

            client.Login(credentials).Wait();

            var response = client.Stacks.ListAllStacks().Result;
            Assert.IsNotNull(response);

            Assert.IsNotNull(lastSenderValidated);
            Assert.IsTrue(globalValidationInvoked);
        }

        [TestMethod]
        [ExpectedException(typeof(System.AggregateException), "Could not establish trust relationship for the SSL/TLS secure channel.")]
        public void LoginWithInvlidCertificate_test()
        {
            var client = new CloudFoundryClient(new Uri(TestUtil.ServerUrl), new CancellationToken(), null, false);
            var credentials = new CloudCredentials() { User = TestUtil.User, Password = TestUtil.Password };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = null;

            client.Login(credentials).Wait();
        }

        [TestMethod]
        [ExpectedException(typeof(System.AggregateException), "Could not establish trust relationship for the SSL/TLS secure channel.")]
        public void CloudFoundryClientWithInvlidCertificate_test()
        {
            var client = new CloudFoundryClient(new Uri(TestUtil.ServerUrl), new CancellationToken(), null, false);
            var credentials = new CloudCredentials() { User = TestUtil.User, Password = TestUtil.Password };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            client.Login(credentials).Wait();

            System.Net.ServicePointManager.ServerCertificateValidationCallback = null;

            client.Stacks.ListAllStacks().Wait();
        }
    }
}
