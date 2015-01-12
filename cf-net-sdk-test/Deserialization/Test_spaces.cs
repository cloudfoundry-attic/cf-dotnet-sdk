using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class SpacesTest
    {

    
        [TestMethod]
        public void TestUpdateSpaceRequest()
        {
            string json = @"{
  ""name"": ""New Space Name""
}";
    
            UpdateSpaceRequest obj = Util.DeserializeJson<UpdateSpaceRequest>(json);
        
            Assert.AreEqual("New Space Name", TestUtil.ToTestableString(obj.Name), true);
        }

    
        [TestMethod]
        public void TestUpdateSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""07f22f05-39c7-4eed-8d53-502427409d68"",
    ""url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68"",
    ""created_at"": ""2014-11-12T12:59:46+02:00"",
    ""updated_at"": ""2014-11-12T12:59:46+02:00""
  },
  ""entity"": {
    ""name"": ""New Space Name"",
    ""organization_guid"": ""28507183-b20f-412b-b3c5-00884ec84d8f"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/28507183-b20f-412b-b3c5-00884ec84d8f"",
    ""developers_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/developers"",
    ""managers_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/managers"",
    ""auditors_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/auditors"",
    ""apps_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/apps"",
    ""routes_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/routes"",
    ""domains_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/domains"",
    ""service_instances_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/service_instances"",
    ""app_events_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/app_events"",
    ""events_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/events"",
    ""security_groups_url"": ""/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/security_groups""
  }
}";
    
            UpdateSpaceResponse obj = Util.DeserializeJson<UpdateSpaceResponse>(json);
        
            Assert.AreEqual("07f22f05-39c7-4eed-8d53-502427409d68", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("New Space Name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("28507183-b20f-412b-b3c5-00884ec84d8f", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/28507183-b20f-412b-b3c5-00884ec84d8f", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/07f22f05-39c7-4eed-8d53-502427409d68/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllDevelopersForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-307"",
        ""url"": ""/v2/users/uaa-id-307"",
        ""created_at"": ""2014-11-12T12:59:47+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-307/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-307/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-307/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-307/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-307/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-307/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-307/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllDevelopersForSpaceResponse> page = Util.DeserializePage<ListAllDevelopersForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-307", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-307", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-307/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveDeveloperFromSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""452de0ee-dd71-4d12-92b9-3badd8a171df"",
    ""url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df"",
    ""created_at"": ""2014-11-12T12:59:47+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1279"",
    ""organization_guid"": ""7d1b36df-2f28-4ac2-a179-8ceb203986be"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/7d1b36df-2f28-4ac2-a179-8ceb203986be"",
    ""developers_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/developers"",
    ""managers_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/managers"",
    ""auditors_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/auditors"",
    ""apps_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/apps"",
    ""routes_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/routes"",
    ""domains_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/domains"",
    ""service_instances_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/service_instances"",
    ""app_events_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/app_events"",
    ""events_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/events"",
    ""security_groups_url"": ""/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/security_groups""
  }
}";
    
            RemoveDeveloperFromSpaceResponse obj = Util.DeserializeJson<RemoveDeveloperFromSpaceResponse>(json);
        
            Assert.AreEqual("452de0ee-dd71-4d12-92b9-3badd8a171df", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1279", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("7d1b36df-2f28-4ac2-a179-8ceb203986be", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/7d1b36df-2f28-4ac2-a179-8ceb203986be", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/452de0ee-dd71-4d12-92b9-3badd8a171df/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServicesForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""16aef387-0264-4de0-a84a-54fbcc3805e8"",
        ""url"": ""/v2/services/16aef387-0264-4de0-a84a-54fbcc3805e8"",
        ""created_at"": ""2014-11-12T12:59:47+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-68"",
        ""provider"": ""provider-59"",
        ""url"": ""https://foo.com/url-71"",
        ""description"": ""desc-159"",
        ""long_description"": null,
        ""version"": ""version-43"",
        ""info_url"": null,
        ""active"": true,
        ""bindable"": true,
        ""unique_id"": ""2e657f16-c515-460b-987b-9c8cd2fbd405"",
        ""extra"": null,
        ""tags"": [

        ],
        ""requires"": [

        ],
        ""documentation_url"": null,
        ""service_broker_guid"": null,
        ""plan_updateable"": false,
        ""service_plans_url"": ""/v2/services/16aef387-0264-4de0-a84a-54fbcc3805e8/service_plans""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServicesForSpaceResponse> page = Util.DeserializePage<ListAllServicesForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("16aef387-0264-4de0-a84a-54fbcc3805e8", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/services/16aef387-0264-4de0-a84a-54fbcc3805e8", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-68", TestUtil.ToTestableString(page[0].Label), true);
                  Assert.AreEqual("provider-59", TestUtil.ToTestableString(page[0].Provider), true);
                  Assert.AreEqual("https://foo.com/url-71", TestUtil.ToTestableString(page[0].Url), true);
                  Assert.AreEqual("desc-159", TestUtil.ToTestableString(page[0].Description), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].LongDescription), true);
                  Assert.AreEqual("version-43", TestUtil.ToTestableString(page[0].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].InfoUrl), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Bindable), true);
                  Assert.AreEqual("2e657f16-c515-460b-987b-9c8cd2fbd405", TestUtil.ToTestableString(page[0].UniqueId), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Extra), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DocumentationUrl), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].ServiceBrokerGuid), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].PlanUpdateable), true);
                  Assert.AreEqual("/v2/services/16aef387-0264-4de0-a84a-54fbcc3805e8/service_plans", TestUtil.ToTestableString(page[0].ServicePlansUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllDomainsForSpaceDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 2,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""61f29f9c-cb36-4692-a62d-7f9289119eb0"",
        ""url"": ""/v2/domains/61f29f9c-cb36-4692-a62d-7f9289119eb0"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain1.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""b36bc148-9f7c-4046-acf7-387af66a7e64"",
        ""url"": ""/v2/domains/b36bc148-9f7c-4046-acf7-387af66a7e64"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain2.com""
      }
    }
  ]
}";
    
            PagedResponse<ListAllDomainsForSpaceDeprecatedResponse> page = Util.DeserializePage<ListAllDomainsForSpaceDeprecatedResponse>(json);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("61f29f9c-cb36-4692-a62d-7f9289119eb0", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/domains/61f29f9c-cb36-4692-a62d-7f9289119eb0", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("customer-app-domain1.com", TestUtil.ToTestableString(page[0].Name), true);
               
               
            
            
                Assert.AreEqual("b36bc148-9f7c-4046-acf7-387af66a7e64", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/domains/b36bc148-9f7c-4046-acf7-387af66a7e64", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("customer-app-domain2.com", TestUtil.ToTestableString(page[1].Name), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveAuditorFromSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""63a784d1-0280-45ee-9d87-4169b26ba4a6"",
    ""url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6"",
    ""created_at"": ""2014-11-12T12:59:46+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1251"",
    ""organization_guid"": ""0d7edc33-ca41-48aa-b2ce-51b9808585ed"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/0d7edc33-ca41-48aa-b2ce-51b9808585ed"",
    ""developers_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/developers"",
    ""managers_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/managers"",
    ""auditors_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/auditors"",
    ""apps_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/apps"",
    ""routes_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/routes"",
    ""domains_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/domains"",
    ""service_instances_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/service_instances"",
    ""app_events_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/app_events"",
    ""events_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/events"",
    ""security_groups_url"": ""/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/security_groups""
  }
}";
    
            RemoveAuditorFromSpaceResponse obj = Util.DeserializeJson<RemoveAuditorFromSpaceResponse>(json);
        
            Assert.AreEqual("63a784d1-0280-45ee-9d87-4169b26ba4a6", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1251", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("0d7edc33-ca41-48aa-b2ce-51b9808585ed", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/0d7edc33-ca41-48aa-b2ce-51b9808585ed", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/63a784d1-0280-45ee-9d87-4169b26ba4a6/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllSpacesResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""fa82b3a8-d095-4668-89b7-e917ff587074"",
        ""url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074"",
        ""created_at"": ""2014-11-12T12:59:46+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-1229"",
        ""organization_guid"": ""07fba830-4583-4ad4-8911-85c1b4281f9f"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/07fba830-4583-4ad4-8911-85c1b4281f9f"",
        ""developers_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/developers"",
        ""managers_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/managers"",
        ""auditors_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/auditors"",
        ""apps_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/apps"",
        ""routes_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/routes"",
        ""domains_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/domains"",
        ""service_instances_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/service_instances"",
        ""app_events_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/app_events"",
        ""events_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/events"",
        ""security_groups_url"": ""/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpacesResponse> page = Util.DeserializePage<ListAllSpacesResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("fa82b3a8-d095-4668-89b7-e917ff587074", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1229", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("07fba830-4583-4ad4-8911-85c1b4281f9f", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/07fba830-4583-4ad4-8911-85c1b4281f9f", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/fa82b3a8-d095-4668-89b7-e917ff587074/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllAppsForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""8a090053-c836-4059-8fe6-33496aa953a4"",
        ""url"": ""/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4"",
        ""created_at"": ""2014-11-12T12:59:48+02:00"",
        ""updated_at"": ""2014-11-12T12:59:48+02:00""
      },
      ""entity"": {
        ""name"": ""name-1291"",
        ""production"": false,
        ""space_guid"": ""a3914f75-ae23-4665-ad1d-4c665d90ff3b"",
        ""stack_guid"": ""65d8b289-7873-4f38-82ba-5f953335b75b"",
        ""buildpack"": null,
        ""detected_buildpack"": null,
        ""environment_json"": null,
        ""memory"": 1024,
        ""instances"": 1,
        ""disk_quota"": 1024,
        ""state"": ""STOPPED"",
        ""version"": ""9acba4f6-ab2d-4c5c-a163-ff668f9b24bf"",
        ""command"": null,
        ""console"": false,
        ""debug"": null,
        ""staging_task_id"": null,
        ""package_state"": ""PENDING"",
        ""health_check_timeout"": null,
        ""staging_failed_reason"": null,
        ""docker_image"": null,
        ""package_updated_at"": ""2014-11-12T12:59:48+02:00"",
        ""detected_start_command"": """",
        ""space_url"": ""/v2/spaces/a3914f75-ae23-4665-ad1d-4c665d90ff3b"",
        ""stack_url"": ""/v2/stacks/65d8b289-7873-4f38-82ba-5f953335b75b"",
        ""events_url"": ""/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4/events"",
        ""service_bindings_url"": ""/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4/service_bindings"",
        ""routes_url"": ""/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4/routes""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAppsForSpaceResponse> page = Util.DeserializePage<ListAllAppsForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("8a090053-c836-4059-8fe6-33496aa953a4", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:48+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2014-11-12T12:59:48+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1291", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Production), true);
                  Assert.AreEqual("a3914f75-ae23-4665-ad1d-4c665d90ff3b", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("65d8b289-7873-4f38-82ba-5f953335b75b", TestUtil.ToTestableString(page[0].StackGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Buildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DetectedBuildpack), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].EnvironmentJson), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[0].Memory), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[0].Instances), true);
                  Assert.AreEqual("1024", TestUtil.ToTestableString(page[0].DiskQuota), true);
                  Assert.AreEqual("STOPPED", TestUtil.ToTestableString(page[0].State), true);
                  Assert.AreEqual("9acba4f6-ab2d-4c5c-a163-ff668f9b24bf", TestUtil.ToTestableString(page[0].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Command), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Console), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Debug), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].StagingTaskId), true);
                  Assert.AreEqual("PENDING", TestUtil.ToTestableString(page[0].PackageState), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].HealthCheckTimeout), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].StagingFailedReason), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DockerImage), true);
                  Assert.AreEqual("2014-11-12T12:59:48+02:00", TestUtil.ToTestableString(page[0].PackageUpdatedAt), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DetectedStartCommand), true);
                  Assert.AreEqual("/v2/spaces/a3914f75-ae23-4665-ad1d-4c665d90ff3b", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/stacks/65d8b289-7873-4f38-82ba-5f953335b75b", TestUtil.ToTestableString(page[0].StackUrl), true);
                  Assert.AreEqual("/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
                  Assert.AreEqual("/v2/apps/8a090053-c836-4059-8fe6-33496aa953a4/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateSecurityGroupWithSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""be6e0892-1292-4464-a14e-a57e974c1fef"",
    ""url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef"",
    ""created_at"": ""2014-11-12T12:59:48+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1301"",
    ""organization_guid"": ""a2743364-c7a3-4cb2-a17f-d5390311c998"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/a2743364-c7a3-4cb2-a17f-d5390311c998"",
    ""developers_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/developers"",
    ""managers_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/managers"",
    ""auditors_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/auditors"",
    ""apps_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/apps"",
    ""routes_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/routes"",
    ""domains_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/domains"",
    ""service_instances_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/service_instances"",
    ""app_events_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/app_events"",
    ""events_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/events"",
    ""security_groups_url"": ""/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/security_groups""
  }
}";
    
            AssociateSecurityGroupWithSpaceResponse obj = Util.DeserializeJson<AssociateSecurityGroupWithSpaceResponse>(json);
        
            Assert.AreEqual("be6e0892-1292-4464-a14e-a57e974c1fef", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:48+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1301", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("a2743364-c7a3-4cb2-a17f-d5390311c998", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/a2743364-c7a3-4cb2-a17f-d5390311c998", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/be6e0892-1292-4464-a14e-a57e974c1fef/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateManagerWithSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""fee18765-1f14-4aa1-80df-5c54ce435fb0"",
    ""url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0"",
    ""created_at"": ""2014-11-12T12:59:47+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1266"",
    ""organization_guid"": ""5f85d7dc-b632-45ac-b67c-f5adf626c090"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/5f85d7dc-b632-45ac-b67c-f5adf626c090"",
    ""developers_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/developers"",
    ""managers_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/managers"",
    ""auditors_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/auditors"",
    ""apps_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/apps"",
    ""routes_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/routes"",
    ""domains_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/domains"",
    ""service_instances_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/service_instances"",
    ""app_events_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/app_events"",
    ""events_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/events"",
    ""security_groups_url"": ""/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/security_groups""
  }
}";
    
            AssociateManagerWithSpaceResponse obj = Util.DeserializeJson<AssociateManagerWithSpaceResponse>(json);
        
            Assert.AreEqual("fee18765-1f14-4aa1-80df-5c54ce435fb0", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1266", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("5f85d7dc-b632-45ac-b67c-f5adf626c090", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/5f85d7dc-b632-45ac-b67c-f5adf626c090", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/fee18765-1f14-4aa1-80df-5c54ce435fb0/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveManagerFromSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""e2c8d8d1-7db9-476b-9462-4b1291b49b78"",
    ""url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78"",
    ""created_at"": ""2014-11-12T12:59:47+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1260"",
    ""organization_guid"": ""b97c20fd-9dbe-4e93-bb1f-87612ce24076"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/b97c20fd-9dbe-4e93-bb1f-87612ce24076"",
    ""developers_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/developers"",
    ""managers_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/managers"",
    ""auditors_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/auditors"",
    ""apps_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/apps"",
    ""routes_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/routes"",
    ""domains_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/domains"",
    ""service_instances_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/service_instances"",
    ""app_events_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/app_events"",
    ""events_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/events"",
    ""security_groups_url"": ""/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/security_groups""
  }
}";
    
            RemoveManagerFromSpaceResponse obj = Util.DeserializeJson<RemoveManagerFromSpaceResponse>(json);
        
            Assert.AreEqual("e2c8d8d1-7db9-476b-9462-4b1291b49b78", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1260", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("b97c20fd-9dbe-4e93-bb1f-87612ce24076", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/b97c20fd-9dbe-4e93-bb1f-87612ce24076", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/e2c8d8d1-7db9-476b-9462-4b1291b49b78/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServiceInstancesForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""83662257-248c-49bf-b680-14ab5bf78115"",
        ""url"": ""/v2/service_instances/83662257-248c-49bf-b680-14ab5bf78115"",
        ""created_at"": ""2014-11-12T12:59:46+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-1249"",
        ""credentials"": {
          ""creds-key-493"": ""creds-val-493""
        },
        ""service_plan_guid"": ""0829dd21-04f7-45d4-bffa-bd0e5363b235"",
        ""space_guid"": ""f0fe8f58-e8e9-4f9b-ae0e-b507d0b9a495"",
        ""gateway_data"": null,
        ""dashboard_url"": null,
        ""type"": ""managed_service_instance"",
        ""space_url"": ""/v2/spaces/f0fe8f58-e8e9-4f9b-ae0e-b507d0b9a495"",
        ""service_plan_url"": ""/v2/service_plans/0829dd21-04f7-45d4-bffa-bd0e5363b235"",
        ""service_bindings_url"": ""/v2/service_instances/83662257-248c-49bf-b680-14ab5bf78115/service_bindings""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceInstancesForSpaceResponse> page = Util.DeserializePage<ListAllServiceInstancesForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("83662257-248c-49bf-b680-14ab5bf78115", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_instances/83662257-248c-49bf-b680-14ab5bf78115", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1249", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("0829dd21-04f7-45d4-bffa-bd0e5363b235", TestUtil.ToTestableString(page[0].ServicePlanGuid), true);
                  Assert.AreEqual("f0fe8f58-e8e9-4f9b-ae0e-b507d0b9a495", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DashboardUrl), true);
                  Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("/v2/spaces/f0fe8f58-e8e9-4f9b-ae0e-b507d0b9a495", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/service_plans/0829dd21-04f7-45d4-bffa-bd0e5363b235", TestUtil.ToTestableString(page[0].ServicePlanUrl), true);
                  Assert.AreEqual("/v2/service_instances/83662257-248c-49bf-b680-14ab5bf78115/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllManagersForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-294"",
        ""url"": ""/v2/users/uaa-id-294"",
        ""created_at"": ""2014-11-12T12:59:47+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-294/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-294/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-294/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-294/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-294/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-294/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-294/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllManagersForSpaceResponse> page = Util.DeserializePage<ListAllManagersForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-294", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-294", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-294/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllRoutesForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""1df03cfe-daaa-4572-87e3-55656730ab6a"",
        ""url"": ""/v2/routes/1df03cfe-daaa-4572-87e3-55656730ab6a"",
        ""created_at"": ""2014-11-12T12:59:46+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""host"": ""host-18"",
        ""domain_guid"": ""63318322-6349-4b5f-99f8-e52c89fa1034"",
        ""space_guid"": ""f1270cfe-a11f-4682-93c3-82337cf58c62"",
        ""domain_url"": ""/v2/domains/63318322-6349-4b5f-99f8-e52c89fa1034"",
        ""space_url"": ""/v2/spaces/f1270cfe-a11f-4682-93c3-82337cf58c62"",
        ""apps_url"": ""/v2/routes/1df03cfe-daaa-4572-87e3-55656730ab6a/apps""
      }
    }
  ]
}";
    
            PagedResponse<ListAllRoutesForSpaceResponse> page = Util.DeserializePage<ListAllRoutesForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("1df03cfe-daaa-4572-87e3-55656730ab6a", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/routes/1df03cfe-daaa-4572-87e3-55656730ab6a", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("host-18", TestUtil.ToTestableString(page[0].Host), true);
                  Assert.AreEqual("63318322-6349-4b5f-99f8-e52c89fa1034", TestUtil.ToTestableString(page[0].DomainGuid), true);
                  Assert.AreEqual("f1270cfe-a11f-4682-93c3-82337cf58c62", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("/v2/domains/63318322-6349-4b5f-99f8-e52c89fa1034", TestUtil.ToTestableString(page[0].DomainUrl), true);
                  Assert.AreEqual("/v2/spaces/f1270cfe-a11f-4682-93c3-82337cf58c62", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/routes/1df03cfe-daaa-4572-87e3-55656730ab6a/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateDeveloperWithSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""aa038799-9659-4dcb-b3bd-15a40352bf4b"",
    ""url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b"",
    ""created_at"": ""2014-11-12T12:59:47+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1285"",
    ""organization_guid"": ""0c96028f-6688-40d5-8fe3-1226279d3449"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/0c96028f-6688-40d5-8fe3-1226279d3449"",
    ""developers_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/developers"",
    ""managers_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/managers"",
    ""auditors_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/auditors"",
    ""apps_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/apps"",
    ""routes_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/routes"",
    ""domains_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/domains"",
    ""service_instances_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/service_instances"",
    ""app_events_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/app_events"",
    ""events_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/events"",
    ""security_groups_url"": ""/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/security_groups""
  }
}";
    
            AssociateDeveloperWithSpaceResponse obj = Util.DeserializeJson<AssociateDeveloperWithSpaceResponse>(json);
        
            Assert.AreEqual("aa038799-9659-4dcb-b3bd-15a40352bf4b", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1285", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("0c96028f-6688-40d5-8fe3-1226279d3449", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/0c96028f-6688-40d5-8fe3-1226279d3449", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/aa038799-9659-4dcb-b3bd-15a40352bf4b/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateSpaceRequest()
        {
            string json = @"{
  ""name"": ""development"",
  ""organization_guid"": ""a6171605-6688-418f-acb0-222a115f36bd""
}";
    
            CreateSpaceRequest obj = Util.DeserializeJson<CreateSpaceRequest>(json);
        
            Assert.AreEqual("development", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("a6171605-6688-418f-acb0-222a115f36bd", TestUtil.ToTestableString(obj.OrganizationGuid), true);
        }

    
        [TestMethod]
        public void TestCreateSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""eca6266e-5516-41df-ba2c-7d45ff73ddf8"",
    ""url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8"",
    ""created_at"": ""2014-11-12T12:59:46+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""development"",
    ""organization_guid"": ""a6171605-6688-418f-acb0-222a115f36bd"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/a6171605-6688-418f-acb0-222a115f36bd"",
    ""developers_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/developers"",
    ""managers_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/managers"",
    ""auditors_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/auditors"",
    ""apps_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/apps"",
    ""routes_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/routes"",
    ""domains_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/domains"",
    ""service_instances_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/service_instances"",
    ""app_events_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/app_events"",
    ""events_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/events"",
    ""security_groups_url"": ""/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/security_groups""
  }
}";
    
            CreateSpaceResponse obj = Util.DeserializeJson<CreateSpaceResponse>(json);
        
            Assert.AreEqual("eca6266e-5516-41df-ba2c-7d45ff73ddf8", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("development", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("a6171605-6688-418f-acb0-222a115f36bd", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/a6171605-6688-418f-acb0-222a115f36bd", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/eca6266e-5516-41df-ba2c-7d45ff73ddf8/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllEventsForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""2825e90c-db20-43a4-8ecc-d185ea0defa3"",
        ""url"": ""/v2/events/2825e90c-db20-43a4-8ecc-d185ea0defa3"",
        ""created_at"": ""2014-11-12T12:59:47+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.space.update"",
        ""actor"": ""uaa-id-301"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@example.com"",
        ""actee"": ""6a475531-cb8b-452f-8696-3417ec6b3143"",
        ""actee_type"": ""space"",
        ""actee_name"": ""name-1272"",
        ""timestamp"": ""2014-11-12T12:59:47+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""new_name""
          }
        },
        ""space_guid"": ""6a475531-cb8b-452f-8696-3417ec6b3143"",
        ""organization_guid"": ""9094de79-0313-4697-89d3-aee964c9a315""
      }
    }
  ]
}";
    
            PagedResponse<ListAllEventsForSpaceResponse> page = Util.DeserializePage<ListAllEventsForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("2825e90c-db20-43a4-8ecc-d185ea0defa3", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/2825e90c-db20-43a4-8ecc-d185ea0defa3", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.space.update", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-301", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@example.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("6a475531-cb8b-452f-8696-3417ec6b3143", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("space", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-1272", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("6a475531-cb8b-452f-8696-3417ec6b3143", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("9094de79-0313-4697-89d3-aee964c9a315", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllAuditorsForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-285"",
        ""url"": ""/v2/users/uaa-id-285"",
        ""created_at"": ""2014-11-12T12:59:47+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-285/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-285/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-285/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-285/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-285/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-285/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-285/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAuditorsForSpaceResponse> page = Util.DeserializePage<ListAllAuditorsForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-285", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-285", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-285/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""4e2798c4-0349-406c-8ac1-de08bed40ce7"",
    ""url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7"",
    ""created_at"": ""2014-11-12T12:59:46+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1240"",
    ""organization_guid"": ""64ff717b-175b-493a-94a6-5c90fa82b899"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/64ff717b-175b-493a-94a6-5c90fa82b899"",
    ""developers_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/developers"",
    ""managers_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/managers"",
    ""auditors_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/auditors"",
    ""apps_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/apps"",
    ""routes_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/routes"",
    ""domains_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/domains"",
    ""service_instances_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/service_instances"",
    ""app_events_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/app_events"",
    ""events_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/events"",
    ""security_groups_url"": ""/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/security_groups""
  }
}";
    
            RetrieveSpaceResponse obj = Util.DeserializeJson<RetrieveSpaceResponse>(json);
        
            Assert.AreEqual("4e2798c4-0349-406c-8ac1-de08bed40ce7", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:46+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1240", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("64ff717b-175b-493a-94a6-5c90fa82b899", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/64ff717b-175b-493a-94a6-5c90fa82b899", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/4e2798c4-0349-406c-8ac1-de08bed40ce7/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestGetSpaceSummaryResponse()
        {
            string json = @"{
  ""guid"": ""572c5a7c-e148-45fc-a1b5-860baf289c6e"",
  ""name"": ""name-424"",
  ""apps"": [
    {
      ""guid"": ""4f2cdbd0-f09c-421a-ac27-cbbd5bc2cb73"",
      ""urls"": [
        ""host-7.domain-14.example.com""
      ],
      ""routes"": [
        {
          ""guid"": ""f5b7e923-0f3e-4fd8-83fe-be4275968539"",
          ""host"": ""host-7"",
          ""domain"": {
            ""guid"": ""6ff2fb72-f013-4525-a257-ea6b9248ecc6"",
            ""name"": ""domain-14.example.com""
          }
        }
      ],
      ""service_count"": 1,
      ""service_names"": [
        ""name-429""
      ],
      ""running_instances"": 0,
      ""name"": ""name-427"",
      ""production"": false,
      ""space_guid"": ""572c5a7c-e148-45fc-a1b5-860baf289c6e"",
      ""stack_guid"": ""db68b85e-76d4-4d37-ac7d-1b058f410f8d"",
      ""buildpack"": null,
      ""detected_buildpack"": null,
      ""environment_json"": null,
      ""memory"": 1024,
      ""instances"": 1,
      ""disk_quota"": 1024,
      ""state"": ""STOPPED"",
      ""version"": ""dd91cfa1-88eb-4cfd-8642-281a6679d382"",
      ""command"": null,
      ""console"": false,
      ""debug"": null,
      ""staging_task_id"": null,
      ""package_state"": ""PENDING"",
      ""health_check_timeout"": null,
      ""staging_failed_reason"": null,
      ""docker_image"": null,
      ""package_updated_at"": ""2014-11-12T12:59:28+02:00"",
      ""detected_start_command"": """"
    }
  ],
  ""services"": [
    {
      ""guid"": ""5922930b-a460-4e9d-a2dc-8523033e25f1"",
      ""name"": ""name-429"",
      ""bound_app_count"": 1,
      ""dashboard_url"": null,
      ""service_plan"": {
        ""guid"": ""15014f09-dbbd-40c1-94b0-fb1fe71449da"",
        ""name"": ""name-430"",
        ""service"": {
          ""guid"": ""d9d1094d-9be1-4bc2-a6c3-92cd8bff25dd"",
          ""label"": ""label-41"",
          ""provider"": ""provider-32"",
          ""version"": ""version-16""
        }
      }
    }
  ]
}";
    
            GetSpaceSummaryResponse obj = Util.DeserializeJson<GetSpaceSummaryResponse>(json);
        
            Assert.AreEqual("572c5a7c-e148-45fc-a1b5-860baf289c6e", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("name-424", TestUtil.ToTestableString(obj.Name), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateAuditorWithSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""e71db9a0-8be7-407c-9f69-af50ba86c161"",
    ""url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161"",
    ""created_at"": ""2014-11-12T12:59:47+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1257"",
    ""organization_guid"": ""bebdc4c4-a331-4fa2-a072-4816ac327a14"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/bebdc4c4-a331-4fa2-a072-4816ac327a14"",
    ""developers_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/developers"",
    ""managers_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/managers"",
    ""auditors_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/auditors"",
    ""apps_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/apps"",
    ""routes_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/routes"",
    ""domains_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/domains"",
    ""service_instances_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/service_instances"",
    ""app_events_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/app_events"",
    ""events_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/events"",
    ""security_groups_url"": ""/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/security_groups""
  }
}";
    
            AssociateAuditorWithSpaceResponse obj = Util.DeserializeJson<AssociateAuditorWithSpaceResponse>(json);
        
            Assert.AreEqual("e71db9a0-8be7-407c-9f69-af50ba86c161", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:47+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1257", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("bebdc4c4-a331-4fa2-a072-4816ac327a14", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/bebdc4c4-a331-4fa2-a072-4816ac327a14", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/e71db9a0-8be7-407c-9f69-af50ba86c161/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveSecurityGroupFromSpaceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""d6ffd3af-8a90-422e-84fd-0400fb09f80c"",
    ""url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c"",
    ""created_at"": ""2014-11-12T12:59:48+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-1293"",
    ""organization_guid"": ""fd01ec06-092c-408a-8f83-8d123cef74e8"",
    ""space_quota_definition_guid"": null,
    ""organization_url"": ""/v2/organizations/fd01ec06-092c-408a-8f83-8d123cef74e8"",
    ""developers_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/developers"",
    ""managers_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/managers"",
    ""auditors_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/auditors"",
    ""apps_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/apps"",
    ""routes_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/routes"",
    ""domains_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/domains"",
    ""service_instances_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/service_instances"",
    ""app_events_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/app_events"",
    ""events_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/events"",
    ""security_groups_url"": ""/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/security_groups""
  }
}";
    
            RemoveSecurityGroupFromSpaceResponse obj = Util.DeserializeJson<RemoveSecurityGroupFromSpaceResponse>(json);
        
            Assert.AreEqual("d6ffd3af-8a90-422e-84fd-0400fb09f80c", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:48+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1293", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("fd01ec06-092c-408a-8f83-8d123cef74e8", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionGuid), true);
            Assert.AreEqual("/v2/organizations/fd01ec06-092c-408a-8f83-8d123cef74e8", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/developers", TestUtil.ToTestableString(obj.DevelopersUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/apps", TestUtil.ToTestableString(obj.AppsUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/routes", TestUtil.ToTestableString(obj.RoutesUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/events", TestUtil.ToTestableString(obj.EventsUrl), true);
            Assert.AreEqual("/v2/spaces/d6ffd3af-8a90-422e-84fd-0400fb09f80c/security_groups", TestUtil.ToTestableString(obj.SecurityGroupsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllSecurityGroupsForSpaceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""34ce2e51-8ca3-4009-b696-b9ae8ffa6239"",
        ""url"": ""/v2/security_groups/34ce2e51-8ca3-4009-b696-b9ae8ffa6239"",
        ""created_at"": ""2014-11-12T12:59:48+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-1300"",
        ""rules"": [
          {
            ""protocol"": ""udp"",
            ""ports"": ""8080"",
            ""destination"": ""198.41.191.47/1""
          }
        ],
        ""running_default"": false,
        ""staging_default"": false,
        ""spaces_url"": ""/v2/security_groups/34ce2e51-8ca3-4009-b696-b9ae8ffa6239/spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSecurityGroupsForSpaceResponse> page = Util.DeserializePage<ListAllSecurityGroupsForSpaceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("34ce2e51-8ca3-4009-b696-b9ae8ffa6239", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/security_groups/34ce2e51-8ca3-4009-b696-b9ae8ffa6239", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:48+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1300", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].StagingDefault), true);
                  Assert.AreEqual("/v2/security_groups/34ce2e51-8ca3-4009-b696-b9ae8ffa6239/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
               
               
            
    
        }

    }
}
