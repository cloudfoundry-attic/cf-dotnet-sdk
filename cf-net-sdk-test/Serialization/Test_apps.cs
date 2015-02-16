using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class AppsTest
    {

    
        [TestMethod]
        public void TestCopyAppBitsForAppExperimentalRequest()
        {
            string json = @"{""source_app_guid"":""e8ecabe0-502c-4a26-8b25-482f9a084d65""}";
            CopyAppBitsForAppExperimentalRequest request = new CopyAppBitsForAppExperimentalRequest();
       
            request.SourceAppGuid = new Guid("e8ecabe0-502c-4a26-8b25-482f9a084d65");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateAppRequest()
        {
            string json = @"{
  ""name"": ""my_super_app"",
  ""memory"": 1024,
  ""instances"": 2,
  ""disk_quota"": 1204,
  ""space_guid"": ""cfa396a7-76dc-491c-8eab-d922227d495b""
}";
            CreateAppRequest request = new CreateAppRequest();
       
            request.Name = "my_super_app";
            request.Memory = 1024;
            request.Instances = 2;
            request.DiskQuota = 1204;
            request.SpaceGuid = new Guid("cfa396a7-76dc-491c-8eab-d922227d495b");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateDockerAppExperimentalRequest()
        {
            string json = @"{
  ""name"": ""docker_app"",
  ""memory"": 1024,
  ""instances"": 2,
  ""disk_quota"": 1204,
  ""space_guid"": ""6d798f83-dd97-4c99-a9a8-ea8e021236c3"",
  ""docker_image"": ""cloudfoundry/hello"",
  ""environment_json"": {
    ""DIEGO_STAGE_BETA"": ""true"",
    ""DIEGO_RUN_BETA"": ""true""
  }
}";
            CreateDockerAppExperimentalRequest request = new CreateDockerAppExperimentalRequest();
       
            request.Name = "docker_app";
            request.Memory = 1024;
            request.Instances = 2;
            request.DiskQuota = 1204;
            request.SpaceGuid = new Guid("6d798f83-dd97-4c99-a9a8-ea8e021236c3");
            request.DockerImage = "cloudfoundry/hello";
            request.EnvironmentJson = TestUtil.GetJsonDictonary(@"{""DIEGO_STAGE_BETA"":""true"",""DIEGO_RUN_BETA"":""true""}");
         
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestUpdateAppRequest()
        {
            string json = @"{
  ""name"": ""new_name""
}";
            UpdateAppRequest request = new UpdateAppRequest();
       
            request.Name = "new_name";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
