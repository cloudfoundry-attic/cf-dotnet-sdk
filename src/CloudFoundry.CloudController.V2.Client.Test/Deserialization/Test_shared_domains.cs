//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//
// This source code was auto-generated by cf-sdk-builder
//

using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.CodeDom.Compiler;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    [GeneratedCodeAttribute("cf-sdk-builder", "1.0.0.0")]
    public class SharedDomainsTest
    {


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
        ""guid"": ""f0a6911f-c183-4cf0-a441-2dd91149cdef"",
        ""url"": ""/v2/shared_domains/f0a6911f-c183-4cf0-a441-2dd91149cdef"",
        ""created_at"": ""2015-03-23T16:53:27+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""shared-domain.com""
      }
    }
  ]
}";

            PagedResponseCollection<FilterSharedDomainsByNameResponse> page = Utilities.DeserializePage<FilterSharedDomainsByNameResponse>(json);

            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PreviousUrl), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
            Assert.AreEqual("f0a6911f-c183-4cf0-a441-2dd91149cdef", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/f0a6911f-c183-4cf0-a441-2dd91149cdef", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:27+00:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("shared-domain.com", TestUtil.ToTestableString(page[0].Name), true);
        }

        [TestMethod]
        public void TestCreateSharedDomainResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""a461ef45-0abd-4afe-b4ee-2acddf86739d"",
    ""url"": ""/v2/shared_domains/a461ef45-0abd-4afe-b4ee-2acddf86739d"",
    ""created_at"": ""2015-03-23T16:53:27+00:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""example.com""
  }
}";

            CreateSharedDomainResponse obj = Utilities.DeserializeJson<CreateSharedDomainResponse>(json);

            Assert.AreEqual("a461ef45-0abd-4afe-b4ee-2acddf86739d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/a461ef45-0abd-4afe-b4ee-2acddf86739d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:27+00:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("example.com", TestUtil.ToTestableString(obj.Name), true);
        }

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
        ""guid"": ""78cde134-b278-4927-ba7a-6019472d7d61"",
        ""url"": ""/v2/shared_domains/78cde134-b278-4927-ba7a-6019472d7d61"",
        ""created_at"": ""2015-03-23T16:53:20+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain1.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""b7e4aa07-da90-4ef0-849f-dc167b3dd875"",
        ""url"": ""/v2/shared_domains/b7e4aa07-da90-4ef0-849f-dc167b3dd875"",
        ""created_at"": ""2015-03-23T16:53:20+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""customer-app-domain2.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""12700de0-395a-4f91-afce-9c8a1c4fdc19"",
        ""url"": ""/v2/shared_domains/12700de0-395a-4f91-afce-9c8a1c4fdc19"",
        ""created_at"": ""2015-03-23T16:53:27+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-28.example.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""6544d161-64d4-4a4f-b01d-82d532be8c7d"",
        ""url"": ""/v2/shared_domains/6544d161-64d4-4a4f-b01d-82d532be8c7d"",
        ""created_at"": ""2015-03-23T16:53:27+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-29.example.com""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""ec8ca1c5-404e-40ca-bb32-5a24b01ac0c7"",
        ""url"": ""/v2/shared_domains/ec8ca1c5-404e-40ca-bb32-5a24b01ac0c7"",
        ""created_at"": ""2015-03-23T16:53:27+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-30.example.com""
      }
    }
  ]
}";

            PagedResponseCollection<ListAllSharedDomainsResponse> page = Utilities.DeserializePage<ListAllSharedDomainsResponse>(json);

            Assert.AreEqual("5", TestUtil.ToTestableString(page.Properties.TotalResults), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PreviousUrl), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
            Assert.AreEqual("78cde134-b278-4927-ba7a-6019472d7d61", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/78cde134-b278-4927-ba7a-6019472d7d61", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:20+00:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("customer-app-domain1.com", TestUtil.ToTestableString(page[0].Name), true);
            Assert.AreEqual("b7e4aa07-da90-4ef0-849f-dc167b3dd875", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/b7e4aa07-da90-4ef0-849f-dc167b3dd875", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:20+00:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("customer-app-domain2.com", TestUtil.ToTestableString(page[1].Name), true);
            Assert.AreEqual("12700de0-395a-4f91-afce-9c8a1c4fdc19", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/12700de0-395a-4f91-afce-9c8a1c4fdc19", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:27+00:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("domain-28.example.com", TestUtil.ToTestableString(page[2].Name), true);
            Assert.AreEqual("6544d161-64d4-4a4f-b01d-82d532be8c7d", TestUtil.ToTestableString(page[3].EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/6544d161-64d4-4a4f-b01d-82d532be8c7d", TestUtil.ToTestableString(page[3].EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:27+00:00", TestUtil.ToTestableString(page[3].EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page[3].EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("domain-29.example.com", TestUtil.ToTestableString(page[3].Name), true);
            Assert.AreEqual("ec8ca1c5-404e-40ca-bb32-5a24b01ac0c7", TestUtil.ToTestableString(page[4].EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/ec8ca1c5-404e-40ca-bb32-5a24b01ac0c7", TestUtil.ToTestableString(page[4].EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:27+00:00", TestUtil.ToTestableString(page[4].EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(page[4].EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("domain-30.example.com", TestUtil.ToTestableString(page[4].Name), true);
        }

        [TestMethod]
        public void TestRetrieveSharedDomainResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""78cde134-b278-4927-ba7a-6019472d7d61"",
    ""url"": ""/v2/shared_domains/78cde134-b278-4927-ba7a-6019472d7d61"",
    ""created_at"": ""2015-03-23T16:53:20+00:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""customer-app-domain1.com""
  }
}";

            RetrieveSharedDomainResponse obj = Utilities.DeserializeJson<RetrieveSharedDomainResponse>(json);

            Assert.AreEqual("78cde134-b278-4927-ba7a-6019472d7d61", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/shared_domains/78cde134-b278-4927-ba7a-6019472d7d61", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2015-03-23T16:53:20+00:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("customer-app-domain1.com", TestUtil.ToTestableString(obj.Name), true);
        }
    }
}
