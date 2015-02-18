using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class SharedDomainsTest
    {

    
        [TestMethod]
        public void TestCreateSharedDomainRequest()
        {
            string json = @"{
  ""name"": ""example.com""
}";
        
            CreateSharedDomainRequest request = new CreateSharedDomainRequest();
       
            request.Name = "example.com";
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
