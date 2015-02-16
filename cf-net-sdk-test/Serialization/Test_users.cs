using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class UsersTest
    {

    
        [TestMethod]
        public void TestUpdateUserRequest()
        {
            string json = @"{
  ""default_space_guid"": ""07847408-706d-4f74-85b5-58c620aaebb8""
}";
            UpdateUserRequest request = new UpdateUserRequest();
       
            request.DefaultSpaceGuid = new Guid("07847408-706d-4f74-85b5-58c620aaebb8");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateUserRequest()
        {
            string json = @"{
  ""guid"": ""guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202""
}";
            CreateUserRequest request = new CreateUserRequest();
       
            request.Guid = "guid-e98d20df-f47f-4b0b-8d2c-f768b38e7202";
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
