using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class RoutesTest
    {

    
        [TestMethod]
        public void TestUpdateRouteRequest()
        {
            string json = @"{
  ""host"": ""new_host""
}";
        
            UpdateRouteRequest request = new UpdateRouteRequest();
       
            request.Host = "new_host";
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateRouteRequest()
        {
            string json = @"{
  ""domain_guid"": ""f1f7f32d-ae3d-4d9c-b1a3-37e2d0118d08"",
  ""space_guid"": ""b61a1218-b3d8-4f94-8134-aecb89079834""
}";
        
            CreateRouteRequest request = new CreateRouteRequest();
       
            request.DomainGuid = new Guid("f1f7f32d-ae3d-4d9c-b1a3-37e2d0118d08");
            request.SpaceGuid = new Guid("b61a1218-b3d8-4f94-8134-aecb89079834");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
