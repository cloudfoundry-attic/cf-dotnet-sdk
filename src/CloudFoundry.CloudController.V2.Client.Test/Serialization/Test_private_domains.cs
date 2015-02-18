using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class PrivateDomainsTest
    {

    
        [TestMethod]
        public void TestCreatePrivateDomainOwnedByGivenOrganizationRequest()
        {
            string json = @"{
  ""name"": ""exmaple.com"",
  ""owning_organization_guid"": ""40b0d85e-db8c-4532-a00d-96398c2dc6ba""
}";
        
            CreatePrivateDomainOwnedByGivenOrganizationRequest request = new CreatePrivateDomainOwnedByGivenOrganizationRequest();
       
            request.Name = "exmaple.com";
            request.OwningOrganizationGuid = new Guid("40b0d85e-db8c-4532-a00d-96398c2dc6ba");
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
