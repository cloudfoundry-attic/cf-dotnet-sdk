using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class SecurityGroupsTest
    {

    
        [TestMethod]
        public void TestListAllSpacesForSecurityGroupResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb"",
        ""url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb"",
        ""created_at"": ""2014-11-12T12:59:31+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-502"",
        ""organization_guid"": ""36cdb2e2-2330-438e-93d2-72890aed24ee"",
        ""space_quota_definition_guid"": null,
        ""organization_url"": ""/v2/organizations/36cdb2e2-2330-438e-93d2-72890aed24ee"",
        ""developers_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/developers"",
        ""managers_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/managers"",
        ""auditors_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/auditors"",
        ""apps_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/apps"",
        ""routes_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/routes"",
        ""domains_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/domains"",
        ""service_instances_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/service_instances"",
        ""app_events_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/app_events"",
        ""events_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/events"",
        ""security_groups_url"": ""/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/security_groups""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSpacesForSecurityGroupResponse> page = Util.DeserializePage<ListAllSpacesForSecurityGroupResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:31+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-502", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("36cdb2e2-2330-438e-93d2-72890aed24ee", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
                  Assert.AreEqual("", TestUtil.ToTestableString(page[0].SpaceQuotaDefinitionGuid), true);
                  Assert.AreEqual("/v2/organizations/36cdb2e2-2330-438e-93d2-72890aed24ee", TestUtil.ToTestableString(page[0].OrganizationUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/developers", TestUtil.ToTestableString(page[0].DevelopersUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/managers", TestUtil.ToTestableString(page[0].ManagersUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/auditors", TestUtil.ToTestableString(page[0].AuditorsUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/apps", TestUtil.ToTestableString(page[0].AppsUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/routes", TestUtil.ToTestableString(page[0].RoutesUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/domains", TestUtil.ToTestableString(page[0].DomainsUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/service_instances", TestUtil.ToTestableString(page[0].ServiceInstancesUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/app_events", TestUtil.ToTestableString(page[0].AppEventsUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/events", TestUtil.ToTestableString(page[0].EventsUrl), true);
                  Assert.AreEqual("/v2/spaces/8c928e87-a99e-440c-a6fb-e2fe5fd9e9bb/security_groups", TestUtil.ToTestableString(page[0].SecurityGroupsUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestAssociateSpaceWithSecurityGroupResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""created_at"": ""2014-11-12T12:59:28+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""dummy1"",
    ""rules"": [

    ],
    ""running_default"": false,
    ""staging_default"": false,
    ""spaces_url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces""
  }
}";
    
            AssociateSpaceWithSecurityGroupResponse obj = Util.DeserializeJson<AssociateSpaceWithSecurityGroupResponse>(json);
        
            Assert.AreEqual("cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("dummy1", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.StagingDefault), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRemoveSpaceFromSecurityGroupResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""created_at"": ""2014-11-12T12:59:28+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""dummy1"",
    ""rules"": [

    ],
    ""running_default"": false,
    ""staging_default"": false,
    ""spaces_url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces""
  }
}";
    
            RemoveSpaceFromSecurityGroupResponse obj = Util.DeserializeJson<RemoveSpaceFromSecurityGroupResponse>(json);
        
            Assert.AreEqual("cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("dummy1", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.StagingDefault), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllSecurityGroupsResponse()
        {
            string json = @"{
  ""total_results"": 5,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""cc49e277-b403-4a52-bedc-df1ce3403b0e"",
        ""url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e"",
        ""created_at"": ""2014-11-12T12:59:28+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""dummy1"",
        ""rules"": [

        ],
        ""running_default"": false,
        ""staging_default"": false,
        ""spaces_url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""e2fba53c-8219-4941-98ff-1a7313605859"",
        ""url"": ""/v2/security_groups/e2fba53c-8219-4941-98ff-1a7313605859"",
        ""created_at"": ""2014-11-12T12:59:28+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""dummy2"",
        ""rules"": [

        ],
        ""running_default"": false,
        ""staging_default"": false,
        ""spaces_url"": ""/v2/security_groups/e2fba53c-8219-4941-98ff-1a7313605859/spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""4a062a1d-9994-4128-97b3-9af62d139689"",
        ""url"": ""/v2/security_groups/4a062a1d-9994-4128-97b3-9af62d139689"",
        ""created_at"": ""2014-11-12T12:59:30+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-487"",
        ""rules"": [
          {
            ""protocol"": ""udp"",
            ""ports"": ""8080"",
            ""destination"": ""198.41.191.47/1""
          }
        ],
        ""running_default"": false,
        ""staging_default"": false,
        ""spaces_url"": ""/v2/security_groups/4a062a1d-9994-4128-97b3-9af62d139689/spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""333347a6-e488-4840-a7e1-e5c2903ad63c"",
        ""url"": ""/v2/security_groups/333347a6-e488-4840-a7e1-e5c2903ad63c"",
        ""created_at"": ""2014-11-12T12:59:30+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-488"",
        ""rules"": [
          {
            ""protocol"": ""udp"",
            ""ports"": ""8080"",
            ""destination"": ""198.41.191.47/1""
          }
        ],
        ""running_default"": false,
        ""staging_default"": false,
        ""spaces_url"": ""/v2/security_groups/333347a6-e488-4840-a7e1-e5c2903ad63c/spaces""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""7255dbdd-38b7-47bc-967f-41d7475d261b"",
        ""url"": ""/v2/security_groups/7255dbdd-38b7-47bc-967f-41d7475d261b"",
        ""created_at"": ""2014-11-12T12:59:30+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-489"",
        ""rules"": [
          {
            ""protocol"": ""udp"",
            ""ports"": ""8080"",
            ""destination"": ""198.41.191.47/1""
          }
        ],
        ""running_default"": false,
        ""staging_default"": false,
        ""spaces_url"": ""/v2/security_groups/7255dbdd-38b7-47bc-967f-41d7475d261b/spaces""
      }
    }
  ]
}";
    
            PagedResponse<ListAllSecurityGroupsResponse> page = Util.DeserializePage<ListAllSecurityGroupsResponse>(json);
        
            Assert.AreEqual("5", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("dummy1", TestUtil.ToTestableString(page[0].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].StagingDefault), true);
                  Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces", TestUtil.ToTestableString(page[0].SpacesUrl), true);
               
               
            
            
                Assert.AreEqual("e2fba53c-8219-4941-98ff-1a7313605859", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/security_groups/e2fba53c-8219-4941-98ff-1a7313605859", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("dummy2", TestUtil.ToTestableString(page[1].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].StagingDefault), true);
                  Assert.AreEqual("/v2/security_groups/e2fba53c-8219-4941-98ff-1a7313605859/spaces", TestUtil.ToTestableString(page[1].SpacesUrl), true);
               
               
            
            
                Assert.AreEqual("4a062a1d-9994-4128-97b3-9af62d139689", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/security_groups/4a062a1d-9994-4128-97b3-9af62d139689", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:30+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-487", TestUtil.ToTestableString(page[2].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[2].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[2].StagingDefault), true);
                  Assert.AreEqual("/v2/security_groups/4a062a1d-9994-4128-97b3-9af62d139689/spaces", TestUtil.ToTestableString(page[2].SpacesUrl), true);
               
               
            
            
                Assert.AreEqual("333347a6-e488-4840-a7e1-e5c2903ad63c", TestUtil.ToTestableString(page[3].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/security_groups/333347a6-e488-4840-a7e1-e5c2903ad63c", TestUtil.ToTestableString(page[3].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:30+02:00", TestUtil.ToTestableString(page[3].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[3].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-488", TestUtil.ToTestableString(page[3].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[3].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[3].StagingDefault), true);
                  Assert.AreEqual("/v2/security_groups/333347a6-e488-4840-a7e1-e5c2903ad63c/spaces", TestUtil.ToTestableString(page[3].SpacesUrl), true);
               
               
            
            
                Assert.AreEqual("7255dbdd-38b7-47bc-967f-41d7475d261b", TestUtil.ToTestableString(page[4].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/security_groups/7255dbdd-38b7-47bc-967f-41d7475d261b", TestUtil.ToTestableString(page[4].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:30+02:00", TestUtil.ToTestableString(page[4].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[4].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-489", TestUtil.ToTestableString(page[4].Name), true);
                  
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[4].RunningDefault), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[4].StagingDefault), true);
                  Assert.AreEqual("/v2/security_groups/7255dbdd-38b7-47bc-967f-41d7475d261b/spaces", TestUtil.ToTestableString(page[4].SpacesUrl), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestUpdateSecurityGroupResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""created_at"": ""2014-11-12T12:59:28+02:00"",
    ""updated_at"": ""2014-11-12T12:59:30+02:00""
  },
  ""entity"": {
    ""name"": ""new_name"",
    ""rules"": [

    ],
    ""running_default"": false,
    ""staging_default"": false,
    ""spaces_url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces""
  }
}";
    
            UpdateSecurityGroupResponse obj = Util.DeserializeJson<UpdateSecurityGroupResponse>(json);
        
            Assert.AreEqual("cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:30+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("new_name", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.StagingDefault), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateSecurityGroupResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""ff94daed-d276-4253-a5cb-f270a6c4e118"",
    ""url"": ""/v2/security_groups/ff94daed-d276-4253-a5cb-f270a6c4e118"",
    ""created_at"": ""2014-11-12T12:59:30+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""my_super_sec_group"",
    ""rules"": [
      {
        ""protocol"": ""icmp"",
        ""destination"": ""0.0.0.0/0"",
        ""type"": 0,
        ""code"": 1
      },
      {
        ""protocol"": ""tcp"",
        ""destination"": ""0.0.0.0/0"",
        ""ports"": ""2048-3000"",
        ""log"": true
      },
      {
        ""protocol"": ""udp"",
        ""destination"": ""0.0.0.0/0"",
        ""ports"": ""53, 5353""
      },
      {
        ""protocol"": ""all"",
        ""destination"": ""0.0.0.0/0""
      }
    ],
    ""running_default"": false,
    ""staging_default"": false,
    ""spaces_url"": ""/v2/security_groups/ff94daed-d276-4253-a5cb-f270a6c4e118/spaces""
  }
}";
    
            CreateSecurityGroupResponse obj = Util.DeserializeJson<CreateSecurityGroupResponse>(json);
        
            Assert.AreEqual("ff94daed-d276-4253-a5cb-f270a6c4e118", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/security_groups/ff94daed-d276-4253-a5cb-f270a6c4e118", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:30+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("my_super_sec_group", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.StagingDefault), true);
            Assert.AreEqual("/v2/security_groups/ff94daed-d276-4253-a5cb-f270a6c4e118/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveSecurityGroupResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e"",
    ""created_at"": ""2014-11-12T12:59:28+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""dummy1"",
    ""rules"": [

    ],
    ""running_default"": false,
    ""staging_default"": false,
    ""spaces_url"": ""/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces""
  }
}";
    
            RetrieveSecurityGroupResponse obj = Util.DeserializeJson<RetrieveSecurityGroupResponse>(json);
        
            Assert.AreEqual("cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:28+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("dummy1", TestUtil.ToTestableString(obj.Name), true);
            
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.RunningDefault), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.StagingDefault), true);
            Assert.AreEqual("/v2/security_groups/cc49e277-b403-4a52-bedc-df1ce3403b0e/spaces", TestUtil.ToTestableString(obj.SpacesUrl), true);
            
            
        }

    }
}
