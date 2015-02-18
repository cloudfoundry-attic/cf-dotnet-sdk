using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class OrganizationsTest
    {

    
        [TestMethod]
        public void TestCreateOrganizationRequest()
        {
            string json = @"{
  ""name"": ""my-org-name"",
  ""quota_definition_guid"": ""d1d8ff79-656c-4579-8ed4-cc96e7f4cb52""
}";
        
            CreateOrganizationRequest request = new CreateOrganizationRequest();
       
            request.Name = "my-org-name";
            request.QuotaDefinitionGuid = new Guid("d1d8ff79-656c-4579-8ed4-cc96e7f4cb52");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateOrganizationRequest()
        {
            string json = @"{
  ""name"": ""New Organization Name"",
  ""quota_definition_guid"": ""4526f37c-ab2d-4525-b643-957f3fe0e494""
}";
        
            UpdateOrganizationRequest request = new UpdateOrganizationRequest();
       
            request.Name = "New Organization Name";
            request.QuotaDefinitionGuid = new Guid("4526f37c-ab2d-4525-b643-957f3fe0e494");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
