using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class ServiceBrokersTest
    {

    
        [TestMethod]
        public void TestCreateServiceBrokerRequest()
        {
            string json = @"{
  ""name"": ""service-broker-name"",
  ""broker_url"": ""https://broker.example.com"",
  ""auth_username"": ""admin"",
  ""auth_password"": ""secretpassw0rd""
}";
        
            CreateServiceBrokerRequest request = new CreateServiceBrokerRequest();
       
            request.Name = "service-broker-name";
            request.BrokerUrl = "https://broker.example.com";
            request.AuthUsername = "admin";
            request.AuthPassword = "secretpassw0rd";
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateServiceBrokerRequest()
        {
            string json = @"{
  ""name"": ""service-broker-name"",
  ""broker_url"": ""https://broker.example.com"",
  ""auth_username"": ""admin"",
  ""auth_password"": ""secretpassw0rd""
}";
        
            UpdateServiceBrokerRequest request = new UpdateServiceBrokerRequest();
       
            request.Name = "service-broker-name";
            request.BrokerUrl = "https://broker.example.com";
            request.AuthUsername = "admin";
            request.AuthPassword = "secretpassw0rd";
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
