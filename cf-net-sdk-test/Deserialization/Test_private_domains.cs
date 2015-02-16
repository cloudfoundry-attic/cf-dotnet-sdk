using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class PrivateDomainsTest
    {

    
        [TestMethod]
        public void TestCreatePrivateDomainOwnedByGivenOrganizationResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""9ad30f3f-b878-42da-b53e-b4d1126bee0b"",
    ""url"": ""/v2/private_domains/9ad30f3f-b878-42da-b53e-b4d1126bee0b"",
    ""created_at"": ""2014-11-12T12:59:45+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""exmaple.com"",
    ""owning_organization_guid"": ""40b0d85e-db8c-4532-a00d-96398c2dc6ba"",
    ""owning_organization_url"": ""/v2/organizations/40b0d85e-db8c-4532-a00d-96398c2dc6ba""
  }
}";
    
            CreatePrivateDomainOwnedByGivenOrganizationResponse obj = Util.DeserializeJson<CreatePrivateDomainOwnedByGivenOrganizationResponse>(json);
        
            Assert.AreEqual("9ad30f3f-b878-42da-b53e-b4d1126bee0b", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/private_domains/9ad30f3f-b878-42da-b53e-b4d1126bee0b", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:45+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("exmaple.com", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("40b0d85e-db8c-4532-a00d-96398c2dc6ba", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
            Assert.AreEqual("/v2/organizations/40b0d85e-db8c-4532-a00d-96398c2dc6ba", TestUtil.ToTestableString(obj.OwningOrganizationUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrievePrivateDomainResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""834d63e6-8d79-4077-8298-dd4210ef977d"",
    ""url"": ""/v2/private_domains/834d63e6-8d79-4077-8298-dd4210ef977d"",
    ""created_at"": ""2014-11-12T12:59:39+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""vcap.me"",
    ""owning_organization_guid"": ""d106e97c-6365-44da-a091-fff732e9a0e8"",
    ""owning_organization_url"": ""/v2/organizations/d106e97c-6365-44da-a091-fff732e9a0e8""
  }
}";
    
            RetrievePrivateDomainResponse obj = Util.DeserializeJson<RetrievePrivateDomainResponse>(json);
        
            Assert.AreEqual("834d63e6-8d79-4077-8298-dd4210ef977d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/private_domains/834d63e6-8d79-4077-8298-dd4210ef977d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("vcap.me", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("d106e97c-6365-44da-a091-fff732e9a0e8", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
            Assert.AreEqual("/v2/organizations/d106e97c-6365-44da-a091-fff732e9a0e8", TestUtil.ToTestableString(obj.OwningOrganizationUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestFilterPrivateDomainsByNameResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""c693c131-63ac-4892-8b68-63378a51897d"",
        ""url"": ""/v2/private_domains/c693c131-63ac-4892-8b68-63378a51897d"",
        ""created_at"": ""2014-11-12T12:59:45+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""my-domain.com"",
        ""owning_organization_guid"": ""39b76901-9f6f-4a40-86d3-4b2e12b251c4"",
        ""owning_organization_url"": ""/v2/organizations/39b76901-9f6f-4a40-86d3-4b2e12b251c4""
      }
    }
  ]
}";
    
            PagedResponse<FilterPrivateDomainsByNameResponse> page = Util.DeserializePage<FilterPrivateDomainsByNameResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("c693c131-63ac-4892-8b68-63378a51897d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/c693c131-63ac-4892-8b68-63378a51897d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:45+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("my-domain.com", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("39b76901-9f6f-4a40-86d3-4b2e12b251c4", TestUtil.ToTestableString(page[0].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/39b76901-9f6f-4a40-86d3-4b2e12b251c4", TestUtil.ToTestableString(page[0].OwningOrganizationUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllPrivateDomainsResponse()
        {
            string json = @"{
  ""total_results"": 4,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""834d63e6-8d79-4077-8298-dd4210ef977d"",
        ""url"": ""/v2/private_domains/834d63e6-8d79-4077-8298-dd4210ef977d"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""vcap.me"",
        ""owning_organization_guid"": ""d106e97c-6365-44da-a091-fff732e9a0e8"",
        ""owning_organization_url"": ""/v2/organizations/d106e97c-6365-44da-a091-fff732e9a0e8""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""329bf27f-9ea4-4726-bff3-2a2f3190c992"",
        ""url"": ""/v2/private_domains/329bf27f-9ea4-4726-bff3-2a2f3190c992"",
        ""created_at"": ""2014-11-12T12:59:45+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-43.example.com"",
        ""owning_organization_guid"": ""a84292c5-7242-41ce-9692-f2c6e19322fa"",
        ""owning_organization_url"": ""/v2/organizations/a84292c5-7242-41ce-9692-f2c6e19322fa""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""27c09671-2948-4a2f-a83b-f9fe82aea318"",
        ""url"": ""/v2/private_domains/27c09671-2948-4a2f-a83b-f9fe82aea318"",
        ""created_at"": ""2014-11-12T12:59:45+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-44.example.com"",
        ""owning_organization_guid"": ""620969cb-7953-4e38-9771-4f32a84ae9a4"",
        ""owning_organization_url"": ""/v2/organizations/620969cb-7953-4e38-9771-4f32a84ae9a4""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""d07e4471-2e41-42d0-8044-5abb7c31993d"",
        ""url"": ""/v2/private_domains/d07e4471-2e41-42d0-8044-5abb7c31993d"",
        ""created_at"": ""2014-11-12T12:59:45+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-45.example.com"",
        ""owning_organization_guid"": ""19313e3c-257d-40d9-83b7-ec5f090e0a06"",
        ""owning_organization_url"": ""/v2/organizations/19313e3c-257d-40d9-83b7-ec5f090e0a06""
      }
    }
  ]
}";
    
            PagedResponse<ListAllPrivateDomainsResponse> page = Util.DeserializePage<ListAllPrivateDomainsResponse>(json);
        
            Assert.AreEqual("4", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("834d63e6-8d79-4077-8298-dd4210ef977d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/834d63e6-8d79-4077-8298-dd4210ef977d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("vcap.me", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("d106e97c-6365-44da-a091-fff732e9a0e8", TestUtil.ToTestableString(page[0].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/d106e97c-6365-44da-a091-fff732e9a0e8", TestUtil.ToTestableString(page[0].OwningOrganizationUrl), true);
               
               
            
            
                Assert.AreEqual("329bf27f-9ea4-4726-bff3-2a2f3190c992", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/329bf27f-9ea4-4726-bff3-2a2f3190c992", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:45+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-43.example.com", TestUtil.ToTestableString(page[1].Name), true);
                  Assert.AreEqual("a84292c5-7242-41ce-9692-f2c6e19322fa", TestUtil.ToTestableString(page[1].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/a84292c5-7242-41ce-9692-f2c6e19322fa", TestUtil.ToTestableString(page[1].OwningOrganizationUrl), true);
               
               
            
            
                Assert.AreEqual("27c09671-2948-4a2f-a83b-f9fe82aea318", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/27c09671-2948-4a2f-a83b-f9fe82aea318", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:45+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-44.example.com", TestUtil.ToTestableString(page[2].Name), true);
                  Assert.AreEqual("620969cb-7953-4e38-9771-4f32a84ae9a4", TestUtil.ToTestableString(page[2].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/620969cb-7953-4e38-9771-4f32a84ae9a4", TestUtil.ToTestableString(page[2].OwningOrganizationUrl), true);
               
               
            
            
                Assert.AreEqual("d07e4471-2e41-42d0-8044-5abb7c31993d", TestUtil.ToTestableString(page[3].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/d07e4471-2e41-42d0-8044-5abb7c31993d", TestUtil.ToTestableString(page[3].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:45+02:00", TestUtil.ToTestableString(page[3].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[3].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-45.example.com", TestUtil.ToTestableString(page[3].Name), true);
                  Assert.AreEqual("19313e3c-257d-40d9-83b7-ec5f090e0a06", TestUtil.ToTestableString(page[3].OwningOrganizationGuid), true);
                  Assert.AreEqual("/v2/organizations/19313e3c-257d-40d9-83b7-ec5f090e0a06", TestUtil.ToTestableString(page[3].OwningOrganizationUrl), true);
               
               
            
    
        }

    }
}
