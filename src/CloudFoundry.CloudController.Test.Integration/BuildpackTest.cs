using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.UAA;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class BuildpackTest
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
        public void ListBuildpacks_test()
        {
            BuildpacksEndpoint buildpacksEndpoint = new BuildpacksEndpoint(client);
            PagedResponseCollection<ListAllBuildpacksResponse> response = null;
            try
            {
                response = buildpacksEndpoint.ListAllBuildpacks().Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Error while reading buildpacks in" + ex.ToString());
            }

            Assert.IsNotNull(response);

            while (response != null && response.Properties.TotalResults != 0)
            {
                foreach (var bp in response)
                {
                    Assert.IsNotNull(bp.Name);
                }
                response = response.GetNextPage().Result;
            }

        }
    }
}
