using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class EnvironmentVariableGroupsTest
    {

    
        [TestMethod]
        public void TestUpdateContentsOfRunningEnvironmentVariableGroupRequest()
        {
            string json = @"{
  ""abc"": 123,
  ""do-re-me"": ""far-so-la-tee""
}";
            UpdateContentsOfRunningEnvironmentVariableGroupRequest request = new UpdateContentsOfRunningEnvironmentVariableGroupRequest();
       
            request.Abc = 123;
            request.Doreme = "far-so-la-tee";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateContentsOfStagingEnvironmentVariableGroupRequest()
        {
            string json = @"{
  ""abc"": 123,
  ""do-re-me"": ""far-so-la-tee""
}";
            UpdateContentsOfStagingEnvironmentVariableGroupRequest request = new UpdateContentsOfStagingEnvironmentVariableGroupRequest();
       
            request.Abc = 123;
            request.Doreme = "far-so-la-tee";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
