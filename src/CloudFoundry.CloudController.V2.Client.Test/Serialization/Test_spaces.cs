using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class SpacesTest
    {

    
        [TestMethod]
        public void TestUpdateSpaceRequest()
        {
            string json = @"{
  ""name"": ""New Space Name""
}";
        
            UpdateSpaceRequest request = new UpdateSpaceRequest();
       
            request.Name = "New Space Name";
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateSpaceRequest()
        {
            string json = @"{
  ""name"": ""development"",
  ""organization_guid"": ""a6171605-6688-418f-acb0-222a115f36bd""
}";
        
            CreateSpaceRequest request = new CreateSpaceRequest();
       
            request.Name = "development";
            request.OrganizationGuid = new Guid("a6171605-6688-418f-acb0-222a115f36bd");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
