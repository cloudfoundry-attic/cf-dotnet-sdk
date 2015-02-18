using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class UserProvidedServiceInstancesTest
    {

    
        [TestMethod]
        public void TestCreateUserProvidedServiceInstanceRequest()
        {
            string json = @"{
  ""space_guid"": ""bf4f67a6-9508-4377-a676-987238f30654"",
  ""name"": ""my-user-provided-instance"",
  ""credentials"": {
    ""somekey"": ""somevalue""
  },
  ""syslog_drain_url"": ""syslog://example.com""
}";
        
            CreateUserProvidedServiceInstanceRequest request = new CreateUserProvidedServiceInstanceRequest();
       
            request.SpaceGuid = new Guid("bf4f67a6-9508-4377-a676-987238f30654");
            request.Name = "my-user-provided-instance";
            request.Credentials = TestUtil.GetJsonDictonary(@"{""somekey"":""somevalue""}");
         
            request.SyslogDrainUrl = "syslog://example.com";
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateUserProvidedServiceInstanceRequest()
        {
            string json = @"{
  ""credentials"": {
    ""somekey"": ""somenewvalue""
  }
}";
        
            UpdateUserProvidedServiceInstanceRequest request = new UpdateUserProvidedServiceInstanceRequest();
       
            request.Credentials = TestUtil.GetJsonDictonary(@"{""somekey"":""somenewvalue""}");
         
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
