using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    public class ResourceMatchTest
    {

    
        [TestMethod]
        public void TestListAllMatchingResourcesRequest()
        {
            string json = @"[
  {
    ""sha1"": ""0427f4582427bc03e9b964d8ffe89874f461df3d"",
    ""size"": 36
  },
  {
    ""sha1"": ""a9993e364706816aba3e25717850c26c9cd0d89d"",
    ""size"": 1
  }
]";
        
            ListAllMatchingResourcesRequest[] request = new ListAllMatchingResourcesRequest[2];
            
            
                    request[0].Sha1 = "0427f4582427bc03e9b964d8ffe89874f461df3d";
                    request[0].Size = 36;
            
            
                    request[1].Sha1 = "a9993e364706816aba3e25717850c26c9cd0d89d";
                    request[1].Size = 1;
            
        
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
