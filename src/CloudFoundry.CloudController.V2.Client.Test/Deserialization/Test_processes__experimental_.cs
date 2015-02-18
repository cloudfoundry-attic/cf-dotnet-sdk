using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class ProcessesExperimentalTest
    {

    
        [TestMethod]
        public void TestCreateProcessResponse()
        {
            string json = @"{
  ""guid"": ""eb15629a-0d84-4144-805e-9225e0f99c4d""
}";
    
            CreateProcessResponse obj = Util.DeserializeJson<CreateProcessResponse>(json);
        
            Assert.AreEqual("eb15629a-0d84-4144-805e-9225e0f99c4d", TestUtil.ToTestableString(obj.Guid), true);
        }

    
        [TestMethod]
        public void TestGetProcessResponse()
        {
            string json = @"{
  ""guid"": ""4ac1f512-0074-42b4-a9a7-b30fdbf08074""
}";
    
            GetProcessResponse obj = Util.DeserializeJson<GetProcessResponse>(json);
        
            Assert.AreEqual("4ac1f512-0074-42b4-a9a7-b30fdbf08074", TestUtil.ToTestableString(obj.Guid), true);
        }

    
        [TestMethod]
        public void TestUpdateProcessResponse()
        {
            string json = @"{
  ""guid"": ""5f637d60-ed0d-4818-a730-824988bdbae0""
}";
    
            UpdateProcessResponse obj = Util.DeserializeJson<UpdateProcessResponse>(json);
        
            Assert.AreEqual("5f637d60-ed0d-4818-a730-824988bdbae0", TestUtil.ToTestableString(obj.Guid), true);
        }

    
        [TestMethod]
        public void TestCreateDockerProcessResponse()
        {
            string json = @"{
  ""guid"": ""87b30ef8-c616-4023-8de1-2b90f37ef352""
}";
    
            CreateDockerProcessResponse obj = Util.DeserializeJson<CreateDockerProcessResponse>(json);
        
            Assert.AreEqual("87b30ef8-c616-4023-8de1-2b90f37ef352", TestUtil.ToTestableString(obj.Guid), true);
        }

    }
}
