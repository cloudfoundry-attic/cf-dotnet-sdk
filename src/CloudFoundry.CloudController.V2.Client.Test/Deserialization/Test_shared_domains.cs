using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class SharedDomainsTest
    {

    
        [TestMethod]
        public void TestListAllSharedDomainsResponse()
        {
            string json = @"{
  ""total_results"": 5,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""61f29f9c-cb36-4692-a62d-7f9289119eb0"",
        ""url"": ""/v2/shared_domains/61f29f9c-cb36-4692-a62d-7f9289119eb0"",
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
        ""url"": ""/v2/shared_domains/b36bc148-9f7c-4046-acf7-387af66a7e64"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain2.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""17da08b5-c598-4677-b893-44e7acafbcf0"",
        ""url"": ""/v2/shared_domains/17da08b5-c598-4677-b893-44e7acafbcf0"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-19.example.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""aa0afb4f-9fe6-4a85-9a77-6cce00178fcb"",
        ""url"": ""/v2/shared_domains/aa0afb4f-9fe6-4a85-9a77-6cce00178fcb"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-20.example.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""28e739b4-61fb-4e62-8ec4-e124de1b6f57"",
        ""url"": ""/v2/shared_domains/28e739b4-61fb-4e62-8ec4-e124de1b6f57"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-21.example.com""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSharedDomainsResponse> page = Util.DeserializePage<ListAllSharedDomainsResponse>(json);
        
            Assert.AreEqual("5", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("61f29f9c-cb36-4692-a62d-7f9289119eb0", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/shared_domains/61f29f9c-cb36-4692-a62d-7f9289119eb0", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("customer-app-domain1.com", TestUtil.ToTestableString(page[0].Name), true);
               
               
            
            
                Assert.AreEqual("b36bc148-9f7c-4046-acf7-387af66a7e64", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/shared_domains/b36bc148-9f7c-4046-acf7-387af66a7e64", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("customer-app-domain2.com", TestUtil.ToTestableString(page[1].Name), true);
               
               
            
            
                Assert.AreEqual("17da08b5-c598-4677-b893-44e7acafbcf0", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/shared_domains/17da08b5-c598-4677-b893-44e7acafbcf0", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-19.example.com", TestUtil.ToTestableString(page[2].Name), true);
               
               
            
            
                Assert.AreEqual("aa0afb4f-9fe6-4a85-9a77-6cce00178fcb", TestUtil.ToTestableString(page[3].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/shared_domains/aa0afb4f-9fe6-4a85-9a77-6cce00178fcb", TestUtil.ToTestableString(page[3].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[3].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[3].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-20.example.com", TestUtil.ToTestableString(page[3].Name), true);
               
               
            
            
                Assert.AreEqual("28e739b4-61fb-4e62-8ec4-e124de1b6f57", TestUtil.ToTestableString(page[4].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/shared_domains/28e739b4-61fb-4e62-8ec4-e124de1b6f57", TestUtil.ToTestableString(page[4].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[4].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[4].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("domain-21.example.com", TestUtil.ToTestableString(page[4].Name), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestFilterSharedDomainsByNameResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""f4071db5-4e54-4022-b2b2-ac702ac8ccbc"",
        ""url"": ""/v2/shared_domains/f4071db5-4e54-4022-b2b2-ac702ac8ccbc"",
        ""created_at"": ""2014-11-12T12:59:39+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""shared-domain.com""
      }
    }
  ]
}";
    
            PagedResponse<FilterSharedDomainsByNameResponse> page = Util.DeserializePage<FilterSharedDomainsByNameResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("f4071db5-4e54-4022-b2b2-ac702ac8ccbc", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/shared_domains/f4071db5-4e54-4022-b2b2-ac702ac8ccbc", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("shared-domain.com", TestUtil.ToTestableString(page[0].Name), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreateSharedDomainResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""78b7e658-fb81-42e4-bdee-7d17bfacbd70"",
    ""url"": ""/v2/shared_domains/78b7e658-fb81-42e4-bdee-7d17bfacbd70"",
    ""created_at"": ""2014-11-12T12:59:39+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""example.com""
  }
}";
    
            CreateSharedDomainResponse obj = Util.DeserializeJson<CreateSharedDomainResponse>(json);
        
            Assert.AreEqual("78b7e658-fb81-42e4-bdee-7d17bfacbd70", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/78b7e658-fb81-42e4-bdee-7d17bfacbd70", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("example.com", TestUtil.ToTestableString(obj.Name), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveSharedDomainResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""61f29f9c-cb36-4692-a62d-7f9289119eb0"",
    ""url"": ""/v2/shared_domains/61f29f9c-cb36-4692-a62d-7f9289119eb0"",
    ""created_at"": ""2014-11-12T12:59:39+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""customer-app-domain1.com""
  }
}";
    
            RetrieveSharedDomainResponse obj = Util.DeserializeJson<RetrieveSharedDomainResponse>(json);
        
            Assert.AreEqual("61f29f9c-cb36-4692-a62d-7f9289119eb0", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/61f29f9c-cb36-4692-a62d-7f9289119eb0", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:39+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("customer-app-domain1.com", TestUtil.ToTestableString(obj.Name), true);
            
            
        }

    }
}
