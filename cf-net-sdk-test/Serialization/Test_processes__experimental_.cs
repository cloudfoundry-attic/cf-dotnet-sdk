using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class ProcessesExperimentalTest
    {

    
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
            CreateProcessRequest request = new CreateProcessRequest();
       
            request.Name = "process";
            request.Memory = 256;
            request.Instances = 2;
            request.DiskQuota = 1024;
            request.SpaceGuid = new Guid("b67b8087-3713-49dd-89ff-a60616818eb5");
            request.StackGuid = new Guid("90adb232-b3c0-486a-9887-681dfe0c9cb7");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
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
            UpdateProcessRequest request = new UpdateProcessRequest();
       
            request.Name = "new_name";
            request.Memory = 2555;
            request.Instances = 2;
            request.DiskQuota = 2048;
            request.SpaceGuid = new Guid("1f208528-e4bf-49a6-aec7-5ada746381d8");
            request.StackGuid = new Guid("e42d88b0-1cc1-4b60-b34c-3442d90ba368");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
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
            CreateDockerProcessRequest request = new CreateDockerProcessRequest();
       
            request.Name = "process";
            request.Memory = 256;
            request.Instances = 2;
            request.DiskQuota = 1024;
            request.SpaceGuid = new Guid("4ee37a38-ec2e-45dd-8a27-5b29d8f55ee5");
            request.StackGuid = new Guid("383a0dde-71ac-4372-b6a6-18c13777dc0a");
            request.DockerImage = "cloudfoundry/hello";
            request.EnvironmentJson = TestUtil.GetJsonDictonary(@"{""CF_DIEGO_BETA"":""true"",""CF_DIEGO_RUN_BETA"":""true""}");
         
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
