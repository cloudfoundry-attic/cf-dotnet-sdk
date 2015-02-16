using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class EventsTest
    {

    
        [TestMethod]
        public void TestListSpaceDeleteEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""1d763c50-7ede-431f-af1e-bc370e5c8ab5"",
        ""url"": ""/v2/events/1d763c50-7ede-431f-af1e-bc370e5c8ab5"",
        ""created_at"": ""2014-11-12T12:59:40+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.space.delete-request"",
        ""actor"": ""uaa-id-224"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""9c3b89fe-c45e-44e1-947f-00bd49330059"",
        ""actee_type"": ""space"",
        ""actee_name"": ""name-982"",
        ""timestamp"": ""2014-11-12T12:59:40+02:00"",
        ""metadata"": {
          ""request"": {
            ""recursive"": true
          }
        },
        ""space_guid"": ""9c3b89fe-c45e-44e1-947f-00bd49330059"",
        ""organization_guid"": ""b7ed2482-803c-4219-8b6f-f178192d03bb""
      }
    }
  ]
}";
    
            PagedResponse<ListSpaceDeleteEventsResponse> page = Util.DeserializePage<ListSpaceDeleteEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("1d763c50-7ede-431f-af1e-bc370e5c8ab5", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/1d763c50-7ede-431f-af1e-bc370e5c8ab5", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.space.delete-request", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-224", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("9c3b89fe-c45e-44e1-947f-00bd49330059", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("space", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-982", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("9c3b89fe-c45e-44e1-947f-00bd49330059", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("b7ed2482-803c-4219-8b6f-f178192d03bb", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAppExitedEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""5b3b48ff-11ce-479c-8f75-e79ca2da5abb"",
        ""url"": ""/v2/events/5b3b48ff-11ce-479c-8f75-e79ca2da5abb"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""app.crash"",
        ""actor"": ""0860bc4a-835c-485a-b017-b4a4bc1b2290"",
        ""actor_type"": ""app"",
        ""actor_name"": ""name-1065"",
        ""actee"": ""0860bc4a-835c-485a-b017-b4a4bc1b2290"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-1065"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {
          ""instance"": 0,
          ""index"": 1,
          ""exit_status"": ""1"",
          ""exit_description"": ""out of memory"",
          ""reason"": ""crashed""
        },
        ""space_guid"": ""7030d9f8-7ed4-4030-a309-b3f44e40088d"",
        ""organization_guid"": ""bace689d-e882-4ca3-80f8-4265bcaac2b4""
      }
    }
  ]
}";
    
            PagedResponse<ListAppExitedEventsResponse> page = Util.DeserializePage<ListAppExitedEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("5b3b48ff-11ce-479c-8f75-e79ca2da5abb", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/5b3b48ff-11ce-479c-8f75-e79ca2da5abb", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("app.crash", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("0860bc4a-835c-485a-b017-b4a4bc1b2290", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("name-1065", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("0860bc4a-835c-485a-b017-b4a4bc1b2290", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-1065", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("7030d9f8-7ed4-4030-a309-b3f44e40088d", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("bace689d-e882-4ca3-80f8-4265bcaac2b4", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveEventResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""ce092d42-fd4c-4068-81e5-f4b166c0a973"",
    ""url"": ""/v2/events/ce092d42-fd4c-4068-81e5-f4b166c0a973"",
    ""created_at"": ""2014-11-12T12:59:41+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""type"": ""name-1094"",
    ""actor"": ""guid-e58e2468-4fef-4d4d-8988-b8b7905135cb"",
    ""actor_type"": ""name-1095"",
    ""actor_name"": ""name-1096"",
    ""actee"": ""guid-d0d8b067-e0c1-4aa4-9631-a4fb8501d7c6"",
    ""actee_type"": ""name-1097"",
    ""actee_name"": ""name-1098"",
    ""timestamp"": ""2014-11-12T12:59:41+02:00"",
    ""metadata"": {

    },
    ""space_guid"": ""d6f4d36c-d8fe-46e1-9cbf-d77f4e8cd8d8"",
    ""organization_guid"": ""84e3c43c-2238-4ef2-8b30-790db9e3d95e""
  }
}";
    
            RetrieveEventResponse obj = Util.DeserializeJson<RetrieveEventResponse>(json);
        
            Assert.AreEqual("ce092d42-fd4c-4068-81e5-f4b166c0a973", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/events/ce092d42-fd4c-4068-81e5-f4b166c0a973", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-1094", TestUtil.ToTestableString(obj.Type), true);
            Assert.AreEqual("guid-e58e2468-4fef-4d4d-8988-b8b7905135cb", TestUtil.ToTestableString(obj.Actor), true);
            Assert.AreEqual("name-1095", TestUtil.ToTestableString(obj.ActorType), true);
            Assert.AreEqual("name-1096", TestUtil.ToTestableString(obj.ActorName), true);
            Assert.AreEqual("guid-d0d8b067-e0c1-4aa4-9631-a4fb8501d7c6", TestUtil.ToTestableString(obj.Actee), true);
            Assert.AreEqual("name-1097", TestUtil.ToTestableString(obj.ActeeType), true);
            Assert.AreEqual("name-1098", TestUtil.ToTestableString(obj.ActeeName), true);
            Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(obj.Timestamp), true);
            
            Assert.AreEqual("d6f4d36c-d8fe-46e1-9cbf-d77f4e8cd8d8", TestUtil.ToTestableString(obj.SpaceGuid), true);
            Assert.AreEqual("84e3c43c-2238-4ef2-8b30-790db9e3d95e", TestUtil.ToTestableString(obj.OrganizationGuid), true);
            
            
        }

    
        [TestMethod]
        public void TestListAppDeleteEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""2a4ddb9c-fd8d-42c6-b4c9-14de0e26f322"",
        ""url"": ""/v2/events/2a4ddb9c-fd8d-42c6-b4c9-14de0e26f322"",
        ""created_at"": ""2014-11-12T12:59:40+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.app.delete-request"",
        ""actor"": ""uaa-id-216"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""8e2c666b-e468-4a38-85d4-b5725e228385"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-868"",
        ""timestamp"": ""2014-11-12T12:59:40+02:00"",
        ""metadata"": {
          ""request"": {
            ""recursive"": false
          }
        },
        ""space_guid"": ""133e93cb-d1ff-434f-8a14-28158d1443a4"",
        ""organization_guid"": ""f0165fe6-0f5b-4caf-af0e-7e39e31d1a2a""
      }
    }
  ]
}";
    
            PagedResponse<ListAppDeleteEventsResponse> page = Util.DeserializePage<ListAppDeleteEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("2a4ddb9c-fd8d-42c6-b4c9-14de0e26f322", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/2a4ddb9c-fd8d-42c6-b4c9-14de0e26f322", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.app.delete-request", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-216", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("8e2c666b-e468-4a38-85d4-b5725e228385", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-868", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("133e93cb-d1ff-434f-8a14-28158d1443a4", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("f0165fe6-0f5b-4caf-af0e-7e39e31d1a2a", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAppUpdateEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""8d7461b5-dcdc-410c-99bf-c893e294ed09"",
        ""url"": ""/v2/events/8d7461b5-dcdc-410c-99bf-c893e294ed09"",
        ""created_at"": ""2014-11-12T12:59:40+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.app.update"",
        ""actor"": ""uaa-id-218"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""8ecdc773-03a3-4b40-a799-be730f78c76b"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-897"",
        ""timestamp"": ""2014-11-12T12:59:40+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""new"",
            ""instances"": 1,
            ""memory"": 84,
            ""state"": ""STOPPED"",
            ""environment_json"": ""PRIVATE DATA HIDDEN""
          }
        },
        ""space_guid"": ""89c5294f-495c-4fc4-99d8-9293aeba9a36"",
        ""organization_guid"": ""ad4fdeab-8a98-4cca-bacd-919b9c0f50c4""
      }
    }
  ]
}";
    
            PagedResponse<ListAppUpdateEventsResponse> page = Util.DeserializePage<ListAppUpdateEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("8d7461b5-dcdc-410c-99bf-c893e294ed09", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/8d7461b5-dcdc-410c-99bf-c893e294ed09", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.app.update", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-218", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("8ecdc773-03a3-4b40-a799-be730f78c76b", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-897", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("89c5294f-495c-4fc4-99d8-9293aeba9a36", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("ad4fdeab-8a98-4cca-bacd-919b9c0f50c4", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListSpaceUpdateEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""044385a9-7a15-4456-8aa5-673a96a971f0"",
        ""url"": ""/v2/events/044385a9-7a15-4456-8aa5-673a96a971f0"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.space.update"",
        ""actor"": ""uaa-id-228"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""ec1a7422-8af5-4c82-bd3a-e7badd7f83e3"",
        ""actee_type"": ""space"",
        ""actee_name"": ""name-1038"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""outer space""
          }
        },
        ""space_guid"": ""ec1a7422-8af5-4c82-bd3a-e7badd7f83e3"",
        ""organization_guid"": ""e8a1bfa3-9eaa-4cfc-9bb5-f4ce28be88c4""
      }
    }
  ]
}";
    
            PagedResponse<ListSpaceUpdateEventsResponse> page = Util.DeserializePage<ListSpaceUpdateEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("044385a9-7a15-4456-8aa5-673a96a971f0", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/044385a9-7a15-4456-8aa5-673a96a971f0", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.space.update", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-228", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("ec1a7422-8af5-4c82-bd3a-e7badd7f83e3", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("space", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-1038", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("ec1a7422-8af5-4c82-bd3a-e7badd7f83e3", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("e8a1bfa3-9eaa-4cfc-9bb5-f4ce28be88c4", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAllEventsResponse()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""ee9ca447-d2d3-482e-a888-fb846367095d"",
        ""url"": ""/v2/events/ee9ca447-d2d3-482e-a888-fb846367095d"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""name-1070"",
        ""actor"": ""guid-68f7fae4-6de7-4f61-8ffd-3b9fb6cf145c"",
        ""actor_type"": ""name-1071"",
        ""actor_name"": ""name-1072"",
        ""actee"": ""guid-eb06713a-a70a-495c-acb8-0997cf15dfc4"",
        ""actee_type"": ""name-1073"",
        ""actee_name"": ""name-1074"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {

        },
        ""space_guid"": ""d4d38dfd-110f-44bd-814b-bea53e4f8bd4"",
        ""organization_guid"": ""eaa483dc-2a10-4e26-843b-622a26cef6c5""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""a4819234-5fd9-444d-a240-d971c9a38d86"",
        ""url"": ""/v2/events/a4819234-5fd9-444d-a240-d971c9a38d86"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""name-1078"",
        ""actor"": ""guid-64d642b9-0f28-4dea-a68f-32389ea8d25b"",
        ""actor_type"": ""name-1079"",
        ""actor_name"": ""name-1080"",
        ""actee"": ""guid-307aa6d5-d638-4b55-b5a0-5e9707384e97"",
        ""actee_type"": ""name-1081"",
        ""actee_name"": ""name-1082"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {

        },
        ""space_guid"": ""6b351ca8-fa59-4a0c-b6fe-32bf88eaa876"",
        ""organization_guid"": ""48c77b90-355c-40ab-a02c-f4a7cbb3c6b8""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""48595ce5-f138-49be-8795-5030575db225"",
        ""url"": ""/v2/events/48595ce5-f138-49be-8795-5030575db225"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""name-1086"",
        ""actor"": ""guid-813db2e3-f915-4ed2-8cb1-54e5b517d9b7"",
        ""actor_type"": ""name-1087"",
        ""actor_name"": ""name-1088"",
        ""actee"": ""guid-471bcbbc-0320-4d27-9748-cf9557071568"",
        ""actee_type"": ""name-1089"",
        ""actee_name"": ""name-1090"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {

        },
        ""space_guid"": ""de995fe3-d320-4fc4-9f7b-48a13ff88d09"",
        ""organization_guid"": ""b27a5f6e-d0fd-4f1f-845a-0dacf44dbc3c""
      }
    }
  ]
}";
    
            PagedResponse<ListAllEventsResponse> page = Util.DeserializePage<ListAllEventsResponse>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("ee9ca447-d2d3-482e-a888-fb846367095d", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/ee9ca447-d2d3-482e-a888-fb846367095d", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1070", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("guid-68f7fae4-6de7-4f61-8ffd-3b9fb6cf145c", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("name-1071", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("name-1072", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("guid-eb06713a-a70a-495c-acb8-0997cf15dfc4", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("name-1073", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-1074", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("d4d38dfd-110f-44bd-814b-bea53e4f8bd4", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("eaa483dc-2a10-4e26-843b-622a26cef6c5", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
            
                Assert.AreEqual("a4819234-5fd9-444d-a240-d971c9a38d86", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/a4819234-5fd9-444d-a240-d971c9a38d86", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1078", TestUtil.ToTestableString(page[1].Type), true);
                  Assert.AreEqual("guid-64d642b9-0f28-4dea-a68f-32389ea8d25b", TestUtil.ToTestableString(page[1].Actor), true);
                  Assert.AreEqual("name-1079", TestUtil.ToTestableString(page[1].ActorType), true);
                  Assert.AreEqual("name-1080", TestUtil.ToTestableString(page[1].ActorName), true);
                  Assert.AreEqual("guid-307aa6d5-d638-4b55-b5a0-5e9707384e97", TestUtil.ToTestableString(page[1].Actee), true);
                  Assert.AreEqual("name-1081", TestUtil.ToTestableString(page[1].ActeeType), true);
                  Assert.AreEqual("name-1082", TestUtil.ToTestableString(page[1].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[1].Timestamp), true);
                  
                  Assert.AreEqual("6b351ca8-fa59-4a0c-b6fe-32bf88eaa876", TestUtil.ToTestableString(page[1].SpaceGuid), true);
                  Assert.AreEqual("48c77b90-355c-40ab-a02c-f4a7cbb3c6b8", TestUtil.ToTestableString(page[1].OrganizationGuid), true);
               
               
            
            
                Assert.AreEqual("48595ce5-f138-49be-8795-5030575db225", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/48595ce5-f138-49be-8795-5030575db225", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-1086", TestUtil.ToTestableString(page[2].Type), true);
                  Assert.AreEqual("guid-813db2e3-f915-4ed2-8cb1-54e5b517d9b7", TestUtil.ToTestableString(page[2].Actor), true);
                  Assert.AreEqual("name-1087", TestUtil.ToTestableString(page[2].ActorType), true);
                  Assert.AreEqual("name-1088", TestUtil.ToTestableString(page[2].ActorName), true);
                  Assert.AreEqual("guid-471bcbbc-0320-4d27-9748-cf9557071568", TestUtil.ToTestableString(page[2].Actee), true);
                  Assert.AreEqual("name-1089", TestUtil.ToTestableString(page[2].ActeeType), true);
                  Assert.AreEqual("name-1090", TestUtil.ToTestableString(page[2].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[2].Timestamp), true);
                  
                  Assert.AreEqual("de995fe3-d320-4fc4-9f7b-48a13ff88d09", TestUtil.ToTestableString(page[2].SpaceGuid), true);
                  Assert.AreEqual("b27a5f6e-d0fd-4f1f-845a-0dacf44dbc3c", TestUtil.ToTestableString(page[2].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListAppCreateEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""00b90299-aaa6-4935-ac5f-07b0523106c5"",
        ""url"": ""/v2/events/00b90299-aaa6-4935-ac5f-07b0523106c5"",
        ""created_at"": ""2014-11-12T12:59:40+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.app.create"",
        ""actor"": ""uaa-id-220"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""660fbd30-d904-46af-aa10-15893d94dd8d"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-926"",
        ""timestamp"": ""2014-11-12T12:59:40+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""new"",
            ""instances"": 1,
            ""memory"": 84,
            ""state"": ""STOPPED"",
            ""environment_json"": ""PRIVATE DATA HIDDEN""
          }
        },
        ""space_guid"": ""b4303aaa-315d-4c1b-9295-67e34ce0eec6"",
        ""organization_guid"": ""65c7d3e1-4424-4b14-88c8-633b9689d6c0""
      }
    }
  ]
}";
    
            PagedResponse<ListAppCreateEventsResponse> page = Util.DeserializePage<ListAppCreateEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("00b90299-aaa6-4935-ac5f-07b0523106c5", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/00b90299-aaa6-4935-ac5f-07b0523106c5", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.app.create", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-220", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("660fbd30-d904-46af-aa10-15893d94dd8d", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-926", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("b4303aaa-315d-4c1b-9295-67e34ce0eec6", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("65c7d3e1-4424-4b14-88c8-633b9689d6c0", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListEventsAssociatedWithAppSinceJanuary12014Response()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""b908fc4b-92f2-464e-8a63-f58a4103767e"",
        ""url"": ""/v2/events/b908fc4b-92f2-464e-8a63-f58a4103767e"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.app.create"",
        ""actor"": ""uaa-id-226"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""20fa8f50-2ce3-4843-b3ae-76211f9c62e6"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-1009"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""new"",
            ""instances"": 1,
            ""memory"": 84,
            ""state"": ""STOPPED"",
            ""environment_json"": ""PRIVATE DATA HIDDEN""
          }
        },
        ""space_guid"": ""6c8a26ca-7563-4bfa-a607-e15c828e365a"",
        ""organization_guid"": ""aacca476-6789-4d36-ad57-1c8c45f0424e""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""c03f911b-8603-409f-81b0-1b68dcb37719"",
        ""url"": ""/v2/events/c03f911b-8603-409f-81b0-1b68dcb37719"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.app.update"",
        ""actor"": ""uaa-id-226"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""20fa8f50-2ce3-4843-b3ae-76211f9c62e6"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-1009"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""new"",
            ""instances"": 1,
            ""memory"": 84,
            ""state"": ""STOPPED"",
            ""environment_json"": ""PRIVATE DATA HIDDEN""
          }
        },
        ""space_guid"": ""6c8a26ca-7563-4bfa-a607-e15c828e365a"",
        ""organization_guid"": ""aacca476-6789-4d36-ad57-1c8c45f0424e""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""6e8e3624-c9a5-4f3c-92ba-a1929bc3df00"",
        ""url"": ""/v2/events/6e8e3624-c9a5-4f3c-92ba-a1929bc3df00"",
        ""created_at"": ""2014-11-12T12:59:41+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.app.delete-request"",
        ""actor"": ""uaa-id-226"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""20fa8f50-2ce3-4843-b3ae-76211f9c62e6"",
        ""actee_type"": ""app"",
        ""actee_name"": ""name-1009"",
        ""timestamp"": ""2014-11-12T12:59:41+02:00"",
        ""metadata"": {
          ""request"": {
            ""recursive"": false
          }
        },
        ""space_guid"": ""6c8a26ca-7563-4bfa-a607-e15c828e365a"",
        ""organization_guid"": ""aacca476-6789-4d36-ad57-1c8c45f0424e""
      }
    }
  ]
}";
    
            PagedResponse<ListEventsAssociatedWithAppSinceJanuary12014Response> page = Util.DeserializePage<ListEventsAssociatedWithAppSinceJanuary12014Response>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("b908fc4b-92f2-464e-8a63-f58a4103767e", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/b908fc4b-92f2-464e-8a63-f58a4103767e", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.app.create", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-226", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("20fa8f50-2ce3-4843-b3ae-76211f9c62e6", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-1009", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("6c8a26ca-7563-4bfa-a607-e15c828e365a", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("aacca476-6789-4d36-ad57-1c8c45f0424e", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
            
                Assert.AreEqual("c03f911b-8603-409f-81b0-1b68dcb37719", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/c03f911b-8603-409f-81b0-1b68dcb37719", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.app.update", TestUtil.ToTestableString(page[1].Type), true);
                  Assert.AreEqual("uaa-id-226", TestUtil.ToTestableString(page[1].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[1].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[1].ActorName), true);
                  Assert.AreEqual("20fa8f50-2ce3-4843-b3ae-76211f9c62e6", TestUtil.ToTestableString(page[1].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[1].ActeeType), true);
                  Assert.AreEqual("name-1009", TestUtil.ToTestableString(page[1].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[1].Timestamp), true);
                  
                  Assert.AreEqual("6c8a26ca-7563-4bfa-a607-e15c828e365a", TestUtil.ToTestableString(page[1].SpaceGuid), true);
                  Assert.AreEqual("aacca476-6789-4d36-ad57-1c8c45f0424e", TestUtil.ToTestableString(page[1].OrganizationGuid), true);
               
               
            
            
                Assert.AreEqual("6e8e3624-c9a5-4f3c-92ba-a1929bc3df00", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/6e8e3624-c9a5-4f3c-92ba-a1929bc3df00", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.app.delete-request", TestUtil.ToTestableString(page[2].Type), true);
                  Assert.AreEqual("uaa-id-226", TestUtil.ToTestableString(page[2].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[2].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[2].ActorName), true);
                  Assert.AreEqual("20fa8f50-2ce3-4843-b3ae-76211f9c62e6", TestUtil.ToTestableString(page[2].Actee), true);
                  Assert.AreEqual("app", TestUtil.ToTestableString(page[2].ActeeType), true);
                  Assert.AreEqual("name-1009", TestUtil.ToTestableString(page[2].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:41+02:00", TestUtil.ToTestableString(page[2].Timestamp), true);
                  
                  Assert.AreEqual("6c8a26ca-7563-4bfa-a607-e15c828e365a", TestUtil.ToTestableString(page[2].SpaceGuid), true);
                  Assert.AreEqual("aacca476-6789-4d36-ad57-1c8c45f0424e", TestUtil.ToTestableString(page[2].OrganizationGuid), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestListSpaceCreateEventsResponse()
        {
            string json = @"{
  ""total_results"": 1,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""19b641b1-955b-43dd-bd74-81b6c79d6c4c"",
        ""url"": ""/v2/events/19b641b1-955b-43dd-bd74-81b6c79d6c4c"",
        ""created_at"": ""2014-11-12T12:59:40+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""type"": ""audit.space.create"",
        ""actor"": ""uaa-id-222"",
        ""actor_type"": ""user"",
        ""actor_name"": ""user@email.com"",
        ""actee"": ""9d34cf65-cd94-416a-b085-5395a74aef11"",
        ""actee_type"": ""space"",
        ""actee_name"": ""name-955"",
        ""timestamp"": ""2014-11-12T12:59:40+02:00"",
        ""metadata"": {
          ""request"": {
            ""name"": ""outer space""
          }
        },
        ""space_guid"": ""9d34cf65-cd94-416a-b085-5395a74aef11"",
        ""organization_guid"": ""8af3d9c4-c6d0-46e0-9ce9-24398ce22fec""
      }
    }
  ]
}";
    
            PagedResponse<ListSpaceCreateEventsResponse> page = Util.DeserializePage<ListSpaceCreateEventsResponse>(json);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("19b641b1-955b-43dd-bd74-81b6c79d6c4c", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/events/19b641b1-955b-43dd-bd74-81b6c79d6c4c", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("audit.space.create", TestUtil.ToTestableString(page[0].Type), true);
                  Assert.AreEqual("uaa-id-222", TestUtil.ToTestableString(page[0].Actor), true);
                  Assert.AreEqual("user", TestUtil.ToTestableString(page[0].ActorType), true);
                  Assert.AreEqual("user@email.com", TestUtil.ToTestableString(page[0].ActorName), true);
                  Assert.AreEqual("9d34cf65-cd94-416a-b085-5395a74aef11", TestUtil.ToTestableString(page[0].Actee), true);
                  Assert.AreEqual("space", TestUtil.ToTestableString(page[0].ActeeType), true);
                  Assert.AreEqual("name-955", TestUtil.ToTestableString(page[0].ActeeName), true);
                  Assert.AreEqual("2014-11-12T12:59:40+02:00", TestUtil.ToTestableString(page[0].Timestamp), true);
                  
                  Assert.AreEqual("9d34cf65-cd94-416a-b085-5395a74aef11", TestUtil.ToTestableString(page[0].SpaceGuid), true);
                  Assert.AreEqual("8af3d9c4-c6d0-46e0-9ce9-24398ce22fec", TestUtil.ToTestableString(page[0].OrganizationGuid), true);
               
               
            
    
        }

    }
}
