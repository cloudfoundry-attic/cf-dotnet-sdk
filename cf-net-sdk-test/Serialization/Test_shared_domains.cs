using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
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
