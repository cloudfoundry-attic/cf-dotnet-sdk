using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class SecurityGroupRunningDefaultsTest
    {

    
        [TestMethod]
        public void TestReturnSecurityGroupsUsedForRunningAppsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""d9c67fbb-ef74-4325-b276-2dbe2b544013"",
        ""url"": ""/v2/config/running_security_groups/d9c67fbb-ef74-4325-b276-2dbe2b544013"",
        ""created_at"": ""2014-11-12T12:59:43+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-1154"",
        ""rules"": [
          {
            ""protocol"": ""udp"",
            ""ports"": ""8080"",
            ""destination"": ""198.41.191.47/1""
          }
        ],
        ""running_default"": true,
        ""staging_default"": false
      }
    }
  ]
}";
    
            PagedResponse<ReturnSecurityGroupsUsedForRunningAppsResponse> page = Util.DeserializePage<ReturnSecurityGroupsUsedForRunningAppsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("d9c67fbb-ef74-4325-b276-2dbe2b544013", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/config/running_security_groups/d9c67fbb-ef74-4325-b276-2dbe2b544013", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1154", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].StagingDefault), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestSetSecurityGroupAsDefaultForRunningAppsResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""7574829c-0b9b-4bff-b41b-bef5f9fc4445"",
    ""url"": ""/v2/config/running_security_groups/7574829c-0b9b-4bff-b41b-bef5f9fc4445"",
    ""created_at"": ""2014-11-12T12:59:43+02:00"",
    ""updated_at"": ""2014-11-12T12:59:43+02:00""
  },
  ""entity"": {
    ""name"": ""name-1155"",
    ""rules"": [
      {
        ""protocol"": ""udp"",
        ""ports"": ""8080"",
        ""destination"": ""198.41.191.47/1""
      }
    ],
    ""running_default"": true,
    ""staging_default"": false
  }
}";
    
            SetSecurityGroupAsDefaultForRunningAppsResponse obj = Util.DeserializeJson<SetSecurityGroupAsDefaultForRunningAppsResponse>(json);
        
            Assert.AreEqual("7574829c-0b9b-4bff-b41b-bef5f9fc4445", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/config/running_security_groups/7574829c-0b9b-4bff-b41b-bef5f9fc4445", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1155", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.StagingDefault), true);
            
            
        }

    }
}
