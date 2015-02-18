using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class ServicePlansTest
    {

    
        [TestMethod]
        public void TestUpdateServicePlanDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""100mb"",
  ""free"": true,
  ""description"": ""Let's you put data in your database!"",
  ""service_guid"": ""a9f310d5-2d2b-41a3-8eb4-70faf642ef73""
}";
        
            UpdateServicePlanDeprecatedRequest request = new UpdateServicePlanDeprecatedRequest();
       
            request.Name = "100mb";
            request.Free = true;
            request.Description = "Let's you put data in your database!";
            request.ServiceGuid = new Guid("a9f310d5-2d2b-41a3-8eb4-70faf642ef73");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateServicePlanDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""100mb"",
  ""free"": true,
  ""description"": ""Let's you put data in your database!"",
  ""service_guid"": ""907897d8-6480-4570-ac09-7db78cfcb61d""
}";
        
            CreateServicePlanDeprecatedRequest request = new CreateServicePlanDeprecatedRequest();
       
            request.Name = "100mb";
            request.Free = true;
            request.Description = "Let's you put data in your database!";
            request.ServiceGuid = new Guid("907897d8-6480-4570-ac09-7db78cfcb61d");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
