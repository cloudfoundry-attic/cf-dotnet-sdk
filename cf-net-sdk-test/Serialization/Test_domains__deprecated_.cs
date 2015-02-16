using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class DomainsDeprecatedTest
    {

    
        [TestMethod]
        public void TestCreatesDomainOwnedByGivenOrganizationDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""exmaple.com"",
  ""wildcard"": true,
  ""owning_organization_guid"": ""3888312a-9b88-4e22-87b6-a408f4f76cd7""
}";
            CreatesDomainOwnedByGivenOrganizationDeprecatedRequest request = new CreatesDomainOwnedByGivenOrganizationDeprecatedRequest();
       
            request.Name = "exmaple.com";
            request.Wildcard = true;
            request.OwningOrganizationGuid = new Guid("3888312a-9b88-4e22-87b6-a408f4f76cd7");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreatesSharedDomainDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""example.com"",
  ""wildcard"": true
}";
            CreatesSharedDomainDeprecatedRequest request = new CreatesSharedDomainDeprecatedRequest();
       
            request.Name = "example.com";
            request.Wildcard = true;
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
