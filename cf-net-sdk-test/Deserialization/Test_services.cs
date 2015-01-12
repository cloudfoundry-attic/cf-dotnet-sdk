using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class ServicesTest
    {

    
        [TestMethod]
        public void TestUpdateServiceDeprecatedRequest()
        {
            string json = @"{
  ""label"": ""SomeMysqlService"",
  ""description"": ""Mysql stores things for you"",
  ""provider"": ""MySql Provider"",
  ""version"": ""2.0"",
  ""url"": ""http://myql.provider.com""
}";
    
            UpdateServiceDeprecatedRequest obj = Util.DeserializeJson<UpdateServiceDeprecatedRequest>(json);
        
            Assert.AreEqual("SomeMysqlService", TestUtil.ToTestableString(obj.Label), true);
            Assert.AreEqual("Mysql stores things for you", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("MySql Provider", TestUtil.ToTestableString(obj.Provider), true);
            Assert.AreEqual("2.0", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("http://myql.provider.com", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestUpdateServiceDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""78cf48b5-e37b-465b-88e7-a6273ea21e1b"",
    ""url"": ""/v2/services/78cf48b5-e37b-465b-88e7-a6273ea21e1b"",
    ""created_at"": ""2014-11-12T12:59:31+02:00"",
    ""updated_at"": ""2014-11-12T12:59:31+02:00""
  },
  ""entity"": {
    ""label"": ""SomeMysqlService"",
    ""provider"": ""MySql Provider"",
    ""url"": ""http://myql.provider.com"",
    ""description"": ""Mysql stores things for you"",
    ""long_description"": null,
    ""version"": ""2.0"",
    ""info_url"": null,
    ""active"": true,
    ""bindable"": true,
    ""unique_id"": ""d4a32f65-7ed7-47de-b03b-5e33b549edb0"",
    ""extra"": null,
    ""tags"": [

    ],
    ""requires"": [

    ],
    ""documentation_url"": null,
    ""service_broker_guid"": ""20569f8c-3179-45c2-b864-671f34d92fbf"",
    ""plan_updateable"": false,
    ""service_plans_url"": ""/v2/services/78cf48b5-e37b-465b-88e7-a6273ea21e1b/service_plans""
  }
}";
    
            UpdateServiceDeprecatedResponse obj = Util.DeserializeJson<UpdateServiceDeprecatedResponse>(json);
        
            Assert.AreEqual("78cf48b5-e37b-465b-88e7-a6273ea21e1b", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/services/78cf48b5-e37b-465b-88e7-a6273ea21e1b", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("SomeMysqlService", TestUtil.ToTestableString(obj.Label), true);
            Assert.AreEqual("MySql Provider", TestUtil.ToTestableString(obj.Provider), true);
            Assert.AreEqual("http://myql.provider.com", TestUtil.ToTestableString(obj.Url), true);
            Assert.AreEqual("Mysql stores things for you", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.LongDescription), true);
            Assert.AreEqual("2.0", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.InfoUrl), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Bindable), true);
            Assert.AreEqual("d4a32f65-7ed7-47de-b03b-5e33b549edb0", TestUtil.ToTestableString(obj.UniqueId), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
            
            
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DocumentationUrl), true);
            Assert.AreEqual("20569f8c-3179-45c2-b864-671f34d92fbf", TestUtil.ToTestableString(obj.ServiceBrokerGuid), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.PlanUpdateable), true);
            Assert.AreEqual("/v2/services/78cf48b5-e37b-465b-88e7-a6273ea21e1b/service_plans", TestUtil.ToTestableString(obj.ServicePlansUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServicePlansForServiceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""f309f7ac-2f2a-4174-ba05-8e906694e5f2"",
        ""url"": ""/v2/service_plans/f309f7ac-2f2a-4174-ba05-8e906694e5f2"",
        ""created_at"": ""2014-11-12T12:59:31+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-526"",
        ""free"": false,
        ""description"": ""desc-114"",
        ""service_guid"": ""c32b047d-054b-4f52-a7f5-565a2d0d5d59"",
        ""extra"": null,
        ""unique_id"": ""451818e0-f4e0-415a-8e8e-61a56a4ed4da"",
        ""public"": true,
        ""active"": true,
        ""service_url"": ""/v2/services/c32b047d-054b-4f52-a7f5-565a2d0d5d59"",
        ""service_instances_url"": ""/v2/service_plans/f309f7ac-2f2a-4174-ba05-8e906694e5f2/service_instances""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServicePlansForServiceResponse> page = Util.DeserializePage<ListAllServicePlansForServiceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("f309f7ac-2f2a-4174-ba05-8e906694e5f2", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plans/f309f7ac-2f2a-4174-ba05-8e906694e5f2", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-526", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Free), true);
                  Assert.AreEqual("desc-114", TestUtil.ToTestableString(page[0].Description), true);
                  Assert.AreEqual("c32b047d-054b-4f52-a7f5-565a2d0d5d59", TestUtil.ToTestableString(page[0].ServiceGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Extra), true);
                  Assert.AreEqual("451818e0-f4e0-415a-8e8e-61a56a4ed4da", TestUtil.ToTestableString(page[0].UniqueId), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Public), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("/v2/services/c32b047d-054b-4f52-a7f5-565a2d0d5d59", TestUtil.ToTestableString(page[0].ServiceUrl), true);
                  Assert.AreEqual("/v2/service_plans/f309f7ac-2f2a-4174-ba05-8e906694e5f2/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveServiceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""c139bb39-b25a-43ee-a050-19c379aa18e7"",
    ""url"": ""/v2/services/c139bb39-b25a-43ee-a050-19c379aa18e7"",
    ""created_at"": ""2014-11-12T12:59:31+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""label"": ""label-52"",
    ""provider"": ""provider-43"",
    ""url"": ""https://foo.com/url-39"",
    ""description"": ""desc-112"",
    ""long_description"": null,
    ""version"": ""version-27"",
    ""info_url"": null,
    ""active"": true,
    ""bindable"": true,
    ""unique_id"": ""2621b0e3-51d0-45b0-aa7f-e461e5fa6d3d"",
    ""extra"": null,
    ""tags"": [

    ],
    ""requires"": [

    ],
    ""documentation_url"": null,
    ""service_broker_guid"": ""766aeb88-37b7-4da2-8b7f-a74aa94a4773"",
    ""plan_updateable"": false,
    ""service_plans_url"": ""/v2/services/c139bb39-b25a-43ee-a050-19c379aa18e7/service_plans""
  }
}";
    
            RetrieveServiceResponse obj = Util.DeserializeJson<RetrieveServiceResponse>(json);
        
            Assert.AreEqual("c139bb39-b25a-43ee-a050-19c379aa18e7", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/services/c139bb39-b25a-43ee-a050-19c379aa18e7", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("label-52", TestUtil.ToTestableString(obj.Label), true);
            Assert.AreEqual("provider-43", TestUtil.ToTestableString(obj.Provider), true);
            Assert.AreEqual("https://foo.com/url-39", TestUtil.ToTestableString(obj.Url), true);
            Assert.AreEqual("desc-112", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.LongDescription), true);
            Assert.AreEqual("version-27", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.InfoUrl), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Bindable), true);
            Assert.AreEqual("2621b0e3-51d0-45b0-aa7f-e461e5fa6d3d", TestUtil.ToTestableString(obj.UniqueId), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
            
            
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DocumentationUrl), true);
            Assert.AreEqual("766aeb88-37b7-4da2-8b7f-a74aa94a4773", TestUtil.ToTestableString(obj.ServiceBrokerGuid), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.PlanUpdateable), true);
            Assert.AreEqual("/v2/services/c139bb39-b25a-43ee-a050-19c379aa18e7/service_plans", TestUtil.ToTestableString(obj.ServicePlansUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServicesResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""2c060ba5-27c9-4fcf-815f-d696e9da735d"",
        ""url"": ""/v2/services/2c060ba5-27c9-4fcf-815f-d696e9da735d"",
        ""created_at"": ""2014-11-12T12:59:31+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-49"",
        ""provider"": ""provider-40"",
        ""url"": ""https://foo.com/url-33"",
        ""description"": ""desc-109"",
        ""long_description"": null,
        ""version"": ""version-24"",
        ""info_url"": null,
        ""active"": true,
        ""bindable"": true,
        ""unique_id"": ""28e4aa93-e54a-430c-b0f8-e4819d422382"",
        ""extra"": null,
        ""tags"": [

        ],
        ""requires"": [

        ],
        ""documentation_url"": null,
        ""service_broker_guid"": ""7de4d510-aacf-4ead-97d7-32828d296de3"",
        ""plan_updateable"": false,
        ""service_plans_url"": ""/v2/services/2c060ba5-27c9-4fcf-815f-d696e9da735d/service_plans""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServicesResponse> page = Util.DeserializePage<ListAllServicesResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("2c060ba5-27c9-4fcf-815f-d696e9da735d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/services/2c060ba5-27c9-4fcf-815f-d696e9da735d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-49", TestUtil.ToTestableString(page[0].Label), true);
                  Assert.AreEqual("provider-40", TestUtil.ToTestableString(page[0].Provider), true);
                  Assert.AreEqual("https://foo.com/url-33", TestUtil.ToTestableString(page[0].Url), true);
                  Assert.AreEqual("desc-109", TestUtil.ToTestableString(page[0].Description), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].LongDescription), true);
                  Assert.AreEqual("version-24", TestUtil.ToTestableString(page[0].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].InfoUrl), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Bindable), true);
                  Assert.AreEqual("28e4aa93-e54a-430c-b0f8-e4819d422382", TestUtil.ToTestableString(page[0].UniqueId), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Extra), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DocumentationUrl), true);
                  Assert.AreEqual("7de4d510-aacf-4ead-97d7-32828d296de3", TestUtil.ToTestableString(page[0].ServiceBrokerGuid), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].PlanUpdateable), true);
                  Assert.AreEqual("/v2/services/2c060ba5-27c9-4fcf-815f-d696e9da735d/service_plans", TestUtil.ToTestableString(page[0].ServicePlansUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreateServiceDeprecatedRequest()
        {
            string json = @"{
  ""label"": ""SomeMysqlService"",
  ""description"": ""Mysql stores things for you"",
  ""provider"": ""MySql Provider"",
  ""version"": ""2.0"",
  ""url"": ""http://myql.provider.com""
}";
    
            CreateServiceDeprecatedRequest obj = Util.DeserializeJson<CreateServiceDeprecatedRequest>(json);
        
            Assert.AreEqual("SomeMysqlService", TestUtil.ToTestableString(obj.Label), true);
            Assert.AreEqual("Mysql stores things for you", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("MySql Provider", TestUtil.ToTestableString(obj.Provider), true);
            Assert.AreEqual("2.0", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("http://myql.provider.com", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestCreateServiceDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""f747d3d3-8a3e-4065-a1db-bba3541fbee7"",
    ""url"": ""/v2/services/f747d3d3-8a3e-4065-a1db-bba3541fbee7"",
    ""created_at"": ""2014-11-12T12:59:31+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""label"": ""SomeMysqlService"",
    ""provider"": ""MySql Provider"",
    ""url"": ""http://myql.provider.com"",
    ""description"": ""Mysql stores things for you"",
    ""long_description"": null,
    ""version"": ""2.0"",
    ""info_url"": null,
    ""active"": false,
    ""bindable"": true,
    ""unique_id"": null,
    ""extra"": null,
    ""tags"": [

    ],
    ""requires"": [

    ],
    ""documentation_url"": null,
    ""service_broker_guid"": null,
    ""plan_updateable"": false,
    ""service_plans_url"": ""/v2/services/f747d3d3-8a3e-4065-a1db-bba3541fbee7/service_plans""
  }
}";
    
            CreateServiceDeprecatedResponse obj = Util.DeserializeJson<CreateServiceDeprecatedResponse>(json);
        
            Assert.AreEqual("f747d3d3-8a3e-4065-a1db-bba3541fbee7", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/services/f747d3d3-8a3e-4065-a1db-bba3541fbee7", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("SomeMysqlService", TestUtil.ToTestableString(obj.Label), true);
            Assert.AreEqual("MySql Provider", TestUtil.ToTestableString(obj.Provider), true);
            Assert.AreEqual("http://myql.provider.com", TestUtil.ToTestableString(obj.Url), true);
            Assert.AreEqual("Mysql stores things for you", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.LongDescription), true);
            Assert.AreEqual("2.0", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.InfoUrl), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Bindable), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.UniqueId), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
            
            
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DocumentationUrl), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ServiceBrokerGuid), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.PlanUpdateable), true);
            Assert.AreEqual("/v2/services/f747d3d3-8a3e-4065-a1db-bba3541fbee7/service_plans", TestUtil.ToTestableString(obj.ServicePlansUrl), true);
            
            
        }

    }
}
