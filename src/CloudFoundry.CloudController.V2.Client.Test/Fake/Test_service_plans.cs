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
    public class ServicePlansEndpoint
{
        [TestMethod]
        public void ListAllServicePlansTest()
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
        ""guid"": ""cec871bb-0e1c-4fd9-a51e-e2ff76bca4c7"",
        ""url"": ""/v2/service_plans/cec871bb-0e1c-4fd9-a51e-e2ff76bca4c7"",
        ""created_at"": ""2016-02-09T10:21:42Z"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-115"",
        ""free"": false,
        ""description"": ""desc-12"",
        ""service_guid"": ""ca2ea771-e155-4c53-b1b6-8a2de79f4072"",
        ""extra"": null,
        ""unique_id"": ""593e4665-edf5-4d6d-8513-9418874024df"",
        ""public"": true,
        ""active"": true,
        ""service_url"": ""/v2/services/ca2ea771-e155-4c53-b1b6-8a2de79f4072"",
        ""service_instances_url"": ""/v2/service_plans/cec871bb-0e1c-4fd9-a51e-e2ff76bca4c7/service_instances""
      }
    }
  ]
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();


                var obj = cfClient.ServicePlans.ListAllServicePlans().Result;

                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalResults), true);
                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalPages), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.PreviousUrl), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.NextUrl), true);
                Assert.AreEqual("cec871bb-0e1c-4fd9-a51e-e2ff76bca4c7", TestUtil.ToTestableString(obj[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plans/cec871bb-0e1c-4fd9-a51e-e2ff76bca4c7", TestUtil.ToTestableString(obj[0].EntityMetadata.Url), true);
                Assert.AreEqual("2016-02-09T10:21:42Z", TestUtil.ToTestableString(obj[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("name-115", TestUtil.ToTestableString(obj[0].Name), true);
                Assert.AreEqual("false", TestUtil.ToTestableString(obj[0].Free), true);
                Assert.AreEqual("desc-12", TestUtil.ToTestableString(obj[0].Description), true);
                Assert.AreEqual("ca2ea771-e155-4c53-b1b6-8a2de79f4072", TestUtil.ToTestableString(obj[0].ServiceGuid), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].Extra), true);
                Assert.AreEqual("593e4665-edf5-4d6d-8513-9418874024df", TestUtil.ToTestableString(obj[0].UniqueId), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj[0].Public), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj[0].Active), true);
                Assert.AreEqual("/v2/services/ca2ea771-e155-4c53-b1b6-8a2de79f4072", TestUtil.ToTestableString(obj[0].ServiceUrl), true);
                Assert.AreEqual("/v2/service_plans/cec871bb-0e1c-4fd9-a51e-e2ff76bca4c7/service_instances", TestUtil.ToTestableString(obj[0].ServiceInstancesUrl), true);

            }
        }

        [TestMethod]
        public void RetrieveServicePlanTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""metadata"": {
    ""guid"": ""b245ce87-5745-4ba4-85a6-62d85e75c550"",
    ""url"": ""/v2/service_plans/b245ce87-5745-4ba4-85a6-62d85e75c550"",
    ""created_at"": ""2016-02-09T10:21:42Z"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-113"",
    ""free"": false,
    ""description"": ""desc-10"",
    ""service_guid"": ""c10e4c6d-c39c-4c2f-a816-d71a5f2c90f5"",
    ""extra"": null,
    ""unique_id"": ""4a61d481-17a1-43e1-84f1-051e1373d8c0"",
    ""public"": true,
    ""active"": true,
    ""service_url"": ""/v2/services/c10e4c6d-c39c-4c2f-a816-d71a5f2c90f5"",
    ""service_instances_url"": ""/v2/service_plans/b245ce87-5745-4ba4-85a6-62d85e75c550/service_instances""
  }
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();


                var obj = cfClient.ServicePlans.RetrieveServicePlan(guid).Result;


                Assert.AreEqual("b245ce87-5745-4ba4-85a6-62d85e75c550", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plans/b245ce87-5745-4ba4-85a6-62d85e75c550", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
                Assert.AreEqual("2016-02-09T10:21:42Z", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("name-113", TestUtil.ToTestableString(obj.Name), true);
                Assert.AreEqual("false", TestUtil.ToTestableString(obj.Free), true);
                Assert.AreEqual("desc-10", TestUtil.ToTestableString(obj.Description), true);
                Assert.AreEqual("c10e4c6d-c39c-4c2f-a816-d71a5f2c90f5", TestUtil.ToTestableString(obj.ServiceGuid), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
                Assert.AreEqual("4a61d481-17a1-43e1-84f1-051e1373d8c0", TestUtil.ToTestableString(obj.UniqueId), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Public), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
                Assert.AreEqual("/v2/services/c10e4c6d-c39c-4c2f-a816-d71a5f2c90f5", TestUtil.ToTestableString(obj.ServiceUrl), true);
                Assert.AreEqual("/v2/service_plans/b245ce87-5745-4ba4-85a6-62d85e75c550/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);

            }
        }

        [TestMethod]
        public void ListAllServiceInstancesForServicePlanTest()
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
        ""guid"": ""81e9009a-bfa3-4d9a-a8df-0682da79f89f"",
        ""url"": ""/v2/service_instances/81e9009a-bfa3-4d9a-a8df-0682da79f89f"",
        ""created_at"": ""2016-02-09T10:21:42Z"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-108"",
        ""credentials"": {
          ""creds-key-47"": ""creds-val-47""
        },
        ""service_plan_guid"": ""1041e8da-47bc-49f1-8537-6a59997227e0"",
        ""space_guid"": ""655b2a47-08d8-4891-8bba-10e3668e1c67"",
        ""gateway_data"": null,
        ""dashboard_url"": null,
        ""type"": ""managed_service_instance"",
        ""last_operation"": null,
        ""space_url"": ""/v2/spaces/655b2a47-08d8-4891-8bba-10e3668e1c67"",
        ""service_plan_url"": ""/v2/service_plans/1041e8da-47bc-49f1-8537-6a59997227e0"",
        ""service_bindings_url"": ""/v2/service_instances/81e9009a-bfa3-4d9a-a8df-0682da79f89f/service_bindings""
      }
    }
  ]
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)200;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();


                var obj = cfClient.ServicePlans.ListAllServiceInstancesForServicePlan(guid).Result;

                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalResults), true);
                Assert.AreEqual("1", TestUtil.ToTestableString(obj.Properties.TotalPages), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.PreviousUrl), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Properties.NextUrl), true);
                Assert.AreEqual("81e9009a-bfa3-4d9a-a8df-0682da79f89f", TestUtil.ToTestableString(obj[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_instances/81e9009a-bfa3-4d9a-a8df-0682da79f89f", TestUtil.ToTestableString(obj[0].EntityMetadata.Url), true);
                Assert.AreEqual("2016-02-09T10:21:42Z", TestUtil.ToTestableString(obj[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("name-108", TestUtil.ToTestableString(obj[0].Name), true);
                Assert.AreEqual("1041e8da-47bc-49f1-8537-6a59997227e0", TestUtil.ToTestableString(obj[0].ServicePlanGuid), true);
                Assert.AreEqual("655b2a47-08d8-4891-8bba-10e3668e1c67", TestUtil.ToTestableString(obj[0].SpaceGuid), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].GatewayData), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].DashboardUrl), true);
                Assert.AreEqual("managed_service_instance", TestUtil.ToTestableString(obj[0].Type), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj[0].LastOperation), true);
                Assert.AreEqual("/v2/spaces/655b2a47-08d8-4891-8bba-10e3668e1c67", TestUtil.ToTestableString(obj[0].SpaceUrl), true);
                Assert.AreEqual("/v2/service_plans/1041e8da-47bc-49f1-8537-6a59997227e0", TestUtil.ToTestableString(obj[0].ServicePlanUrl), true);
                Assert.AreEqual("/v2/service_instances/81e9009a-bfa3-4d9a-a8df-0682da79f89f/service_bindings", TestUtil.ToTestableString(obj[0].ServiceBindingsUrl), true);

            }
        }

        [TestMethod]
        public void UpdateServicePlanDeprecatedTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""metadata"": {
    ""guid"": ""a80c2e55-e2e8-4981-ac01-e5ab7535b5fe"",
    ""url"": ""/v2/service_plans/a80c2e55-e2e8-4981-ac01-e5ab7535b5fe"",
    ""created_at"": ""2016-02-09T10:21:42Z"",
    ""updated_at"": ""2016-02-09T10:21:42Z""
  },
  ""entity"": {
    ""name"": ""100mb"",
    ""free"": true,
    ""description"": ""Let's you put data in your database!"",
    ""service_guid"": ""f8879a1c-4f4c-41e8-8753-405c7986abed"",
    ""extra"": null,
    ""unique_id"": ""a2e1410c-eae7-43db-af5f-8f74b5aa889e"",
    ""public"": true,
    ""active"": true,
    ""service_url"": ""/v2/services/f8879a1c-4f4c-41e8-8753-405c7986abed"",
    ""service_instances_url"": ""/v2/service_plans/a80c2e55-e2e8-4981-ac01-e5ab7535b5fe/service_instances""
  }
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)201;
                var cfClient = clients.CreateCloudFoundryClient();

                UpdateServicePlanDeprecatedRequest value = new UpdateServicePlanDeprecatedRequest();


                var obj = cfClient.ServicePlans.UpdateServicePlanDeprecated(value).Result;


                Assert.AreEqual("a80c2e55-e2e8-4981-ac01-e5ab7535b5fe", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plans/a80c2e55-e2e8-4981-ac01-e5ab7535b5fe", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
                Assert.AreEqual("2016-02-09T10:21:42Z", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
                Assert.AreEqual("2016-02-09T10:21:42Z", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("100mb", TestUtil.ToTestableString(obj.Name), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Free), true);
                Assert.AreEqual("Let's you put data in your database!", TestUtil.ToTestableString(obj.Description), true);
                Assert.AreEqual("f8879a1c-4f4c-41e8-8753-405c7986abed", TestUtil.ToTestableString(obj.ServiceGuid), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
                Assert.AreEqual("a2e1410c-eae7-43db-af5f-8f74b5aa889e", TestUtil.ToTestableString(obj.UniqueId), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Public), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
                Assert.AreEqual("/v2/services/f8879a1c-4f4c-41e8-8753-405c7986abed", TestUtil.ToTestableString(obj.ServiceUrl), true);
                Assert.AreEqual("/v2/service_plans/a80c2e55-e2e8-4981-ac01-e5ab7535b5fe/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);

            }
        }

        [TestMethod]
        public void DeleteServicePlansTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                clients.ExpectedStatusCode = (HttpStatusCode)204;
                var cfClient = clients.CreateCloudFoundryClient();

                Guid? guid = Guid.NewGuid();


                cfClient.ServicePlans.DeleteServicePlans(guid).Wait();

            }
        }

        [TestMethod]
        public void CreateServicePlanDeprecatedTest()
        {
            using (ShimsContext.Create())
            {
                MockClients clients = new MockClients();

                string json = @"{
  ""metadata"": {
    ""guid"": ""fd3f70a8-eaf1-4b46-a35a-652dbc3542ca"",
    ""url"": ""/v2/service_plans/fd3f70a8-eaf1-4b46-a35a-652dbc3542ca"",
    ""created_at"": ""2016-02-09T10:21:42Z"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""100mb"",
    ""free"": true,
    ""description"": ""Let's you put data in your database!"",
    ""service_guid"": ""2d03c09b-e0fb-4cd2-a47d-3392fe3663b7"",
    ""extra"": null,
    ""unique_id"": ""b9708803-b407-4934-a495-5cc7dec3cc62"",
    ""public"": true,
    ""active"": true,
    ""service_url"": ""/v2/services/2d03c09b-e0fb-4cd2-a47d-3392fe3663b7"",
    ""service_instances_url"": ""/v2/service_plans/fd3f70a8-eaf1-4b46-a35a-652dbc3542ca/service_instances""
  }
}";
                clients.JsonResponse = json;

                clients.ExpectedStatusCode = (HttpStatusCode)201;
                var cfClient = clients.CreateCloudFoundryClient();

                CreateServicePlanDeprecatedRequest value = new CreateServicePlanDeprecatedRequest();


                var obj = cfClient.ServicePlans.CreateServicePlanDeprecated(value).Result;


                Assert.AreEqual("fd3f70a8-eaf1-4b46-a35a-652dbc3542ca", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plans/fd3f70a8-eaf1-4b46-a35a-652dbc3542ca", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
                Assert.AreEqual("2016-02-09T10:21:42Z", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
                Assert.AreEqual("100mb", TestUtil.ToTestableString(obj.Name), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Free), true);
                Assert.AreEqual("Let's you put data in your database!", TestUtil.ToTestableString(obj.Description), true);
                Assert.AreEqual("2d03c09b-e0fb-4cd2-a47d-3392fe3663b7", TestUtil.ToTestableString(obj.ServiceGuid), true);
                Assert.AreEqual("", TestUtil.ToTestableString(obj.Extra), true);
                Assert.AreEqual("b9708803-b407-4934-a495-5cc7dec3cc62", TestUtil.ToTestableString(obj.UniqueId), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Public), true);
                Assert.AreEqual("true", TestUtil.ToTestableString(obj.Active), true);
                Assert.AreEqual("/v2/services/2d03c09b-e0fb-4cd2-a47d-3392fe3663b7", TestUtil.ToTestableString(obj.ServiceUrl), true);
                Assert.AreEqual("/v2/service_plans/fd3f70a8-eaf1-4b46-a35a-652dbc3542ca/service_instances", TestUtil.ToTestableString(obj.ServiceInstancesUrl), true);

            }
        }

    }
}