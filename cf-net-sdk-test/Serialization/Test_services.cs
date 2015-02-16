using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class ServicesTest
    {

    
        [TestMethod]
        public void TestCreateServiceDeprecatedRequest()
        {
            string json = @"{
  ""label"": ""SomeMysqlService"",
  ""description"": ""Mysql stores things for you"",
  ""provider"": ""MySql Provider"",
  ""version"": ""2.0"",
  ""url"": ""http://myql.provider.com""
}";
            CreateServiceDeprecatedRequest request = new CreateServiceDeprecatedRequest();
       
            request.Label = "SomeMysqlService";
            request.Description = "Mysql stores things for you";
            request.Provider = "MySql Provider";
            request.Version = "2.0";
            request.Url = "http://myql.provider.com";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateServiceDeprecatedRequest()
        {
            string json = @"{
  ""label"": ""SomeMysqlService"",
  ""description"": ""Mysql stores things for you"",
  ""provider"": ""MySql Provider"",
  ""version"": ""2.0"",
  ""url"": ""http://myql.provider.com""
}";
            UpdateServiceDeprecatedRequest request = new UpdateServiceDeprecatedRequest();
       
            request.Label = "SomeMysqlService";
            request.Description = "Mysql stores things for you";
            request.Provider = "MySql Provider";
            request.Version = "2.0";
            request.Url = "http://myql.provider.com";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
