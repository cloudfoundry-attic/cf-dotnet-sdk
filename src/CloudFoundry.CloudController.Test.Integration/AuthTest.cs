using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Exceptions;
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
