using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cf_net_sdk_test.Serialization
{
    [TestClass]
    public class ServiceBindingsTest
    {

    
        [TestMethod]
        public void TestCreateServiceBindingRequest()
        {
            string json = @"{
  ""service_instance_guid"": ""b172309e-2870-4d22-a633-01469a83a40f"",
  ""app_guid"": ""46215bdf-03c6-41fb-a8e7-63ae457a80f1""
}";
            CreateServiceBindingRequest request = new CreateServiceBindingRequest();
       
            request.ServiceInstanceGuid = new Guid("b172309e-2870-4d22-a633-01469a83a40f");
            request.AppGuid = new Guid("46215bdf-03c6-41fb-a8e7-63ae457a80f1");
            string result = JsonConvert.SerializeObject(request, Formatting.None);
            Assert.AreEqual(result, TestUtil.ToUnformatedJsonString(json));
        }

    }
}
