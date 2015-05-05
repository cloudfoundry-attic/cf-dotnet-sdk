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

using CloudFoundry.CloudController.V2.Client.Data;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom.Compiler;
using System.Net;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Client.Test.Fake
{
    [TestClass]
    [GeneratedCodeAttribute("cf-sdk-builder", "1.0.0.0")]
    public class PrivateDomainsEndpoint
{
        [TestMethod]
        public void FilterPrivateDomainsByNameTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""1ceccf7a-9980-4011-b94a-df7b48579fd0"",
        ""url"": ""/v2/private_domains/1ceccf7a-9980-4011-b94a-df7b48579fd0"",
        ""created_at"": ""2015-04-16T12:04:23+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""my-domain.com"",
        ""owning_organization_guid"": ""cd64c73e-5e5a-4120-834e-4c9d541a6bef"",
        ""owning_organization_url"": ""/v2/organizations/cd64c73e-5e5a-4120-834e-4c9d541a6bef""
      }
    }
  ]
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();


                var obj = cfClient.PrivateDomains.FilterPrivateDomainsByName().Result;

                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalResults), true);
                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalPages), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.PreviousUrl), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.NextUrl), true);
                Assert.AreEqual("1ceccf7a-9980-4011-b94a-df7b48579fd0", TestUtil.ToTestableString(obj[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/1ceccf7a-9980-4011-b94a-df7b48579fd0", TestUtil.ToTestableString(obj[0].EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:23+00:00", TestUtil.ToTestableString(obj[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("my-domain.com", TestUtil.ToTestableString(obj[0].Name), true);
                Assert.AreEqual("cd64c73e-5e5a-4120-834e-4c9d541a6bef", TestUtil.ToTestableString(obj[0].OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/cd64c73e-5e5a-4120-834e-4c9d541a6bef", TestUtil.ToTestableString(obj[0].OwningOrganizationUrl), true);

            }
        }

        [TestMethod]
        public void RetrievePrivateDomainTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""metadata"": {
    ""guid"": ""face0158-42ca-4003-8a48-d1c56a793ac8"",
    ""url"": ""/v2/private_domains/face0158-42ca-4003-8a48-d1c56a793ac8"",
    ""created_at"": ""2015-04-16T12:04:14+00:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""vcap.me"",
    ""owning_organization_guid"": ""68378f1b-b6b1-4b89-8614-ff80330b6ae0"",
    ""owning_organization_url"": ""/v2/organizations/68378f1b-b6b1-4b89-8614-ff80330b6ae0""
  }
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();


                var obj = cfClient.PrivateDomains.RetrievePrivateDomain(guid).Result;


                Assert.AreEqual("face0158-42ca-4003-8a48-d1c56a793ac8", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/face0158-42ca-4003-8a48-d1c56a793ac8", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:14+00:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("vcap.me", TestUtil.ToTestableString(obj.Name), true);
                Assert.AreEqual("68378f1b-b6b1-4b89-8614-ff80330b6ae0", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/68378f1b-b6b1-4b89-8614-ff80330b6ae0", TestUtil.ToTestableString(obj.OwningOrganizationUrl), true);

            }
        }

        [TestMethod]
        public void CreatePrivateDomainOwnedByGivenOrganizationTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""metadata"": {
    ""guid"": ""aadbdf75-19ef-4040-969a-63ca474f82e3"",
    ""url"": ""/v2/private_domains/aadbdf75-19ef-4040-969a-63ca474f82e3"",
    ""created_at"": ""2015-04-16T12:04:23+00:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""exmaple.com"",
    ""owning_organization_guid"": ""6fc8d52b-8ba9-4c93-9973-44b18e04d6ec"",
    ""owning_organization_url"": ""/v2/organizations/6fc8d52b-8ba9-4c93-9973-44b18e04d6ec""
  }
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)201;
                var cfClient = clients.CreateCloudFoundryClient();

                CreatePrivateDomainOwnedByGivenOrganizationRequest value = new CreatePrivateDomainOwnedByGivenOrganizationRequest();


                var obj = cfClient.PrivateDomains.CreatePrivateDomainOwnedByGivenOrganization(value).Result;


                Assert.AreEqual("aadbdf75-19ef-4040-969a-63ca474f82e3", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/aadbdf75-19ef-4040-969a-63ca474f82e3", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:23+00:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("exmaple.com", TestUtil.ToTestableString(obj.Name), true);
                Assert.AreEqual("6fc8d52b-8ba9-4c93-9973-44b18e04d6ec", TestUtil.ToTestableString(obj.OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/6fc8d52b-8ba9-4c93-9973-44b18e04d6ec", TestUtil.ToTestableString(obj.OwningOrganizationUrl), true);

            }
        }

        [TestMethod]
        public void DeletePrivateDomainTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                clients.ExpectedStatusCode = (HttpStatusCode)204;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();


                cfClient.PrivateDomains.DeletePrivateDomain(guid).Wait();

            }
        }

        [TestMethod]
        public void ListAllPrivateDomainsTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""total_results"": 4,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""face0158-42ca-4003-8a48-d1c56a793ac8"",
        ""url"": ""/v2/private_domains/face0158-42ca-4003-8a48-d1c56a793ac8"",
        ""created_at"": ""2015-04-16T12:04:14+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""vcap.me"",
        ""owning_organization_guid"": ""68378f1b-b6b1-4b89-8614-ff80330b6ae0"",
        ""owning_organization_url"": ""/v2/organizations/68378f1b-b6b1-4b89-8614-ff80330b6ae0""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""2d7e8a14-7a7a-4660-9447-6b3b0654ff53"",
        ""url"": ""/v2/private_domains/2d7e8a14-7a7a-4660-9447-6b3b0654ff53"",
        ""created_at"": ""2015-04-16T12:04:22+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-12.example.com"",
        ""owning_organization_guid"": ""1e4011a2-2bc2-409c-8f2f-2fdba9c29428"",
        ""owning_organization_url"": ""/v2/organizations/1e4011a2-2bc2-409c-8f2f-2fdba9c29428""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""c8424d9e-a56c-4c05-a5f5-ea55b1a22289"",
        ""url"": ""/v2/private_domains/c8424d9e-a56c-4c05-a5f5-ea55b1a22289"",
        ""created_at"": ""2015-04-16T12:04:22+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-13.example.com"",
        ""owning_organization_guid"": ""9ff01ed0-5bbc-42a6-b632-6bc93d081059"",
        ""owning_organization_url"": ""/v2/organizations/9ff01ed0-5bbc-42a6-b632-6bc93d081059""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""504291d6-6d65-44cd-9c00-7a6c79731139"",
        ""url"": ""/v2/private_domains/504291d6-6d65-44cd-9c00-7a6c79731139"",
        ""created_at"": ""2015-04-16T12:04:22+00:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""domain-14.example.com"",
        ""owning_organization_guid"": ""df4fad05-3e5b-4663-ace6-c14cc9f35e21"",
        ""owning_organization_url"": ""/v2/organizations/df4fad05-3e5b-4663-ace6-c14cc9f35e21""
      }
    }
  ]
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();


                var obj = cfClient.PrivateDomains.ListAllPrivateDomains().Result;

                Assert.AreEqual("4", TestUtil.ToTestableString(obj.Properties.TotalResults), true);
                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalPages), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.PreviousUrl), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.NextUrl), true);
                Assert.AreEqual("face0158-42ca-4003-8a48-d1c56a793ac8", TestUtil.ToTestableString(obj[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/face0158-42ca-4003-8a48-d1c56a793ac8", TestUtil.ToTestableString(obj[0].EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:14+00:00", TestUtil.ToTestableString(obj[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("vcap.me", TestUtil.ToTestableString(obj[0].Name), true);
                Assert.AreEqual("68378f1b-b6b1-4b89-8614-ff80330b6ae0", TestUtil.ToTestableString(obj[0].OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/68378f1b-b6b1-4b89-8614-ff80330b6ae0", TestUtil.ToTestableString(obj[0].OwningOrganizationUrl), true);
                Assert.AreEqual("2d7e8a14-7a7a-4660-9447-6b3b0654ff53", TestUtil.ToTestableString(obj[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/2d7e8a14-7a7a-4660-9447-6b3b0654ff53", TestUtil.ToTestableString(obj[1].EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:22+00:00", TestUtil.ToTestableString(obj[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[1].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("domain-12.example.com", TestUtil.ToTestableString(obj[1].Name), true);
                Assert.AreEqual("1e4011a2-2bc2-409c-8f2f-2fdba9c29428", TestUtil.ToTestableString(obj[1].OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/1e4011a2-2bc2-409c-8f2f-2fdba9c29428", TestUtil.ToTestableString(obj[1].OwningOrganizationUrl), true);
                Assert.AreEqual("c8424d9e-a56c-4c05-a5f5-ea55b1a22289", TestUtil.ToTestableString(obj[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/c8424d9e-a56c-4c05-a5f5-ea55b1a22289", TestUtil.ToTestableString(obj[2].EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:22+00:00", TestUtil.ToTestableString(obj[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[2].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("domain-13.example.com", TestUtil.ToTestableString(obj[2].Name), true);
                Assert.AreEqual("9ff01ed0-5bbc-42a6-b632-6bc93d081059", TestUtil.ToTestableString(obj[2].OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/9ff01ed0-5bbc-42a6-b632-6bc93d081059", TestUtil.ToTestableString(obj[2].OwningOrganizationUrl), true);
                Assert.AreEqual("504291d6-6d65-44cd-9c00-7a6c79731139", TestUtil.ToTestableString(obj[3].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/private_domains/504291d6-6d65-44cd-9c00-7a6c79731139", TestUtil.ToTestableString(obj[3].EntityMetadata.Url), true);
                Assert.AreEqual("2015-04-16T12:04:22+00:00", TestUtil.ToTestableString(obj[3].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[3].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("domain-14.example.com", TestUtil.ToTestableString(obj[3].Name), true);
                Assert.AreEqual("df4fad05-3e5b-4663-ace6-c14cc9f35e21", TestUtil.ToTestableString(obj[3].OwningOrganizationGuid), true);
                Assert.AreEqual("/v2/organizations/df4fad05-3e5b-4663-ace6-c14cc9f35e21", TestUtil.ToTestableString(obj[3].OwningOrganizationUrl), true);

            }
        }

    }
}