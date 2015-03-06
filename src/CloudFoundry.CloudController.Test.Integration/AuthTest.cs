using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.Common.Exceptions;
using CloudFoundry.UAA;
using CloudFoundry.UAA.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class AuthTest
    {

        [TestMethod]
        public void Login_context_test()
        {
            if (TestUtil.IgnoreCertificate)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            }
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = TestUtil.User;
            credentials.Password = TestUtil.Password;

            var client = TestUtil.GetClient();
            var authEndpoint = client.Info.GetInfo().Result.AuthorizationEndpoint;
            var authUri = new Uri(authEndpoint.TrimEnd('/') + "/oauth/token");


            UAAClient uaaClient = new UAAClient(authUri);

            var context = uaaClient.Login(credentials).Result;

            Assert.IsTrue(context.IsLoggedIn);
            Assert.AreEqual(context.Uri, authUri);
            Assert.IsNotNull(context.Token.AccessToken);
            Assert.IsNotNull(context.Token.RefreshToken);
            Assert.IsFalse(context.Token.IsExpired);
            Assert.IsTrue(context.Token.Expires > DateTime.Now);

        }


        [TestMethod]
        public void Login_test()
        {
            var client = TestUtil.GetClient();
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = TestUtil.User;
            credentials.Password = TestUtil.Password;
            try
            {
                client.Login(credentials).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Error while loging in" + ex.ToString());
            }

        }

        [TestMethod]
        public void Login_incorrect_user_test()
        {
            var client = TestUtil.GetClient();
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = Guid.NewGuid().ToString();
            credentials.Password = TestUtil.Password;
            try
            {
                client.Login(credentials).Wait();
            }
            catch (AggregateException aggEx)
            {
                Assert.IsInstanceOfType(aggEx.InnerException, typeof(AuthenticationException));
                Assert.IsTrue(aggEx.InnerException.Message.Contains("Unable to connect to target with the provided credentials. Error message: invalid_grant"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected AuthError but got :" + ex.ToString());
            }
        }

        [TestMethod]
        public void Login_incorrect_password_test()
        {
            var client = TestUtil.GetClient();
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = TestUtil.User;
            credentials.Password = Guid.NewGuid().ToString();
            try
            {
                client.Login(credentials).Wait();
            }
            catch (AggregateException aggEx)
            {
                Assert.IsInstanceOfType(aggEx.InnerException, typeof(AuthenticationException));
                Assert.IsTrue(aggEx.InnerException.Message.Contains("Unable to connect to target with the provided credentials. Error message: invalid_grant"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected AuthError but got :" + ex.ToString());
            }
        }

    }
}
