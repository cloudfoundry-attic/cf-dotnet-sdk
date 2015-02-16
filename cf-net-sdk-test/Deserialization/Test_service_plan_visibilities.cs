using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class ServicePlanVisibilitiesTest
    {

    
        [TestMethod]
        public void TestListAllServicePlanVisibilitiesResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""e06eaaa5-1343-4937-a69a-aa69ab537830"",
        ""url"": ""/v2/service_plan_visibilities/e06eaaa5-1343-4937-a69a-aa69ab537830"",
        ""created_at"": ""2014-11-12T12:59:44+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""service_plan_guid"": ""1baeddb7-bc65-4514-b362-cbc0c3576fb3"",
        ""organization_guid"": ""c2bfdc7e-271e-47bc-ae6a-246f64ac3218"",
        ""service_plan_url"": ""/v2/service_plans/1baeddb7-bc65-4514-b362-cbc0c3576fb3"",
        ""organization_url"": ""/v2/organizations/c2bfdc7e-271e-47bc-ae6a-246f64ac3218""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServicePlanVisibilitiesResponse> page = Util.DeserializePage<ListAllServicePlanVisibilitiesResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("e06eaaa5-1343-4937-a69a-aa69ab537830", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_plan_visibilities/e06eaaa5-1343-4937-a69a-aa69ab537830", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("1baeddb7-bc65-4514-b362-cbc0c3576fb3", TestUtil.ToTestableString(page[0].ServicePlanGuid), true);
                  Assert.AreEqual("c2bfdc7e-271e-47bc-ae6a-246f64ac3218", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("/v2/service_plans/1baeddb7-bc65-4514-b362-cbc0c3576fb3", TestUtil.ToTestableString(page[0].ServicePlanUrl), true);
                  Assert.AreEqual("/v2/organizations/c2bfdc7e-271e-47bc-ae6a-246f64ac3218", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestUpdateServicePlanVisibilityResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""bf1fd2e7-1b43-44f2-914f-06935d3124cb"",
    ""url"": ""/v2/service_plan_visibilities/bf1fd2e7-1b43-44f2-914f-06935d3124cb"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""updated_at"": ""2014-11-12T12:59:44+02:00""
  },
  ""entity"": {
    ""service_plan_guid"": ""f5e79b16-edf4-443f-87ef-7f128bfdcde3"",
    ""organization_guid"": ""fe3e4b18-394e-48bb-9442-cc1e85cfcf61"",
    ""service_plan_url"": ""/v2/service_plans/f5e79b16-edf4-443f-87ef-7f128bfdcde3"",
    ""organization_url"": ""/v2/organizations/fe3e4b18-394e-48bb-9442-cc1e85cfcf61""
  }
}";
    
            UpdateServicePlanVisibilityResponse obj = Util.DeserializeJson<UpdateServicePlanVisibilityResponse>(json);
        
            Assert.AreEqual("bf1fd2e7-1b43-44f2-914f-06935d3124cb", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_plan_visibilities/bf1fd2e7-1b43-44f2-914f-06935d3124cb", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("f5e79b16-edf4-443f-87ef-7f128bfdcde3", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("fe3e4b18-394e-48bb-9442-cc1e85cfcf61", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("/v2/service_plans/f5e79b16-edf4-443f-87ef-7f128bfdcde3", TestUtil.ToTestableString(obj.ServicePlanUrl), true);
            Assert.AreEqual("/v2/organizations/fe3e4b18-394e-48bb-9442-cc1e85cfcf61", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveServicePlanVisibilityResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""8d1648bd-d3ca-4918-baf4-18ce87ab90fd"",
    ""url"": ""/v2/service_plan_visibilities/8d1648bd-d3ca-4918-baf4-18ce87ab90fd"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""service_plan_guid"": ""62a4e2ae-340a-4989-a407-03dbda88e63a"",
    ""organization_guid"": ""4e331dcc-b77e-42ea-88c4-b8e664575461"",
    ""service_plan_url"": ""/v2/service_plans/62a4e2ae-340a-4989-a407-03dbda88e63a"",
    ""organization_url"": ""/v2/organizations/4e331dcc-b77e-42ea-88c4-b8e664575461""
  }
}";
    
            RetrieveServicePlanVisibilityResponse obj = Util.DeserializeJson<RetrieveServicePlanVisibilityResponse>(json);
        
            Assert.AreEqual("8d1648bd-d3ca-4918-baf4-18ce87ab90fd", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_plan_visibilities/8d1648bd-d3ca-4918-baf4-18ce87ab90fd", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("62a4e2ae-340a-4989-a407-03dbda88e63a", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("4e331dcc-b77e-42ea-88c4-b8e664575461", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("/v2/service_plans/62a4e2ae-340a-4989-a407-03dbda88e63a", TestUtil.ToTestableString(obj.ServicePlanUrl), true);
            Assert.AreEqual("/v2/organizations/4e331dcc-b77e-42ea-88c4-b8e664575461", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateServicePlanVisibilityResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""a0078840-0b41-4c62-aa4f-bfce658784bb"",
    ""url"": ""/v2/service_plan_visibilities/a0078840-0b41-4c62-aa4f-bfce658784bb"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""service_plan_guid"": ""aeb83366-300a-451e-a885-c6edd065fd5e"",
    ""organization_guid"": ""cb7e7f18-1dec-4503-956b-60524c5da57d"",
    ""service_plan_url"": ""/v2/service_plans/aeb83366-300a-451e-a885-c6edd065fd5e"",
    ""organization_url"": ""/v2/organizations/cb7e7f18-1dec-4503-956b-60524c5da57d""
  }
}";
    
            CreateServicePlanVisibilityResponse obj = Util.DeserializeJson<CreateServicePlanVisibilityResponse>(json);
        
            Assert.AreEqual("a0078840-0b41-4c62-aa4f-bfce658784bb", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_plan_visibilities/a0078840-0b41-4c62-aa4f-bfce658784bb", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("aeb83366-300a-451e-a885-c6edd065fd5e", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("cb7e7f18-1dec-4503-956b-60524c5da57d", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            Assert.AreEqual("/v2/service_plans/aeb83366-300a-451e-a885-c6edd065fd5e", TestUtil.ToTestableString(obj.ServicePlanUrl), true);
            Assert.AreEqual("/v2/organizations/cb7e7f18-1dec-4503-956b-60524c5da57d", TestUtil.ToTestableString(obj.OrganizationUrl), true);
            
            
        }

    }
}
