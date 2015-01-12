using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class DomainsDeprecatedTest
    {

    
        [TestMethod]
        public void TestRetrieveDomainDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""81162eb4-ca5e-462a-a6e8-42a8fdfc0c3f"",
    ""url"": ""/v2/domains/81162eb4-ca5e-462a-a6e8-42a8fdfc0c3f"",
    ""created_at"": ""2014-11-12T12:59:19+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""domain-5.example.com""
  }
}";
    
            RetrieveDomainDeprecatedResponse obj = Util.DeserializeJson<RetrieveDomainDeprecatedResponse>(json);
        
            Assert.AreEqual("81162eb4-ca5e-462a-a6e8-42a8fdfc0c3f", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/domains/81162eb4-ca5e-462a-a6e8-42a8fdfc0c3f", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("domain-5.example.com", TestUtil.ToTestableString(obj.Name), true);
            
            
        }

    
        [TestMethod]
        public void TestCreatesSharedDomainDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""example.com"",
  ""wildcard"": true
}";
    
            CreatesSharedDomainDeprecatedRequest obj = Util.DeserializeJson<CreatesSharedDomainDeprecatedRequest>(json);
        
            Assert.AreEqual("example.com", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Wildcard), true);
        }

    
        [TestMethod]
        public void TestCreatesSharedDomainDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""d4624ac6-8699-4eb6-9fed-161232ee2030"",
    ""url"": ""/v2/domains/d4624ac6-8699-4eb6-9fed-161232ee2030"",
    ""created_at"": ""2014-11-12T12:59:19+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""example.com"",
    ""owning_organization_guid"": null
  }
}";
    
            CreatesSharedDomainDeprecatedResponse obj = Util.DeserializeJson<CreatesSharedDomainDeprecatedResponse>(json);
        
            Assert.AreEqual("d4624ac6-8699-4eb6-9fed-161232ee2030", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/domains/d4624ac6-8699-4eb6-9fed-161232ee2030", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("example.com", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllDomainsDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 4,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""a10045e3-b7af-4b26-8dfa-4358753eba14"",
        ""url"": ""/v2/domains/a10045e3-b7af-4b26-8dfa-4358753eba14"",
        ""created_at"": ""2014-11-12T12:59:18+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain1.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""a1e34a27-de5e-4684-a945-795284380c72"",
        ""url"": ""/v2/domains/a1e34a27-de5e-4684-a945-795284380c72"",
        ""created_at"": ""2014-11-12T12:59:18+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain2.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""fac0ff91-bd76-4516-9959-21789bf0a6ac"",
        ""url"": ""/v2/domains/fac0ff91-bd76-4516-9959-21789bf0a6ac"",
        ""created_at"": ""2014-11-12T12:59:18+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""vcap.me"",
        ""owning_organization_guid"": ""e4012541-d492-43f5-9298-3ab33c1702f3"",
        ""owning_organization_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3"",
        ""spaces_url"": ""/v2/domains/fac0ff91-bd76-4516-9959-21789bf0a6ac/spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""a4a89f2f-9c9e-4441-947a-986ce850f829"",
        ""url"": ""/v2/domains/a4a89f2f-9c9e-4441-947a-986ce850f829"",
        ""created_at"": ""2014-11-12T12:59:18+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-1.example.com""
      }
    }
  ]
}";
    
            PagedResponse<ListAllDomainsDeprecatedResponse> page = Util.DeserializePage<ListAllDomainsDeprecatedResponse>(json);
        
            Assert.AreEqual("4", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("a10045e3-b7af-4b26-8dfa-4358753eba14", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/domains/a10045e3-b7af-4b26-8dfa-4358753eba14", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:18+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("customer-app-domain1.com", TestUtil.ToTestableString(page[0].Name), true);
               
               
            
            
                Assert.AreEqual("a1e34a27-de5e-4684-a945-795284380c72", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/domains/a1e34a27-de5e-4684-a945-795284380c72", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:18+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("customer-app-domain2.com", TestUtil.ToTestableString(page[1].Name), true);
               
               
            
            
                Assert.AreEqual("fac0ff91-bd76-4516-9959-21789bf0a6ac", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/domains/fac0ff91-bd76-4516-9959-21789bf0a6ac", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:18+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("vcap.me", TestUtil.ToTestableString(page[2].Name), true);
                  Assert.AreEqual("e4012541-d492-43f5-9298-3ab33c1702f3", TestUtil.ToTestableString(page[2].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3", TestUtil.ToTestableString(page[2].OwningOrganizationUrl), true);
                  Assert.AreEqual("/v2/domains/fac0ff91-bd76-4516-9959-21789bf0a6ac/spaces", TestUtil.ToTestableString(page[2].SpacesUrl), true);
               
               
            
            
                Assert.AreEqual("a4a89f2f-9c9e-4441-947a-986ce850f829", TestUtil.ToTestableString(page[3].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/domains/a4a89f2f-9c9e-4441-947a-986ce850f829", TestUtil.ToTestableString(page[3].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:18+02:00", TestUtil.ToTestableString(page[3].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[3].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-1.example.com", TestUtil.ToTestableString(page[3].Name), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllSpacesForDomainDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""08566816-f559-4110-b949-ac3b7f4ed3f8"",
        ""url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8"",
        ""created_at"": ""2014-11-12T12:59:19+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-5"",
        ""organization_guid"": ""c22cc6e2-15ba-4952-9fb6-e5168e0242bf"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/c22cc6e2-15ba-4952-9fb6-e5168e0242bf"",
        ""developers_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/developers"",
        ""managers_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/managers"",
        ""auditors_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/auditors"",
        ""apps_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/apps"",
        ""routes_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/routes"",
        ""domains_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/domains"",
        ""service_instances_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/service_instances"",
        ""app_events_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/app_events"",
        ""events_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/events"",
        ""security_groups_url"": ""/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpacesForDomainDeprecatedResponse> page = Util.DeserializePage<ListAllSpacesForDomainDeprecatedResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("08566816-f559-4110-b949-ac3b7f4ed3f8", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-5", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("c22cc6e2-15ba-4952-9fb6-e5168e0242bf", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/c22cc6e2-15ba-4952-9fb6-e5168e0242bf", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/08566816-f559-4110-b949-ac3b7f4ed3f8/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreatesDomainOwnedByGivenOrganizationDeprecatedRequest()
        {
            string json = @"{
  ""name"": ""exmaple.com"",
  ""wildcard"": true,
  ""owning_organization_guid"": ""3888312a-9b88-4e22-87b6-a408f4f76cd7""
}";
    
            CreatesDomainOwnedByGivenOrganizationDeprecatedRequest obj = Util.DeserializeJson<CreatesDomainOwnedByGivenOrganizationDeprecatedRequest>(json);
        
            Assert.AreEqual("exmaple.com", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Wildcard), true);
            Assert.AreEqual("3888312a-9b88-4e22-87b6-a408f4f76cd7", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
        }

    
        [TestMethod]
        public void TestCreatesDomainOwnedByGivenOrganizationDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""38c4ecf0-4264-441e-bff6-f86371613dc2"",
    ""url"": ""/v2/domains/38c4ecf0-4264-441e-bff6-f86371613dc2"",
    ""created_at"": ""2014-11-12T12:59:19+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""exmaple.com"",
    ""owning_organization_guid"": ""3888312a-9b88-4e22-87b6-a408f4f76cd7"",
    ""owning_organization_url"": ""/v2/organizations/3888312a-9b88-4e22-87b6-a408f4f76cd7"",
    ""spaces_url"": ""/v2/domains/38c4ecf0-4264-441e-bff6-f86371613dc2/spaces""
  }
}";
    
            CreatesDomainOwnedByGivenOrganizationDeprecatedResponse obj = Util.DeserializeJson<CreatesDomainOwnedByGivenOrganizationDeprecatedResponse>(json);
        
            Assert.AreEqual("38c4ecf0-4264-441e-bff6-f86371613dc2", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/domains/38c4ecf0-4264-441e-bff6-f86371613dc2", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:19+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("exmaple.com", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("3888312a-9b88-4e22-87b6-a408f4f76cd7", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
            Assert.AreEqual("/v2/organizations/3888312a-9b88-4e22-87b6-a408f4f76cd7", TestUtil.ToTestableString(obj.OwningOrganizationUrl), true);
            Assert.AreEqual("/v2/domains/38c4ecf0-4264-441e-bff6-f86371613dc2/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    }
}
