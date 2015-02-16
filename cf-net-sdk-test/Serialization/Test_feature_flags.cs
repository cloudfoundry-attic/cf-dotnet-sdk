using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class FeatureFlagsTest
    {

    
        [TestMethod]
        public void TestSetFeatureFlagRequest()
        {
            string json = @"{
  ""enabled"": true
}";
            SetFeatureFlagRequest request = new SetFeatureFlagRequest();
       
            request.Enabled = true;
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
