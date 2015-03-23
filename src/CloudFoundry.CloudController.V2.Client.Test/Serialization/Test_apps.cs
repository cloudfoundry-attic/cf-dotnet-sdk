//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//
// This source code was auto-generated by cf-sdk-builder
//

using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.V2.Test.Serialization
{
    [TestClass]
    [GeneratedCodeAttribute("cf-sdk-builder", "1.0.0.0")]
    public class AppsTest
    {

        [TestMethod]
        public void TestCopyAppBitsForAppRequest()
        {
            string json = @"{""source_app_guid"":""87921368-772f-4a51-82e8-7c371c0a6f60""}";

            CopyAppBitsForAppRequest request = new CopyAppBitsForAppRequest();

            request.SourceAppGuid = new Guid("87921368-772f-4a51-82e8-7c371c0a6f60");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(TestUtil.ToUnformatedJsonString(json), result);
        }
        [TestMethod]
        public void TestCreateAppRequest()
        {
            string json = @"{
  ""name"": ""my_super_app"",
  ""space_guid"": ""f3e46394-d748-4cb7-be23-432facf83ce2""
}";

            CreateAppRequest request = new CreateAppRequest();

            request.Name = "my_super_app";
            request.SpaceGuid = new Guid("f3e46394-d748-4cb7-be23-432facf83ce2");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(TestUtil.ToUnformatedJsonString(json), result);
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
            Assert.AreEqual(TestUtil.ToUnformatedJsonString(json), result);
        }
        [TestMethod]
        public void TestCreateDockerAppExperimentalRequest()
        {
            string json = @"{
  ""name"": ""docker_app"",
  ""space_guid"": ""b6aded2c-2836-4116-a494-bf2a611e160f"",
  ""docker_image"": ""cloudfoundry/hello"",
  ""environment_json"": {
    ""DIEGO_STAGE_BETA"": ""true"",
    ""DIEGO_RUN_BETA"": ""true""
  }
}";

            CreateDockerAppExperimentalRequest request = new CreateDockerAppExperimentalRequest();

            request.Name = "docker_app";
            request.SpaceGuid = new Guid("b6aded2c-2836-4116-a494-bf2a611e160f");
            request.DockerImage = "cloudfoundry/hello";
            request.EnvironmentJson = TestUtil.GetJsonDictonary(@"{""DIEGO_STAGE_BETA"":""true"",""DIEGO_RUN_BETA"":""true""}");

            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(TestUtil.ToUnformatedJsonString(json), result);
        }
    }
}
