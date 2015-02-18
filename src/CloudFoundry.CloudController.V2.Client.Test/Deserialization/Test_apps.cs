using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class AppsTest
    {

    
        [TestMethod]
        public void TestGetInstanceInformationForStartedAppResponse()
        {
            string json = @"{""0"":{""state"":""RUNNING"",""since"":1403140717.984577,""debug_ip"":null,""debug_port"":null,""console_ip"":null,""console_port"":null}}";
    
            GetInstanceInformationForStartedAppResponse obj = Util.DeserializeJson<GetInstanceInformationForStartedAppResponse>(json);
        
            
        }

    
        [TestMethod]
        public void TestRestageAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""93affb5c-9295-4399-b2f2-c72df6d5e056"",
    ""url"": ""/v2/apps/93affb5c-9295-4399-b2f2-c72df6d5e056"",
    ""created_at"": ""2014-11-12T12:59:38+02:00"",
    ""updated_at"": ""2014-11-12T12:59:38+02:00""
  },
  ""entity"": {
    ""name"": ""name-808"",
    ""production"": false,
    ""space_guid"": ""d3074e8c-1280-4642-a247-d315767cc37a"",
    ""stack_guid"": ""4cedc453-f356-4f42-9be7-43917085ee18"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": null,
    ""memory"": 1024,
    ""instances"": 1,
    ""disk_quota"": 1024,
    ""state"": ""STARTED"",
    ""version"": ""485d2d74-3568-4bb1-b2ed-d607bdd362a5"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": ""2014-11-12T12:59:38+02:00"",
    ""detected_start_command"": """"
  }
}";
    
            RestageAppResponse obj = Util.DeserializeJson<RestageAppResponse>(json);
        
            Assert.AreEqual("93affb5c-9295-4399-b2f2-c72df6d5e056", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/93affb5c-9295-4399-b2f2-c72df6d5e056", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-808", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("d3074e8c-1280-4642-a247-d315767cc37a", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("4cedc453-f356-4f42-9be7-43917085ee18", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STARTED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("485d2d74-3568-4bb1-b2ed-d607bdd362a5", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            
            
        }

    
        [TestMethod]
        public void TestGetEnvForAppResponse()
        {
            string json = @"{
  ""staging_env_json"": {
    ""STAGING_ENV"": ""staging_value""
  },
  ""running_env_json"": {
    ""RUNNING_ENV"": ""running_value""
  },
  ""environment_json"": {
    ""env_var"": ""env_val""
  },
  ""system_env_json"": {
    ""VCAP_SERVICES"": {

    }
  },
  ""application_env_json"": {
    ""VCAP_APPLICATION"": {
      ""limits"": {
        ""mem"": 1024,
        ""disk"": 1024,
        ""fds"": 16384
      },
      ""application_version"": ""30538d3e-64db-45a8-b0bc-d49ea25a4e65"",
      ""application_name"": ""name-117"",
      ""application_uris"": [

      ],
      ""version"": ""30538d3e-64db-45a8-b0bc-d49ea25a4e65"",
      ""name"": ""name-117"",
      ""space_name"": ""name-118"",
      ""space_id"": ""fd89b65d-4d27-401b-842c-8416baae7a5c"",
      ""uris"": [

      ],
      ""users"": null
    }
  }
}";
    
            GetEnvForAppResponse obj = Util.DeserializeJson<GetEnvForAppResponse>(json);
        
            
            
            
            
            
        }

    
        [TestMethod]
        public void TestRetrieveAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""30c47909-d693-4c6b-8195-d9afb7c1ea93"",
    ""url"": ""/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93"",
    ""created_at"": ""2014-11-12T12:59:20+02:00"",
    ""updated_at"": ""2014-11-12T12:59:21+02:00""
  },
  ""entity"": {
    ""name"": ""name-87"",
    ""production"": false,
    ""space_guid"": ""cabdb263-7fc5-4271-89d5-1c97d110549f"",
    ""stack_guid"": ""eceddb9c-f99a-4985-97b2-6058916f55dd"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": null,
    ""memory"": 1024,
    ""instances"": 1,
    ""disk_quota"": 1024,
    ""state"": ""STOPPED"",
    ""version"": ""19e4b295-3f47-4d3e-ab2e-e1e9a367bf72"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": ""2014-11-12T12:59:20+02:00"",
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/cabdb263-7fc5-4271-89d5-1c97d110549f"",
    ""stack_url"": ""/v2/stacks/eceddb9c-f99a-4985-97b2-6058916f55dd"",
    ""events_url"": ""/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93/events"",
    ""service_bindings_url"": ""/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93/service_bindings"",
    ""routes_url"": ""/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93/routes""
  }
}";
    
            RetrieveAppResponse obj = Util.DeserializeJson<RetrieveAppResponse>(json);
        
            Assert.AreEqual("30c47909-d693-4c6b-8195-d9afb7c1ea93", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:20+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:21+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-87", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("cabdb263-7fc5-4271-89d5-1c97d110549f", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("eceddb9c-f99a-4985-97b2-6058916f55dd", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("19e4b295-3f47-4d3e-ab2e-e1e9a367bf72", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:20+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/cabdb263-7fc5-4271-89d5-1c97d110549f", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/eceddb9c-f99a-4985-97b2-6058916f55dd", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/30c47909-d693-4c6b-8195-d9afb7c1ea93/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCopyAppBitsForAppExperimentalResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""4e0c6f66-171c-4784-8553-bc5e974f50c0"",
    ""created_at"": ""2014-11-12T12:59:29+02:00"",
    ""url"": ""/v2/jobs/4e0c6f66-171c-4784-8553-bc5e974f50c0""
  },
  ""entity"": {
    ""guid"": ""4e0c6f66-171c-4784-8553-bc5e974f50c0"",
    ""status"": ""queued""
  }
}";
    
            CopyAppBitsForAppExperimentalResponse obj = Util.DeserializeJson<CopyAppBitsForAppExperimentalResponse>(json);
        
            Assert.AreEqual("4e0c6f66-171c-4784-8553-bc5e974f50c0", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("/v2/jobs/4e0c6f66-171c-4784-8553-bc5e974f50c0", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("4e0c6f66-171c-4784-8553-bc5e974f50c0", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("queued", TestUtil.ToTestableString(obj.Status), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllAppsResponse()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""35ffbf52-7be7-40eb-a3a2-c9dde458c0d9"",
        ""url"": ""/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9"",
        ""created_at"": ""2014-11-12T12:59:19+02:00"",
        ""updated_at"": ""2014-11-12T12:59:19+02:00""
      },
      ""entity"": {
        ""name"": ""name-21"",
        ""production"": false,
        ""space_guid"": ""6d14795f-a16d-4ace-aa33-e5b2dcfb5710"",
        ""stack_guid"": ""a0ec29a3-123c-4999-8cc1-68e89612d490"",
        ""buildpack"": null,
        ""detected_buildpack"": null,
        ""environment_json"": null,
        ""memory"": 1024,
        ""instances"": 1,
        ""disk_quota"": 1024,
        ""state"": ""STOPPED"",
        ""version"": ""b43870fa-f2bd-44b4-b816-f796d95ad504"",
        ""command"": null,
        ""console"": false,
        ""debug"": null,
        ""staging_task_id"": null,
        ""package_state"": ""PENDING"",
        ""health_check_timeout"": null,
        ""staging_failed_reason"": null,
        ""docker_image"": null,
        ""package_updated_at"": ""2014-11-12T12:59:19+02:00"",
        ""detected_start_command"": """",
        ""space_url"": ""/v2/spaces/6d14795f-a16d-4ace-aa33-e5b2dcfb5710"",
        ""stack_url"": ""/v2/stacks/a0ec29a3-123c-4999-8cc1-68e89612d490"",
        ""events_url"": ""/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9/events"",
        ""service_bindings_url"": ""/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9/service_bindings"",
        ""routes_url"": ""/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9/routes""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""504d4c61-e954-4c1a-b7b2-bc447adc7a5c"",
        ""url"": ""/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c"",
        ""created_at"": ""2014-11-12T12:59:19+02:00"",
        ""updated_at"": ""2014-11-12T12:59:19+02:00""
      },
      ""entity"": {
        ""name"": ""name-26"",
        ""production"": false,
        ""space_guid"": ""f6de2ced-95ef-49be-9e36-0de52fa36ae3"",
        ""stack_guid"": ""a37804ac-9091-4cf7-b064-1d66c87a3360"",
        ""buildpack"": null,
        ""detected_buildpack"": null,
        ""environment_json"": null,
        ""memory"": 1024,
        ""instances"": 1,
        ""disk_quota"": 1024,
        ""state"": ""STOPPED"",
        ""version"": ""613bbdf2-366e-4ab9-948e-5b392e0c963b"",
        ""command"": null,
        ""console"": false,
        ""debug"": null,
        ""staging_task_id"": null,
        ""package_state"": ""PENDING"",
        ""health_check_timeout"": null,
        ""staging_failed_reason"": null,
        ""docker_image"": null,
        ""package_updated_at"": ""2014-11-12T12:59:19+02:00"",
        ""detected_start_command"": """",
        ""space_url"": ""/v2/spaces/f6de2ced-95ef-49be-9e36-0de52fa36ae3"",
        ""stack_url"": ""/v2/stacks/a37804ac-9091-4cf7-b064-1d66c87a3360"",
        ""events_url"": ""/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c/events"",
        ""service_bindings_url"": ""/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c/service_bindings"",
        ""routes_url"": ""/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c/routes""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""882e9d7d-bacc-44fc-ae14-b2eb65b30112"",
        ""url"": ""/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112"",
        ""created_at"": ""2014-11-12T12:59:19+02:00"",
        ""updated_at"": ""2014-11-12T12:59:20+02:00""
      },
      ""entity"": {
        ""name"": ""name-31"",
        ""production"": false,
        ""space_guid"": ""140deca4-2ef0-4a0f-ad64-acae4aa4834a"",
        ""stack_guid"": ""f7249aa5-0e4c-4e6e-be6d-4d48183d1b91"",
        ""buildpack"": null,
        ""detected_buildpack"": null,
        ""environment_json"": null,
        ""memory"": 1024,
        ""instances"": 1,
        ""disk_quota"": 1024,
        ""state"": ""STOPPED"",
        ""version"": ""38311e0c-eee4-4b26-bd29-c897d9181bc9"",
        ""command"": null,
        ""console"": false,
        ""debug"": null,
        ""staging_task_id"": null,
        ""package_state"": ""PENDING"",
        ""health_check_timeout"": null,
        ""staging_failed_reason"": null,
        ""docker_image"": null,
        ""package_updated_at"": ""2014-11-12T12:59:19+02:00"",
        ""detected_start_command"": """",
        ""space_url"": ""/v2/spaces/140deca4-2ef0-4a0f-ad64-acae4aa4834a"",
        ""stack_url"": ""/v2/stacks/f7249aa5-0e4c-4e6e-be6d-4d48183d1b91"",
        ""events_url"": ""/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112/events"",
        ""service_bindings_url"": ""/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112/service_bindings"",
        ""routes_url"": ""/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112/routes""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAppsResponse> page = Util.DeserializePage<ListAllAppsResponse>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("35ffbf52-7be7-40eb-a3a2-c9dde458c0d9", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-21", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Production), true);
                  Assert.AreEqual("6d14795f-a16d-4ace-aa33-e5b2dcfb5710", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("a0ec29a3-123c-4999-8cc1-68e89612d490", TestUtil.ToTestableString(page[0].StackGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Buildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DetectedBuildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].EnvironmentJson), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[0].Memory), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[0].Instances), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[0].DiskQuota), true);
                  Assert.AreEqual("STOPPED", TestUtil.ToTestableString(page[0].State), true);
                  Assert.AreEqual("b43870fa-f2bd-44b4-b816-f796d95ad504", TestUtil.ToTestableString(page[0].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Command), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Console), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Debug), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].StagingTaskId), true);
                  Assert.AreEqual("PENDING", TestUtil.ToTestableString(page[0].PackageState), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].HealthCheckTimeout), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].StagingFailedReason), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DockerImage), true);
                  Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[0].PackageUpdatedAt), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DetectedStartCommand), true);
                  Assert.AreEqual("/v2/spaces/6d14795f-a16d-4ace-aa33-e5b2dcfb5710", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/stacks/a0ec29a3-123c-4999-8cc1-68e89612d490", TestUtil.ToTestableString(page[0].StackUrl), true);
                  Assert.AreEqual("/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
                  Assert.AreEqual("/v2/apps/35ffbf52-7be7-40eb-a3a2-c9dde458c0d9/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
               
               
            
            
                Assert.AreEqual("504d4c61-e954-4c1a-b7b2-bc447adc7a5c", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-26", TestUtil.ToTestableString(page[1].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].Production), true);
                  Assert.AreEqual("f6de2ced-95ef-49be-9e36-0de52fa36ae3", TestUtil.ToTestableString(page[1].SpaceGuid), true);
                  Assert.AreEqual("a37804ac-9091-4cf7-b064-1d66c87a3360", TestUtil.ToTestableString(page[1].StackGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].Buildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].DetectedBuildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].EnvironmentJson), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[1].Memory), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[1].Instances), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[1].DiskQuota), true);
                  Assert.AreEqual("STOPPED", TestUtil.ToTestableString(page[1].State), true);
                  Assert.AreEqual("613bbdf2-366e-4ab9-948e-5b392e0c963b", TestUtil.ToTestableString(page[1].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].Command), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].Console), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].Debug), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].StagingTaskId), true);
                  Assert.AreEqual("PENDING", TestUtil.ToTestableString(page[1].PackageState), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].HealthCheckTimeout), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].StagingFailedReason), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].DockerImage), true);
                  Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[1].PackageUpdatedAt), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].DetectedStartCommand), true);
                  Assert.AreEqual("/v2/spaces/f6de2ced-95ef-49be-9e36-0de52fa36ae3", TestUtil.ToTestableString(page[1].SpaceUrl), true);
                  Assert.AreEqual("/v2/stacks/a37804ac-9091-4cf7-b064-1d66c87a3360", TestUtil.ToTestableString(page[1].StackUrl), true);
                  Assert.AreEqual("/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c/events", TestUtil.ToTestableString(page[1].EventsUrl), true);
                  Assert.AreEqual("/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c/service_bindings", TestUtil.ToTestableString(page[1].ServiceBindingsUrl), true);
                  Assert.AreEqual("/v2/apps/504d4c61-e954-4c1a-b7b2-bc447adc7a5c/routes", TestUtil.ToTestableString(page[1].RoutesUrl), true);
               
               
            
            
                Assert.AreEqual("882e9d7d-bacc-44fc-ae14-b2eb65b30112", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2014-11-12T12:59:20+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-31", TestUtil.ToTestableString(page[2].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[2].Production), true);
                  Assert.AreEqual("140deca4-2ef0-4a0f-ad64-acae4aa4834a", TestUtil.ToTestableString(page[2].SpaceGuid), true);
                  Assert.AreEqual("f7249aa5-0e4c-4e6e-be6d-4d48183d1b91", TestUtil.ToTestableString(page[2].StackGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].Buildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].DetectedBuildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].EnvironmentJson), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[2].Memory), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[2].Instances), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[2].DiskQuota), true);
                  Assert.AreEqual("STOPPED", TestUtil.ToTestableString(page[2].State), true);
                  Assert.AreEqual("38311e0c-eee4-4b26-bd29-c897d9181bc9", TestUtil.ToTestableString(page[2].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].Command), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[2].Console), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].Debug), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].StagingTaskId), true);
                  Assert.AreEqual("PENDING", TestUtil.ToTestableString(page[2].PackageState), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].HealthCheckTimeout), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].StagingFailedReason), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].DockerImage), true);
                  Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[2].PackageUpdatedAt), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[2].DetectedStartCommand), true);
                  Assert.AreEqual("/v2/spaces/140deca4-2ef0-4a0f-ad64-acae4aa4834a", TestUtil.ToTestableString(page[2].SpaceUrl), true);
                  Assert.AreEqual("/v2/stacks/f7249aa5-0e4c-4e6e-be6d-4d48183d1b91", TestUtil.ToTestableString(page[2].StackUrl), true);
                  Assert.AreEqual("/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112/events", TestUtil.ToTestableString(page[2].EventsUrl), true);
                  Assert.AreEqual("/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112/service_bindings", TestUtil.ToTestableString(page[2].ServiceBindingsUrl), true);
                  Assert.AreEqual("/v2/apps/882e9d7d-bacc-44fc-ae14-b2eb65b30112/routes", TestUtil.ToTestableString(page[2].RoutesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreateAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""e7f32731-94fc-4403-9d61-17183912c889"",
    ""url"": ""/v2/apps/e7f32731-94fc-4403-9d61-17183912c889"",
    ""created_at"": ""2014-11-12T12:59:20+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""my_super_app"",
    ""production"": false,
    ""space_guid"": ""cfa396a7-76dc-491c-8eab-d922227d495b"",
    ""stack_guid"": ""0b546dda-cf0e-4a86-a70e-c24368f7d025"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": {

    },
    ""memory"": 1024,
    ""instances"": 2,
    ""disk_quota"": 1204,
    ""state"": ""STOPPED"",
    ""version"": ""2c4778d8-b517-43a2-8df1-38472a8ca4ad"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": null,
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/cfa396a7-76dc-491c-8eab-d922227d495b"",
    ""stack_url"": ""/v2/stacks/0b546dda-cf0e-4a86-a70e-c24368f7d025"",
    ""events_url"": ""/v2/apps/e7f32731-94fc-4403-9d61-17183912c889/events"",
    ""service_bindings_url"": ""/v2/apps/e7f32731-94fc-4403-9d61-17183912c889/service_bindings"",
    ""routes_url"": ""/v2/apps/e7f32731-94fc-4403-9d61-17183912c889/routes""
  }
}";
    
            CreateAppResponse obj = Util.DeserializeJson<CreateAppResponse>(json);
        
            Assert.AreEqual("e7f32731-94fc-4403-9d61-17183912c889", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/e7f32731-94fc-4403-9d61-17183912c889", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:20+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("my_super_app", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("cfa396a7-76dc-491c-8eab-d922227d495b", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("0b546dda-cf0e-4a86-a70e-c24368f7d025", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("2", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1204", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("2c4778d8-b517-43a2-8df1-38472a8ca4ad", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/cfa396a7-76dc-491c-8eab-d922227d495b", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/0b546dda-cf0e-4a86-a70e-c24368f7d025", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/e7f32731-94fc-4403-9d61-17183912c889/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/e7f32731-94fc-4403-9d61-17183912c889/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/e7f32731-94fc-4403-9d61-17183912c889/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestGetAppSummaryResponse()
        {
            string json = @"{""guid"":""dcfaf228-01c0-4882-bf0d-b3cae1bd6fd8"",""name"":""name-813"",""routes"":[{""guid"":""17833edc-282c-4de2-a900-f0a8c9c44937"",""host"":""host-8"",""domain"":{""guid"":""ef0cc712-e743-414a-a305-4e74168c3ff5"",""name"":""domain-15.example.com""}}],""running_instances"":0,""services"":[{""guid"":""e2d42c6f-b8a0-4178-891e-526a1c99c158"",""name"":""name-815"",""bound_app_count"":1,""dashboard_url"":null,""service_plan"":{""guid"":""03e60743-347a-4256-ac0f-647f021a0f09"",""name"":""name-816"",""service"":{""guid"":""3d2aa46e-ee11-4856-b5d9-842c5cbb414f"",""label"":""label-58"",""provider"":""provider-49"",""version"":""version-33""}}}],""available_domains"":[{""guid"":""ef0cc712-e743-414a-a305-4e74168c3ff5"",""name"":""domain-15.example.com"",""owning_organization_guid"":""a4f472bf-e45d-466a-bf5b-2cd653c5e685""},{""guid"":""a9a6c250-5035-4cd8-85d8-1afaa028fd2c"",""name"":""customer-app-domain1.com""},{""guid"":""2b812234-4326-4615-8fe5-dd6800a685aa"",""name"":""customer-app-domain2.com""}],""name"":""name-813"",""production"":false,""space_guid"":""1af35b26-e2b9-4962-9f94-f4deafb5f2f0"",""stack_guid"":""a641262b-a08a-4df4-ae77-f0ec55b1f928"",""buildpack"":null,""detected_buildpack"":null,""environment_json"":null,""memory"":1024,""instances"":1,""disk_quota"":1024,""state"":""STOPPED"",""version"":""7e15bd12-4471-4f6a-be3f-54a530792d4a"",""command"":null,""console"":false,""debug"":null,""staging_task_id"":null,""package_state"":""PENDING"",""health_check_timeout"":null,""staging_failed_reason"":null,""docker_image"":null,""package_updated_at"":""2014-11-12T12:59:38+02:00"",""detected_start_command"":""""}";
    
            GetAppSummaryResponse obj = Util.DeserializeJson<GetAppSummaryResponse>(json);
        
            Assert.AreEqual("dcfaf228-01c0-4882-bf0d-b3cae1bd6fd8", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("name-813", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("0", TestUtil.ToTestableString(obj.RunningInstances), true);
            
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("1af35b26-e2b9-4962-9f94-f4deafb5f2f0", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("a641262b-a08a-4df4-ae77-f0ec55b1f928", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("7e15bd12-4471-4f6a-be3f-54a530792d4a", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
        }

    
        [TestMethod]
        public void TestRemoveServiceBindingFromAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""356b3729-3b74-4a9d-b233-f6471aa6e311"",
    ""url"": ""/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311"",
    ""created_at"": ""2014-11-12T12:59:22+02:00"",
    ""updated_at"": ""2014-11-12T12:59:22+02:00""
  },
  ""entity"": {
    ""name"": ""name-211"",
    ""production"": false,
    ""space_guid"": ""ebc5e430-be6e-4fe7-8fec-b5b5ed9ca290"",
    ""stack_guid"": ""82824444-1544-4928-9950-b224cf36728c"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": null,
    ""memory"": 1024,
    ""instances"": 1,
    ""disk_quota"": 1024,
    ""state"": ""STOPPED"",
    ""version"": ""474a4641-f7c4-4d9c-a545-84336ef557df"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": ""2014-11-12T12:59:22+02:00"",
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/ebc5e430-be6e-4fe7-8fec-b5b5ed9ca290"",
    ""stack_url"": ""/v2/stacks/82824444-1544-4928-9950-b224cf36728c"",
    ""events_url"": ""/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311/events"",
    ""service_bindings_url"": ""/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311/service_bindings"",
    ""routes_url"": ""/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311/routes""
  }
}";
    
            RemoveServiceBindingFromAppResponse obj = Util.DeserializeJson<RemoveServiceBindingFromAppResponse>(json);
        
            Assert.AreEqual("356b3729-3b74-4a9d-b233-f6471aa6e311", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:22+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:22+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-211", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("ebc5e430-be6e-4fe7-8fec-b5b5ed9ca290", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("82824444-1544-4928-9950-b224cf36728c", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("474a4641-f7c4-4d9c-a545-84336ef557df", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:22+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/ebc5e430-be6e-4fe7-8fec-b5b5ed9ca290", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/82824444-1544-4928-9950-b224cf36728c", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/356b3729-3b74-4a9d-b233-f6471aa6e311/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllRoutesForAppResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""c9eef0f8-bad6-47ab-9062-ab23e30af19e"",
        ""url"": ""/v2/routes/c9eef0f8-bad6-47ab-9062-ab23e30af19e"",
        ""created_at"": ""2014-11-12T12:59:23+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""host"": ""host-3"",
        ""domain_guid"": ""ca3127ca-54f8-422c-bcbe-1c2db3608ae6"",
        ""space_guid"": ""91e3c5b9-eb7a-4333-b55e-d6b3cd916286"",
        ""domain_url"": ""/v2/domains/ca3127ca-54f8-422c-bcbe-1c2db3608ae6"",
        ""space_url"": ""/v2/spaces/91e3c5b9-eb7a-4333-b55e-d6b3cd916286"",
        ""apps_url"": ""/v2/routes/c9eef0f8-bad6-47ab-9062-ab23e30af19e/apps""
      }
    }
  ]
}";
    
            PagedResponse<ListAllRoutesForAppResponse> page = Util.DeserializePage<ListAllRoutesForAppResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("c9eef0f8-bad6-47ab-9062-ab23e30af19e", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/routes/c9eef0f8-bad6-47ab-9062-ab23e30af19e", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("host-3", TestUtil.ToTestableString(page[0].Host), true);
                  Assert.AreEqual("ca3127ca-54f8-422c-bcbe-1c2db3608ae6", TestUtil.ToTestableString(page[0].DomainGuid), true);
                  Assert.AreEqual("91e3c5b9-eb7a-4333-b55e-d6b3cd916286", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("/v2/domains/ca3127ca-54f8-422c-bcbe-1c2db3608ae6", TestUtil.ToTestableString(page[0].DomainUrl), true);
                  Assert.AreEqual("/v2/spaces/91e3c5b9-eb7a-4333-b55e-d6b3cd916286", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/routes/c9eef0f8-bad6-47ab-9062-ab23e30af19e/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestGetDetailedStatsForStartedAppResponse()
        {
            string json = @"{""0"":{""state"":""RUNNING"",""stats"":{""usage"":{""disk"":66392064,""mem"":29880320,""cpu"":0.13511219703079957,""time"":""2014-06-19 22:37:58 +0000""},""name"":""app_name"",""uris"":[""app_name.example.com""],""host"":""10.0.0.1"",""port"":61035,""uptime"":65007,""mem_quota"":536870912,""disk_quota"":1073741824,""fds_quota"":16384}}}";
    
            GetDetailedStatsForStartedAppResponse obj = Util.DeserializeJson<GetDetailedStatsForStartedAppResponse>(json);
        
            
        }

    
        [TestMethod]
        public void TestCreateDockerAppExperimentalResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""9fe07b5a-5676-4e5e-bc52-d9cc19feec50"",
    ""url"": ""/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50"",
    ""created_at"": ""2014-11-12T12:59:20+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""docker_app"",
    ""production"": false,
    ""space_guid"": ""6d798f83-dd97-4c99-a9a8-ea8e021236c3"",
    ""stack_guid"": ""0b546dda-cf0e-4a86-a70e-c24368f7d025"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": {
      ""DIEGO_STAGE_BETA"": ""true"",
      ""DIEGO_RUN_BETA"": ""true""
    },
    ""memory"": 1024,
    ""instances"": 2,
    ""disk_quota"": 1204,
    ""state"": ""STOPPED"",
    ""version"": ""7671ca9c-0f5f-4c86-8a64-ceda5f9fbb1c"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": ""cloudfoundry/hello:latest"",
    ""package_updated_at"": ""2014-11-12T12:59:20+02:00"",
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/6d798f83-dd97-4c99-a9a8-ea8e021236c3"",
    ""stack_url"": ""/v2/stacks/0b546dda-cf0e-4a86-a70e-c24368f7d025"",
    ""events_url"": ""/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50/events"",
    ""service_bindings_url"": ""/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50/service_bindings"",
    ""routes_url"": ""/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50/routes""
  }
}";
    
            CreateDockerAppExperimentalResponse obj = Util.DeserializeJson<CreateDockerAppExperimentalResponse>(json);
        
            Assert.AreEqual("9fe07b5a-5676-4e5e-bc52-d9cc19feec50", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:20+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("docker_app", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("6d798f83-dd97-4c99-a9a8-ea8e021236c3", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("0b546dda-cf0e-4a86-a70e-c24368f7d025", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("2", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1204", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("7671ca9c-0f5f-4c86-8a64-ceda5f9fbb1c", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("cloudfoundry/hello:latest", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:20+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/6d798f83-dd97-4c99-a9a8-ea8e021236c3", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/0b546dda-cf0e-4a86-a70e-c24368f7d025", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/9fe07b5a-5676-4e5e-bc52-d9cc19feec50/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestUpdateAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""65601cf4-1e13-424b-a58b-9a16dfe871f5"",
    ""url"": ""/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5"",
    ""created_at"": ""2014-11-12T12:59:19+02:00"",
    ""updated_at"": ""2014-11-12T12:59:19+02:00""
  },
  ""entity"": {
    ""name"": ""new_name"",
    ""production"": false,
    ""space_guid"": ""93313154-a04c-43be-bd89-48beee092789"",
    ""stack_guid"": ""cf94d7e2-6c9d-4e33-92d6-2bda87c717c2"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": null,
    ""memory"": 1024,
    ""instances"": 1,
    ""disk_quota"": 1024,
    ""state"": ""STOPPED"",
    ""version"": ""d25faf46-6e6e-4305-b86f-49dc74ad715a"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": ""2014-11-12T12:59:19+02:00"",
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/93313154-a04c-43be-bd89-48beee092789"",
    ""stack_url"": ""/v2/stacks/cf94d7e2-6c9d-4e33-92d6-2bda87c717c2"",
    ""events_url"": ""/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5/events"",
    ""service_bindings_url"": ""/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5/service_bindings"",
    ""routes_url"": ""/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5/routes""
  }
}";
    
            UpdateAppResponse obj = Util.DeserializeJson<UpdateAppResponse>(json);
        
            Assert.AreEqual("65601cf4-1e13-424b-a58b-9a16dfe871f5", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("new_name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("93313154-a04c-43be-bd89-48beee092789", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("cf94d7e2-6c9d-4e33-92d6-2bda87c717c2", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("d25faf46-6e6e-4305-b86f-49dc74ad715a", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/93313154-a04c-43be-bd89-48beee092789", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/cf94d7e2-6c9d-4e33-92d6-2bda87c717c2", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/65601cf4-1e13-424b-a58b-9a16dfe871f5/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestUploadsBitsForAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""aa8e031a-eb3c-424c-8cbe-8ca24b1981ee"",
    ""created_at"": ""2014-11-12T12:59:30+02:00"",
    ""url"": ""/v2/jobs/aa8e031a-eb3c-424c-8cbe-8ca24b1981ee""
  },
  ""entity"": {
    ""guid"": ""aa8e031a-eb3c-424c-8cbe-8ca24b1981ee"",
    ""status"": ""queued""
  }
}";
    
            UploadsBitsForAppResponse obj = Util.DeserializeJson<UploadsBitsForAppResponse>(json);
        
            Assert.AreEqual("aa8e031a-eb3c-424c-8cbe-8ca24b1981ee", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:30+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("/v2/jobs/aa8e031a-eb3c-424c-8cbe-8ca24b1981ee", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("aa8e031a-eb3c-424c-8cbe-8ca24b1981ee", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("queued", TestUtil.ToTestableString(obj.Status), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveRouteFromAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""670cac9f-25d7-47be-84bd-0a72ea903b8a"",
    ""url"": ""/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a"",
    ""created_at"": ""2014-11-12T12:59:23+02:00"",
    ""updated_at"": ""2014-11-12T12:59:23+02:00""
  },
  ""entity"": {
    ""name"": ""name-230"",
    ""production"": false,
    ""space_guid"": ""86c6a77e-cce3-4255-88ab-eb5d115d65f5"",
    ""stack_guid"": ""89443ebf-04dc-4b26-b3f9-490a9c150c65"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": null,
    ""memory"": 1024,
    ""instances"": 1,
    ""disk_quota"": 1024,
    ""state"": ""STOPPED"",
    ""version"": ""9121c35a-5873-4871-b745-c11f6039acb2"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": ""2014-11-12T12:59:23+02:00"",
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/86c6a77e-cce3-4255-88ab-eb5d115d65f5"",
    ""stack_url"": ""/v2/stacks/89443ebf-04dc-4b26-b3f9-490a9c150c65"",
    ""events_url"": ""/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a/events"",
    ""service_bindings_url"": ""/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a/service_bindings"",
    ""routes_url"": ""/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a/routes""
  }
}";
    
            RemoveRouteFromAppResponse obj = Util.DeserializeJson<RemoveRouteFromAppResponse>(json);
        
            Assert.AreEqual("670cac9f-25d7-47be-84bd-0a72ea903b8a", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-230", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("86c6a77e-cce3-4255-88ab-eb5d115d65f5", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("89443ebf-04dc-4b26-b3f9-490a9c150c65", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("9121c35a-5873-4871-b745-c11f6039acb2", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/86c6a77e-cce3-4255-88ab-eb5d115d65f5", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/89443ebf-04dc-4b26-b3f9-490a9c150c65", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/670cac9f-25d7-47be-84bd-0a72ea903b8a/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServiceBindingsForAppResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""6f13d3b0-0617-4777-80a5-6dbc42db19e5"",
        ""url"": ""/v2/service_bindings/6f13d3b0-0617-4777-80a5-6dbc42db19e5"",
        ""created_at"": ""2014-11-12T12:59:22+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""app_guid"": ""01ec0565-496a-4c9f-8519-5eb4308ff8f0"",
        ""service_instance_guid"": ""b71040d7-e3a6-41f8-9655-735877aa1ada"",
        ""credentials"": {
          ""creds-key-37"": ""creds-val-37""
        },
        ""binding_options"": {

        },
        ""gateway_data"": null,
        ""gateway_name"": """",
        ""syslog_drain_url"": null,
        ""app_url"": ""/v2/apps/01ec0565-496a-4c9f-8519-5eb4308ff8f0"",
        ""service_instance_url"": ""/v2/service_instances/b71040d7-e3a6-41f8-9655-735877aa1ada""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceBindingsForAppResponse> page = Util.DeserializePage<ListAllServiceBindingsForAppResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("6f13d3b0-0617-4777-80a5-6dbc42db19e5", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_bindings/6f13d3b0-0617-4777-80a5-6dbc42db19e5", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:22+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("01ec0565-496a-4c9f-8519-5eb4308ff8f0", TestUtil.ToTestableString(page[0].AppGuid), true);
                  Assert.AreEqual("b71040d7-e3a6-41f8-9655-735877aa1ada", TestUtil.ToTestableString(page[0].ServiceInstanceGuid), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayName), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SyslogDrainUrl), true);
                  Assert.AreEqual("/v2/apps/01ec0565-496a-4c9f-8519-5eb4308ff8f0", TestUtil.ToTestableString(page[0].AppUrl), true);
                  Assert.AreEqual("/v2/service_instances/b71040d7-e3a6-41f8-9655-735877aa1ada", TestUtil.ToTestableString(page[0].ServiceInstanceUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateRouteWithAppResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""133e6406-8710-4918-bc33-af72177eada9"",
    ""url"": ""/v2/apps/133e6406-8710-4918-bc33-af72177eada9"",
    ""created_at"": ""2014-11-12T12:59:23+02:00"",
    ""updated_at"": ""2014-11-12T12:59:23+02:00""
  },
  ""entity"": {
    ""name"": ""name-250"",
    ""production"": false,
    ""space_guid"": ""f588b082-7f64-4f62-b6bf-74c596aed5ad"",
    ""stack_guid"": ""3764784b-5caa-476a-ac31-751db5fac01d"",
    ""buildpack"": null,
    ""detected_buildpack"": null,
    ""environment_json"": null,
    ""memory"": 1024,
    ""instances"": 1,
    ""disk_quota"": 1024,
    ""state"": ""STOPPED"",
    ""version"": ""9e69be28-3e28-42d2-831e-2b41d6011a93"",
    ""command"": null,
    ""console"": false,
    ""debug"": null,
    ""staging_task_id"": null,
    ""package_state"": ""PENDING"",
    ""health_check_timeout"": null,
    ""staging_failed_reason"": null,
    ""docker_image"": null,
    ""package_updated_at"": ""2014-11-12T12:59:23+02:00"",
    ""detected_start_command"": """",
    ""space_url"": ""/v2/spaces/f588b082-7f64-4f62-b6bf-74c596aed5ad"",
    ""stack_url"": ""/v2/stacks/3764784b-5caa-476a-ac31-751db5fac01d"",
    ""events_url"": ""/v2/apps/133e6406-8710-4918-bc33-af72177eada9/events"",
    ""service_bindings_url"": ""/v2/apps/133e6406-8710-4918-bc33-af72177eada9/service_bindings"",
    ""routes_url"": ""/v2/apps/133e6406-8710-4918-bc33-af72177eada9/routes""
  }
}";
    
            AssociateRouteWithAppResponse obj = Util.DeserializeJson<AssociateRouteWithAppResponse>(json);
        
            Assert.AreEqual("133e6406-8710-4918-bc33-af72177eada9", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/apps/133e6406-8710-4918-bc33-af72177eada9", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-250", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Production), true);
            Assert.AreEqual("f588b082-7f64-4f62-b6bf-74c596aed5ad", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("3764784b-5caa-476a-ac31-751db5fac01d", TestUtil.ToTestableString(obj.StackGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Buildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedBuildpack), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EnvironmentJson), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.Memory), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Instances), true);
            Assert.AreEqual("1024", TestUtil.ToTestableString(obj.DiskQuota), true);
            Assert.AreEqual("STOPPED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("9e69be28-3e28-42d2-831e-2b41d6011a93", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Command), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Console), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Debug), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingTaskId), true);
            Assert.AreEqual("PENDING", TestUtil.ToTestableString(obj.PackageState), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.HealthCheckTimeout), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.StagingFailedReason), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DockerImage), true);
            Assert.AreEqual("2014-11-12T12:59:23+02:00", TestUtil.ToTestableString(obj.PackageUpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DetectedStartCommand), true);
            Assert.AreEqual("/v2/spaces/f588b082-7f64-4f62-b6bf-74c596aed5ad", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/stacks/3764784b-5caa-476a-ac31-751db5fac01d", TestUtil.ToTestableString(obj.StackUrl), true);
            Assert.AreEqual("/v2/apps/133e6406-8710-4918-bc33-af72177eada9/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/apps/133e6406-8710-4918-bc33-af72177eada9/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            Assert.AreEqual("/v2/apps/133e6406-8710-4918-bc33-af72177eada9/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            
            
        }

    }
}
