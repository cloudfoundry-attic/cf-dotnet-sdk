using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class ServicePlanVisibilitiesTest
    {

    
        [TestMethod]
        public void TestUpdateServicePlanVisibilityRequest()
        {
            string json = @"{
  ""service_plan_guid"": ""f5e79b16-edf4-443f-87ef-7f128bfdcde3"",
  ""organization_guid"": ""fe3e4b18-394e-48bb-9442-cc1e85cfcf61""
}";
            UpdateServicePlanVisibilityRequest request = new UpdateServicePlanVisibilityRequest();
       
            request.ServicePlanGuid = new Guid("f5e79b16-edf4-443f-87ef-7f128bfdcde3");
            request.OrganizationGuid = new Guid("fe3e4b18-394e-48bb-9442-cc1e85cfcf61");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    
        [TestMethod]
        public void TestCreateServicePlanVisibilityRequest()
        {
            string json = @"{
  ""service_plan_guid"": ""aeb83366-300a-451e-a885-c6edd065fd5e"",
  ""organization_guid"": ""cb7e7f18-1dec-4503-956b-60524c5da57d""
}";
            CreateServicePlanVisibilityRequest request = new CreateServicePlanVisibilityRequest();
       
            request.ServicePlanGuid = new Guid("aeb83366-300a-451e-a885-c6edd065fd5e");
            request.OrganizationGuid = new Guid("cb7e7f18-1dec-4503-956b-60524c5da57d");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
