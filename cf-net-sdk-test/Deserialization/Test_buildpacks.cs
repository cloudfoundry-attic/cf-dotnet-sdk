using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class BuildpacksTest
    {

    
        [TestMethod]
        public void TestChangePositionOfBuildpackRequest()
        {
            string json = @"{
  ""position"": 3
}";
    
            ChangePositionOfBuildpackRequest obj = Util.DeserializeJson<ChangePositionOfBuildpackRequest>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(obj.Position), true);
        }

    
        [TestMethod]
        public void TestChangePositionOfBuildpackResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""a3652e2d-544a-4a6a-9241-3a51d63c190c"",
    ""url"": ""/v2/buildpacks/a3652e2d-544a-4a6a-9241-3a51d63c190c"",
    ""created_at"": ""2014-11-12T12:59:33+02:00"",
    ""updated_at"": ""2014-11-12T12:59:33+02:00""
  },
  ""entity"": {
    ""name"": ""name_1"",
    ""position"": 3,
    ""enabled"": true,
    ""locked"": false,
    ""filename"": ""name-567""
  }
}";
    
            ChangePositionOfBuildpackResponse obj = Util.DeserializeJson<ChangePositionOfBuildpackResponse>(json);
        
            Assert.AreEqual("a3652e2d-544a-4a6a-9241-3a51d63c190c", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/buildpacks/a3652e2d-544a-4a6a-9241-3a51d63c190c", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name_1", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("3", TestUtil.ToTestableString(obj.Position), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Locked), true);
            Assert.AreEqual("name-567", TestUtil.ToTestableString(obj.Filename), true);
            
            
        }

    
        [TestMethod]
        public void TestListAllBuildpacksResponse()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""09fb6236-50f5-40d6-8d94-03f1bbf34355"",
        ""url"": ""/v2/buildpacks/09fb6236-50f5-40d6-8d94-03f1bbf34355"",
        ""created_at"": ""2014-11-12T12:59:33+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name_1"",
        ""position"": 1,
        ""enabled"": true,
        ""locked"": false,
        ""filename"": ""name-573""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""e29cd298-8ff3-4113-b09d-505d8fc1042d"",
        ""url"": ""/v2/buildpacks/e29cd298-8ff3-4113-b09d-505d8fc1042d"",
        ""created_at"": ""2014-11-12T12:59:33+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name_2"",
        ""position"": 2,
        ""enabled"": true,
        ""locked"": false,
        ""filename"": ""name-574""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""882231d5-3fae-4f70-b571-53406491b983"",
        ""url"": ""/v2/buildpacks/882231d5-3fae-4f70-b571-53406491b983"",
        ""created_at"": ""2014-11-12T12:59:33+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name_3"",
        ""position"": 3,
        ""enabled"": true,
        ""locked"": false,
        ""filename"": ""name-575""
      }
    }
  ]
}";
    
            PagedResponse<ListAllBuildpacksResponse> page = Util.DeserializePage<ListAllBuildpacksResponse>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("09fb6236-50f5-40d6-8d94-03f1bbf34355", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/buildpacks/09fb6236-50f5-40d6-8d94-03f1bbf34355", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name_1", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("1", TestUtil.ToTestableString(page[0].Position), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[0].Enabled), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[0].Locked), true);
                  Assert.AreEqual("name-573", TestUtil.ToTestableString(page[0].Filename), true);
               
               
            
            
                Assert.AreEqual("e29cd298-8ff3-4113-b09d-505d8fc1042d", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/buildpacks/e29cd298-8ff3-4113-b09d-505d8fc1042d", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name_2", TestUtil.ToTestableString(page[1].Name), true);
                  Assert.AreEqual("2", TestUtil.ToTestableString(page[1].Position), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[1].Enabled), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[1].Locked), true);
                  Assert.AreEqual("name-574", TestUtil.ToTestableString(page[1].Filename), true);
               
               
            
            
                Assert.AreEqual("882231d5-3fae-4f70-b571-53406491b983", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/buildpacks/882231d5-3fae-4f70-b571-53406491b983", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name_3", TestUtil.ToTestableString(page[2].Name), true);
                  Assert.AreEqual("3", TestUtil.ToTestableString(page[2].Position), true);
                  Assert.AreEqual("true", TestUtil.ToTestableString(page[2].Enabled), true);
                  Assert.AreEqual("false", TestUtil.ToTestableString(page[2].Locked), true);
                  Assert.AreEqual("name-575", TestUtil.ToTestableString(page[2].Filename), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestCreatesAdminBuildpackRequest()
        {
            string json = @"{
  ""name"": ""Golang_buildpack""
}";
    
            CreatesAdminBuildpackRequest obj = Util.DeserializeJson<CreatesAdminBuildpackRequest>(json);
        
            Assert.AreEqual("Golang_buildpack", TestUtil.ToTestableString(obj.Name), true);
        }

    
        [TestMethod]
        public void TestCreatesAdminBuildpackResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""2980a61d-1fe1-4362-a04f-6fa93eb32fdf"",
    ""url"": ""/v2/buildpacks/2980a61d-1fe1-4362-a04f-6fa93eb32fdf"",
    ""created_at"": ""2014-11-12T12:59:33+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""Golang_buildpack"",
    ""position"": 1,
    ""enabled"": true,
    ""locked"": false,
    ""filename"": null
  }
}";
    
            CreatesAdminBuildpackResponse obj = Util.DeserializeJson<CreatesAdminBuildpackResponse>(json);
        
            Assert.AreEqual("2980a61d-1fe1-4362-a04f-6fa93eb32fdf", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/buildpacks/2980a61d-1fe1-4362-a04f-6fa93eb32fdf", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("Golang_buildpack", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Position), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Locked), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.Filename), true);
            
            
        }

    
        [TestMethod]
        public void TestLockOrUnlockBuildpackRequest()
        {
            string json = @"{
  ""locked"": true
}";
    
            LockOrUnlockBuildpackRequest obj = Util.DeserializeJson<LockOrUnlockBuildpackRequest>(json);
        
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Locked), true);
        }

    
        [TestMethod]
        public void TestLockOrUnlockBuildpackResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""c4e27438-119b-4fc8-87c0-45dbc8e4919d"",
    ""url"": ""/v2/buildpacks/c4e27438-119b-4fc8-87c0-45dbc8e4919d"",
    ""created_at"": ""2014-11-12T12:59:33+02:00"",
    ""updated_at"": ""2014-11-12T12:59:33+02:00""
  },
  ""entity"": {
    ""name"": ""name_1"",
    ""position"": 1,
    ""enabled"": true,
    ""locked"": true,
    ""filename"": ""name-564""
  }
}";
    
            LockOrUnlockBuildpackResponse obj = Util.DeserializeJson<LockOrUnlockBuildpackResponse>(json);
        
            Assert.AreEqual("c4e27438-119b-4fc8-87c0-45dbc8e4919d", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/buildpacks/c4e27438-119b-4fc8-87c0-45dbc8e4919d", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name_1", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Position), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Locked), true);
            Assert.AreEqual("name-564", TestUtil.ToTestableString(obj.Filename), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveBuildpackResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""e3d67ff5-a89b-4526-8112-ccabf0499a7b"",
    ""url"": ""/v2/buildpacks/e3d67ff5-a89b-4526-8112-ccabf0499a7b"",
    ""created_at"": ""2014-11-12T12:59:33+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name_1"",
    ""position"": 1,
    ""enabled"": true,
    ""locked"": false,
    ""filename"": ""name-582""
  }
}";
    
            RetrieveBuildpackResponse obj = Util.DeserializeJson<RetrieveBuildpackResponse>(json);
        
            Assert.AreEqual("e3d67ff5-a89b-4526-8112-ccabf0499a7b", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/buildpacks/e3d67ff5-a89b-4526-8112-ccabf0499a7b", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name_1", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Position), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Locked), true);
            Assert.AreEqual("name-582", TestUtil.ToTestableString(obj.Filename), true);
            
            
        }

    
        [TestMethod]
        public void TestEnableOrDisableBuildpackRequest()
        {
            string json = @"{
  ""enabled"": false
}";
    
            EnableOrDisableBuildpackRequest obj = Util.DeserializeJson<EnableOrDisableBuildpackRequest>(json);
        
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Enabled), true);
        }

    
        [TestMethod]
        public void TestEnableOrDisableBuildpackResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""b63086cc-1db0-454a-a90d-950541415a43"",
    ""url"": ""/v2/buildpacks/b63086cc-1db0-454a-a90d-950541415a43"",
    ""created_at"": ""2014-11-12T12:59:33+02:00"",
    ""updated_at"": ""2014-11-12T12:59:33+02:00""
  },
  ""entity"": {
    ""name"": ""name_1"",
    ""position"": 1,
    ""enabled"": false,
    ""locked"": false,
    ""filename"": ""name-570""
  }
}";
    
            EnableOrDisableBuildpackResponse obj = Util.DeserializeJson<EnableOrDisableBuildpackResponse>(json);
        
            Assert.AreEqual("b63086cc-1db0-454a-a90d-950541415a43", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/buildpacks/b63086cc-1db0-454a-a90d-950541415a43", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:33+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name_1", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("1", TestUtil.ToTestableString(obj.Position), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Locked), true);
            Assert.AreEqual("name-570", TestUtil.ToTestableString(obj.Filename), true);
            
            
        }

    }
}
