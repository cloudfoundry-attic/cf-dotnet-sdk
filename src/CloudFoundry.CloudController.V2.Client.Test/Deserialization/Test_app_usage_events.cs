using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class AppUsageEventsTest
    {

    
        [TestMethod]
        public void TestListAllAppUsageEventsResponse()
        {
            string json = @"{
  ""total_results"": 2,
  ""total_pages"": 2,
  ""prev_url"": null,
  ""next_url"": ""/v2/app_usage_events?after_guid=d9554652-5ac2-4d7a-b400-57e84c46d808=asc=2=1"",
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""941cc763-da04-4c32-b8fc-e050355bb1a2"",
        ""url"": ""/v2/app_usage_events/941cc763-da04-4c32-b8fc-e050355bb1a2"",
        ""created_at"": ""2014-11-12T12:59:38+02:00""
      },
      ""entity"": {
        ""state"": ""STARTED"",
        ""memory_in_mb_per_instance"": 564,
        ""instance_count"": 1,
        ""app_guid"": ""guid-b86e9a9c-3c67-4ef7-adee-328d0fc77423"",
        ""app_name"": ""name-829"",
        ""space_guid"": ""guid-9a49950f-ed6a-4c22-8711-198bffcb9115"",
        ""space_name"": ""name-830"",
        ""org_guid"": ""guid-6874d4e1-30e8-451d-ad1e-9e83d032afd2"",
        ""buildpack_guid"": ""guid-4dacb110-9279-4a51-8823-046554ca3682"",
        ""buildpack_name"": ""name-831""
      }
    }
  ]
}";
    
            PagedResponse<ListAllAppUsageEventsResponse> page = Util.DeserializePage<ListAllAppUsageEventsResponse>(json);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("2", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("/v2/app_usage_events?after_guid=d9554652-5ac2-4d7a-b400-57e84c46d808=asc=2=1", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("941cc763-da04-4c32-b8fc-e050355bb1a2", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/app_usage_events/941cc763-da04-4c32-b8fc-e050355bb1a2", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                  Assert.AreEqual("STARTED", TestUtil.ToTestableString(page[0].State), true);
                  Assert.AreEqual("564", TestUtil.ToTestableString(page[0].MemoryInMbPerInstance), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[0].InstanceCount), true);
                  Assert.AreEqual("guid-b86e9a9c-3c67-4ef7-adee-328d0fc77423", TestUtil.ToTestableString(page[0].AppGuid), true);
                  Assert.AreEqual("name-829", TestUtil.ToTestableString(page[0].AppName), true);
                  Assert.AreEqual("guid-9a49950f-ed6a-4c22-8711-198bffcb9115", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("name-830", TestUtil.ToTestableString(page[0].SpaceName), true);
                  Assert.AreEqual("guid-6874d4e1-30e8-451d-ad1e-9e83d032afd2", TestUtil.ToTestableString(page[0].OrgGuid), true);
                  Assert.AreEqual("guid-4dacb110-9279-4a51-8823-046554ca3682", TestUtil.ToTestableString(page[0].BuildpackGuid), true);
                  Assert.AreEqual("name-831", TestUtil.ToTestableString(page[0].BuildpackName), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveAppUsageEventResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""93827094-14c2-4a71-911f-ef19d66131c3"",
    ""url"": ""/v2/app_usage_events/93827094-14c2-4a71-911f-ef19d66131c3"",
    ""created_at"": ""2014-11-12T12:59:38+02:00""
  },
  ""entity"": {
    ""state"": ""STARTED"",
    ""memory_in_mb_per_instance"": 564,
    ""instance_count"": 1,
    ""app_guid"": ""guid-281a3103-44ee-42af-9442-7b853558ddc1"",
    ""app_name"": ""name-817"",
    ""space_guid"": ""guid-43ac2e10-205d-464b-bd8d-79391a705f78"",
    ""space_name"": ""name-818"",
    ""org_guid"": ""guid-42b49a83-84e2-4774-a5cc-8105b267e437"",
    ""buildpack_guid"": ""guid-c7819b46-b169-485e-8e62-3a63f13d458a"",
    ""buildpack_name"": ""name-819""
  }
}";
    
            RetrieveAppUsageEventResponse obj = Util.DeserializeJson<RetrieveAppUsageEventResponse>(json);
        
            Assert.AreEqual("93827094-14c2-4a71-911f-ef19d66131c3", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/app_usage_events/93827094-14c2-4a71-911f-ef19d66131c3", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:38+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("STARTED", TestUtil.ToTestableString(obj.State), true);
            Assert.AreEqual("564", TestUtil.ToTestableString(obj.MemoryInMbPerInstance), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.InstanceCount), true);
            Assert.AreEqual("guid-281a3103-44ee-42af-9442-7b853558ddc1", TestUtil.ToTestableString(obj.AppGuid), true);
            Assert.AreEqual("name-817", TestUtil.ToTestableString(obj.AppName), true);
            Assert.AreEqual("guid-43ac2e10-205d-464b-bd8d-79391a705f78", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("name-818", TestUtil.ToTestableString(obj.SpaceName), true);
            Assert.AreEqual("guid-42b49a83-84e2-4774-a5cc-8105b267e437", TestUtil.ToTestableString(obj.OrgGuid), true);
            Assert.AreEqual("guid-c7819b46-b169-485e-8e62-3a63f13d458a", TestUtil.ToTestableString(obj.BuildpackGuid), true);
            Assert.AreEqual("name-819", TestUtil.ToTestableString(obj.BuildpackName), true);
            
            
        }

    }
}
