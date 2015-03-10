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
    public class ServiceInstanceTest
    {
        static CloudFoundryClient client;
        static Guid orgGuid;
        static Guid spaceGuid;

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

            CreateSpaceRequest spc = new CreateSpaceRequest();
            spc.Name = "test_" + Guid.NewGuid().ToString();
            spc.OrganizationGuid = orgGuid;
            var newSpace = client.Spaces.CreateSpace(spc).Result;
            spaceGuid = new Guid(newSpace.EntityMetadata.Guid);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            client.Spaces.DeleteSpace(spaceGuid).Wait();

            client.Organizations.DeleteOrganization(orgGuid).Wait();
        }

        [TestMethod]
        public void ServiceInstance_test()
        {
            var services = client.Services.ListAllServices().Result;
            Guid serviceGuid = new Guid(services.FirstOrDefault(s => s.Label == "mysql").EntityMetadata.Guid);

            var plans = client.Services.ListAllServicePlansForService(serviceGuid).Result;
            Guid servicePlanGuid = new Guid(plans.FirstOrDefault().EntityMetadata.Guid);
            CreateServiceInstanceResponse newService = null;
            RetrieveServiceInstanceResponse readService = null;
            UpdateServiceInstanceResponse updatedService = null;

            CreateServiceInstanceRequest createService = new CreateServiceInstanceRequest();
            createService.SpaceGuid = spaceGuid;
            createService.Name = "svc" + Guid.NewGuid().ToString().Substring(0, 3);
            createService.ServicePlanGuid = servicePlanGuid;
            try
            {
                newService = client.ServiceInstances.CreateServiceInstance(createService).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while creating service instance: {0}", ex.ToString());
            }

            Assert.IsNotNull(newService);
            Assert.AreEqual(createService.Name, newService.Name);

            try
            {
                readService = client.ServiceInstances.RetrieveServiceInstance(new Guid(newService.EntityMetadata.Guid)).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while reading service instance: {0}", ex.ToString());
            }

            UpdateServiceInstanceRequest updateService = new UpdateServiceInstanceRequest();
            updateService.Name = "svc" + Guid.NewGuid().ToString().Substring(0, 3);
            try
            {
                updatedService = client.ServiceInstances.UpdateServiceInstance(new Guid(newService.EntityMetadata.Guid), updateService).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while updating service instance: {0}", ex.ToString());
            }

            Assert.IsNotNull(updatedService);
            Assert.AreEqual(updateService.Name, updatedService.Name);

            try
            {
                client.ServiceInstances.DeleteServiceInstance(new Guid(newService.EntityMetadata.Guid)).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while deleting service instance: {0}", ex.ToString());
            }
        }
    }
}
