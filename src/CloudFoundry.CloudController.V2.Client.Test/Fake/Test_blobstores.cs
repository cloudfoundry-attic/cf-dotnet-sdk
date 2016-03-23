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
    public class BlobstoresEndpoint
{
        [TestMethod]
        public void DeleteAllBlobsInBuildpackCacheBlobstoreTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""metadata"": {
    ""guid"": ""cf93dee8-0716-43cd-aaa7-c0d8a81a0940"",
    ""created_at"": ""2016-03-21T10:59:33Z"",
    ""url"": ""/v2/jobs/e4193a85-14bf-44a5-a6f9-6781487885b0""
  },
  ""entity"": {
    ""guid"": ""cf93dee8-0716-43cd-aaa7-c0d8a81a0940"",
    ""status"": ""queued""
  }
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)202;
                var cfClient = clients.CreateCloudFoundryClient();


                var obj = cfClient.Blobstores.DeleteAllBlobsInBuildpackCacheBlobstore().Result;


                Assert.AreEqual("cf93dee8-0716-43cd-aaa7-c0d8a81a0940", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
                Assert.AreEqual("2016-03-21T10:59:33Z", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
                Assert.AreEqual("/v2/jobs/e4193a85-14bf-44a5-a6f9-6781487885b0", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
                Assert.AreEqual("cf93dee8-0716-43cd-aaa7-c0d8a81a0940", TestUtil.ToTestableString(obj.Guid), true);
                Assert.AreEqual("queued", TestUtil.ToTestableString(obj.Status), true);

            }
        }

    }
}