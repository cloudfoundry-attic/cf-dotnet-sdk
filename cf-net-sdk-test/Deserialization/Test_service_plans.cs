using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class ServicePlansTest
    {

    
        [TestMethod]
        public void TestCreateServicePlanDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""100mb"",
  ""free"": true,
  ""description"": ""Let's you put data in your database!"",
  ""service_guid"": ""907897d8-6480-4570-ac09-7db78cfcb61d""
}";
    
            CreateServicePlanDeprecatedRequest obj = Util.DeserializeJson<CreateServicePlanDeprecatedRequest>(json);
        
            Assert.AreEqual("100mb", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Free), true);
            Assert.AreEqual("Let's you put data in your database!", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("907897d8-6480-4570-ac09-7db78cfcb61d", TestUtil.ToTestableString(obj.ServiceGuid), true);
        }

    
        [TestMethod]
        public void TestCreateServicePlanDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""11d01689-6dad-4d70-90c3-80c3bda196ea"",
    ""url"": ""/v2/service_plans/11d01689-6dad-4d70-90c3-80c3bda196ea"",
    ""created_at"": ""2014-11-12T12:59:29+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""100mb"",
    ""free"": true,
    ""description"": ""Let's you put data in your database!"",
    ""service_guid"": ""907897d8-6480-4570-ac09-7db78cfcb61d"",
    ""extra"": null,
    ""unique_id"": ""be76af60-02bd-4fae-a6af-87bb918e3a45"",
    ""public"": true,
    ""active"": true,
    ""service_url"": ""/v2/services/907897d8-6480-4570-ac09-7db78cfcb61d"",
    ""service_instances_url"": ""/v2/service_plans/11d01689-6dad-4d70-90c3-80c3bda196ea/service_instances""
  }
}";
    
            CreateServicePlanDeprecatedResponse obj = Util.DeserializeJson<CreateServicePlanDeprecatedResponse>(json);
        
            Assert.AreEqual("11d01689-6dad-4d70-90c3-80c3bda196ea", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_plans/11d01689-6dad-4d70-90c3-80c3bda196ea", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("100mb", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Free), true);
            Assert.AreEqual("Let's you put data in your database!", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("907897d8-6480-4570-ac09-7db78cfcb61d", TestUtil.ToTestableString(obj.ServiceGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
            Assert.AreEqual("be76af60-02bd-4fae-a6af-87bb918e3a45", TestUtil.ToTestableString(obj.UniqueId), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Public), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("/v2/services/907897d8-6480-4570-ac09-7db78cfcb61d", TestUtil.ToTestableString(obj.ServiceUrl), true);
            Assert.AreEqual("/v2/service_plans/11d01689-6dad-4d70-90c3-80c3bda196ea/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServicePlansResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""6bccfa2a-8475-4638-8a9a-669b5523d102"",
        ""url"": ""/v2/service_plans/6bccfa2a-8475-4638-8a9a-669b5523d102"",
        ""created_at"": ""2014-11-12T12:59:29+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-432"",
        ""free"": false,
        ""description"": ""desc-90"",
        ""service_guid"": ""e6552ffb-7aba-4102-a799-ddde12d84008"",
        ""extra"": null,
        ""unique_id"": ""26c238ff-b27c-4812-b59f-26c6825d00ad"",
        ""public"": true,
        ""active"": true,
        ""service_url"": ""/v2/services/e6552ffb-7aba-4102-a799-ddde12d84008"",
        ""service_instances_url"": ""/v2/service_plans/6bccfa2a-8475-4638-8a9a-669b5523d102/service_instances""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServicePlansResponse> page = Util.DeserializePage<ListAllServicePlansResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("6bccfa2a-8475-4638-8a9a-669b5523d102", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plans/6bccfa2a-8475-4638-8a9a-669b5523d102", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-432", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Free), true);
                  Assert.AreEqual("desc-90", TestUtil.ToTestableString(page[0].Description), true);
                  Assert.AreEqual("e6552ffb-7aba-4102-a799-ddde12d84008", TestUtil.ToTestableString(page[0].ServiceGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Extra), true);
                  Assert.AreEqual("26c238ff-b27c-4812-b59f-26c6825d00ad", TestUtil.ToTestableString(page[0].UniqueId), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Public), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("/v2/services/e6552ffb-7aba-4102-a799-ddde12d84008", TestUtil.ToTestableString(page[0].ServiceUrl), true);
                  Assert.AreEqual("/v2/service_plans/6bccfa2a-8475-4638-8a9a-669b5523d102/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestUpdateServicePlanDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""100mb"",
  ""free"": true,
  ""description"": ""Let's you put data in your database!"",
  ""service_guid"": ""a9f310d5-2d2b-41a3-8eb4-70faf642ef73""
}";
    
            UpdateServicePlanDeprecatedRequest obj = Util.DeserializeJson<UpdateServicePlanDeprecatedRequest>(json);
        
            Assert.AreEqual("100mb", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Free), true);
            Assert.AreEqual("Let's you put data in your database!", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("a9f310d5-2d2b-41a3-8eb4-70faf642ef73", TestUtil.ToTestableString(obj.ServiceGuid), true);
        }

    
        [TestMethod]
        public void TestUpdateServicePlanDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""6a4367bd-9473-4766-bff8-6be4a3b1929d"",
    ""url"": ""/v2/service_plans/6a4367bd-9473-4766-bff8-6be4a3b1929d"",
    ""created_at"": ""2014-11-12T12:59:29+02:00"",
    ""updated_at"": ""2014-11-12T12:59:29+02:00""
  },
  ""entity"": {
    ""name"": ""100mb"",
    ""free"": true,
    ""description"": ""Let's you put data in your database!"",
    ""service_guid"": ""a9f310d5-2d2b-41a3-8eb4-70faf642ef73"",
    ""extra"": null,
    ""unique_id"": ""6ad49558-dc79-4ceb-b8ee-3e494ea68705"",
    ""public"": true,
    ""active"": true,
    ""service_url"": ""/v2/services/a9f310d5-2d2b-41a3-8eb4-70faf642ef73"",
    ""service_instances_url"": ""/v2/service_plans/6a4367bd-9473-4766-bff8-6be4a3b1929d/service_instances""
  }
}";
    
            UpdateServicePlanDeprecatedResponse obj = Util.DeserializeJson<UpdateServicePlanDeprecatedResponse>(json);
        
            Assert.AreEqual("6a4367bd-9473-4766-bff8-6be4a3b1929d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_plans/6a4367bd-9473-4766-bff8-6be4a3b1929d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("100mb", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Free), true);
            Assert.AreEqual("Let's you put data in your database!", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("a9f310d5-2d2b-41a3-8eb4-70faf642ef73", TestUtil.ToTestableString(obj.ServiceGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
            Assert.AreEqual("6ad49558-dc79-4ceb-b8ee-3e494ea68705", TestUtil.ToTestableString(obj.UniqueId), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Public), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("/v2/services/a9f310d5-2d2b-41a3-8eb4-70faf642ef73", TestUtil.ToTestableString(obj.ServiceUrl), true);
            Assert.AreEqual("/v2/service_plans/6a4367bd-9473-4766-bff8-6be4a3b1929d/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServiceInstancesForServicePlanResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""9f43d0ac-e261-48e7-a01d-596de681ac44"",
        ""url"": ""/v2/service_instances/9f43d0ac-e261-48e7-a01d-596de681ac44"",
        ""created_at"": ""2014-11-12T12:59:29+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-437"",
        ""credentials"": {
          ""creds-key-175"": ""creds-val-175""
        },
        ""service_plan_guid"": ""d3c55dea-f3b4-4af4-9d14-021da7f34624"",
        ""space_guid"": ""957e6dda-7f77-497b-b4a1-7b664b97e7d8"",
        ""gateway_data"": null,
        ""dashboard_url"": null,
        ""type"": ""managed_service_instance"",
        ""space_url"": ""/v2/spaces/957e6dda-7f77-497b-b4a1-7b664b97e7d8"",
        ""service_plan_url"": ""/v2/service_plans/d3c55dea-f3b4-4af4-9d14-021da7f34624"",
        ""service_bindings_url"": ""/v2/service_instances/9f43d0ac-e261-48e7-a01d-596de681ac44/service_bindings""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceInstancesForServicePlanResponse> page = Util.DeserializePage<ListAllServiceInstancesForServicePlanResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("9f43d0ac-e261-48e7-a01d-596de681ac44", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_instances/9f43d0ac-e261-48e7-a01d-596de681ac44", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-437", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("d3c55dea-f3b4-4af4-9d14-021da7f34624", TestUtil.ToTestableString(page[0].ServicePlanGuid), true);
                  Assert.AreEqual("957e6dda-7f77-497b-b4a1-7b664b97e7d8", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DashboardUrl), true);
                  Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("/v2/spaces/957e6dda-7f77-497b-b4a1-7b664b97e7d8", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/service_plans/d3c55dea-f3b4-4af4-9d14-021da7f34624", TestUtil.ToTestableString(page[0].ServicePlanUrl), true);
                  Assert.AreEqual("/v2/service_instances/9f43d0ac-e261-48e7-a01d-596de681ac44/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveServicePlanResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""019f791d-903f-46e5-83db-6a3d4fc0da25"",
    ""url"": ""/v2/service_plans/019f791d-903f-46e5-83db-6a3d4fc0da25"",
    ""created_at"": ""2014-11-12T12:59:29+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-435"",
    ""free"": false,
    ""description"": ""desc-96"",
    ""service_guid"": ""4be605fc-12b5-4c66-a314-af9affae2c7f"",
    ""extra"": null,
    ""unique_id"": ""f858e043-7fbc-403d-aa2e-ef9c19594896"",
    ""public"": true,
    ""active"": true,
    ""service_url"": ""/v2/services/4be605fc-12b5-4c66-a314-af9affae2c7f"",
    ""service_instances_url"": ""/v2/service_plans/019f791d-903f-46e5-83db-6a3d4fc0da25/service_instances""
  }
}";
    
            RetrieveServicePlanResponse obj = Util.DeserializeJson<RetrieveServicePlanResponse>(json);
        
            Assert.AreEqual("019f791d-903f-46e5-83db-6a3d4fc0da25", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_plans/019f791d-903f-46e5-83db-6a3d4fc0da25", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:29+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-435", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Free), true);
            Assert.AreEqual("desc-96", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("4be605fc-12b5-4c66-a314-af9affae2c7f", TestUtil.ToTestableString(obj.ServiceGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
            Assert.AreEqual("f858e043-7fbc-403d-aa2e-ef9c19594896", TestUtil.ToTestableString(obj.UniqueId), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Public), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("/v2/services/4be605fc-12b5-4c66-a314-af9affae2c7f", TestUtil.ToTestableString(obj.ServiceUrl), true);
            Assert.AreEqual("/v2/service_plans/019f791d-903f-46e5-83db-6a3d4fc0da25/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            
            
        }

    }
}
