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
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            SpacesEndpoint spaceEndpoint = new SpacesEndpoint(client);
            spaceEndpoint.DeleteSpace(spaceGuid).Wait();

            OrganizationsEndpoint orgsEndpoint = new OrganizationsEndpoint(client);
            orgsEndpoint.DeleteOrganization(orgGuid).Wait();
        }

        [TestMethod]
        public void ServiceInstance_test()
        {
            ServicesEndpoint servicesEndpoint = new ServicesEndpoint(client);
            ServiceInstancesEndpoint serviceInstanceEndpoint = new ServiceInstancesEndpoint(client);
            
            var services = servicesEndpoint.ListAllServices().Result;
            Guid serviceGuid = new Guid(services.FirstOrDefault(s => s.Label == "mysql").EntityMetadata.Guid);

            var plans = servicesEndpoint.ListAllServicePlansForService(serviceGuid).Result;
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
                newService = serviceInstanceEndpoint.CreateServiceInstance(createService).Result;
            }
            catch(Exception ex)
            {
                Assert.Fail("Exception while creating service instance: {0}", ex.ToString());
            }

            Assert.IsNotNull(newService);
            Assert.AreEqual(createService.Name, newService.Name);

            try
            {
                readService = serviceInstanceEndpoint.RetrieveServiceInstance(new Guid(newService.EntityMetadata.Guid)).Result;
            }
            catch(Exception ex)
            {
                Assert.Fail("Exception while reading service instance: {0}", ex.ToString());            
            }

            UpdateServiceInstanceRequest updateService = new UpdateServiceInstanceRequest();
            updateService.Name = "svc" + Guid.NewGuid().ToString().Substring(0, 3);
            try
            {
                updatedService = serviceInstanceEndpoint.UpdateServiceInstance(new Guid(newService.EntityMetadata.Guid), updateService).Result;
            }
            catch(Exception ex)            
            {
                Assert.Fail("Exception while updating service instance: {0}", ex.ToString());            
            }
        
            Assert.IsNotNull(updatedService);
            Assert.AreEqual(updateService.Name, updatedService.Name);

            try
            {
                serviceInstanceEndpoint.DeleteServiceInstance(new Guid(newService.EntityMetadata.Guid)).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception while deleting service instance: {0}", ex.ToString());
            }
        }
    }
}
