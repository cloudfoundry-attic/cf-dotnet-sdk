using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class StacksTest
    {

    
        [TestMethod]
        public void TestRetrieveStackResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""95e9f0db-77a4-4a0b-b12e-e18319e818f2"",
    ""url"": ""/v2/stacks/95e9f0db-77a4-4a0b-b12e-e18319e818f2"",
    ""created_at"": ""2014-11-12T12:59:28+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""lucid64"",
    ""description"": ""Ubuntu 10.04 on x86-64""
  }
}";
    
            RetrieveStackResponse obj = Util.DeserializeJson<RetrieveStackResponse>(json);
        
            Assert.AreEqual("95e9f0db-77a4-4a0b-b12e-e18319e818f2", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/stacks/95e9f0db-77a4-4a0b-b12e-e18319e818f2", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("lucid64", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("Ubuntu 10.04 on x86-64", TestUtil.ToTestableString(obj.Description), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllStacksResponse()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""95e9f0db-77a4-4a0b-b12e-e18319e818f2"",
        ""url"": ""/v2/stacks/95e9f0db-77a4-4a0b-b12e-e18319e818f2"",
        ""created_at"": ""2014-11-12T12:59:28+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""lucid64"",
        ""description"": ""Ubuntu 10.04 on x86-64""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""0d02c758-c1a1-45ce-b530-7d8e31c2f4f0"",
        ""url"": ""/v2/stacks/0d02c758-c1a1-45ce-b530-7d8e31c2f4f0"",
        ""created_at"": ""2014-11-12T12:59:28+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""default-stack-name"",
        ""description"": ""default-stack-description""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""4fb88d9a-cc7f-4669-aecc-b46df8ef5815"",
        ""url"": ""/v2/stacks/4fb88d9a-cc7f-4669-aecc-b46df8ef5815"",
        ""created_at"": ""2014-11-12T12:59:28+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""cider"",
        ""description"": ""cider-description""
      }
    }
  ]
}";
    
            PagedResponse<ListAllStacksResponse> page = Util.DeserializePage<ListAllStacksResponse>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("95e9f0db-77a4-4a0b-b12e-e18319e818f2", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/stacks/95e9f0db-77a4-4a0b-b12e-e18319e818f2", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("lucid64", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("Ubuntu 10.04 on x86-64", TestUtil.ToTestableString(page[0].Description), true);
               
               
            
            
                Assert.AreEqual("0d02c758-c1a1-45ce-b530-7d8e31c2f4f0", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/stacks/0d02c758-c1a1-45ce-b530-7d8e31c2f4f0", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("default-stack-name", TestUtil.ToTestableString(page[1].Name), true);
                  Assert.AreEqual("default-stack-description", TestUtil.ToTestableString(page[1].Description), true);
               
               
            
            
                Assert.AreEqual("4fb88d9a-cc7f-4669-aecc-b46df8ef5815", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/stacks/4fb88d9a-cc7f-4669-aecc-b46df8ef5815", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("cider", TestUtil.ToTestableString(page[2].Name), true);
                  Assert.AreEqual("cider-description", TestUtil.ToTestableString(page[2].Description), true);
               
               
            
    
        }

    }
}
