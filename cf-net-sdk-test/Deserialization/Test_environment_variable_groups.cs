using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class EnvironmentVariableGroupsTest
    {

    
        [TestMethod]
        public void TestGettingContentsOfRunningEnvironmentVariableGroupResponse()
        {
            string json = @"{
  ""abc"": 123,
  ""do-re-me"": ""far-so-la-tee""
}";
    
            GettingContentsOfRunningEnvironmentVariableGroupResponse obj = Util.DeserializeJson<GettingContentsOfRunningEnvironmentVariableGroupResponse>(json);
        
            Assert.AreEqual("123", TestUtil.ToTestableString(obj.Abc), true);
            Assert.AreEqual("far-so-la-tee", TestUtil.ToTestableString(obj.Doreme), true);
        }

    
        [TestMethod]
        public void TestUpdateContentsOfRunningEnvironmentVariableGroupResponse()
        {
            string json = @"{
  ""abc"": 123,
  ""do-re-me"": ""far-so-la-tee""
}";
    
            UpdateContentsOfRunningEnvironmentVariableGroupResponse obj = Util.DeserializeJson<UpdateContentsOfRunningEnvironmentVariableGroupResponse>(json);
        
            Assert.AreEqual("123", TestUtil.ToTestableString(obj.Abc), true);
            Assert.AreEqual("far-so-la-tee", TestUtil.ToTestableString(obj.Doreme), true);
        }

    
        [TestMethod]
        public void TestUpdateContentsOfStagingEnvironmentVariableGroupResponse()
        {
            string json = @"{
  ""abc"": 123,
  ""do-re-me"": ""far-so-la-tee""
}";
    
            UpdateContentsOfStagingEnvironmentVariableGroupResponse obj = Util.DeserializeJson<UpdateContentsOfStagingEnvironmentVariableGroupResponse>(json);
        
            Assert.AreEqual("123", TestUtil.ToTestableString(obj.Abc), true);
            Assert.AreEqual("far-so-la-tee", TestUtil.ToTestableString(obj.Doreme), true);
        }

    
        [TestMethod]
        public void TestGettingContentsOfStagingEnvironmentVariableGroupResponse()
        {
            string json = @"{
  ""abc"": 123,
  ""do-re-me"": ""far-so-la-tee""
}";
    
            GettingContentsOfStagingEnvironmentVariableGroupResponse obj = Util.DeserializeJson<GettingContentsOfStagingEnvironmentVariableGroupResponse>(json);
        
            Assert.AreEqual("123", TestUtil.ToTestableString(obj.Abc), true);
            Assert.AreEqual("far-so-la-tee", TestUtil.ToTestableString(obj.Doreme), true);
        }

    }
}
