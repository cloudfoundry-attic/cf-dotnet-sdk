using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class BuildpacksTest
    {

    
        [TestMethod]
        public void TestEnableOrDisableBuildpackRequest()
        {
            string json = @"{
  ""enabled"": false
}";
            EnableOrDisableBuildpackRequest request = new EnableOrDisableBuildpackRequest();
       
            request.Enabled = false;
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreatesAdminBuildpackRequest()
        {
            string json = @"{
  ""name"": ""Golang_buildpack""
}";
            CreatesAdminBuildpackRequest request = new CreatesAdminBuildpackRequest();
       
            request.Name = "Golang_buildpack";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestChangePositionOfBuildpackRequest()
        {
            string json = @"{
  ""position"": 3
}";
            ChangePositionOfBuildpackRequest request = new ChangePositionOfBuildpackRequest();
       
            request.Position = 3;
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestLockOrUnlockBuildpackRequest()
        {
            string json = @"{
  ""locked"": true
}";
            LockOrUnlockBuildpackRequest request = new LockOrUnlockBuildpackRequest();
       
            request.Locked = true;
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
