using CloudFoundry.UAA;
using CloudFoundry.UAA.Authentication;
using CloudFoundry.UAA.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Client.Test.Authentication
{
    [TestClass]
    public class Test_UAAClient
    {
        [TestMethod]
        public void TestUAAClientLoginCredentials()
        {
            Token testToken = new Token();
            testToken.AccessToken = "accessToken";
            testToken.Expires = DateTime.Now.AddDays(1000);
            testToken.RefreshToken = "refreshToken";
            var uaaClient = TestUtil.GetUAAClient(testToken);

            var context = uaaClient.Login(new CloudCredentials() { User = "test", Password = "test" }).Result;

            Assert.IsTrue(context.IsLoggedIn);
            Assert.AreEqual(context.Uri, new Uri("http://uaa.foo.bar"));
            Assert.AreEqual(context.Token.AccessToken, testToken.AccessToken);
            Assert.AreEqual(context.Token.Expires, testToken.Expires);
            Assert.IsFalse(context.Token.IsExpired);
            Assert.AreEqual(context.Token.RefreshToken, testToken.RefreshToken);

        }

        [TestMethod]
        public void TestUAAClientLoginRefreshToken()
        {
            Token testToken = new Token();
            testToken.AccessToken = "accessToken";
            testToken.Expires = DateTime.Now.AddDays(1000);
            testToken.RefreshToken = "refreshToken";
            var uaaClient = TestUtil.GetUAAClient(testToken);

            var context = uaaClient.Login("refreshToken").Result;

            Assert.IsTrue(context.IsLoggedIn);
            Assert.AreEqual(context.Uri, new Uri("http://uaa.foo.bar"));
            Assert.AreEqual(context.Token.AccessToken, testToken.AccessToken);
            Assert.AreEqual(context.Token.Expires, testToken.Expires);
            Assert.IsFalse(context.Token.IsExpired);
            Assert.AreEqual(context.Token.RefreshToken, testToken.RefreshToken);

        }

        [TestMethod]
        public void TestUAAClientLoginExpired()
        {
            Token testToken = new Token();
            testToken.AccessToken = "accessToken";
            testToken.Expires = DateTime.Now.Subtract(new TimeSpan(1, 0, 0));
            testToken.RefreshToken = "refreshToken";
            var uaaClient = TestUtil.GetUAAClient(testToken);

            var context = uaaClient.Login("refreshToken").Result;

            Assert.IsTrue(context.Token.IsExpired);
        }

        [TestMethod]
        public void TestUAAClientNotLoggedIn()
        {
            UAAClient uaaClient = new UAAClient(new Uri("http://uaa.foo.bar"));

            Assert.IsFalse(uaaClient.Context.IsLoggedIn);

        }

        [TestMethod]
        public void TestUAAClientExceptionGenerateContextNotLogedIn()
        {
            UAAClient uaaClient = new UAAClient(new Uri("http://uaa.foo.bar"));
            AuthenticationContext context = null;

            try
            {
                context = uaaClient.GenerateContext().Result;
                Assert.Fail("No exception was thrown when generating context for an unauthorized client");
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex.GetType() != typeof(AuthenticationException))
                    {
                        Assert.Fail(string.Format(CultureInfo.InvariantCulture, "Expected type of AuthenticationException but got {0}", ex.ToString()));
                    }
                }
            }


        }
    }
}
