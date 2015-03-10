using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.UAA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class OrgTest
    {
        static CloudFoundryClient client;
        static Guid orgGuid;

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
            CreateOrganizationRequest org = new CreateOrganizationRequest();
            org.Name = "test_" + Guid.NewGuid().ToString();
            var newOrg = client.Organizations.CreateOrganization(org).Result;
            orgGuid = new Guid(newOrg.EntityMetadata.Guid);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            client.Organizations.DeleteOrganization(orgGuid).Wait();

        }

        [TestMethod]
        public void ListOrgs_test()
        {
            PagedResponseCollection<ListAllOrganizationsResponse> response = null;
            try
            {
                response = client.Organizations.ListAllOrganizations().Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Error while reading organizations in" + ex.ToString());
            }

            Assert.IsNotNull(response);

            while (response != null && response.Properties.TotalResults != 0)
            {
                foreach (var org in response)
                {
                    Assert.IsNotNull(org.Name);
                }
                response = response.GetNextPage().Result;
            }

        }
    }
}
