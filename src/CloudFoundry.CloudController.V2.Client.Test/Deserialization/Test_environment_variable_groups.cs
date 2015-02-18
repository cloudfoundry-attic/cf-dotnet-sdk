using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
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
