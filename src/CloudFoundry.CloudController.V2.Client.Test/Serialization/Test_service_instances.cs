using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class ServiceInstancesTest
    {

    
        [TestMethod]
        public void TestCreateServiceInstanceRequest()
        {
            string json = @"{
  ""space_guid"": ""fbd197d6-3ce3-43c3-ad44-0a001712db52"",
  ""name"": ""my-service-instance"",
  ""service_plan_guid"": ""ef9e93a0-c306-4a56-9a9c-4a7da955b78e""
}";
        
            CreateServiceInstanceRequest request = new CreateServiceInstanceRequest();
       
            request.SpaceGuid = new Guid("fbd197d6-3ce3-43c3-ad44-0a001712db52");
            request.Name = "my-service-instance";
            request.ServicePlanGuid = new Guid("ef9e93a0-c306-4a56-9a9c-4a7da955b78e");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateServicePlanServiceInstanceRequest()
        {
            string json = @"{""service_plan_guid"":""123becae-a489-4529-9b27-e54275cdb12d""}";
        
            UpdateServicePlanServiceInstanceRequest request = new UpdateServicePlanServiceInstanceRequest();
       
            request.ServicePlanGuid = new Guid("123becae-a489-4529-9b27-e54275cdb12d");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestMigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest()
        {
            string json = @"{""service_plan_guid"":""e0083a69-c281-4dc9-9af7-46acc8478b2f""}";
        
            MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest request = new MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest();
       
            request.ServicePlanGuid = new Guid("e0083a69-c281-4dc9-9af7-46acc8478b2f");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
