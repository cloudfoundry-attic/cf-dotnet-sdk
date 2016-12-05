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

using CloudFoundry.CloudController.V3.Client.Data;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom.Compiler;
using System.Net;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V3.Client.Test.Fake
{
    [TestClass]
    [GeneratedCodeAttribute("cf-sdk-builder", "1.0.0.0")]
    public class AppRoutesExperimentalEndpoint
{
        [TestMethod]
        public void ListRoutesTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""pagination"": {
    ""total_results"": 2,
    ""first"": {
      ""href"": ""/v3/apps/81fd7035-3bde-4ae3-a7f7-1aad80563eae/routes?page=1=50""
    },
    ""last"": {
      ""href"": ""/v3/apps/81fd7035-3bde-4ae3-a7f7-1aad80563eae/routes?page=1=50""
    },
    ""next"": null,
    ""previous"": null
  },
  ""resources"": [
    {
      ""guid"": ""8cef2922-645e-48c3-9454-556326a92f24"",
      ""host"": ""host-19"",
      ""path"": """",
      ""created_at"": ""2016-07-07T09:16:59Z"",
      ""updated_at"": null,
      ""links"": {
        ""space"": {
          ""href"": ""/v2/spaces/d0ad9c37-137a-4af1-819c-740aed6ce1cd""
        },
        ""domain"": {
          ""href"": ""/v2/domains/4522b68e-0623-4111-90f3-fda8727518b1""
        }
      }
    },
    {
      ""guid"": ""8cef2922-645e-48c3-9454-556326a92f24"",
      ""host"": ""host-20"",
      ""path"": ""/foo/bar"",
      ""created_at"": ""2016-07-07T09:16:59Z"",
      ""updated_at"": null,
      ""links"": {
        ""space"": {
          ""href"": ""/v2/spaces/d0ad9c37-137a-4af1-819c-740aed6ce1cd""
        },
        ""domain"": {
          ""href"": ""/v2/domains/1de3dd61-812b-44ac-81cb-1d04f6f0f042""
        }
      }
    }
  ]
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();


                var obj = cfClient.AppRoutesExperimental.ListRoutes(guid).Result;

                Assert.AreEqual("8cef2922-645e-48c3-9454-556326a92f24", TestUtil.ToTestableString(obj[0].Guid), true);
                Assert.AreEqual("host-19", TestUtil.ToTestableString(obj[0].Host), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].Path), true);
                Assert.AreEqual("2016-07-07T09:16:59Z", TestUtil.ToTestableString(obj[0].CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].UpdatedAt), true);
                Assert.AreEqual("8cef2922-645e-48c3-9454-556326a92f24", TestUtil.ToTestableString(obj[1].Guid), true);
                Assert.AreEqual("host-20", TestUtil.ToTestableString(obj[1].Host), true);
                Assert.AreEqual("/foo/bar", TestUtil.ToTestableString(obj[1].Path), true);
                Assert.AreEqual("2016-07-07T09:16:59Z", TestUtil.ToTestableString(obj[1].CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[1].UpdatedAt), true);

            }
        }

        [TestMethod]
        public void MapRouteTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                clients.ExpectedStatusCode = (HttpStatusCode)204;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();

                MapRouteRequest value = new MapRouteRequest();


                cfClient.AppRoutesExperimental.MapRoute(guid, value).Wait();

            }
        }

        [TestMethod]
        public void UnmapRouteTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                clients.ExpectedStatusCode = (HttpStatusCode)204;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();

                UnmapRouteRequest value = new UnmapRouteRequest();


                cfClient.AppRoutesExperimental.UnmapRoute(guid, value).Wait();

            }
        }

    }
}