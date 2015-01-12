using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class ServiceBindingsTest
    {

    
        [TestMethod]
        public void TestRetrieveServiceBindingResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""97d49b2f-4178-49cf-ae46-bcd71f091caf"",
    ""url"": ""/v2/service_bindings/97d49b2f-4178-49cf-ae46-bcd71f091caf"",
    ""created_at"": ""2014-11-12T12:59:33+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""app_guid"": ""76e9d753-2666-4a48-9fc8-219649f97a20"",
    ""service_instance_guid"": ""4ad46458-d7da-46ee-998e-a6b5049bdf29"",
    ""credentials"": {
      ""creds-key-239"": ""creds-val-239""
    },
    ""binding_options"": {

    },
    ""gateway_data"": null,
    ""gateway_name"": """",
    ""syslog_drain_url"": null,
    ""app_url"": ""/v2/apps/76e9d753-2666-4a48-9fc8-219649f97a20"",
    ""service_instance_url"": ""/v2/service_instances/4ad46458-d7da-46ee-998e-a6b5049bdf29""
  }
}";
    
            RetrieveServiceBindingResponse obj = Util.DeserializeJson<RetrieveServiceBindingResponse>(json);
        
            Assert.AreEqual("97d49b2f-4178-49cf-ae46-bcd71f091caf", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_bindings/97d49b2f-4178-49cf-ae46-bcd71f091caf", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("76e9d753-2666-4a48-9fc8-219649f97a20", TestUtil.ToTestableString(obj.AppGuid), true);
            Assert.AreEqual("4ad46458-d7da-46ee-998e-a6b5049bdf29", TestUtil.ToTestableString(obj.ServiceInstanceGuid), true);
            
            
            Assert.AreEqual("", TestUtil.ToTestableString(obj.GatewayData), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.GatewayName), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SyslogDrainUrl), true);
            Assert.AreEqual("/v2/apps/76e9d753-2666-4a48-9fc8-219649f97a20", TestUtil.ToTestableString(obj.AppUrl), true);
            Assert.AreEqual("/v2/service_instances/4ad46458-d7da-46ee-998e-a6b5049bdf29", TestUtil.ToTestableString(obj.ServiceInstanceUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllServiceBindingsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""85e9c65c-d061-45c8-baef-9d4299bac76e"",
        ""url"": ""/v2/service_bindings/85e9c65c-d061-45c8-baef-9d4299bac76e"",
        ""created_at"": ""2014-11-12T12:59:32+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""app_guid"": ""2076da6a-a95a-48af-a9df-47dfab61ca93"",
        ""service_instance_guid"": ""c9ad7bb7-6099-46c4-9675-efb17240c5db"",
        ""credentials"": {
          ""creds-key-226"": ""creds-val-226""
        },
        ""binding_options"": {

        },
        ""gateway_data"": null,
        ""gateway_name"": """",
        ""syslog_drain_url"": null,
        ""app_url"": ""/v2/apps/2076da6a-a95a-48af-a9df-47dfab61ca93"",
        ""service_instance_url"": ""/v2/service_instances/c9ad7bb7-6099-46c4-9675-efb17240c5db""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceBindingsResponse> page = Util.DeserializePage<ListAllServiceBindingsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("85e9c65c-d061-45c8-baef-9d4299bac76e", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_bindings/85e9c65c-d061-45c8-baef-9d4299bac76e", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:32+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("2076da6a-a95a-48af-a9df-47dfab61ca93", TestUtil.ToTestableString(page[0].AppGuid), true);
                  Assert.AreEqual("c9ad7bb7-6099-46c4-9675-efb17240c5db", TestUtil.ToTestableString(page[0].ServiceInstanceGuid), true);
                  
                  
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayData), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].GatewayName), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SyslogDrainUrl), true);
                  Assert.AreEqual("/v2/apps/2076da6a-a95a-48af-a9df-47dfab61ca93", TestUtil.ToTestableString(page[0].AppUrl), true);
                  Assert.AreEqual("/v2/service_instances/c9ad7bb7-6099-46c4-9675-efb17240c5db", TestUtil.ToTestableString(page[0].ServiceInstanceUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreateServiceBindingRequest()
        {
            string json = @"{
  ""service_instance_guid"": ""b172309e-2870-4d22-a633-01469a83a40f"",
  ""app_guid"": ""46215bdf-03c6-41fb-a8e7-63ae457a80f1""
}";
    
            CreateServiceBindingRequest obj = Util.DeserializeJson<CreateServiceBindingRequest>(json);
        
            Assert.AreEqual("b172309e-2870-4d22-a633-01469a83a40f", TestUtil.ToTestableString(obj.ServiceInstanceGuid), true);
            Assert.AreEqual("46215bdf-03c6-41fb-a8e7-63ae457a80f1", TestUtil.ToTestableString(obj.AppGuid), true);
        }

    
        [TestMethod]
        public void TestCreateServiceBindingResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""80e1d606-e3c9-490e-8411-ac46d318a0a9"",
    ""url"": ""/v2/service_bindings/80e1d606-e3c9-490e-8411-ac46d318a0a9"",
    ""created_at"": ""2014-11-12T12:59:32+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""app_guid"": ""46215bdf-03c6-41fb-a8e7-63ae457a80f1"",
    ""service_instance_guid"": ""b172309e-2870-4d22-a633-01469a83a40f"",
    ""credentials"": {
      ""creds-key-232"": ""creds-val-232""
    },
    ""binding_options"": {

    },
    ""gateway_data"": null,
    ""gateway_name"": """",
    ""syslog_drain_url"": null,
    ""app_url"": ""/v2/apps/46215bdf-03c6-41fb-a8e7-63ae457a80f1"",
    ""service_instance_url"": ""/v2/user_provided_service_instances/b172309e-2870-4d22-a633-01469a83a40f""
  }
}";
    
            CreateServiceBindingResponse obj = Util.DeserializeJson<CreateServiceBindingResponse>(json);
        
            Assert.AreEqual("80e1d606-e3c9-490e-8411-ac46d318a0a9", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_bindings/80e1d606-e3c9-490e-8411-ac46d318a0a9", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:32+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("46215bdf-03c6-41fb-a8e7-63ae457a80f1", TestUtil.ToTestableString(obj.AppGuid), true);
            Assert.AreEqual("b172309e-2870-4d22-a633-01469a83a40f", TestUtil.ToTestableString(obj.ServiceInstanceGuid), true);
            
            
            Assert.AreEqual("", TestUtil.ToTestableString(obj.GatewayData), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.GatewayName), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.SyslogDrainUrl), true);
            Assert.AreEqual("/v2/apps/46215bdf-03c6-41fb-a8e7-63ae457a80f1", TestUtil.ToTestableString(obj.AppUrl), true);
            Assert.AreEqual("/v2/user_provided_service_instances/b172309e-2870-4d22-a633-01469a83a40f", TestUtil.ToTestableString(obj.ServiceInstanceUrl), true);
            
            
        }

    }
}
