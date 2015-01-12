using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class ServiceInstancesTest
    {

    
        [TestMethod]
        public void TestUpdateServicePlanServiceInstanceRequest()
        {
            string json = @"{""service_plan_guid"":""123becae-a489-4529-9b27-e54275cdb12d""}";
    
            UpdateServicePlanServiceInstanceRequest obj = Util.DeserializeJson<UpdateServicePlanServiceInstanceRequest>(json);
        
            Assert.AreEqual("123becae-a489-4529-9b27-e54275cdb12d", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
        }

    
        [TestMethod]
        public void TestUpdateServicePlanServiceInstanceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""ec1bb9b8-6ac3-4603-ab40-28b70a0a7edc"",
    ""url"": ""/v2/service_instances/ec1bb9b8-6ac3-4603-ab40-28b70a0a7edc"",
    ""created_at"": ""2014-11-12T12:59:25+02:00"",
    ""updated_at"": ""2014-11-12T12:59:25+02:00""
  },
  ""entity"": {
    ""name"": ""name-321"",
    ""credentials"": {
      ""creds-key-99"": ""creds-val-99""
    },
    ""service_plan_guid"": ""123becae-a489-4529-9b27-e54275cdb12d"",
    ""space_guid"": ""a4d0a357-e568-4794-bea7-8843204694a4"",
    ""gateway_data"": null,
    ""dashboard_url"": null,
    ""type"": ""managed_service_instance"",
    ""space_url"": ""/v2/spaces/a4d0a357-e568-4794-bea7-8843204694a4"",
    ""service_plan_url"": ""/v2/service_plans/123becae-a489-4529-9b27-e54275cdb12d"",
    ""service_bindings_url"": ""/v2/service_instances/ec1bb9b8-6ac3-4603-ab40-28b70a0a7edc/service_bindings""
  }
}";
    
            UpdateServicePlanServiceInstanceResponse obj = Util.DeserializeJson<UpdateServicePlanServiceInstanceResponse>(json);
        
            Assert.AreEqual("ec1bb9b8-6ac3-4603-ab40-28b70a0a7edc", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_instances/ec1bb9b8-6ac3-4603-ab40-28b70a0a7edc", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-321", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("123becae-a489-4529-9b27-e54275cdb12d", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("a4d0a357-e568-4794-bea7-8843204694a4", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.GatewayData), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DashboardUrl), true);
            Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("/v2/spaces/a4d0a357-e568-4794-bea7-8843204694a4", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/service_plans/123becae-a489-4529-9b27-e54275cdb12d", TestUtil.ToTestableString(obj.ServicePlanUrl), true);
            Assert.AreEqual("/v2/service_instances/ec1bb9b8-6ac3-4603-ab40-28b70a0a7edc/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateServiceInstanceRequest()
        {
            string json = @"{
  ""space_guid"": ""fbd197d6-3ce3-43c3-ad44-0a001712db52"",
  ""name"": ""my-service-instance"",
  ""service_plan_guid"": ""ef9e93a0-c306-4a56-9a9c-4a7da955b78e""
}";
    
            CreateServiceInstanceRequest obj = Util.DeserializeJson<CreateServiceInstanceRequest>(json);
        
            Assert.AreEqual("fbd197d6-3ce3-43c3-ad44-0a001712db52", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("my-service-instance", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("ef9e93a0-c306-4a56-9a9c-4a7da955b78e", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
        }

    
        [TestMethod]
        public void TestCreateServiceInstanceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""5b3e2fb7-4264-40e8-a43c-031b373d258a"",
    ""url"": ""/v2/service_instances/5b3e2fb7-4264-40e8-a43c-031b373d258a"",
    ""created_at"": ""2014-11-12T12:59:26+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""my-service-instance"",
    ""credentials"": {
      ""creds-key-103"": ""creds-val-103""
    },
    ""service_plan_guid"": ""ef9e93a0-c306-4a56-9a9c-4a7da955b78e"",
    ""space_guid"": ""fbd197d6-3ce3-43c3-ad44-0a001712db52"",
    ""gateway_data"": ""CONFIGURATION"",
    ""dashboard_url"": ""http://dashboard.example.com"",
    ""type"": ""managed_service_instance"",
    ""space_url"": ""/v2/spaces/fbd197d6-3ce3-43c3-ad44-0a001712db52"",
    ""service_plan_url"": ""/v2/service_plans/ef9e93a0-c306-4a56-9a9c-4a7da955b78e"",
    ""service_bindings_url"": ""/v2/service_instances/5b3e2fb7-4264-40e8-a43c-031b373d258a/service_bindings""
  }
}";
    
            CreateServiceInstanceResponse obj = Util.DeserializeJson<CreateServiceInstanceResponse>(json);
        
            Assert.AreEqual("5b3e2fb7-4264-40e8-a43c-031b373d258a", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_instances/5b3e2fb7-4264-40e8-a43c-031b373d258a", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("my-service-instance", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("ef9e93a0-c306-4a56-9a9c-4a7da955b78e", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("fbd197d6-3ce3-43c3-ad44-0a001712db52", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("CONFIGURATION", TestUtil.ToTestableString(obj.GatewayData), true);
            Assert.AreEqual("http://dashboard.example.com", TestUtil.ToTestableString(obj.DashboardUrl), true);
            Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("/v2/spaces/fbd197d6-3ce3-43c3-ad44-0a001712db52", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/service_plans/ef9e93a0-c306-4a56-9a9c-4a7da955b78e", TestUtil.ToTestableString(obj.ServicePlanUrl), true);
            Assert.AreEqual("/v2/service_instances/5b3e2fb7-4264-40e8-a43c-031b373d258a/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServiceInstancesResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""0f40c245-545e-4bbd-85b9-4c5f020dfea1"",
        ""url"": ""/v2/service_instances/0f40c245-545e-4bbd-85b9-4c5f020dfea1"",
        ""created_at"": ""2014-11-12T12:59:26+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-326"",
        ""credentials"": {
          ""creds-key-102"": ""creds-val-102""
        },
        ""service_plan_guid"": ""99a86ce0-2421-4688-8ed7-6209039e1ff8"",
        ""space_guid"": ""b4ddc0c8-523e-478f-912c-987f3dcdef0c"",
        ""gateway_data"": null,
        ""dashboard_url"": null,
        ""type"": ""managed_service_instance"",
        ""space_url"": ""/v2/spaces/b4ddc0c8-523e-478f-912c-987f3dcdef0c"",
        ""service_plan_url"": ""/v2/service_plans/99a86ce0-2421-4688-8ed7-6209039e1ff8"",
        ""service_bindings_url"": ""/v2/service_instances/0f40c245-545e-4bbd-85b9-4c5f020dfea1/service_bindings""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceInstancesResponse> page = Util.DeserializePage<ListAllServiceInstancesResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("0f40c245-545e-4bbd-85b9-4c5f020dfea1", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_instances/0f40c245-545e-4bbd-85b9-4c5f020dfea1", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-326", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("99a86ce0-2421-4688-8ed7-6209039e1ff8", TestUtil.ToTestableString(page[0].ServicePlanGuid), true);
                  Assert.AreEqual("b4ddc0c8-523e-478f-912c-987f3dcdef0c", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DashboardUrl), true);
                  Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("/v2/spaces/b4ddc0c8-523e-478f-912c-987f3dcdef0c", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/service_plans/99a86ce0-2421-4688-8ed7-6209039e1ff8", TestUtil.ToTestableString(page[0].ServicePlanUrl), true);
                  Assert.AreEqual("/v2/service_instances/0f40c245-545e-4bbd-85b9-4c5f020dfea1/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllServiceBindingsForServiceInstanceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""4f223f33-b08d-459d-a3fd-44c392e4ae48"",
        ""url"": ""/v2/service_bindings/4f223f33-b08d-459d-a3fd-44c392e4ae48"",
        ""created_at"": ""2014-11-12T12:59:26+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""app_guid"": ""3f91cde8-c279-4370-a55c-3f97be660766"",
        ""service_instance_guid"": ""e44a383a-5161-4385-ba5d-b9df4eb22a43"",
        ""credentials"": {
          ""creds-key-121"": ""creds-val-121""
        },
        ""binding_options"": {

        },
        ""gateway_data"": null,
        ""gateway_name"": """",
        ""syslog_drain_url"": null,
        ""app_url"": ""/v2/apps/3f91cde8-c279-4370-a55c-3f97be660766"",
        ""service_instance_url"": ""/v2/service_instances/e44a383a-5161-4385-ba5d-b9df4eb22a43""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceBindingsForServiceInstanceResponse> page = Util.DeserializePage<ListAllServiceBindingsForServiceInstanceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("4f223f33-b08d-459d-a3fd-44c392e4ae48", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_bindings/4f223f33-b08d-459d-a3fd-44c392e4ae48", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("3f91cde8-c279-4370-a55c-3f97be660766", TestUtil.ToTestableString(page[0].AppGuid), true);
                  Assert.AreEqual("e44a383a-5161-4385-ba5d-b9df4eb22a43", TestUtil.ToTestableString(page[0].ServiceInstanceGuid), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayName), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SyslogDrainUrl), true);
                  Assert.AreEqual("/v2/apps/3f91cde8-c279-4370-a55c-3f97be660766", TestUtil.ToTestableString(page[0].AppUrl), true);
                  Assert.AreEqual("/v2/service_instances/e44a383a-5161-4385-ba5d-b9df4eb22a43", TestUtil.ToTestableString(page[0].ServiceInstanceUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveServiceInstanceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""18679f8b-aeae-41e8-8510-3bee52838b58"",
    ""url"": ""/v2/service_instances/18679f8b-aeae-41e8-8510-3bee52838b58"",
    ""created_at"": ""2014-11-12T12:59:26+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-345"",
    ""credentials"": {
      ""creds-key-111"": ""creds-val-111""
    },
    ""service_plan_guid"": ""9fecc9f4-ff69-46be-b381-aea7b513776f"",
    ""space_guid"": ""96bb3f56-fe59-4cfc-a4d2-d1ea87e12e19"",
    ""gateway_data"": null,
    ""dashboard_url"": null,
    ""type"": ""managed_service_instance"",
    ""space_url"": ""/v2/spaces/96bb3f56-fe59-4cfc-a4d2-d1ea87e12e19"",
    ""service_plan_url"": ""/v2/service_plans/9fecc9f4-ff69-46be-b381-aea7b513776f"",
    ""service_bindings_url"": ""/v2/service_instances/18679f8b-aeae-41e8-8510-3bee52838b58/service_bindings""
  }
}";
    
            RetrieveServiceInstanceResponse obj = Util.DeserializeJson<RetrieveServiceInstanceResponse>(json);
        
            Assert.AreEqual("18679f8b-aeae-41e8-8510-3bee52838b58", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_instances/18679f8b-aeae-41e8-8510-3bee52838b58", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-345", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("9fecc9f4-ff69-46be-b381-aea7b513776f", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("96bb3f56-fe59-4cfc-a4d2-d1ea87e12e19", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.GatewayData), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DashboardUrl), true);
            Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("/v2/spaces/96bb3f56-fe59-4cfc-a4d2-d1ea87e12e19", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/service_plans/9fecc9f4-ff69-46be-b381-aea7b513776f", TestUtil.ToTestableString(obj.ServicePlanUrl), true);
            Assert.AreEqual("/v2/service_instances/18679f8b-aeae-41e8-8510-3bee52838b58/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestMigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest()
        {
            string json = @"{""service_plan_guid"":""e0083a69-c281-4dc9-9af7-46acc8478b2f""}";
    
            MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest obj = Util.DeserializeJson<MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalRequest>(json);
        
            Assert.AreEqual("e0083a69-c281-4dc9-9af7-46acc8478b2f", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
        }

    
        [TestMethod]
        public void TestMigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalResponse()
        {
            string json = @"{""changed_count"":1}";
    
            MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalResponse obj = Util.DeserializeJson<MigrateServiceInstancesFromOneServicePlanToAnotherServicePlanExperimentalResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.ChangedCount), true);
        }

    
        [TestMethod]
        public void TestRetrievingPermissionsOnServiceInstanceResponse()
        {
            string json = @"{""manage"":true}";
    
            RetrievingPermissionsOnServiceInstanceResponse obj = Util.DeserializeJson<RetrievingPermissionsOnServiceInstanceResponse>(json);
        
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Manage), true);
        }

    }
}
