using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    class StackTest
    {
        static CloudFoundryClient client;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            client = TestUtil.GetClient();
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
        public void ListStacks_test()
        {
            StacksEndpoint stacksEndpoint = new StacksEndpoint(client);
            PagedResponseCollection<ListAllStacksResponse> response = null;
            try
            {
                response = stacksEndpoint.ListAllStacks().Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Error while reading stacks in" + ex.ToString());
            }

            Assert.IsNotNull(response);            

            while (response != null && response.Properties.TotalResults != 0)
            {
                foreach (var stack in response)
                {
                    Assert.IsNotNull(stack.Name);
                }
                response = response.GetNextPage().Result;
            }

        }
    }
}
