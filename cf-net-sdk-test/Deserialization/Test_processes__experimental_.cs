using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class ProcessesExperimentalTest
    {

    
        [TestMethod]
        public void TestCreateDockerProcessRequest()
        {
            string json = @"{
  ""name"": ""process"",
  ""memory"": 256,
  ""instances"": 2,
  ""disk_quota"": 1024,
  ""space_guid"": ""4ee37a38-ec2e-45dd-8a27-5b29d8f55ee5"",
  ""stack_guid"": ""383a0dde-71ac-4372-b6a6-18c13777dc0a"",
  ""docker_image"": ""cloudfoundry/hello"",
  ""environment_json"": {
    ""CF_DIEGO_BETA"": ""true"",
    ""CF_DIEGO_RUN_BETA"": ""true""
  }
}";
    
            CreateDockerProcessRequest obj = Util.DeserializeJson<CreateDockerProcessRequest>(json);
        
            Assert.AreEqual("process", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("256", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("2", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("4ee37a38-ec2e-45dd-8a27-5b29d8f55ee5", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("383a0dde-71ac-4372-b6a6-18c13777dc0a", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("cloudfoundry/hello", TestUtil.ToTestableString(obj.DockerImage), true);
            
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

    
        [TestMethod]
        public void TestUpdateProcessRequest()
        {
            string json = @"{
  ""name"": ""new_name"",
  ""memory"": 2555,
  ""instances"": 2,
  ""disk_quota"": 2048,
  ""space_guid"": ""1f208528-e4bf-49a6-aec7-5ada746381d8"",
  ""stack_guid"": ""e42d88b0-1cc1-4b60-b34c-3442d90ba368""
}";
    
            UpdateProcessRequest obj = Util.DeserializeJson<UpdateProcessRequest>(json);
        
            Assert.AreEqual("new_name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("2555", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("2", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("2048", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("1f208528-e4bf-49a6-aec7-5ada746381d8", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("e42d88b0-1cc1-4b60-b34c-3442d90ba368", TestUtil.ToTestableString(obj.StackGuid), true);
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
        public void TestCreateProcessRequest()
        {
            string json = @"{
  ""name"": ""process"",
  ""memory"": 256,
  ""instances"": 2,
  ""disk_quota"": 1024,
  ""space_guid"": ""b67b8087-3713-49dd-89ff-a60616818eb5"",
  ""stack_guid"": ""90adb232-b3c0-486a-9887-681dfe0c9cb7""
}";
    
            CreateProcessRequest obj = Util.DeserializeJson<CreateProcessRequest>(json);
        
            Assert.AreEqual("process", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("256", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("2", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("b67b8087-3713-49dd-89ff-a60616818eb5", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("90adb232-b3c0-486a-9887-681dfe0c9cb7", TestUtil.ToTestableString(obj.StackGuid), true);
        }

    
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

    }
}
