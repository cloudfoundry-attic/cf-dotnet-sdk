using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class ServiceauthtokensDeprecatedTest
    {

    
        [TestMethod]
        public void TestListAllServiceAuthTokensDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""5a012d18-b948-4350-87cd-6b88bf0f4ad5"",
        ""url"": ""/v2/service_auth_tokens/5a012d18-b948-4350-87cd-6b88bf0f4ad5"",
        ""created_at"": ""2014-11-12T12:59:26+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-16"",
        ""provider"": ""provider-16""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""d87e2855-a2df-4729-a762-fc6a9d3b2051"",
        ""url"": ""/v2/service_auth_tokens/d87e2855-a2df-4729-a762-fc6a9d3b2051"",
        ""created_at"": ""2014-11-12T12:59:26+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-17"",
        ""provider"": ""provider-17""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""f72c5011-ecc6-43bc-9d83-e58541140a3c"",
        ""url"": ""/v2/service_auth_tokens/f72c5011-ecc6-43bc-9d83-e58541140a3c"",
        ""created_at"": ""2014-11-12T12:59:26+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-18"",
        ""provider"": ""provider-18""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceAuthTokensDeprecatedResponse> page = Util.DeserializePage<ListAllServiceAuthTokensDeprecatedResponse>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("5a012d18-b948-4350-87cd-6b88bf0f4ad5", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_auth_tokens/5a012d18-b948-4350-87cd-6b88bf0f4ad5", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-16", TestUtil.ToTestableString(page[0].Label), true);
                  Assert.AreEqual("provider-16", TestUtil.ToTestableString(page[0].Provider), true);
               
               
            
            
                Assert.AreEqual("d87e2855-a2df-4729-a762-fc6a9d3b2051", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_auth_tokens/d87e2855-a2df-4729-a762-fc6a9d3b2051", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-17", TestUtil.ToTestableString(page[1].Label), true);
                  Assert.AreEqual("provider-17", TestUtil.ToTestableString(page[1].Provider), true);
               
               
            
            
                Assert.AreEqual("f72c5011-ecc6-43bc-9d83-e58541140a3c", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_auth_tokens/f72c5011-ecc6-43bc-9d83-e58541140a3c", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:26+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-18", TestUtil.ToTestableString(page[2].Label), true);
                  Assert.AreEqual("provider-18", TestUtil.ToTestableString(page[2].Provider), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestFilterResultSetByLabelDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""2e44c44d-a46a-44be-a66b-1a6d942b5b83"",
        ""url"": ""/v2/service_auth_tokens/2e44c44d-a46a-44be-a66b-1a6d942b5b83"",
        ""created_at"": ""2014-11-12T12:59:27+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""Nic-Token"",
        ""provider"": ""provider-22""
      }
    }
  ]
}";
    
            PagedResponse<FilterResultSetByLabelDeprecatedResponse> page = Util.DeserializePage<FilterResultSetByLabelDeprecatedResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("2e44c44d-a46a-44be-a66b-1a6d942b5b83", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_auth_tokens/2e44c44d-a46a-44be-a66b-1a6d942b5b83", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("Nic-Token", TestUtil.ToTestableString(page[0].Label), true);
                  Assert.AreEqual("provider-22", TestUtil.ToTestableString(page[0].Provider), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveServiceAuthTokenDeprecatedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""c653eb31-ffe2-43d6-b5af-83fd5161729d"",
    ""url"": ""/v2/service_auth_tokens/c653eb31-ffe2-43d6-b5af-83fd5161729d"",
    ""created_at"": ""2014-11-12T12:59:27+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""label"": ""label-29"",
    ""provider"": ""provider-29""
  }
}";
    
            RetrieveServiceAuthTokenDeprecatedResponse obj = Util.DeserializeJson<RetrieveServiceAuthTokenDeprecatedResponse>(json);
        
            Assert.AreEqual("c653eb31-ffe2-43d6-b5af-83fd5161729d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_auth_tokens/c653eb31-ffe2-43d6-b5af-83fd5161729d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("label-29", TestUtil.ToTestableString(obj.Label), true);
            Assert.AreEqual("provider-29", TestUtil.ToTestableString(obj.Provider), true);
            
            
        }

    
        [TestMethod]
        public void TestFilterResultSetByProviderDeprecatedResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""23f53d9d-3942-4ea1-8f24-bd35f9860fab"",
        ""url"": ""/v2/service_auth_tokens/23f53d9d-3942-4ea1-8f24-bd35f9860fab"",
        ""created_at"": ""2014-11-12T12:59:27+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""label"": ""label-25"",
        ""provider"": ""Face-Offer""
      }
    }
  ]
}";
    
            PagedResponse<FilterResultSetByProviderDeprecatedResponse> page = Util.DeserializePage<FilterResultSetByProviderDeprecatedResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("23f53d9d-3942-4ea1-8f24-bd35f9860fab", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_auth_tokens/23f53d9d-3942-4ea1-8f24-bd35f9860fab", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("label-25", TestUtil.ToTestableString(page[0].Label), true);
                  Assert.AreEqual("Face-Offer", TestUtil.ToTestableString(page[0].Provider), true);
               
               
            
    
        }

    }
}
