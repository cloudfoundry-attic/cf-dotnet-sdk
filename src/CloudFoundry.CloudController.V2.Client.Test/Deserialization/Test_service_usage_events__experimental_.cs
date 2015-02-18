using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class ServiceUsageEventsExperimentalTest
    {

    
        [TestMethod]
        public void TestListServiceUsageEventsResponse()
        {
            string json = @"{
  ""total_results"": 2,
  ""total_pages"": 2,
  ""prev_url"": null,
  ""next_url"": ""/v2/service_usage_events?after_guid=6929a1df-e83f-4995-83e5-e47c8e2a5691=asc=2=1"",
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""7d2bcf61-3b3e-4db9-8773-cfcc6b7c82c4"",
        ""url"": ""/v2/service_usage_events/7d2bcf61-3b3e-4db9-8773-cfcc6b7c82c4"",
        ""created_at"": ""2014-11-12T12:59:28+02:00""
      },
      ""entity"": {
        ""state"": ""CREATED"",
        ""org_guid"": ""guid-7f335cbe-2e34-4aab-a6dd-422f36532296"",
        ""space_guid"": ""guid-10443f79-89d0-40c3-a708-a54faec43e5d"",
        ""space_name"": ""name-418"",
        ""service_instance_guid"": ""guid-c5ad8b3f-cfed-4f9f-aca1-b77987eb0df7"",
        ""service_instance_name"": ""name-419"",
        ""service_instance_type"": ""type-8"",
        ""service_plan_guid"": ""guid-0cb74df5-77f8-401b-9d10-1630ca46cb04"",
        ""service_plan_name"": ""name-420"",
        ""service_guid"": ""guid-98d3b6ce-b716-42ef-b821-c6fc4d19ed76"",
        ""service_label"": ""label-39""
      }
    }
  ]
}";
    
            PagedResponse<ListServiceUsageEventsResponse> page = Util.DeserializePage<ListServiceUsageEventsResponse>(json);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("/v2/service_usage_events?after_guid=6929a1df-e83f-4995-83e5-e47c8e2a5691=asc=2=1", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("7d2bcf61-3b3e-4db9-8773-cfcc6b7c82c4", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_usage_events/7d2bcf61-3b3e-4db9-8773-cfcc6b7c82c4", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                  Assert.AreEqual("CREATED", TestUtil.ToTestableString(page[0].State), true);
                  Assert.AreEqual("guid-7f335cbe-2e34-4aab-a6dd-422f36532296", TestUtil.ToTestableString(page[0].OrgGuid), true);
                  Assert.AreEqual("guid-10443f79-89d0-40c3-a708-a54faec43e5d", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("name-418", TestUtil.ToTestableString(page[0].SpaceName), true);
                  Assert.AreEqual("guid-c5ad8b3f-cfed-4f9f-aca1-b77987eb0df7", TestUtil.ToTestableString(page[0].ServiceInstanceGuid), true);
                  Assert.AreEqual("name-419", TestUtil.ToTestableString(page[0].ServiceInstanceName), true);
                  Assert.AreEqual("type-8", TestUtil.ToTestableString(page[0].ServiceInstanceType), true);
                  Assert.AreEqual("guid-0cb74df5-77f8-401b-9d10-1630ca46cb04", TestUtil.ToTestableString(page[0].ServicePlanGuid), true);
                  Assert.AreEqual("name-420", TestUtil.ToTestableString(page[0].ServicePlanName), true);
                  Assert.AreEqual("guid-98d3b6ce-b716-42ef-b821-c6fc4d19ed76", TestUtil.ToTestableString(page[0].ServiceGuid), true);
                  Assert.AreEqual("label-39", TestUtil.ToTestableString(page[0].ServiceLabel), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveServiceUsageEventResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""eb8090cd-a746-4eed-9bae-40167006a2aa"",
    ""url"": ""/v2/service_usage_events/eb8090cd-a746-4eed-9bae-40167006a2aa"",
    ""created_at"": ""2014-11-12T12:59:28+02:00""
  },
  ""entity"": {
    ""state"": ""CREATED"",
    ""org_guid"": ""guid-23d8cdc6-072f-449d-9c0d-46c3f778b5a0"",
    ""space_guid"": ""guid-f21dbeed-8343-44bb-9b75-d0ce8842d4a4"",
    ""space_name"": ""name-406"",
    ""service_instance_guid"": ""guid-a11e1a4b-8dfa-4f14-b221-686c004b8488"",
    ""service_instance_name"": ""name-407"",
    ""service_instance_type"": ""type-4"",
    ""service_plan_guid"": ""guid-39a5a16e-a013-4571-8231-dbbefca0a59a"",
    ""service_plan_name"": ""name-408"",
    ""service_guid"": ""guid-c265f6e2-16b1-47a8-b330-1d63c6f2cd5c"",
    ""service_label"": ""label-35""
  }
}";
    
            RetrieveServiceUsageEventResponse obj = Util.DeserializeJson<RetrieveServiceUsageEventResponse>(json);
        
            Assert.AreEqual("eb8090cd-a746-4eed-9bae-40167006a2aa", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_usage_events/eb8090cd-a746-4eed-9bae-40167006a2aa", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("CREATED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("guid-23d8cdc6-072f-449d-9c0d-46c3f778b5a0", TestUtil.ToTestableString(obj.OrgGuid), true);
            Assert.AreEqual("guid-f21dbeed-8343-44bb-9b75-d0ce8842d4a4", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("name-406", TestUtil.ToTestableString(obj.SpaceName), true);
            Assert.AreEqual("guid-a11e1a4b-8dfa-4f14-b221-686c004b8488", TestUtil.ToTestableString(obj.ServiceInstanceGuid), true);
            Assert.AreEqual("name-407", TestUtil.ToTestableString(obj.ServiceInstanceName), true);
            Assert.AreEqual("type-4", TestUtil.ToTestableString(obj.ServiceInstanceType), true);
            Assert.AreEqual("guid-39a5a16e-a013-4571-8231-dbbefca0a59a", TestUtil.ToTestableString(obj.ServicePlanGuid), true);
            Assert.AreEqual("name-408", TestUtil.ToTestableString(obj.ServicePlanName), true);
            Assert.AreEqual("guid-c265f6e2-16b1-47a8-b330-1d63c6f2cd5c", TestUtil.ToTestableString(obj.ServiceGuid), true);
            Assert.AreEqual("label-35", TestUtil.ToTestableString(obj.ServiceLabel), true);
            
            
        }

    }
}
