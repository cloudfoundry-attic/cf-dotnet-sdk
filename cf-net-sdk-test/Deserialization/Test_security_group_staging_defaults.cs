using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class SecurityGroupStagingDefaultsTest
    {

    
        [TestMethod]
        public void TestReturnSecurityGroupsUsedForStagingResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""6fbb9d20-a689-4fd1-a989-089269875cfe"",
        ""url"": ""/v2/config/staging_security_groups/6fbb9d20-a689-4fd1-a989-089269875cfe"",
        ""created_at"": ""2014-11-12T12:59:43+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-1160"",
        ""rules"": [
          {
            ""protocol"": ""udp"",
            ""ports"": ""8080"",
            ""destination"": ""198.41.191.47/1""
          }
        ],
        ""running_default"": false,
        ""staging_default"": true
      }
    }
  ]
}";
    
            PagedResponse<ReturnSecurityGroupsUsedForStagingResponse> page = Util.DeserializePage<ReturnSecurityGroupsUsedForStagingResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("6fbb9d20-a689-4fd1-a989-089269875cfe", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/config/staging_security_groups/6fbb9d20-a689-4fd1-a989-089269875cfe", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1160", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].RunningDefault), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].StagingDefault), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestSetSecurityGroupAsDefaultForStagingResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""64b8f5f6-5fd2-4cb5-a202-f753cae1ff51"",
    ""url"": ""/v2/config/staging_security_groups/64b8f5f6-5fd2-4cb5-a202-f753cae1ff51"",
    ""created_at"": ""2014-11-12T12:59:43+02:00"",
    ""updated_at"": ""2014-11-12T12:59:43+02:00""
  },
  ""entity"": {
    ""name"": ""name-1161"",
    ""rules"": [
      {
        ""protocol"": ""udp"",
        ""ports"": ""8080"",
        ""destination"": ""198.41.191.47/1""
      }
    ],
    ""running_default"": false,
    ""staging_default"": true
  }
}";
    
            SetSecurityGroupAsDefaultForStagingResponse obj = Util.DeserializeJson<SetSecurityGroupAsDefaultForStagingResponse>(json);
        
            Assert.AreEqual("64b8f5f6-5fd2-4cb5-a202-f753cae1ff51", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/config/staging_security_groups/64b8f5f6-5fd2-4cb5-a202-f753cae1ff51", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1161", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.StagingDefault), true);
            
            
        }

    }
}
