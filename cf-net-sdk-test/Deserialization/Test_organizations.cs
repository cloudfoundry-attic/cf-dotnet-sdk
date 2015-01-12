using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class OrganizationsTest
    {

    
        [TestMethod]
        public void TestRetrieveOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""b2bd672d-82cc-4f0c-bdcf-5980372ebe6d"",
    ""url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d"",
    ""created_at"": ""2014-11-12T12:59:24+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-276"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""c4fc94b5-d48d-4a02-86d8-5a7bb4e8ec74"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/c4fc94b5-d48d-4a02-86d8-5a7bb4e8ec74"",
    ""spaces_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/spaces"",
    ""domains_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/domains"",
    ""private_domains_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/private_domains"",
    ""users_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/users"",
    ""managers_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/managers"",
    ""billing_managers_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/billing_managers"",
    ""auditors_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/auditors"",
    ""app_events_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/space_quota_definitions""
  }
}";
    
            RetrieveOrganizationResponse obj = Util.DeserializeJson<RetrieveOrganizationResponse>(json);
        
            Assert.AreEqual("b2bd672d-82cc-4f0c-bdcf-5980372ebe6d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-276", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("c4fc94b5-d48d-4a02-86d8-5a7bb4e8ec74", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/c4fc94b5-d48d-4a02-86d8-5a7bb4e8ec74", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/b2bd672d-82cc-4f0c-bdcf-5980372ebe6d/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllOrganizationsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""e4012541-d492-43f5-9298-3ab33c1702f3"",
        ""url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3"",
        ""created_at"": ""2014-11-12T12:59:18+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""the-system_domain-org-name"",
        ""billing_enabled"": false,
        ""quota_definition_guid"": ""0e37233d-e8dc-49b1-9adb-3b6c7a16e31a"",
        ""status"": ""active"",
        ""quota_definition_url"": ""/v2/quota_definitions/0e37233d-e8dc-49b1-9adb-3b6c7a16e31a"",
        ""spaces_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/spaces"",
        ""domains_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/domains"",
        ""private_domains_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/private_domains"",
        ""users_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/users"",
        ""managers_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/managers"",
        ""billing_managers_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/billing_managers"",
        ""auditors_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/auditors"",
        ""app_events_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/app_events"",
        ""space_quota_definitions_url"": ""/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/space_quota_definitions""
      }
    }
  ]
}";
    
            PagedResponse<ListAllOrganizationsResponse> page = Util.DeserializePage<ListAllOrganizationsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("e4012541-d492-43f5-9298-3ab33c1702f3", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:18+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("the-system_domain-org-name", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].BillingEnabled), true);
                  Assert.AreEqual("0e37233d-e8dc-49b1-9adb-3b6c7a16e31a", TestUtil.ToTestableString(page[0].QuotaDefinitionGuid), true);
                  Assert.AreEqual("active", TestUtil.ToTestableString(page[0].Status), true);
                  Assert.AreEqual("/v2/quota_definitions/0e37233d-e8dc-49b1-9adb-3b6c7a16e31a", TestUtil.ToTestableString(page[0].QuotaDefinitionUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/private_domains", TestUtil.ToTestableString(page[0].PrivateDomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/users", TestUtil.ToTestableString(page[0].UsersUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/billing_managers", TestUtil.ToTestableString(page[0].BillingManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/organizations/e4012541-d492-43f5-9298-3ab33c1702f3/space_quota_definitions", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveUserFromOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""d5bcbd9b-5a5e-4887-97e5-b8d9014cd044"",
    ""url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044"",
    ""created_at"": ""2014-11-12T12:59:25+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-310"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""468b65d9-2733-4b0f-92cc-0b39fff72f0f"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/468b65d9-2733-4b0f-92cc-0b39fff72f0f"",
    ""spaces_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/spaces"",
    ""domains_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/domains"",
    ""private_domains_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/private_domains"",
    ""users_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/users"",
    ""managers_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/managers"",
    ""billing_managers_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/billing_managers"",
    ""auditors_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/auditors"",
    ""app_events_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/space_quota_definitions""
  }
}";
    
            RemoveUserFromOrganizationResponse obj = Util.DeserializeJson<RemoveUserFromOrganizationResponse>(json);
        
            Assert.AreEqual("d5bcbd9b-5a5e-4887-97e5-b8d9014cd044", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-310", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("468b65d9-2733-4b0f-92cc-0b39fff72f0f", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/468b65d9-2733-4b0f-92cc-0b39fff72f0f", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/d5bcbd9b-5a5e-4887-97e5-b8d9014cd044/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveBillingManagerFromOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""733c5a29-9f60-406d-a17b-59cd91867ef7"",
    ""url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7"",
    ""created_at"": ""2014-11-12T12:59:24+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-281"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""e52d8e2c-8e21-4ca8-ade2-60b2f59a51d8"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/e52d8e2c-8e21-4ca8-ade2-60b2f59a51d8"",
    ""spaces_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/spaces"",
    ""domains_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/domains"",
    ""private_domains_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/private_domains"",
    ""users_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/users"",
    ""managers_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/managers"",
    ""billing_managers_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/billing_managers"",
    ""auditors_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/auditors"",
    ""app_events_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/space_quota_definitions""
  }
}";
    
            RemoveBillingManagerFromOrganizationResponse obj = Util.DeserializeJson<RemoveBillingManagerFromOrganizationResponse>(json);
        
            Assert.AreEqual("733c5a29-9f60-406d-a17b-59cd91867ef7", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-281", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("e52d8e2c-8e21-4ca8-ade2-60b2f59a51d8", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/e52d8e2c-8e21-4ca8-ade2-60b2f59a51d8", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/733c5a29-9f60-406d-a17b-59cd91867ef7/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestGetOrganizationSummaryResponse()
        {
            string json = @"{""guid"":""3a38dcb3-74da-47aa-a8e3-5c39ed15b016"",""name"":""name-561"",""status"":""active"",""spaces"":[{""guid"":""cb8e27af-c346-432d-86bf-7e7fc0774231"",""name"":""name-563"",""service_count"":0,""app_count"":0,""mem_dev_total"":0,""mem_prod_total"":0}]}";
    
            GetOrganizationSummaryResponse obj = Util.DeserializeJson<GetOrganizationSummaryResponse>(json);
        
            Assert.AreEqual("3a38dcb3-74da-47aa-a8e3-5c39ed15b016", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("name-561", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            
        }

    
        [TestMethod]
        public void TestListAllSpacesForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""cbbb0826-d655-4e37-bfe3-aeabc501c240"",
        ""url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240"",
        ""created_at"": ""2014-11-12T12:59:24+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-280"",
        ""organization_guid"": ""7cd6341c-83df-40b7-8ba3-0626db32d6a9"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/7cd6341c-83df-40b7-8ba3-0626db32d6a9"",
        ""developers_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/developers"",
        ""managers_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/managers"",
        ""auditors_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/auditors"",
        ""apps_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/apps"",
        ""routes_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/routes"",
        ""domains_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/domains"",
        ""service_instances_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/service_instances"",
        ""app_events_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/app_events"",
        ""events_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/events"",
        ""security_groups_url"": ""/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpacesForOrganizationResponse> page = Util.DeserializePage<ListAllSpacesForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("cbbb0826-d655-4e37-bfe3-aeabc501c240", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-280", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("7cd6341c-83df-40b7-8ba3-0626db32d6a9", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/7cd6341c-83df-40b7-8ba3-0626db32d6a9", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/cbbb0826-d655-4e37-bfe3-aeabc501c240/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllSpaceQuotaDefinitionsForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""7697380d-df59-4d90-8fa0-16c7be0a4a2a"",
        ""url"": ""/v2/space_quota_definitions/7697380d-df59-4d90-8fa0-16c7be0a4a2a"",
        ""created_at"": ""2014-11-12T12:59:25+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-309"",
        ""organization_guid"": ""9f89b134-7d2c-4a9d-9bd3-5b69ef1273dc"",
        ""non_basic_services_allowed"": true,
        ""total_services"": 60,
        ""total_routes"": 1000,
        ""memory_limit"": 20480,
        ""instance_memory_limit"": -1,
        ""organization_url"": ""/v2/organizations/9f89b134-7d2c-4a9d-9bd3-5b69ef1273dc"",
        ""spaces_url"": ""/v2/space_quota_definitions/7697380d-df59-4d90-8fa0-16c7be0a4a2a/spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpaceQuotaDefinitionsForOrganizationResponse> page = Util.DeserializePage<ListAllSpaceQuotaDefinitionsForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("7697380d-df59-4d90-8fa0-16c7be0a4a2a", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/space_quota_definitions/7697380d-df59-4d90-8fa0-16c7be0a4a2a", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-309", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("9f89b134-7d2c-4a9d-9bd3-5b69ef1273dc", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].NonBasicServicesAllowed), true);
                  Assert.AreEqual("60", TestUtil.ToTestableString(page[0].TotalServices), true);
                  Assert.AreEqual("1000", TestUtil.ToTestableString(page[0].TotalRoutes), true);
                  Assert.AreEqual("20480", TestUtil.ToTestableString(page[0].MemoryLimit), true);
                  Assert.AreEqual("-1", TestUtil.ToTestableString(page[0].InstanceMemoryLimit), true);
                  Assert.AreEqual("/v2/organizations/9f89b134-7d2c-4a9d-9bd3-5b69ef1273dc", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/space_quota_definitions/7697380d-df59-4d90-8fa0-16c7be0a4a2a/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateBillingManagerWithOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""1188988b-cb62-4b48-a7ed-831b573d59c5"",
    ""url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5"",
    ""created_at"": ""2014-11-12T12:59:24+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-285"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""6f1e4fcf-0827-4043-86f8-ddf78900c910"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/6f1e4fcf-0827-4043-86f8-ddf78900c910"",
    ""spaces_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/spaces"",
    ""domains_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/domains"",
    ""private_domains_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/private_domains"",
    ""users_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/users"",
    ""managers_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/managers"",
    ""billing_managers_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/billing_managers"",
    ""auditors_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/auditors"",
    ""app_events_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/space_quota_definitions""
  }
}";
    
            AssociateBillingManagerWithOrganizationResponse obj = Util.DeserializeJson<AssociateBillingManagerWithOrganizationResponse>(json);
        
            Assert.AreEqual("1188988b-cb62-4b48-a7ed-831b573d59c5", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-285", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("6f1e4fcf-0827-4043-86f8-ddf78900c910", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/6f1e4fcf-0827-4043-86f8-ddf78900c910", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/1188988b-cb62-4b48-a7ed-831b573d59c5/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllUsersForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-59"",
        ""url"": ""/v2/users/uaa-id-59"",
        ""created_at"": ""2014-11-12T12:59:25+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-59/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-59/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-59/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-59/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-59/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-59/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-59/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllUsersForOrganizationResponse> page = Util.DeserializePage<ListAllUsersForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-59", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-59", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-59/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateUserWithOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""3d9ae659-f550-480d-8b02-8cbe662fae1d"",
    ""url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d"",
    ""created_at"": ""2014-11-12T12:59:25+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-314"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""24b6758c-ea9b-4bfb-8353-3b79d20fc72c"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/24b6758c-ea9b-4bfb-8353-3b79d20fc72c"",
    ""spaces_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/spaces"",
    ""domains_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/domains"",
    ""private_domains_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/private_domains"",
    ""users_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/users"",
    ""managers_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/managers"",
    ""billing_managers_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/billing_managers"",
    ""auditors_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/auditors"",
    ""app_events_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/space_quota_definitions""
  }
}";
    
            AssociateUserWithOrganizationResponse obj = Util.DeserializeJson<AssociateUserWithOrganizationResponse>(json);
        
            Assert.AreEqual("3d9ae659-f550-480d-8b02-8cbe662fae1d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-314", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("24b6758c-ea9b-4bfb-8353-3b79d20fc72c", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/24b6758c-ea9b-4bfb-8353-3b79d20fc72c", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/3d9ae659-f550-480d-8b02-8cbe662fae1d/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServicesForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""5c706442-656c-40c2-8add-af6c4123386b"",
        ""url"": ""/v2/services/5c706442-656c-40c2-8add-af6c4123386b"",
        ""created_at"": ""2014-11-12T12:59:25+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-5"",
        ""provider"": ""provider-5"",
        ""url"": ""https://foo.com/url-5"",
        ""description"": ""desc-59"",
        ""long_description"": null,
        ""version"": ""version-5"",
        ""info_url"": null,
        ""active"": true,
        ""bindable"": true,
        ""unique_id"": ""22b5643b-7d86-425b-a929-be48412e97f3"",
        ""extra"": null,
        ""tags"": [

        ],
        ""requires"": [

        ],
        ""documentation_url"": null,
        ""service_broker_guid"": null,
        ""plan_updateable"": false,
        ""service_plans_url"": ""/v2/services/5c706442-656c-40c2-8add-af6c4123386b/service_plans""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServicesForOrganizationResponse> page = Util.DeserializePage<ListAllServicesForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("5c706442-656c-40c2-8add-af6c4123386b", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/services/5c706442-656c-40c2-8add-af6c4123386b", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-5", TestUtil.ToTestableString(page[0].Label), true);
                  Assert.AreEqual("provider-5", TestUtil.ToTestableString(page[0].Provider), true);
                  Assert.AreEqual("https://foo.com/url-5", TestUtil.ToTestableString(page[0].Url), true);
                  Assert.AreEqual("desc-59", TestUtil.ToTestableString(page[0].Description), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].LongDescription), true);
                  Assert.AreEqual("version-5", TestUtil.ToTestableString(page[0].Version), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].InfoUrl), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Bindable), true);
                  Assert.AreEqual("22b5643b-7d86-425b-a929-be48412e97f3", TestUtil.ToTestableString(page[0].UniqueId), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].Extra), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DocumentationUrl), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].ServiceBrokerGuid), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].PlanUpdateable), true);
                  Assert.AreEqual("/v2/services/5c706442-656c-40c2-8add-af6c4123386b/service_plans", TestUtil.ToTestableString(page[0].ServicePlansUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveAuditorFromOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""03e848d3-6b46-483b-a492-d4224ef94d37"",
    ""url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37"",
    ""created_at"": ""2014-11-12T12:59:25+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-301"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""37df8e42-a213-455e-aa25-6c8e576552ae"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/37df8e42-a213-455e-aa25-6c8e576552ae"",
    ""spaces_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/spaces"",
    ""domains_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/domains"",
    ""private_domains_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/private_domains"",
    ""users_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/users"",
    ""managers_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/managers"",
    ""billing_managers_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/billing_managers"",
    ""auditors_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/auditors"",
    ""app_events_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/space_quota_definitions""
  }
}";
    
            RemoveAuditorFromOrganizationResponse obj = Util.DeserializeJson<RemoveAuditorFromOrganizationResponse>(json);
        
            Assert.AreEqual("03e848d3-6b46-483b-a492-d4224ef94d37", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-301", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("37df8e42-a213-455e-aa25-6c8e576552ae", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/37df8e42-a213-455e-aa25-6c8e576552ae", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/03e848d3-6b46-483b-a492-d4224ef94d37/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllPrivateDomainsForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""3073015d-497d-4eba-9a77-046687929f98"",
        ""url"": ""/v2/private_domains/3073015d-497d-4eba-9a77-046687929f98"",
        ""created_at"": ""2014-11-12T12:59:24+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-13.example.com"",
        ""owning_organization_guid"": ""afc2ba20-8184-4db2-b2cd-ecdcf497c887"",
        ""owning_organization_url"": ""/v2/organizations/afc2ba20-8184-4db2-b2cd-ecdcf497c887""
      }
    }
  ]
}";
    
            PagedResponse<ListAllPrivateDomainsForOrganizationResponse> page = Util.DeserializePage<ListAllPrivateDomainsForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("3073015d-497d-4eba-9a77-046687929f98", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/3073015d-497d-4eba-9a77-046687929f98", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-13.example.com", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("afc2ba20-8184-4db2-b2cd-ecdcf497c887", TestUtil.ToTestableString(page[0].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/afc2ba20-8184-4db2-b2cd-ecdcf497c887", TestUtil.ToTestableString(page[0].OwningOrganizationUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateManagerWithOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""8c255aeb-a306-45a8-b365-a56b946af19f"",
    ""url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f"",
    ""created_at"": ""2014-11-12T12:59:25+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-295"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""4d157079-42f6-4e06-bc7b-b23776dbd6fd"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/4d157079-42f6-4e06-bc7b-b23776dbd6fd"",
    ""spaces_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/spaces"",
    ""domains_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/domains"",
    ""private_domains_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/private_domains"",
    ""users_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/users"",
    ""managers_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/managers"",
    ""billing_managers_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/billing_managers"",
    ""auditors_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/auditors"",
    ""app_events_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/space_quota_definitions""
  }
}";
    
            AssociateManagerWithOrganizationResponse obj = Util.DeserializeJson<AssociateManagerWithOrganizationResponse>(json);
        
            Assert.AreEqual("8c255aeb-a306-45a8-b365-a56b946af19f", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-295", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("4d157079-42f6-4e06-bc7b-b23776dbd6fd", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/4d157079-42f6-4e06-bc7b-b23776dbd6fd", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/8c255aeb-a306-45a8-b365-a56b946af19f/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestUpdateOrganizationRequest()
        {
            string json = @"{
  ""name"": ""New Organization Name"",
  ""quota_definition_guid"": ""4526f37c-ab2d-4525-b643-957f3fe0e494""
}";
    
            UpdateOrganizationRequest obj = Util.DeserializeJson<UpdateOrganizationRequest>(json);
        
            Assert.AreEqual("New Organization Name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("4526f37c-ab2d-4525-b643-957f3fe0e494", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
        }

    
        [TestMethod]
        public void TestUpdateOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""917f3776-249d-4fd8-995c-301afaeb4df7"",
    ""url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7"",
    ""created_at"": ""2014-11-12T12:59:24+02:00"",
    ""updated_at"": ""2014-11-12T12:59:24+02:00""
  },
  ""entity"": {
    ""name"": ""New Organization Name"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""4526f37c-ab2d-4525-b643-957f3fe0e494"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/4526f37c-ab2d-4525-b643-957f3fe0e494"",
    ""spaces_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/spaces"",
    ""domains_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/domains"",
    ""private_domains_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/private_domains"",
    ""users_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/users"",
    ""managers_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/managers"",
    ""billing_managers_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/billing_managers"",
    ""auditors_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/auditors"",
    ""app_events_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/space_quota_definitions""
  }
}";
    
            UpdateOrganizationResponse obj = Util.DeserializeJson<UpdateOrganizationResponse>(json);
        
            Assert.AreEqual("917f3776-249d-4fd8-995c-301afaeb4df7", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("New Organization Name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("4526f37c-ab2d-4525-b643-957f3fe0e494", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/4526f37c-ab2d-4525-b643-957f3fe0e494", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/917f3776-249d-4fd8-995c-301afaeb4df7/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateOrganizationRequest()
        {
            string json = @"{
  ""name"": ""my-org-name"",
  ""quota_definition_guid"": ""d1d8ff79-656c-4579-8ed4-cc96e7f4cb52""
}";
    
            CreateOrganizationRequest obj = Util.DeserializeJson<CreateOrganizationRequest>(json);
        
            Assert.AreEqual("my-org-name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("d1d8ff79-656c-4579-8ed4-cc96e7f4cb52", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
        }

    
        [TestMethod]
        public void TestCreateOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""b7e3906e-f2ea-4b53-88e1-e17a6bb29c00"",
    ""url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00"",
    ""created_at"": ""2014-11-12T12:59:24+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""my-org-name"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""d1d8ff79-656c-4579-8ed4-cc96e7f4cb52"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/d1d8ff79-656c-4579-8ed4-cc96e7f4cb52"",
    ""spaces_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/spaces"",
    ""domains_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/domains"",
    ""private_domains_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/private_domains"",
    ""users_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/users"",
    ""managers_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/managers"",
    ""billing_managers_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/billing_managers"",
    ""auditors_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/auditors"",
    ""app_events_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/space_quota_definitions""
  }
}";
    
            CreateOrganizationResponse obj = Util.DeserializeJson<CreateOrganizationResponse>(json);
        
            Assert.AreEqual("b7e3906e-f2ea-4b53-88e1-e17a6bb29c00", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("my-org-name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("d1d8ff79-656c-4579-8ed4-cc96e7f4cb52", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/d1d8ff79-656c-4579-8ed4-cc96e7f4cb52", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/b7e3906e-f2ea-4b53-88e1-e17a6bb29c00/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllDomainsForOrganizationDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 2,
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
    }
  ]
}";
    
            PagedResponse<ListAllDomainsForOrganizationDeprecatedResponse> page = Util.DeserializePage<ListAllDomainsForOrganizationDeprecatedResponse>(json);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
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
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllManagersForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 2,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-41"",
        ""url"": ""/v2/users/uaa-id-41"",
        ""created_at"": ""2014-11-12T12:59:25+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-41/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-41/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-41/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-41/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-41/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-41/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-41/audited_spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""uaa-id-42"",
        ""url"": ""/v2/users/uaa-id-42"",
        ""created_at"": ""2014-11-12T12:59:25+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-42/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-42/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-42/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-42/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-42/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-42/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-42/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllManagersForOrganizationResponse> page = Util.DeserializePage<ListAllManagersForOrganizationResponse>(json);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-41", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-41", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-41/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
            
                Assert.AreEqual("uaa-id-42", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-42", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/spaces", TestUtil.ToTestableString(page[1].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/organizations", TestUtil.ToTestableString(page[1].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/managed_organizations", TestUtil.ToTestableString(page[1].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/billing_managed_organizations", TestUtil.ToTestableString(page[1].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/audited_organizations", TestUtil.ToTestableString(page[1].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/managed_spaces", TestUtil.ToTestableString(page[1].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-42/audited_spaces", TestUtil.ToTestableString(page[1].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveManagerFromOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""f58cc6fd-fba3-4618-8082-f70c81f73b9d"",
    ""url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d"",
    ""created_at"": ""2014-11-12T12:59:24+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-291"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""f42afdec-89c9-4994-9673-72ab711c3920"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/f42afdec-89c9-4994-9673-72ab711c3920"",
    ""spaces_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/spaces"",
    ""domains_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/domains"",
    ""private_domains_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/private_domains"",
    ""users_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/users"",
    ""managers_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/managers"",
    ""billing_managers_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/billing_managers"",
    ""auditors_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/auditors"",
    ""app_events_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/space_quota_definitions""
  }
}";
    
            RemoveManagerFromOrganizationResponse obj = Util.DeserializeJson<RemoveManagerFromOrganizationResponse>(json);
        
            Assert.AreEqual("f58cc6fd-fba3-4618-8082-f70c81f73b9d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-291", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("f42afdec-89c9-4994-9673-72ab711c3920", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/f42afdec-89c9-4994-9673-72ab711c3920", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/f58cc6fd-fba3-4618-8082-f70c81f73b9d/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllAuditorsForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-51"",
        ""url"": ""/v2/users/uaa-id-51"",
        ""created_at"": ""2014-11-12T12:59:25+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-51/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-51/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-51/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-51/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-51/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-51/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-51/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAuditorsForOrganizationResponse> page = Util.DeserializePage<ListAllAuditorsForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-51", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-51", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-51/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllBillingManagersForOrganizationResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-31"",
        ""url"": ""/v2/users/uaa-id-31"",
        ""created_at"": ""2014-11-12T12:59:24+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-31/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-31/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-31/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-31/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-31/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-31/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-31/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllBillingManagersForOrganizationResponse> page = Util.DeserializePage<ListAllBillingManagersForOrganizationResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-31", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-31", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:24+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-31/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateAuditorWithOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""5467b5d0-ba1d-4071-8ea4-804e9334430e"",
    ""url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e"",
    ""created_at"": ""2014-11-12T12:59:25+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-305"",
    ""billing_enabled"": false,
    ""quota_definition_guid"": ""2b3b0611-b751-4a5e-99e9-bacc35cbd9da"",
    ""status"": ""active"",
    ""quota_definition_url"": ""/v2/quota_definitions/2b3b0611-b751-4a5e-99e9-bacc35cbd9da"",
    ""spaces_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/spaces"",
    ""domains_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/domains"",
    ""private_domains_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/private_domains"",
    ""users_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/users"",
    ""managers_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/managers"",
    ""billing_managers_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/billing_managers"",
    ""auditors_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/auditors"",
    ""app_events_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/app_events"",
    ""space_quota_definitions_url"": ""/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/space_quota_definitions""
  }
}";
    
            AssociateAuditorWithOrganizationResponse obj = Util.DeserializeJson<AssociateAuditorWithOrganizationResponse>(json);
        
            Assert.AreEqual("5467b5d0-ba1d-4071-8ea4-804e9334430e", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-305", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.BillingEnabled), true);
            Assert.AreEqual("2b3b0611-b751-4a5e-99e9-bacc35cbd9da", TestUtil.ToTestableString(obj.QuotaDefinitionGuid), true);
            Assert.AreEqual("active", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("/v2/quota_definitions/2b3b0611-b751-4a5e-99e9-bacc35cbd9da", TestUtil.ToTestableString(obj.QuotaDefinitionUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/domains", TestUtil.ToTestableString(obj.DomainsUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/private_domains", TestUtil.ToTestableString(obj.PrivateDomainsUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/users", TestUtil.ToTestableString(obj.UsersUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/managers", TestUtil.ToTestableString(obj.ManagersUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/billing_managers", TestUtil.ToTestableString(obj.BillingManagersUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/auditors", TestUtil.ToTestableString(obj.AuditorsUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/app_events", TestUtil.ToTestableString(obj.AppEventsUrl), true);
            Assert.AreEqual("/v2/organizations/5467b5d0-ba1d-4071-8ea4-804e9334430e/space_quota_definitions", TestUtil.ToTestableString(obj.SpaceQuotaDefinitionsUrl), true);
            
            
        }

    }
}
