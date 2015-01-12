using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class UserProvidedServiceInstancesTest
    {

    
        [TestMethod]
        public void TestUpdateUserProvidedServiceInstanceRequest()
        {
            string json = @"{
  ""credentials"": {
    ""somekey"": ""somenewvalue""
  }
}";
    
            UpdateUserProvidedServiceInstanceRequest obj = Util.DeserializeJson<UpdateUserProvidedServiceInstanceRequest>(json);
        
            
        }

    
        [TestMethod]
        public void TestUpdateUserProvidedServiceInstanceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""9c86058c-8fb6-47d8-ab17-7f15fcc871b8"",
    ""url"": ""/v2/user_provided_service_instances/9c86058c-8fb6-47d8-ab17-7f15fcc871b8"",
    ""created_at"": ""2014-11-12T12:59:27+02:00"",
    ""updated_at"": ""2014-11-12T12:59:27+02:00""
  },
  ""entity"": {
    ""name"": ""name-368"",
    ""credentials"": {
      ""somekey"": ""somenewvalue""
    },
    ""space_guid"": ""3ee03e15-768f-4986-b345-d1b57a9d4a0d"",
    ""type"": ""user_provided_service_instance"",
    ""syslog_drain_url"": ""https://foo.com/url-17"",
    ""space_url"": ""/v2/spaces/3ee03e15-768f-4986-b345-d1b57a9d4a0d"",
    ""service_bindings_url"": ""/v2/user_provided_service_instances/9c86058c-8fb6-47d8-ab17-7f15fcc871b8/service_bindings""
  }
}";
    
            UpdateUserProvidedServiceInstanceResponse obj = Util.DeserializeJson<UpdateUserProvidedServiceInstanceResponse>(json);
        
            Assert.AreEqual("9c86058c-8fb6-47d8-ab17-7f15fcc871b8", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/user_provided_service_instances/9c86058c-8fb6-47d8-ab17-7f15fcc871b8", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-368", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("3ee03e15-768f-4986-b345-d1b57a9d4a0d", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("user_provided_service_instance", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("https://foo.com/url-17", TestUtil.ToTestableString(obj.SyslogDrainUrl), true);
            Assert.AreEqual("/v2/spaces/3ee03e15-768f-4986-b345-d1b57a9d4a0d", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/user_provided_service_instances/9c86058c-8fb6-47d8-ab17-7f15fcc871b8/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveUserProvidedServiceInstanceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""a32fe5fb-f12b-45a7-977c-7fa8c18b1b03"",
    ""url"": ""/v2/user_provided_service_instances/a32fe5fb-f12b-45a7-977c-7fa8c18b1b03"",
    ""created_at"": ""2014-11-12T12:59:28+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-387"",
    ""credentials"": {
      ""creds-key-148"": ""creds-val-148""
    },
    ""space_guid"": ""a1d01712-9036-4281-85c4-0e6eb8e323da"",
    ""type"": ""user_provided_service_instance"",
    ""syslog_drain_url"": ""https://foo.com/url-21"",
    ""space_url"": ""/v2/spaces/a1d01712-9036-4281-85c4-0e6eb8e323da"",
    ""service_bindings_url"": ""/v2/user_provided_service_instances/a32fe5fb-f12b-45a7-977c-7fa8c18b1b03/service_bindings""
  }
}";
    
            RetrieveUserProvidedServiceInstanceResponse obj = Util.DeserializeJson<RetrieveUserProvidedServiceInstanceResponse>(json);
        
            Assert.AreEqual("a32fe5fb-f12b-45a7-977c-7fa8c18b1b03", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/user_provided_service_instances/a32fe5fb-f12b-45a7-977c-7fa8c18b1b03", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-387", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("a1d01712-9036-4281-85c4-0e6eb8e323da", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("user_provided_service_instance", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("https://foo.com/url-21", TestUtil.ToTestableString(obj.SyslogDrainUrl), true);
            Assert.AreEqual("/v2/spaces/a1d01712-9036-4281-85c4-0e6eb8e323da", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/user_provided_service_instances/a32fe5fb-f12b-45a7-977c-7fa8c18b1b03/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServiceBindingsForUserProvidedServiceInstanceResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""cd529ad9-a294-4dc1-91d3-514f3ca97f3c"",
        ""url"": ""/v2/service_bindings/cd529ad9-a294-4dc1-91d3-514f3ca97f3c"",
        ""created_at"": ""2014-11-12T12:59:28+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""app_guid"": ""eb4b8694-f5db-4df7-aa18-693255934f17"",
        ""service_instance_guid"": ""378448ae-ad17-472b-ab67-7391708e8e7e"",
        ""credentials"": {
          ""creds-key-152"": ""creds-val-152""
        },
        ""binding_options"": {

        },
        ""gateway_data"": null,
        ""gateway_name"": """",
        ""syslog_drain_url"": null,
        ""app_url"": ""/v2/apps/eb4b8694-f5db-4df7-aa18-693255934f17"",
        ""service_instance_url"": ""/v2/user_provided_service_instances/378448ae-ad17-472b-ab67-7391708e8e7e""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceBindingsForUserProvidedServiceInstanceResponse> page = Util.DeserializePage<ListAllServiceBindingsForUserProvidedServiceInstanceResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("cd529ad9-a294-4dc1-91d3-514f3ca97f3c", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_bindings/cd529ad9-a294-4dc1-91d3-514f3ca97f3c", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("eb4b8694-f5db-4df7-aa18-693255934f17", TestUtil.ToTestableString(page[0].AppGuid), true);
                  Assert.AreEqual("378448ae-ad17-472b-ab67-7391708e8e7e", TestUtil.ToTestableString(page[0].ServiceInstanceGuid), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayName), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SyslogDrainUrl), true);
                  Assert.AreEqual("/v2/apps/eb4b8694-f5db-4df7-aa18-693255934f17", TestUtil.ToTestableString(page[0].AppUrl), true);
                  Assert.AreEqual("/v2/user_provided_service_instances/378448ae-ad17-472b-ab67-7391708e8e7e", TestUtil.ToTestableString(page[0].ServiceInstanceUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreateUserProvidedServiceInstanceRequest()
        {
            string json = @"{
  ""space_guid"": ""bf4f67a6-9508-4377-a676-987238f30654"",
  ""name"": ""my-user-provided-instance"",
  ""credentials"": {
    ""somekey"": ""somevalue""
  },
  ""syslog_drain_url"": ""syslog://example.com""
}";
    
            CreateUserProvidedServiceInstanceRequest obj = Util.DeserializeJson<CreateUserProvidedServiceInstanceRequest>(json);
        
            Assert.AreEqual("bf4f67a6-9508-4377-a676-987238f30654", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("my-user-provided-instance", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("syslog://example.com", TestUtil.ToTestableString(obj.SyslogDrainUrl), true);
        }

    
        [TestMethod]
        public void TestCreateUserProvidedServiceInstanceResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""4d4a4498-4a06-4ae6-b84c-c37dd24c7a40"",
    ""url"": ""/v2/user_provided_service_instances/4d4a4498-4a06-4ae6-b84c-c37dd24c7a40"",
    ""created_at"": ""2014-11-12T12:59:27+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""my-user-provided-instance"",
    ""credentials"": {
      ""somekey"": ""somevalue""
    },
    ""space_guid"": ""bf4f67a6-9508-4377-a676-987238f30654"",
    ""type"": ""user_provided_service_instance"",
    ""syslog_drain_url"": ""syslog://example.com"",
    ""space_url"": ""/v2/spaces/bf4f67a6-9508-4377-a676-987238f30654"",
    ""service_bindings_url"": ""/v2/user_provided_service_instances/4d4a4498-4a06-4ae6-b84c-c37dd24c7a40/service_bindings""
  }
}";
    
            CreateUserProvidedServiceInstanceResponse obj = Util.DeserializeJson<CreateUserProvidedServiceInstanceResponse>(json);
        
            Assert.AreEqual("4d4a4498-4a06-4ae6-b84c-c37dd24c7a40", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/user_provided_service_instances/4d4a4498-4a06-4ae6-b84c-c37dd24c7a40", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("my-user-provided-instance", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("bf4f67a6-9508-4377-a676-987238f30654", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("user_provided_service_instance", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("syslog://example.com", TestUtil.ToTestableString(obj.SyslogDrainUrl), true);
            Assert.AreEqual("/v2/spaces/bf4f67a6-9508-4377-a676-987238f30654", TestUtil.ToTestableString(obj.SpaceUrl), true);
            Assert.AreEqual("/v2/user_provided_service_instances/4d4a4498-4a06-4ae6-b84c-c37dd24c7a40/service_bindings", TestUtil.ToTestableString(obj.ServiceBindingsUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllUserProvidedServiceInstancesResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""8dfb8eac-f596-4aff-b370-2bc1bc5de0cc"",
        ""url"": ""/v2/user_provided_service_instances/8dfb8eac-f596-4aff-b370-2bc1bc5de0cc"",
        ""created_at"": ""2014-11-12T12:59:27+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-372"",
        ""credentials"": {
          ""creds-key-139"": ""creds-val-139""
        },
        ""space_guid"": ""8903be55-1cb1-4fed-a073-97c34298e5c6"",
        ""type"": ""user_provided_service_instance"",
        ""syslog_drain_url"": ""https://foo.com/url-18"",
        ""space_url"": ""/v2/spaces/8903be55-1cb1-4fed-a073-97c34298e5c6"",
        ""service_bindings_url"": ""/v2/user_provided_service_instances/8dfb8eac-f596-4aff-b370-2bc1bc5de0cc/service_bindings""
      }
    }
  ]
}";
    
            PagedResponse<ListAllUserProvidedServiceInstancesResponse> page = Util.DeserializePage<ListAllUserProvidedServiceInstancesResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("8dfb8eac-f596-4aff-b370-2bc1bc5de0cc", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/user_provided_service_instances/8dfb8eac-f596-4aff-b370-2bc1bc5de0cc", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:27+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-372", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("8903be55-1cb1-4fed-a073-97c34298e5c6", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("user_provided_service_instance", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("https://foo.com/url-18", TestUtil.ToTestableString(page[0].SyslogDrainUrl), true);
                  Assert.AreEqual("/v2/spaces/8903be55-1cb1-4fed-a073-97c34298e5c6", TestUtil.ToTestableString(page[0].SpaceUrl), true);
                  Assert.AreEqual("/v2/user_provided_service_instances/8dfb8eac-f596-4aff-b370-2bc1bc5de0cc/service_bindings", TestUtil.ToTestableString(page[0].ServiceBindingsUrl), true);
               
               
            
    
        }

    }
}
