using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class OrganizationQuotaDefinitionsTest
    {

    
        [TestMethod]
        public void TestListAllOrganizationQuotaDefinitionsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""2010c4bf-ab44-417a-abd7-869fab753b4d"",
        ""url"": ""/v2/quota_definitions/2010c4bf-ab44-417a-abd7-869fab753b4d"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""default"",
        ""non_basic_services_allowed"": true,
        ""total_services"": 100,
        ""total_routes"": 1000,
        ""memory_limit"": 10240,
        ""trial_db_allowed"": false,
        ""instance_memory_limit"": -1
      }
    }
  ]
}";
    
            PagedResponse<ListAllOrganizationQuotaDefinitionsResponse> page = Util.DeserializePage<ListAllOrganizationQuotaDefinitionsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("2010c4bf-ab44-417a-abd7-869fab753b4d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/quota_definitions/2010c4bf-ab44-417a-abd7-869fab753b4d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("default", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].NonBasicServicesAllowed), true);
                  Assert.AreEqual("100", TestUtil.ToTestableString(page[0].TotalServices), true);
                  Assert.AreEqual("1000", TestUtil.ToTestableString(page[0].TotalRoutes), true);
                  Assert.AreEqual("10240", TestUtil.ToTestableString(page[0].MemoryLimit), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].TrialDbAllowed), true);
                  Assert.AreEqual("-1", TestUtil.ToTestableString(page[0].InstanceMemoryLimit), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestUpdateOrganizationQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""6fd8faad-d617-4636-b0aa-776ca8028992"",
    ""url"": ""/v2/quota_definitions/6fd8faad-d617-4636-b0aa-776ca8028992"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""updated_at"": ""2014-11-12T12:59:44+02:00""
  },
  ""entity"": {
    ""name"": ""name-1165"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 60,
    ""total_routes"": 1000,
    ""memory_limit"": 20480,
    ""trial_db_allowed"": false,
    ""instance_memory_limit"": -1
  }
}";
    
            UpdateOrganizationQuotaDefinitionResponse obj = Util.DeserializeJson<UpdateOrganizationQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("6fd8faad-d617-4636-b0aa-776ca8028992", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/quota_definitions/6fd8faad-d617-4636-b0aa-776ca8028992", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1165", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("60", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("1000", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("20480", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.TrialDbAllowed), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveOrganizationQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""6db7c06a-aa52-4931-b235-632e39f37057"",
    ""url"": ""/v2/quota_definitions/6db7c06a-aa52-4931-b235-632e39f37057"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1167"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 60,
    ""total_routes"": 1000,
    ""memory_limit"": 20480,
    ""trial_db_allowed"": false,
    ""instance_memory_limit"": -1
  }
}";
    
            RetrieveOrganizationQuotaDefinitionResponse obj = Util.DeserializeJson<RetrieveOrganizationQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("6db7c06a-aa52-4931-b235-632e39f37057", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/quota_definitions/6db7c06a-aa52-4931-b235-632e39f37057", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1167", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("60", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("1000", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("20480", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.TrialDbAllowed), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateOrganizationQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""6ef906c1-335f-4359-8dc1-c2bf7940789a"",
    ""url"": ""/v2/quota_definitions/6ef906c1-335f-4359-8dc1-c2bf7940789a"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""gold_quota"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 5,
    ""total_routes"": 10,
    ""memory_limit"": 5120,
    ""trial_db_allowed"": false,
    ""instance_memory_limit"": 10240
  }
}";
    
            CreateOrganizationQuotaDefinitionResponse obj = Util.DeserializeJson<CreateOrganizationQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("6ef906c1-335f-4359-8dc1-c2bf7940789a", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/quota_definitions/6ef906c1-335f-4359-8dc1-c2bf7940789a", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("gold_quota", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("5", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("10", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("5120", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.TrialDbAllowed), true);
            Assert.AreEqual("10240", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            
            
        }

    }
}
