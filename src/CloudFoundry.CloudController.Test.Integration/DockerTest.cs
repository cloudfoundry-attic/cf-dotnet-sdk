using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.UAA;
using System.Net;
using System.Globalization;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class DockerTest
    {
        static CloudFoundryClient client;
        static Guid orgGuid;
        static Guid spaceGuid;
        static Guid stackGuid;
        static Guid domainGuid;
        static String domainName;
        static Guid appGuid;
        static Guid routeGuid;

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

            stackGuid = client.Stacks.ListAllStacks().Result[0].EntityMetadata.Guid;

            var domain = client.DomainsDeprecated.ListAllDomainsDeprecated().Result[0];
            domainGuid = domain.EntityMetadata.Guid;
            domainName = domain.Name;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            client.Apps.DeleteApp(appGuid).Wait();

            client.Routes.DeleteRoute(routeGuid, true).Wait();

            client.Spaces.DeleteSpace(spaceGuid).Wait();

            client.Organizations.DeleteOrganization(orgGuid).Wait();

        }

        [TestMethod]
        public void Docker_Application_test()
        {
            CreateDockerAppResponse dockerApp = null;
            UpdateAppResponse startResponse = null;
            CreateRouteResponse routeResponse = null;
            AssociateAppWithRouteResponse assocResponse = null;

            CreateDockerAppRequest docker = new CreateDockerAppRequest();
            docker.Name = Guid.NewGuid().ToString();
            docker.DockerImage = "viovanov/node-env-tiny";
            docker.Instances = 1;
            docker.Memory = 256;
            docker.SpaceGuid = spaceGuid;
            docker.StackGuid = stackGuid;

            try
            {
                dockerApp = client.Apps.CreateDockerApp(docker).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Error creating docker app: {0}", ex.ToString());
            }

            appGuid = dockerApp.EntityMetadata.Guid;

            UpdateAppRequest startDocker = new UpdateAppRequest();
            startDocker.State = "STARTED";
            try
            {
                startResponse = client.Apps.UpdateApp(dockerApp.EntityMetadata.Guid, startDocker).Result;  
            }
            catch (Exception ex)
            {
                Assert.Fail("Error starting docker app: {0}", ex.ToString());
            }
            Assert.IsNotNull(startResponse);

            CreateRouteRequest createDockerRoute = new CreateRouteRequest();
            createDockerRoute.DomainGuid = domainGuid;
            createDockerRoute.SpaceGuid = spaceGuid;
            createDockerRoute.Host = Guid.NewGuid().ToString();

            try
            {
                routeResponse = client.Routes.CreateRoute(createDockerRoute).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Error creating docker app route: {0}", ex.ToString());
            }
            Assert.IsNotNull(routeResponse);

            routeGuid = routeResponse.EntityMetadata.Guid;

            try
            {
                assocResponse = client.Routes.AssociateAppWithRoute(routeResponse.EntityMetadata.Guid, dockerApp.EntityMetadata.Guid).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Error binding route to app: {0}", ex.ToString());
            }

            Assert.IsTrue(CheckIfAppIsWorking(string.Format(CultureInfo.InvariantCulture, "{0}.{1}", createDockerRoute.Host, domainName),60));
        }

        private bool CheckIfAppIsWorking(string route, int retryCount)
        {
            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    WebRequest request = WebRequest.Create(string.Format("http://{0}", route));
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                catch //If exception thrown then couldn't get response from address
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }
            return false;
        }
    }
}

