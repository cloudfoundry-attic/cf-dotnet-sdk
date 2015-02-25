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
            OrganizationsEndpoint orgsEndpoint = new OrganizationsEndpoint(client);
            CreateOrganizationRequest org = new CreateOrganizationRequest();
            org.Name = "test_" + Guid.NewGuid().ToString();
            var newOrg = orgsEndpoint.CreateOrganization(org).Result;
            orgGuid = new Guid(newOrg.EntityMetadata.Guid);

            SpacesEndpoint spaceEndpoint = new SpacesEndpoint(client);
            CreateSpaceRequest spc = new CreateSpaceRequest();
            spc.Name = "test_" + Guid.NewGuid().ToString();
            spc.OrganizationGuid = orgGuid;
            var newSpace = spaceEndpoint.CreateSpace(spc).Result;
            spaceGuid = new Guid(newSpace.EntityMetadata.Guid);

            DomainsDeprecatedEndpoint domainsEndpoint = new DomainsDeprecatedEndpoint(client);
            CreatesSharedDomainDeprecatedRequest r = new CreatesSharedDomainDeprecatedRequest();
            r.Name = Guid.NewGuid().ToString() + ".com";
            r.Wildcard = true;
            domainGuid = new Guid(domainsEndpoint.CreatesSharedDomainDeprecated(r).Result.EntityMetadata.Guid);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            SpacesEndpoint spaceEndpoint = new SpacesEndpoint(client);
            spaceEndpoint.DeleteSpace(spaceGuid).Wait();

            OrganizationsEndpoint orgsEndpoint = new OrganizationsEndpoint(client);
            orgsEndpoint.DeleteOrganization(orgGuid).Wait();

            DomainsDeprecatedEndpoint domainsEndpoint = new DomainsDeprecatedEndpoint(client);
            domainsEndpoint.DeleteDomainDeprecated(domainGuid).Wait();
        }

        [TestMethod]
        public void Route_test()
        {
            CreateRouteResponse newRoute = null;
            UpdateRouteResponse updatedRoute = null;
            RetrieveRouteResponse retrieveRoute = null;

            RoutesEndpoint routesEndpoint = new RoutesEndpoint(client);
            CreateRouteRequest request = new CreateRouteRequest();
            request.DomainGuid = domainGuid;
            request.SpaceGuid = spaceGuid;

            try
            {
                newRoute = routesEndpoint.CreateRoute(request).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while creating route: {0}", ex.ToString());
            }
            Assert.IsNotNull(newRoute);

            try
            {
                retrieveRoute = routesEndpoint.RetrieveRoute(new Guid(newRoute.EntityMetadata.Guid)).Result;
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
                updatedRoute = routesEndpoint.UpdateRoute(new Guid(newRoute.EntityMetadata.Guid), updateR).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while updating route: {0}", ex.ToString());
            }
            Assert.IsNotNull(updatedRoute);
            Assert.AreEqual(updateR.Host, updatedRoute.Host);

            try
            {
                routesEndpoint.DeleteRoute(new Guid(newRoute.EntityMetadata.Guid)).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while deleting space: {0}", ex.ToString());
            }
        }
    }
}
