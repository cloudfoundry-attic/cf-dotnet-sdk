using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class RoutesTest
    {

    
        [TestMethod]
        public void TestListAllAppsForRouteResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""a1b5039e-1281-4707-99a9-db075aaf2e5d"",
        ""url"": ""/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d"",
        ""created_at"": ""2014-11-12T12:59:43+02:00"",
        ""updated_at"": ""2014-11-12T12:59:43+02:00""
      },
      ""entity"": {
        ""name"": ""name-1144"",
        ""production"": false,
        ""space_guid"": ""6ead3df7-5fb8-4990-ae3e-86b61c8b898a"",
        ""stack_guid"": ""7e1d9cf4-9021-4f1a-8767-509ae01f7af3"",
        ""buildpack"": null,
        ""detected_buildpack"": null,
        ""environment_json"": null,
        ""memory"": 1024,
        ""instances"": 1,
        ""disk_quota"": 1024,
        ""state"": ""STOPPED"",
        ""version"": ""66454ac9-808c-496a-8f38-29fcc723c9ed"",
        ""command"": null,
        ""console"": false,
        ""debug"": null,
        ""staging_task_id"": null,
        ""package_state"": ""PENDING"",
        ""health_check_timeout"": null,
        ""staging_failed_reason"": null,
        ""docker_image"": null,
        ""package_updated_at"": ""2014-11-12T12:59:43+02:00"",
        ""detected_start_command"": """",
        ""space_url"": ""/v2/spaces/6ead3df7-5fb8-4990-ae3e-86b61c8b898a"",
        ""stack_url"": ""/v2/stacks/7e1d9cf4-9021-4f1a-8767-509ae01f7af3"",
        ""events_url"": ""/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d/events"",
        ""service_bindings_url"": ""/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d/service_bindings"",
        ""routes_url"": ""/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d/routes""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAppsForRouteResponse> page = Util.DeserializePage<ListAllAppsForRouteResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("a1b5039e-1281-4707-99a9-db075aaf2e5d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1144", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Production), true);
                  Assert.AreEqual("6ead3df7-5fb8-4990-ae3e-86b61c8b898a", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("7e1d9cf4-9021-4f1a-8767-509ae01f7af3", TestUtil.ToTestableString(page[0].StackGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Buildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DetectedBuildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].EnvironmentJson), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[0].Memory), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[0].Instances), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[0].DiskQuota), true);
                  Assert.AreEqual("STOPPED", TestUtil.ToTestableString(page[0].State), true);
                  Assert.AreEqual("66454ac9-808c-496a-8f38-29fcc723c9ed", TestUtil.ToTestableString(page[0].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Command), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Console), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Debug), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].StagingTaskId), true);
                  Assert.AreEqual("PENDING", TestUtil.ToTestableString(page[0].PackageState), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].HealthCheckTimeout), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].StagingFailedReason), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DockerImage), true);
                  Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(page[0].PackageUpdatedAt), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DetectedStartCommand), true);
                  Assert.AreEqual("/v2/spaces/6ead3df7-5fb8-4990-ae3e-86b61c8b898a", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/stacks/7e1d9cf4-9021-4f1a-8767-509ae01f7af3", TestUtil.ToTestableString(page[0].StackUrl), true);
                  Assert.AreEqual("/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
                  Assert.AreEqual("/v2/apps/a1b5039e-1281-4707-99a9-db075aaf2e5d/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveRouteResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""d89fc979-e105-49ec-b944-f7563870ce6f"",
    ""url"": ""/v2/routes/d89fc979-e105-49ec-b944-f7563870ce6f"",
    ""created_at"": ""2014-11-12T12:59:42+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""host"": ""host-14"",
    ""domain_guid"": ""db3966e7-2f79-4137-97e5-f6eff6d5b889"",
    ""space_guid"": ""2e73715e-1621-4214-a9a2-075ff70719d9"",
    ""domain_url"": ""/v2/domains/db3966e7-2f79-4137-97e5-f6eff6d5b889"",
    ""space_url"": ""/v2/spaces/2e73715e-1621-4214-a9a2-075ff70719d9"",
    ""apps_url"": ""/v2/routes/d89fc979-e105-49ec-b944-f7563870ce6f/apps""
  }
}";
    
            RetrieveRouteResponse obj = Util.DeserializeJson<RetrieveRouteResponse>(json);
        
            Assert.AreEqual("d89fc979-e105-49ec-b944-f7563870ce6f", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/routes/d89fc979-e105-49ec-b944-f7563870ce6f", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:42+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("host-14", TestUtil.ToTestableString(obj.Host), true);
            Assert.AreEqual("db3966e7-2f79-4137-97e5-f6eff6d5b889", TestUtil.ToTestableString(obj.DomainGuid), true);
            Assert.AreEqual("2e73715e-1621-4214-a9a2-075ff70719d9", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("/v2/domains/db3966e7-2f79-4137-97e5-f6eff6d5b889", TestUtil.ToTestableString(obj.DomainUrl), true);
            Assert.AreEqual("/v2/spaces/2e73715e-1621-4214-a9a2-075ff70719d9", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/routes/d89fc979-e105-49ec-b944-f7563870ce6f/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestUpdateRouteResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""7c107c44-b842-4dc7-a517-1ed3841d1ec6"",
    ""url"": ""/v2/routes/7c107c44-b842-4dc7-a517-1ed3841d1ec6"",
    ""created_at"": ""2014-11-12T12:59:42+02:00"",
    ""updated_at"": ""2014-11-12T12:59:42+02:00""
  },
  ""entity"": {
    ""host"": ""new_host"",
    ""domain_guid"": ""cd43247e-ead0-4511-9950-4f47eeb28897"",
    ""space_guid"": ""84cc465d-0a1b-4a25-89d8-146e3d5c913a"",
    ""domain_url"": ""/v2/domains/cd43247e-ead0-4511-9950-4f47eeb28897"",
    ""space_url"": ""/v2/spaces/84cc465d-0a1b-4a25-89d8-146e3d5c913a"",
    ""apps_url"": ""/v2/routes/7c107c44-b842-4dc7-a517-1ed3841d1ec6/apps""
  }
}";
    
            UpdateRouteResponse obj = Util.DeserializeJson<UpdateRouteResponse>(json);
        
            Assert.AreEqual("7c107c44-b842-4dc7-a517-1ed3841d1ec6", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/routes/7c107c44-b842-4dc7-a517-1ed3841d1ec6", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:42+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:42+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("new_host", TestUtil.ToTestableString(obj.Host), true);
            Assert.AreEqual("cd43247e-ead0-4511-9950-4f47eeb28897", TestUtil.ToTestableString(obj.DomainGuid), true);
            Assert.AreEqual("84cc465d-0a1b-4a25-89d8-146e3d5c913a", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("/v2/domains/cd43247e-ead0-4511-9950-4f47eeb28897", TestUtil.ToTestableString(obj.DomainUrl), true);
            Assert.AreEqual("/v2/spaces/84cc465d-0a1b-4a25-89d8-146e3d5c913a", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/routes/7c107c44-b842-4dc7-a517-1ed3841d1ec6/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveAppFromRouteResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""f951fd50-e9ce-4424-9048-f9eca06ca548"",
    ""url"": ""/v2/routes/f951fd50-e9ce-4424-9048-f9eca06ca548"",
    ""created_at"": ""2014-11-12T12:59:43+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""host"": ""host-15"",
    ""domain_guid"": ""dbd5a586-e97b-405f-93cb-d3ee6c8ed521"",
    ""space_guid"": ""a2a4955e-5bd5-41d1-9941-f4aca43c2f9a"",
    ""domain_url"": ""/v2/domains/dbd5a586-e97b-405f-93cb-d3ee6c8ed521"",
    ""space_url"": ""/v2/spaces/a2a4955e-5bd5-41d1-9941-f4aca43c2f9a"",
    ""apps_url"": ""/v2/routes/f951fd50-e9ce-4424-9048-f9eca06ca548/apps""
  }
}";
    
            RemoveAppFromRouteResponse obj = Util.DeserializeJson<RemoveAppFromRouteResponse>(json);
        
            Assert.AreEqual("f951fd50-e9ce-4424-9048-f9eca06ca548", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/routes/f951fd50-e9ce-4424-9048-f9eca06ca548", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("host-15", TestUtil.ToTestableString(obj.Host), true);
            Assert.AreEqual("dbd5a586-e97b-405f-93cb-d3ee6c8ed521", TestUtil.ToTestableString(obj.DomainGuid), true);
            Assert.AreEqual("a2a4955e-5bd5-41d1-9941-f4aca43c2f9a", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("/v2/domains/dbd5a586-e97b-405f-93cb-d3ee6c8ed521", TestUtil.ToTestableString(obj.DomainUrl), true);
            Assert.AreEqual("/v2/spaces/a2a4955e-5bd5-41d1-9941-f4aca43c2f9a", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/routes/f951fd50-e9ce-4424-9048-f9eca06ca548/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateRouteResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""3ae218ed-f388-4a3a-8933-6556c4e93bcb"",
    ""url"": ""/v2/routes/3ae218ed-f388-4a3a-8933-6556c4e93bcb"",
    ""created_at"": ""2014-11-12T12:59:42+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""host"": """",
    ""domain_guid"": ""f1f7f32d-ae3d-4d9c-b1a3-37e2d0118d08"",
    ""space_guid"": ""b61a1218-b3d8-4f94-8134-aecb89079834"",
    ""domain_url"": ""/v2/domains/f1f7f32d-ae3d-4d9c-b1a3-37e2d0118d08"",
    ""space_url"": ""/v2/spaces/b61a1218-b3d8-4f94-8134-aecb89079834"",
    ""apps_url"": ""/v2/routes/3ae218ed-f388-4a3a-8933-6556c4e93bcb/apps""
  }
}";
    
            CreateRouteResponse obj = Util.DeserializeJson<CreateRouteResponse>(json);
        
            Assert.AreEqual("3ae218ed-f388-4a3a-8933-6556c4e93bcb", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/routes/3ae218ed-f388-4a3a-8933-6556c4e93bcb", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:42+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Host), true);
            Assert.AreEqual("f1f7f32d-ae3d-4d9c-b1a3-37e2d0118d08", TestUtil.ToTestableString(obj.DomainGuid), true);
            Assert.AreEqual("b61a1218-b3d8-4f94-8134-aecb89079834", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("/v2/domains/f1f7f32d-ae3d-4d9c-b1a3-37e2d0118d08", TestUtil.ToTestableString(obj.DomainUrl), true);
            Assert.AreEqual("/v2/spaces/b61a1218-b3d8-4f94-8134-aecb89079834", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/routes/3ae218ed-f388-4a3a-8933-6556c4e93bcb/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateAppWithRouteResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""549d29fd-fa0a-4c60-896f-6c75d69d497f"",
    ""url"": ""/v2/routes/549d29fd-fa0a-4c60-896f-6c75d69d497f"",
    ""created_at"": ""2014-11-12T12:59:43+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""host"": ""host-17"",
    ""domain_guid"": ""1fa9a878-8c07-4d5e-93ad-66e23de7af5a"",
    ""space_guid"": ""9801c31e-d7ad-4d81-a9c7-0f571de4fc2c"",
    ""domain_url"": ""/v2/domains/1fa9a878-8c07-4d5e-93ad-66e23de7af5a"",
    ""space_url"": ""/v2/spaces/9801c31e-d7ad-4d81-a9c7-0f571de4fc2c"",
    ""apps_url"": ""/v2/routes/549d29fd-fa0a-4c60-896f-6c75d69d497f/apps""
  }
}";
    
            AssociateAppWithRouteResponse obj = Util.DeserializeJson<AssociateAppWithRouteResponse>(json);
        
            Assert.AreEqual("549d29fd-fa0a-4c60-896f-6c75d69d497f", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/routes/549d29fd-fa0a-4c60-896f-6c75d69d497f", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("host-17", TestUtil.ToTestableString(obj.Host), true);
            Assert.AreEqual("1fa9a878-8c07-4d5e-93ad-66e23de7af5a", TestUtil.ToTestableString(obj.DomainGuid), true);
            Assert.AreEqual("9801c31e-d7ad-4d81-a9c7-0f571de4fc2c", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("/v2/domains/1fa9a878-8c07-4d5e-93ad-66e23de7af5a", TestUtil.ToTestableString(obj.DomainUrl), true);
            Assert.AreEqual("/v2/spaces/9801c31e-d7ad-4d81-a9c7-0f571de4fc2c", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/routes/549d29fd-fa0a-4c60-896f-6c75d69d497f/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllRoutesResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""d498880e-21f9-4eb1-bf9d-2a854f5c098b"",
        ""url"": ""/v2/routes/d498880e-21f9-4eb1-bf9d-2a854f5c098b"",
        ""created_at"": ""2014-11-12T12:59:42+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""host"": ""host-11"",
        ""domain_guid"": ""b6fd8255-e416-4a4c-a73b-194e8686c9c0"",
        ""space_guid"": ""6a7865ef-87a1-432d-ab05-41f77400449d"",
        ""domain_url"": ""/v2/domains/b6fd8255-e416-4a4c-a73b-194e8686c9c0"",
        ""space_url"": ""/v2/spaces/6a7865ef-87a1-432d-ab05-41f77400449d"",
        ""apps_url"": ""/v2/routes/d498880e-21f9-4eb1-bf9d-2a854f5c098b/apps""
      }
    }
  ]
}";
    
            PagedResponse<ListAllRoutesResponse> page = Util.DeserializePage<ListAllRoutesResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("d498880e-21f9-4eb1-bf9d-2a854f5c098b", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/routes/d498880e-21f9-4eb1-bf9d-2a854f5c098b", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:42+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("host-11", TestUtil.ToTestableString(page[0].Host), true);
                  Assert.AreEqual("b6fd8255-e416-4a4c-a73b-194e8686c9c0", TestUtil.ToTestableString(page[0].DomainGuid), true);
                  Assert.AreEqual("6a7865ef-87a1-432d-ab05-41f77400449d", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("/v2/domains/b6fd8255-e416-4a4c-a73b-194e8686c9c0", TestUtil.ToTestableString(page[0].DomainUrl), true);
                  Assert.AreEqual("/v2/spaces/6a7865ef-87a1-432d-ab05-41f77400449d", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/routes/d498880e-21f9-4eb1-bf9d-2a854f5c098b/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
               
               
            
    
        }

    }
}
