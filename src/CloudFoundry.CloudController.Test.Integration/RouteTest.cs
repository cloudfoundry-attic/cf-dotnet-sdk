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
    public class RouteTest
    {
        static CloudFoundryClient client;
        static Guid orgGuid;
        static Guid spaceGuid;
        static Guid domainGuid;

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
            orgGuid = newOrg.EntityMetadata.Guid;

            CreateSpaceRequest spc = new CreateSpaceRequest();
            spc.Name = "test_" + Guid.NewGuid().ToString();
            spc.OrganizationGuid = orgGuid;
            var newSpace = client.Spaces.CreateSpace(spc).Result;
            spaceGuid = newSpace.EntityMetadata.Guid;

            CreatesSharedDomainDeprecatedRequest r = new CreatesSharedDomainDeprecatedRequest();
            r.Name = Guid.NewGuid().ToString() + ".com";
            r.Wildcard = true;
            domainGuid = client.DomainsDeprecated.CreatesSharedDomainDeprecated(r).Result.EntityMetadata.Guid;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            client.Spaces.DeleteSpace(spaceGuid).Wait();

            client.Organizations.DeleteOrganization(orgGuid).Wait();

            client.DomainsDeprecated.DeleteDomainDeprecated(domainGuid).Wait();
        }

        [TestMethod]
        public void Route_test()
        {
            CreateRouteResponse newRoute = null;
            UpdateRouteResponse updatedRoute = null;
            RetrieveRouteResponse retrieveRoute = null;

            CreateRouteRequest request = new CreateRouteRequest();
            request.DomainGuid = domainGuid;
            request.SpaceGuid = spaceGuid;

            try
            {
                newRoute = client.Routes.CreateRoute(request).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while creating route: {0}", ex.ToString());
            }
            Assert.IsNotNull(newRoute);

            try
            {
                retrieveRoute = client.Routes.RetrieveRoute(newRoute.EntityMetadata.Guid).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while reading route: {0}", ex.ToString());
            }
            Assert.IsNotNull(retrieveRoute);

            UpdateRouteRequest updateR = new UpdateRouteRequest();
            updateR.Host = "newtestdomain";

            try
            {
                updatedRoute = client.Routes.UpdateRoute(newRoute.EntityMetadata.Guid, updateR).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while updating route: {0}", ex.ToString());
            }
            Assert.IsNotNull(updatedRoute);
            Assert.AreEqual(updateR.Host, updatedRoute.Host);

            try
            {
                client.Routes.DeleteRoute(newRoute.EntityMetadata.Guid).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while deleting space: {0}", ex.ToString());
            }
        }
    }
}
