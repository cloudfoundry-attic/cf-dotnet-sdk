using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class ResourceMatchTest
    {

    
        [TestMethod]
        public void TestListAllMatchingResourcesResponse()
        {
            string json = @"[{""sha1"":""0427f4582427bc03e9b964d8ffe89874f461df3d"",""size"":36}]";
    
        ListAllMatchingResourcesResponse[] obj = Util.DeserializeJson<ListAllMatchingResourcesResponse[]>(json);
        
            
        Assert.AreEqual("0427f4582427bc03e9b964d8ffe89874f461df3d", TestUtil.ToTestableString(obj[0].Sha1), true);
        Assert.AreEqual("36", TestUtil.ToTestableString(obj[0].Size), true);
        
    
        }

    }
}
