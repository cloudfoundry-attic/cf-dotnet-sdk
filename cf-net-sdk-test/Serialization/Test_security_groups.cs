using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class SecurityGroupsTest
    {

    
        [TestMethod]
        public void TestUpdateSecurityGroupRequest()
        {
            string json = @"{
  ""name"": ""new_name"",
  ""rules"": [

  ]
}";
            UpdateSecurityGroupRequest request = new UpdateSecurityGroupRequest();
       
            request.Name = "new_name";
            request.Rules = Array.ConvertAll(TestUtil.GetJsonArray(@"[]"), (p => (Dictionary<string, dynamic>)p));
         
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateSecurityGroupRequest()
        {
            string json = @"{
  ""name"": ""my_super_sec_group"",
  ""rules"": [
    {
      ""protocol"": ""icmp"",
      ""destination"": ""0.0.0.0/0"",
      ""type"": 0,
      ""code"": 1
    },
    {
      ""protocol"": ""tcp"",
      ""destination"": ""0.0.0.0/0"",
      ""ports"": ""2048-3000"",
      ""log"": true
    },
    {
      ""protocol"": ""udp"",
      ""destination"": ""0.0.0.0/0"",
      ""ports"": ""53, 5353""
    },
    {
      ""protocol"": ""all"",
      ""destination"": ""0.0.0.0/0""
    }
  ]
}";
            CreateSecurityGroupRequest request = new CreateSecurityGroupRequest();
       
            request.Name = "my_super_sec_group";
            request.Rules = Array.ConvertAll(TestUtil.GetJsonArray(@"[{""protocol"":""icmp"",""destination"":""0.0.0.0/0"",""type"":0,""code"":1},{""protocol"":""tcp"",""destination"":""0.0.0.0/0"",""ports"":""2048-3000"",""log"":true},{""protocol"":""udp"",""destination"":""0.0.0.0/0"",""ports"":""53, 5353""},{""protocol"":""all"",""destination"":""0.0.0.0/0""}]"), (p => (Dictionary<string, dynamic>)p));
         
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
