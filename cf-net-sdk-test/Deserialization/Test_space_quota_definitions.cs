using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class SpaceQuotaDefinitionsTest
    {

    
        [TestMethod]
        public void TestRemoveSpaceFromSpaceQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""6692e2cb-6802-4bfd-9f16-2659b22d7cab"",
    ""url"": ""/v2/space_quota_definitions/6692e2cb-6802-4bfd-9f16-2659b22d7cab"",
    ""created_at"": ""2014-11-12T12:59:38+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-784"",
    ""organization_guid"": ""9928e49e-0a30-40f0-b7d6-3b055dffbe03"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 60,
    ""total_routes"": 1000,
    ""memory_limit"": 20480,
    ""instance_memory_limit"": -1,
    ""organization_url"": ""/v2/organizations/9928e49e-0a30-40f0-b7d6-3b055dffbe03"",
    ""spaces_url"": ""/v2/space_quota_definitions/6692e2cb-6802-4bfd-9f16-2659b22d7cab/spaces""
  }
}";
    
            RemoveSpaceFromSpaceQuotaDefinitionResponse obj = Util.DeserializeJson<RemoveSpaceFromSpaceQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("6692e2cb-6802-4bfd-9f16-2659b22d7cab", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/space_quota_definitions/6692e2cb-6802-4bfd-9f16-2659b22d7cab", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-784", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("9928e49e-0a30-40f0-b7d6-3b055dffbe03", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("60", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("1000", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("20480", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            Assert.AreEqual("/v2/organizations/9928e49e-0a30-40f0-b7d6-3b055dffbe03", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/space_quota_definitions/6692e2cb-6802-4bfd-9f16-2659b22d7cab/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateSpaceWithSpaceQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""8e0d39f5-4f72-4f86-9fba-74eb1ef6e468"",
    ""url"": ""/v2/space_quota_definitions/8e0d39f5-4f72-4f86-9fba-74eb1ef6e468"",
    ""created_at"": ""2014-11-12T12:59:38+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-794"",
    ""organization_guid"": ""18d16b10-e60f-4743-b0af-09f397b8ba7d"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 60,
    ""total_routes"": 1000,
    ""memory_limit"": 20480,
    ""instance_memory_limit"": -1,
    ""organization_url"": ""/v2/organizations/18d16b10-e60f-4743-b0af-09f397b8ba7d"",
    ""spaces_url"": ""/v2/space_quota_definitions/8e0d39f5-4f72-4f86-9fba-74eb1ef6e468/spaces""
  }
}";
    
            AssociateSpaceWithSpaceQuotaDefinitionResponse obj = Util.DeserializeJson<AssociateSpaceWithSpaceQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("8e0d39f5-4f72-4f86-9fba-74eb1ef6e468", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/space_quota_definitions/8e0d39f5-4f72-4f86-9fba-74eb1ef6e468", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-794", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("18d16b10-e60f-4743-b0af-09f397b8ba7d", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("60", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("1000", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("20480", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            Assert.AreEqual("/v2/organizations/18d16b10-e60f-4743-b0af-09f397b8ba7d", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/space_quota_definitions/8e0d39f5-4f72-4f86-9fba-74eb1ef6e468/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveSpaceQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""27e2df0c-df96-46bf-87d0-59545cc33360"",
    ""url"": ""/v2/space_quota_definitions/27e2df0c-df96-46bf-87d0-59545cc33360"",
    ""created_at"": ""2014-11-12T12:59:38+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-802"",
    ""organization_guid"": ""edf5bf92-75a7-439a-8359-af38f6fba8c9"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 60,
    ""total_routes"": 1000,
    ""memory_limit"": 20480,
    ""instance_memory_limit"": -1,
    ""organization_url"": ""/v2/organizations/edf5bf92-75a7-439a-8359-af38f6fba8c9"",
    ""spaces_url"": ""/v2/space_quota_definitions/27e2df0c-df96-46bf-87d0-59545cc33360/spaces""
  }
}";
    
            RetrieveSpaceQuotaDefinitionResponse obj = Util.DeserializeJson<RetrieveSpaceQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("27e2df0c-df96-46bf-87d0-59545cc33360", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/space_quota_definitions/27e2df0c-df96-46bf-87d0-59545cc33360", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-802", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("edf5bf92-75a7-439a-8359-af38f6fba8c9", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("60", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("1000", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("20480", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            Assert.AreEqual("/v2/organizations/edf5bf92-75a7-439a-8359-af38f6fba8c9", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/space_quota_definitions/27e2df0c-df96-46bf-87d0-59545cc33360/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateSpaceQuotaDefinitionRequest()
        {
            string json = @"{
  ""name"": ""gold_quota"",
  ""non_basic_services_allowed"": true,
  ""total_services"": 5,
  ""total_routes"": 10,
  ""memory_limit"": 5120,
  ""organization_guid"": ""42febec3-d385-488e-93b6-8569309ae97c""
}";
    
            CreateSpaceQuotaDefinitionRequest obj = Util.DeserializeJson<CreateSpaceQuotaDefinitionRequest>(json);
        
            Assert.AreEqual("gold_quota", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("5", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("10", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("5120", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("42febec3-d385-488e-93b6-8569309ae97c", TestUtil.ToTestableString(obj.OrganizationGuid), true);
        }

    
        [TestMethod]
        public void TestCreateSpaceQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""4dc16a69-9458-4b0b-b80b-3ca4716fa1fe"",
    ""url"": ""/v2/space_quota_definitions/4dc16a69-9458-4b0b-b80b-3ca4716fa1fe"",
    ""created_at"": ""2014-11-12T12:59:38+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""gold_quota"",
    ""organization_guid"": ""42febec3-d385-488e-93b6-8569309ae97c"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 5,
    ""total_routes"": 10,
    ""memory_limit"": 5120,
    ""instance_memory_limit"": -1,
    ""organization_url"": ""/v2/organizations/42febec3-d385-488e-93b6-8569309ae97c"",
    ""spaces_url"": ""/v2/space_quota_definitions/4dc16a69-9458-4b0b-b80b-3ca4716fa1fe/spaces""
  }
}";
    
            CreateSpaceQuotaDefinitionResponse obj = Util.DeserializeJson<CreateSpaceQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("4dc16a69-9458-4b0b-b80b-3ca4716fa1fe", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/space_quota_definitions/4dc16a69-9458-4b0b-b80b-3ca4716fa1fe", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("gold_quota", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("42febec3-d385-488e-93b6-8569309ae97c", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("5", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("10", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("5120", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            Assert.AreEqual("/v2/organizations/42febec3-d385-488e-93b6-8569309ae97c", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/space_quota_definitions/4dc16a69-9458-4b0b-b80b-3ca4716fa1fe/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestUpdateSpaceQuotaDefinitionRequest()
        {
            string json = @"{

}";
    
            UpdateSpaceQuotaDefinitionRequest obj = Util.DeserializeJson<UpdateSpaceQuotaDefinitionRequest>(json);
        
        }

    
        [TestMethod]
        public void TestUpdateSpaceQuotaDefinitionResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""d536f31f-03bb-4113-8ecd-350d447ea4f0"",
    ""url"": ""/v2/space_quota_definitions/d536f31f-03bb-4113-8ecd-350d447ea4f0"",
    ""created_at"": ""2014-11-12T12:59:38+02:00"",
    ""updated_at"": ""2014-11-12T12:59:38+02:00""
  },
  ""entity"": {
    ""name"": ""name-799"",
    ""organization_guid"": ""fb6132c5-c2d7-45f4-ac59-cc97d4bea830"",
    ""non_basic_services_allowed"": true,
    ""total_services"": 60,
    ""total_routes"": 1000,
    ""memory_limit"": 20480,
    ""instance_memory_limit"": -1,
    ""organization_url"": ""/v2/organizations/fb6132c5-c2d7-45f4-ac59-cc97d4bea830"",
    ""spaces_url"": ""/v2/space_quota_definitions/d536f31f-03bb-4113-8ecd-350d447ea4f0/spaces""
  }
}";
    
            UpdateSpaceQuotaDefinitionResponse obj = Util.DeserializeJson<UpdateSpaceQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("d536f31f-03bb-4113-8ecd-350d447ea4f0", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/space_quota_definitions/d536f31f-03bb-4113-8ecd-350d447ea4f0", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-799", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("fb6132c5-c2d7-45f4-ac59-cc97d4bea830", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.NonBasicServicesAllowed), true);
            Assert.AreEqual("60", TestUtil.ToTestableString(obj.TotalServices), true);
            Assert.AreEqual("1000", TestUtil.ToTestableString(obj.TotalRoutes), true);
            Assert.AreEqual("20480", TestUtil.ToTestableString(obj.MemoryLimit), true);
            Assert.AreEqual("-1", TestUtil.ToTestableString(obj.InstanceMemoryLimit), true);
            Assert.AreEqual("/v2/organizations/fb6132c5-c2d7-45f4-ac59-cc97d4bea830", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/space_quota_definitions/d536f31f-03bb-4113-8ecd-350d447ea4f0/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllSpacesForSpaceQuotaDefinitionResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""f96951d0-143f-4939-9297-fce49b28907d"",
        ""url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d"",
        ""created_at"": ""2014-11-12T12:59:38+02:00"",
        ""updated_at"": ""2014-11-12T12:59:38+02:00""
      },
      ""entity"": {
        ""name"": ""name-792"",
        ""organization_guid"": ""5dc71799-2a26-4099-a5cd-8fcfbc2d7a3a"",
        ""space_quota_definition_guid"": ""2b9bb99b-e11e-48aa-941b-4fd298f408cc"",
        ""organization_url"": ""/v2/organizations/5dc71799-2a26-4099-a5cd-8fcfbc2d7a3a"",
        ""space_quota_definition_url"": ""/v2/space_quota_definitions/2b9bb99b-e11e-48aa-941b-4fd298f408cc"",
        ""developers_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/developers"",
        ""managers_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/managers"",
        ""auditors_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/auditors"",
        ""apps_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/apps"",
        ""routes_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/routes"",
        ""domains_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/domains"",
        ""service_instances_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/service_instances"",
        ""app_events_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/app_events"",
        ""events_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/events"",
        ""security_groups_url"": ""/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpacesForSpaceQuotaDefinitionResponse> page = Util.DeserializePage<ListAllSpacesForSpaceQuotaDefinitionResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("f96951d0-143f-4939-9297-fce49b28907d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-792", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("5dc71799-2a26-4099-a5cd-8fcfbc2d7a3a", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("2b9bb99b-e11e-48aa-941b-4fd298f408cc", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/5dc71799-2a26-4099-a5cd-8fcfbc2d7a3a", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/space_quota_definitions/2b9bb99b-e11e-48aa-941b-4fd298f408cc", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/f96951d0-143f-4939-9297-fce49b28907d/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllSpaceQuotaDefinitionsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""f0cab7a0-53aa-4d05-95b6-6db13ee1aade"",
        ""url"": ""/v2/space_quota_definitions/f0cab7a0-53aa-4d05-95b6-6db13ee1aade"",
        ""created_at"": ""2014-11-12T12:59:37+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-773"",
        ""organization_guid"": ""b2768d66-ad15-4c35-9e5b-68fd38809dae"",
        ""non_basic_services_allowed"": true,
        ""total_services"": 60,
        ""total_routes"": 1000,
        ""memory_limit"": 20480,
        ""instance_memory_limit"": -1,
        ""organization_url"": ""/v2/organizations/b2768d66-ad15-4c35-9e5b-68fd38809dae"",
        ""spaces_url"": ""/v2/space_quota_definitions/f0cab7a0-53aa-4d05-95b6-6db13ee1aade/spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpaceQuotaDefinitionsResponse> page = Util.DeserializePage<ListAllSpaceQuotaDefinitionsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("f0cab7a0-53aa-4d05-95b6-6db13ee1aade", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/space_quota_definitions/f0cab7a0-53aa-4d05-95b6-6db13ee1aade", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-773", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("b2768d66-ad15-4c35-9e5b-68fd38809dae", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].NonBasicServicesAllowed), true);
                  Assert.AreEqual("60", TestUtil.ToTestableString(page[0].TotalServices), true);
                  Assert.AreEqual("1000", TestUtil.ToTestableString(page[0].TotalRoutes), true);
                  Assert.AreEqual("20480", TestUtil.ToTestableString(page[0].MemoryLimit), true);
                  Assert.AreEqual("-1", TestUtil.ToTestableString(page[0].InstanceMemoryLimit), true);
                  Assert.AreEqual("/v2/organizations/b2768d66-ad15-4c35-9e5b-68fd38809dae", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/space_quota_definitions/f0cab7a0-53aa-4d05-95b6-6db13ee1aade/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
               
               
            
    
        }

    }
}
