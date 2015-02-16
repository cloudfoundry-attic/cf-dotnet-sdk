using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class UsersTest
    {

    
        [TestMethod]
        public void TestRemoveSpaceFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-153"",
    ""url"": ""/v2/users/uaa-id-153"",
    ""created_at"": ""2014-11-12T12:59:35+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""257a858c-08c7-4241-86ae-515911baf852"",
    ""default_space_url"": ""/v2/spaces/257a858c-08c7-4241-86ae-515911baf852"",
    ""spaces_url"": ""/v2/users/uaa-id-153/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-153/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-153/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-153/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-153/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-153/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-153/audited_spaces""
  }
}";
    
            RemoveSpaceFromUserResponse obj = Util.DeserializeJson<RemoveSpaceFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-153", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-153", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("257a858c-08c7-4241-86ae-515911baf852", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/257a858c-08c7-4241-86ae-515911baf852", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-153/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateSpaceWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-157"",
    ""url"": ""/v2/users/uaa-id-157"",
    ""created_at"": ""2014-11-12T12:59:35+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""02ad6cc4-569f-479f-9837-98990259fd0f"",
    ""default_space_url"": ""/v2/spaces/02ad6cc4-569f-479f-9837-98990259fd0f"",
    ""spaces_url"": ""/v2/users/uaa-id-157/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-157/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-157/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-157/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-157/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-157/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-157/audited_spaces""
  }
}";
    
            AssociateSpaceWithUserResponse obj = Util.DeserializeJson<AssociateSpaceWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-157", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-157", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("02ad6cc4-569f-479f-9837-98990259fd0f", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/02ad6cc4-569f-479f-9837-98990259fd0f", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-157/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveBillingManagedOrganizationFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-159"",
    ""url"": ""/v2/users/uaa-id-159"",
    ""created_at"": ""2014-11-12T12:59:35+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""b801bcc0-044f-4f5b-94cd-4bea35b084a1"",
    ""default_space_url"": ""/v2/spaces/b801bcc0-044f-4f5b-94cd-4bea35b084a1"",
    ""spaces_url"": ""/v2/users/uaa-id-159/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-159/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-159/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-159/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-159/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-159/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-159/audited_spaces""
  }
}";
    
            RemoveBillingManagedOrganizationFromUserResponse obj = Util.DeserializeJson<RemoveBillingManagedOrganizationFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-159", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-159", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("b801bcc0-044f-4f5b-94cd-4bea35b084a1", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/b801bcc0-044f-4f5b-94cd-4bea35b084a1", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-159/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveAuditedOrganizationFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-165"",
    ""url"": ""/v2/users/uaa-id-165"",
    ""created_at"": ""2014-11-12T12:59:36+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""f6490d2a-08fd-42c5-bcb7-76568185a45b"",
    ""default_space_url"": ""/v2/spaces/f6490d2a-08fd-42c5-bcb7-76568185a45b"",
    ""spaces_url"": ""/v2/users/uaa-id-165/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-165/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-165/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-165/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-165/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-165/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-165/audited_spaces""
  }
}";
    
            RemoveAuditedOrganizationFromUserResponse obj = Util.DeserializeJson<RemoveAuditedOrganizationFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-165", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-165", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("f6490d2a-08fd-42c5-bcb7-76568185a45b", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/f6490d2a-08fd-42c5-bcb7-76568185a45b", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-165/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllBillingManagedOrganizationsForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""3ac8feca-9b05-4b2b-a159-c74a80d2e540"",
        ""url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540"",
        ""created_at"": ""2014-11-12T12:59:35+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-680"",
        ""billing_enabled"": false,
        ""quota_definition_guid"": ""1558c21e-69e4-4e19-be91-c0aebb428c77"",
        ""status"": ""active"",
        ""quota_definition_url"": ""/v2/quota_definitions/1558c21e-69e4-4e19-be91-c0aebb428c77"",
        ""spaces_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/spaces"",
        ""domains_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/domains"",
        ""private_domains_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/private_domains"",
        ""users_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/users"",
        ""managers_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/managers"",
        ""billing_managers_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/billing_managers"",
        ""auditors_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/auditors"",
        ""app_events_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/app_events"",
        ""space_quota_definitions_url"": ""/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/space_quota_definitions""
      }
    }
  ]
}";
    
            PagedResponse<ListAllBillingManagedOrganizationsForUserResponse> page = Util.DeserializePage<ListAllBillingManagedOrganizationsForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("3ac8feca-9b05-4b2b-a159-c74a80d2e540", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-680", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].BillingEnabled), true);
                  Assert.AreEqual("1558c21e-69e4-4e19-be91-c0aebb428c77", TestUtil.ToTestableString(page[0].QuotaDefinitionGuid), true);
                  Assert.AreEqual("active", TestUtil.ToTestableString(page[0].Status), true);
                  Assert.AreEqual("/v2/quota_definitions/1558c21e-69e4-4e19-be91-c0aebb428c77", TestUtil.ToTestableString(page[0].QuotaDefinitionUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/private_domains", TestUtil.ToTestableString(page[0].PrivateDomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/users", TestUtil.ToTestableString(page[0].UsersUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/billing_managers", TestUtil.ToTestableString(page[0].BillingManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/organizations/3ac8feca-9b05-4b2b-a159-c74a80d2e540/space_quota_definitions", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllAuditedOrganizationsForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""42c0a9f2-ee61-4d87-aefe-ea9f5cd528be"",
        ""url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be"",
        ""created_at"": ""2014-11-12T12:59:36+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-701"",
        ""billing_enabled"": false,
        ""quota_definition_guid"": ""f885b3bf-7b1b-453c-9909-f38f366894a5"",
        ""status"": ""active"",
        ""quota_definition_url"": ""/v2/quota_definitions/f885b3bf-7b1b-453c-9909-f38f366894a5"",
        ""spaces_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/spaces"",
        ""domains_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/domains"",
        ""private_domains_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/private_domains"",
        ""users_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/users"",
        ""managers_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/managers"",
        ""billing_managers_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/billing_managers"",
        ""auditors_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/auditors"",
        ""app_events_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/app_events"",
        ""space_quota_definitions_url"": ""/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/space_quota_definitions""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAuditedOrganizationsForUserResponse> page = Util.DeserializePage<ListAllAuditedOrganizationsForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("42c0a9f2-ee61-4d87-aefe-ea9f5cd528be", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-701", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].BillingEnabled), true);
                  Assert.AreEqual("f885b3bf-7b1b-453c-9909-f38f366894a5", TestUtil.ToTestableString(page[0].QuotaDefinitionGuid), true);
                  Assert.AreEqual("active", TestUtil.ToTestableString(page[0].Status), true);
                  Assert.AreEqual("/v2/quota_definitions/f885b3bf-7b1b-453c-9909-f38f366894a5", TestUtil.ToTestableString(page[0].QuotaDefinitionUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/private_domains", TestUtil.ToTestableString(page[0].PrivateDomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/users", TestUtil.ToTestableString(page[0].UsersUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/billing_managers", TestUtil.ToTestableString(page[0].BillingManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/organizations/42c0a9f2-ee61-4d87-aefe-ea9f5cd528be/space_quota_definitions", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllOrganizationsForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""db94f013-b796-4586-b76a-3f9cb044f5cd"",
        ""url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd"",
        ""created_at"": ""2014-11-12T12:59:34+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-614"",
        ""billing_enabled"": false,
        ""quota_definition_guid"": ""f420f4ce-7889-4f38-bd93-a8387100268e"",
        ""status"": ""active"",
        ""quota_definition_url"": ""/v2/quota_definitions/f420f4ce-7889-4f38-bd93-a8387100268e"",
        ""spaces_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/spaces"",
        ""domains_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/domains"",
        ""private_domains_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/private_domains"",
        ""users_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/users"",
        ""managers_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/managers"",
        ""billing_managers_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/billing_managers"",
        ""auditors_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/auditors"",
        ""app_events_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/app_events"",
        ""space_quota_definitions_url"": ""/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/space_quota_definitions""
      }
    }
  ]
}";
    
            PagedResponse<ListAllOrganizationsForUserResponse> page = Util.DeserializePage<ListAllOrganizationsForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("db94f013-b796-4586-b76a-3f9cb044f5cd", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-614", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].BillingEnabled), true);
                  Assert.AreEqual("f420f4ce-7889-4f38-bd93-a8387100268e", TestUtil.ToTestableString(page[0].QuotaDefinitionGuid), true);
                  Assert.AreEqual("active", TestUtil.ToTestableString(page[0].Status), true);
                  Assert.AreEqual("/v2/quota_definitions/f420f4ce-7889-4f38-bd93-a8387100268e", TestUtil.ToTestableString(page[0].QuotaDefinitionUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/private_domains", TestUtil.ToTestableString(page[0].PrivateDomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/users", TestUtil.ToTestableString(page[0].UsersUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/billing_managers", TestUtil.ToTestableString(page[0].BillingManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/organizations/db94f013-b796-4586-b76a-3f9cb044f5cd/space_quota_definitions", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllManagedSpacesForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a"",
        ""url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a"",
        ""created_at"": ""2014-11-12T12:59:36+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-743"",
        ""organization_guid"": ""2a47fd5f-5afc-493a-ad95-479bfbadbda9"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/2a47fd5f-5afc-493a-ad95-479bfbadbda9"",
        ""developers_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/developers"",
        ""managers_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/managers"",
        ""auditors_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/auditors"",
        ""apps_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/apps"",
        ""routes_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/routes"",
        ""domains_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/domains"",
        ""service_instances_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/service_instances"",
        ""app_events_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/app_events"",
        ""events_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/events"",
        ""security_groups_url"": ""/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllManagedSpacesForUserResponse> page = Util.DeserializePage<ListAllManagedSpacesForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-743", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("2a47fd5f-5afc-493a-ad95-479bfbadbda9", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/2a47fd5f-5afc-493a-ad95-479bfbadbda9", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/a5bb8f8b-d5a3-41b3-b729-8a0920e24a6a/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveManagedOrganizationFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-171"",
    ""url"": ""/v2/users/uaa-id-171"",
    ""created_at"": ""2014-11-12T12:59:36+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""ce225f1e-338c-4ac2-9680-f2cb17733a7d"",
    ""default_space_url"": ""/v2/spaces/ce225f1e-338c-4ac2-9680-f2cb17733a7d"",
    ""spaces_url"": ""/v2/users/uaa-id-171/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-171/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-171/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-171/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-171/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-171/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-171/audited_spaces""
  }
}";
    
            RemoveManagedOrganizationFromUserResponse obj = Util.DeserializeJson<RemoveManagedOrganizationFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-171", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-171", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("ce225f1e-338c-4ac2-9680-f2cb17733a7d", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/ce225f1e-338c-4ac2-9680-f2cb17733a7d", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-171/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestGetUserSummaryResponse()
        {
            string json = @"{""metadata"":{""guid"":""uaa-id-64"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""organizations"":[{""metadata"":{""guid"":""0121d60f-b890-41d0-a1c1-be9ffc2c4539"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-316"",""billing_enabled"":false,""status"":""active"",""spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}],""quota_definition"":{""metadata"":{""guid"":""dc0df1b8-0e1e-4c88-ba38-cc5b735984ee"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-317"",""non_basic_services_allowed"":true,""total_services"":60,""memory_limit"":20480,""trial_db_allowed"":false}},""managers"":[{""metadata"":{""guid"":""uaa-id-64"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""admin"":false,""active"":false,""default_space_guid"":null}}]}}],""managed_organizations"":[{""metadata"":{""guid"":""0121d60f-b890-41d0-a1c1-be9ffc2c4539"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-316"",""billing_enabled"":false,""status"":""active"",""spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}],""quota_definition"":{""metadata"":{""guid"":""dc0df1b8-0e1e-4c88-ba38-cc5b735984ee"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-317"",""non_basic_services_allowed"":true,""total_services"":60,""memory_limit"":20480,""trial_db_allowed"":false}},""managers"":[{""metadata"":{""guid"":""uaa-id-64"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""admin"":false,""active"":false,""default_space_guid"":null}}]}}],""billing_managed_organizations"":[{""metadata"":{""guid"":""0121d60f-b890-41d0-a1c1-be9ffc2c4539"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-316"",""billing_enabled"":false,""status"":""active"",""spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}],""quota_definition"":{""metadata"":{""guid"":""dc0df1b8-0e1e-4c88-ba38-cc5b735984ee"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-317"",""non_basic_services_allowed"":true,""total_services"":60,""memory_limit"":20480,""trial_db_allowed"":false}},""managers"":[{""metadata"":{""guid"":""uaa-id-64"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""admin"":false,""active"":false,""default_space_guid"":null}}]}}],""audited_organizations"":[{""metadata"":{""guid"":""0121d60f-b890-41d0-a1c1-be9ffc2c4539"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-316"",""billing_enabled"":false,""status"":""active"",""spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}],""quota_definition"":{""metadata"":{""guid"":""dc0df1b8-0e1e-4c88-ba38-cc5b735984ee"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-317"",""non_basic_services_allowed"":true,""total_services"":60,""memory_limit"":20480,""trial_db_allowed"":false}},""managers"":[{""metadata"":{""guid"":""uaa-id-64"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""admin"":false,""active"":false,""default_space_guid"":null}}]}}],""spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}],""managed_spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}],""audited_spaces"":[{""metadata"":{""guid"":""2bda1873-c869-47e4-a4e1-76c1a6bb127f"",""created_at"":""2014-11-12T12:59:25+02:00"",""updated_at"":null},""entity"":{""name"":""name-318""}}]}}";
    
            GetUserSummaryResponse obj = Util.DeserializeJson<GetUserSummaryResponse>(json);
        
            Assert.AreEqual("uaa-id-64", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:25+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            
            
            
            
            
            
            
            
            
        }

    
        [TestMethod]
        public void TestAssociateManagedOrganizationWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-177"",
    ""url"": ""/v2/users/uaa-id-177"",
    ""created_at"": ""2014-11-12T12:59:36+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""a2e93a5a-2838-464d-8266-7c87804d72aa"",
    ""default_space_url"": ""/v2/spaces/a2e93a5a-2838-464d-8266-7c87804d72aa"",
    ""spaces_url"": ""/v2/users/uaa-id-177/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-177/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-177/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-177/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-177/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-177/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-177/audited_spaces""
  }
}";
    
            AssociateManagedOrganizationWithUserResponse obj = Util.DeserializeJson<AssociateManagedOrganizationWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-177", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-177", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("a2e93a5a-2838-464d-8266-7c87804d72aa", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/a2e93a5a-2838-464d-8266-7c87804d72aa", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-177/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllUsersResponse()
        {
            string json = @"{
  ""total_results"": 2,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""uaa-id-133"",
        ""url"": ""/v2/users/uaa-id-133"",
        ""created_at"": ""2014-11-12T12:59:34+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": false,
        ""active"": false,
        ""default_space_guid"": ""cbb524fa-c5d9-4dab-bcff-ffa2c778adcc"",
        ""default_space_url"": ""/v2/spaces/cbb524fa-c5d9-4dab-bcff-ffa2c778adcc"",
        ""spaces_url"": ""/v2/users/uaa-id-133/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-133/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-133/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-133/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-133/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-133/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-133/audited_spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""uaa-id-134"",
        ""url"": ""/v2/users/uaa-id-134"",
        ""created_at"": ""2014-11-12T12:59:34+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""admin"": true,
        ""active"": false,
        ""default_space_guid"": null,
        ""spaces_url"": ""/v2/users/uaa-id-134/spaces"",
        ""organizations_url"": ""/v2/users/uaa-id-134/organizations"",
        ""managed_organizations_url"": ""/v2/users/uaa-id-134/managed_organizations"",
        ""billing_managed_organizations_url"": ""/v2/users/uaa-id-134/billing_managed_organizations"",
        ""audited_organizations_url"": ""/v2/users/uaa-id-134/audited_organizations"",
        ""managed_spaces_url"": ""/v2/users/uaa-id-134/managed_spaces"",
        ""audited_spaces_url"": ""/v2/users/uaa-id-134/audited_spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllUsersResponse> page = Util.DeserializePage<ListAllUsersResponse>(json);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("uaa-id-133", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-133", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Active), true);
                  Assert.AreEqual("cbb524fa-c5d9-4dab-bcff-ffa2c778adcc", TestUtil.ToTestableString(page[0].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/spaces/cbb524fa-c5d9-4dab-bcff-ffa2c778adcc", TestUtil.ToTestableString(page[0].DefaultSpaceUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/organizations", TestUtil.ToTestableString(page[0].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/managed_organizations", TestUtil.ToTestableString(page[0].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/billing_managed_organizations", TestUtil.ToTestableString(page[0].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/audited_organizations", TestUtil.ToTestableString(page[0].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/managed_spaces", TestUtil.ToTestableString(page[0].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-133/audited_spaces", TestUtil.ToTestableString(page[0].AuditedSpacesUrl), true);
               
               
            
            
                Assert.AreEqual("uaa-id-134", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/users/uaa-id-134", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[1].Admin), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].Active), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[1].DefaultSpaceGuid), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/spaces", TestUtil.ToTestableString(page[1].SpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/organizations", TestUtil.ToTestableString(page[1].OrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/managed_organizations", TestUtil.ToTestableString(page[1].ManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/billing_managed_organizations", TestUtil.ToTestableString(page[1].BillingManagedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/audited_organizations", TestUtil.ToTestableString(page[1].AuditedOrganizationsUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/managed_spaces", TestUtil.ToTestableString(page[1].ManagedSpacesUrl), true);
                  Assert.AreEqual("/v2/users/uaa-id-134/audited_spaces", TestUtil.ToTestableString(page[1].AuditedSpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateAuditedOrganizationWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-169"",
    ""url"": ""/v2/users/uaa-id-169"",
    ""created_at"": ""2014-11-12T12:59:36+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""9c0095a8-e69a-406f-9e03-940d3de64642"",
    ""default_space_url"": ""/v2/spaces/9c0095a8-e69a-406f-9e03-940d3de64642"",
    ""spaces_url"": ""/v2/users/uaa-id-169/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-169/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-169/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-169/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-169/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-169/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-169/audited_spaces""
  }
}";
    
            AssociateAuditedOrganizationWithUserResponse obj = Util.DeserializeJson<AssociateAuditedOrganizationWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-169", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-169", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("9c0095a8-e69a-406f-9e03-940d3de64642", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/9c0095a8-e69a-406f-9e03-940d3de64642", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-169/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateManagedSpaceWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-184"",
    ""url"": ""/v2/users/uaa-id-184"",
    ""created_at"": ""2014-11-12T12:59:36+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""dc2d4abc-3610-4778-9837-8948f3d2df6b"",
    ""default_space_url"": ""/v2/spaces/dc2d4abc-3610-4778-9837-8948f3d2df6b"",
    ""spaces_url"": ""/v2/users/uaa-id-184/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-184/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-184/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-184/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-184/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-184/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-184/audited_spaces""
  }
}";
    
            AssociateManagedSpaceWithUserResponse obj = Util.DeserializeJson<AssociateManagedSpaceWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-184", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-184", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("dc2d4abc-3610-4778-9837-8948f3d2df6b", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/dc2d4abc-3610-4778-9837-8948f3d2df6b", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-184/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateOrganizationWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-145"",
    ""url"": ""/v2/users/uaa-id-145"",
    ""created_at"": ""2014-11-12T12:59:34+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""d29c981b-b787-4342-83ea-f88e80e1a91f"",
    ""default_space_url"": ""/v2/spaces/d29c981b-b787-4342-83ea-f88e80e1a91f"",
    ""spaces_url"": ""/v2/users/uaa-id-145/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-145/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-145/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-145/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-145/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-145/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-145/audited_spaces""
  }
}";
    
            AssociateOrganizationWithUserResponse obj = Util.DeserializeJson<AssociateOrganizationWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-145", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-145", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("d29c981b-b787-4342-83ea-f88e80e1a91f", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/d29c981b-b787-4342-83ea-f88e80e1a91f", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-145/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-139"",
    ""url"": ""/v2/users/uaa-id-139"",
    ""created_at"": ""2014-11-12T12:59:34+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""a96141d9-1fb6-4265-a610-4c3429aff8cb"",
    ""default_space_url"": ""/v2/spaces/a96141d9-1fb6-4265-a610-4c3429aff8cb"",
    ""spaces_url"": ""/v2/users/uaa-id-139/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-139/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-139/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-139/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-139/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-139/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-139/audited_spaces""
  }
}";
    
            RetrieveUserResponse obj = Util.DeserializeJson<RetrieveUserResponse>(json);
        
            Assert.AreEqual("uaa-id-139", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-139", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("a96141d9-1fb6-4265-a610-4c3429aff8cb", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/a96141d9-1fb6-4265-a610-4c3429aff8cb", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-139/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestAssociateAuditedSpaceWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-151"",
    ""url"": ""/v2/users/uaa-id-151"",
    ""created_at"": ""2014-11-12T12:59:35+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""b423a9be-5188-42ec-83c1-13399cd71241"",
    ""default_space_url"": ""/v2/spaces/b423a9be-5188-42ec-83c1-13399cd71241"",
    ""spaces_url"": ""/v2/users/uaa-id-151/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-151/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-151/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-151/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-151/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-151/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-151/audited_spaces""
  }
}";
    
            AssociateAuditedSpaceWithUserResponse obj = Util.DeserializeJson<AssociateAuditedSpaceWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-151", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-151", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("b423a9be-5188-42ec-83c1-13399cd71241", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/b423a9be-5188-42ec-83c1-13399cd71241", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-151/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllSpacesForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""5a4f8899-b923-4c8a-b909-6884d5904cc0"",
        ""url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0"",
        ""created_at"": ""2014-11-12T12:59:35+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-659"",
        ""organization_guid"": ""9392fbe5-9ac0-4f42-b650-d902c9e100a4"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/9392fbe5-9ac0-4f42-b650-d902c9e100a4"",
        ""developers_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/developers"",
        ""managers_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/managers"",
        ""auditors_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/auditors"",
        ""apps_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/apps"",
        ""routes_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/routes"",
        ""domains_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/domains"",
        ""service_instances_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/service_instances"",
        ""app_events_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/app_events"",
        ""events_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/events"",
        ""security_groups_url"": ""/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpacesForUserResponse> page = Util.DeserializePage<ListAllSpacesForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("5a4f8899-b923-4c8a-b909-6884d5904cc0", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-659", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("9392fbe5-9ac0-4f42-b650-d902c9e100a4", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/9392fbe5-9ac0-4f42-b650-d902c9e100a4", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/5a4f8899-b923-4c8a-b909-6884d5904cc0/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllAuditedSpacesForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""ceca62ed-3715-43b8-80d4-15d90c3ab1bc"",
        ""url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc"",
        ""created_at"": ""2014-11-12T12:59:35+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-635"",
        ""organization_guid"": ""4b51ed33-06c3-4a05-9eba-39ac10843f6e"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/4b51ed33-06c3-4a05-9eba-39ac10843f6e"",
        ""developers_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/developers"",
        ""managers_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/managers"",
        ""auditors_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/auditors"",
        ""apps_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/apps"",
        ""routes_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/routes"",
        ""domains_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/domains"",
        ""service_instances_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/service_instances"",
        ""app_events_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/app_events"",
        ""events_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/events"",
        ""security_groups_url"": ""/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAuditedSpacesForUserResponse> page = Util.DeserializePage<ListAllAuditedSpacesForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("ceca62ed-3715-43b8-80d4-15d90c3ab1bc", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-635", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("4b51ed33-06c3-4a05-9eba-39ac10843f6e", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/4b51ed33-06c3-4a05-9eba-39ac10843f6e", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/ceca62ed-3715-43b8-80d4-15d90c3ab1bc/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateBillingManagedOrganizationWithUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-163"",
    ""url"": ""/v2/users/uaa-id-163"",
    ""created_at"": ""2014-11-12T12:59:35+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""672c7e91-5cde-4553-9764-9e9aba860a74"",
    ""default_space_url"": ""/v2/spaces/672c7e91-5cde-4553-9764-9e9aba860a74"",
    ""spaces_url"": ""/v2/users/uaa-id-163/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-163/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-163/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-163/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-163/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-163/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-163/audited_spaces""
  }
}";
    
            AssociateBillingManagedOrganizationWithUserResponse obj = Util.DeserializeJson<AssociateBillingManagedOrganizationWithUserResponse>(json);
        
            Assert.AreEqual("uaa-id-163", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-163", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:35+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("672c7e91-5cde-4553-9764-9e9aba860a74", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/672c7e91-5cde-4553-9764-9e9aba860a74", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-163/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestUpdateUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-131"",
    ""url"": ""/v2/users/uaa-id-131"",
    ""created_at"": ""2014-11-12T12:59:34+02:00"",
    ""updated_at"": ""2014-11-12T12:59:34+02:00""
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""07847408-706d-4f74-85b5-58c620aaebb8"",
    ""default_space_url"": ""/v2/spaces/07847408-706d-4f74-85b5-58c620aaebb8"",
    ""spaces_url"": ""/v2/users/uaa-id-131/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-131/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-131/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-131/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-131/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-131/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-131/audited_spaces""
  }
}";
    
            UpdateUserResponse obj = Util.DeserializeJson<UpdateUserResponse>(json);
        
            Assert.AreEqual("uaa-id-131", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-131", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("07847408-706d-4f74-85b5-58c620aaebb8", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/07847408-706d-4f74-85b5-58c620aaebb8", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-131/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202"",
    ""url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202"",
    ""created_at"": ""2014-11-12T12:59:34+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": null,
    ""spaces_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/spaces"",
    ""organizations_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/organizations"",
    ""managed_organizations_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/audited_spaces""
  }
}";
    
            CreateUserResponse obj = Util.DeserializeJson<CreateUserResponse>(json);
        
            Assert.AreEqual("guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveOrganizationFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-141"",
    ""url"": ""/v2/users/uaa-id-141"",
    ""created_at"": ""2014-11-12T12:59:34+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""ea268e31-4ead-4dd1-9519-75608cdb8220"",
    ""default_space_url"": ""/v2/spaces/ea268e31-4ead-4dd1-9519-75608cdb8220"",
    ""spaces_url"": ""/v2/users/uaa-id-141/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-141/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-141/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-141/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-141/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-141/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-141/audited_spaces""
  }
}";
    
            RemoveOrganizationFromUserResponse obj = Util.DeserializeJson<RemoveOrganizationFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-141", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-141", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("ea268e31-4ead-4dd1-9519-75608cdb8220", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/ea268e31-4ead-4dd1-9519-75608cdb8220", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-141/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllManagedOrganizationsForUserResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf"",
        ""url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf"",
        ""created_at"": ""2014-11-12T12:59:36+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-722"",
        ""billing_enabled"": false,
        ""quota_definition_guid"": ""dc537500-0afb-4b67-ad99-d2c1516143ec"",
        ""status"": ""active"",
        ""quota_definition_url"": ""/v2/quota_definitions/dc537500-0afb-4b67-ad99-d2c1516143ec"",
        ""spaces_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/spaces"",
        ""domains_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/domains"",
        ""private_domains_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/private_domains"",
        ""users_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/users"",
        ""managers_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/managers"",
        ""billing_managers_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/billing_managers"",
        ""auditors_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/auditors"",
        ""app_events_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/app_events"",
        ""space_quota_definitions_url"": ""/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/space_quota_definitions""
      }
    }
  ]
}";
    
            PagedResponse<ListAllManagedOrganizationsForUserResponse> page = Util.DeserializePage<ListAllManagedOrganizationsForUserResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-722", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].BillingEnabled), true);
                  Assert.AreEqual("dc537500-0afb-4b67-ad99-d2c1516143ec", TestUtil.ToTestableString(page[0].QuotaDefinitionGuid), true);
                  Assert.AreEqual("active", TestUtil.ToTestableString(page[0].Status), true);
                  Assert.AreEqual("/v2/quota_definitions/dc537500-0afb-4b67-ad99-d2c1516143ec", TestUtil.ToTestableString(page[0].QuotaDefinitionUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/private_domains", TestUtil.ToTestableString(page[0].PrivateDomainsUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/users", TestUtil.ToTestableString(page[0].UsersUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/billing_managers", TestUtil.ToTestableString(page[0].BillingManagersUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/organizations/e994bdd2-8e9d-45f6-9bda-6be4db1c8ddf/space_quota_definitions", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRemoveAuditedSpaceFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-147"",
    ""url"": ""/v2/users/uaa-id-147"",
    ""created_at"": ""2014-11-12T12:59:34+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""e01dd151-179f-4016-a97b-58360b9f48a7"",
    ""default_space_url"": ""/v2/spaces/e01dd151-179f-4016-a97b-58360b9f48a7"",
    ""spaces_url"": ""/v2/users/uaa-id-147/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-147/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-147/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-147/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-147/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-147/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-147/audited_spaces""
  }
}";
    
            RemoveAuditedSpaceFromUserResponse obj = Util.DeserializeJson<RemoveAuditedSpaceFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-147", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-147", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:34+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("e01dd151-179f-4016-a97b-58360b9f48a7", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/e01dd151-179f-4016-a97b-58360b9f48a7", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-147/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveManagedSpaceFromUserResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""uaa-id-180"",
    ""url"": ""/v2/users/uaa-id-180"",
    ""created_at"": ""2014-11-12T12:59:36+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""admin"": false,
    ""active"": false,
    ""default_space_guid"": ""4da9d917-9afd-425f-9aa9-cfe17471f775"",
    ""default_space_url"": ""/v2/spaces/4da9d917-9afd-425f-9aa9-cfe17471f775"",
    ""spaces_url"": ""/v2/users/uaa-id-180/spaces"",
    ""organizations_url"": ""/v2/users/uaa-id-180/organizations"",
    ""managed_organizations_url"": ""/v2/users/uaa-id-180/managed_organizations"",
    ""billing_managed_organizations_url"": ""/v2/users/uaa-id-180/billing_managed_organizations"",
    ""audited_organizations_url"": ""/v2/users/uaa-id-180/audited_organizations"",
    ""managed_spaces_url"": ""/v2/users/uaa-id-180/managed_spaces"",
    ""audited_spaces_url"": ""/v2/users/uaa-id-180/audited_spaces""
  }
}";
    
            RemoveManagedSpaceFromUserResponse obj = Util.DeserializeJson<RemoveManagedSpaceFromUserResponse>(json);
        
            Assert.AreEqual("uaa-id-180", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/users/uaa-id-180", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:36+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Admin), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Active), true);
            Assert.AreEqual("4da9d917-9afd-425f-9aa9-cfe17471f775", TestUtil.ToTestableString(obj.DefaultSpaceGuid), true);
            Assert.AreEqual("/v2/spaces/4da9d917-9afd-425f-9aa9-cfe17471f775", TestUtil.ToTestableString(obj.DefaultSpaceUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/organizations", TestUtil.ToTestableString(obj.OrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/managed_organizations", TestUtil.ToTestableString(obj.ManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/billing_managed_organizations", TestUtil.ToTestableString(obj.BillingManagedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/audited_organizations", TestUtil.ToTestableString(obj.AuditedOrganizationsUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/managed_spaces", TestUtil.ToTestableString(obj.ManagedSpacesUrl), true);
            Assert.AreEqual("/v2/users/uaa-id-180/audited_spaces", TestUtil.ToTestableString(obj.AuditedSpacesUrl), true);
            
            
        }

    }
}
