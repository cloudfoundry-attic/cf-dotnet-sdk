using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
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
