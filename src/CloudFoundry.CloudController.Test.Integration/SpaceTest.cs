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
    public class SpaceTest
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
        public void Spaces_test()
        {
            CreateSpaceResponse newSpace = null;
            UpdateSpaceResponse updatedSpace = null;
            GetSpaceSummaryResponse spaceSummary = null;
            CreateSpaceRequest spc = new CreateSpaceRequest();
            spc.Name = "test_" + Guid.NewGuid().ToString();
            spc.OrganizationGuid = orgGuid;

            try
            {
                newSpace = client.Spaces.CreateSpace(spc).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while creating space: {0}", ex.ToString());
            }
            Assert.IsNotNull(newSpace);

            try
            {
                spaceSummary = client.Spaces.GetSpaceSummary(new Guid(newSpace.EntityMetadata.Guid)).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while reading space: {0}", ex.ToString());
            }
            Assert.IsNotNull(spaceSummary);

            UpdateSpaceRequest sr = new UpdateSpaceRequest();
            sr.Name = "new_name_" + Guid.NewGuid().ToString();

            try
            {
                updatedSpace = client.Spaces.UpdateSpace(new Guid(newSpace.EntityMetadata.Guid), sr).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while updating space: {0}", ex.ToString());
            }
            Assert.IsNotNull(updatedSpace);
            Assert.AreEqual(sr.Name, updatedSpace.Name);

            try
            {
                client.Spaces.DeleteSpace(new Guid(newSpace.EntityMetadata.Guid)).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while deleting space: {0}", ex.ToString());
            }
        }

    }
}
