using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cf_net_sdk.Client.Data;
using cf_net_sdk;

namespace cf_net_sdk_test.Deserialization
{
    [TestClass]
    public class FeatureFlagsTest
    {

    
        [TestMethod]
        public void TestGetAppBitsUploadFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""app_bits_upload"",
  ""enabled"": true,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/app_bits_upload""
}";
    
            GetAppBitsUploadFeatureFlagResponse obj = Util.DeserializeJson<GetAppBitsUploadFeatureFlagResponse>(json);
        
            Assert.AreEqual("app_bits_upload", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/app_bits_upload", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestGetServiceInstanceCreationFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""service_instance_creation"",
  ""enabled"": true,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/service_instance_creation""
}";
    
            GetServiceInstanceCreationFeatureFlagResponse obj = Util.DeserializeJson<GetServiceInstanceCreationFeatureFlagResponse>(json);
        
            Assert.AreEqual("service_instance_creation", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/service_instance_creation", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestGetRouteCreationFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""route_creation"",
  ""enabled"": true,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/route_creation""
}";
    
            GetRouteCreationFeatureFlagResponse obj = Util.DeserializeJson<GetRouteCreationFeatureFlagResponse>(json);
        
            Assert.AreEqual("route_creation", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/route_creation", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestGetUserOrgCreationFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""user_org_creation"",
  ""enabled"": false,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/user_org_creation""
}";
    
            GetUserOrgCreationFeatureFlagResponse obj = Util.DeserializeJson<GetUserOrgCreationFeatureFlagResponse>(json);
        
            Assert.AreEqual("user_org_creation", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("false", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/user_org_creation", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestGetPrivateDomainCreationFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""private_domain_creation"",
  ""enabled"": true,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/private_domain_creation""
}";
    
            GetPrivateDomainCreationFeatureFlagResponse obj = Util.DeserializeJson<GetPrivateDomainCreationFeatureFlagResponse>(json);
        
            Assert.AreEqual("private_domain_creation", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/private_domain_creation", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestSetFeatureFlagRequest()
        {
            string json = @"{
  ""enabled"": true
}";
    
            SetFeatureFlagRequest obj = Util.DeserializeJson<SetFeatureFlagRequest>(json);
        
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
        }

    
        [TestMethod]
        public void TestSetFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""user_org_creation"",
  ""enabled"": true,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/user_org_creation""
}";
    
            SetFeatureFlagResponse obj = Util.DeserializeJson<SetFeatureFlagResponse>(json);
        
            Assert.AreEqual("user_org_creation", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/user_org_creation", TestUtil.ToTestableString(obj.Url), true);
        }

    
        [TestMethod]
        public void TestGetAppScalingFeatureFlagResponse()
        {
            string json = @"{
  ""name"": ""app_scaling"",
  ""enabled"": true,
  ""error_message"": null,
  ""url"": ""/v2/config/feature_flags/app_scaling""
}";
    
            GetAppScalingFeatureFlagResponse obj = Util.DeserializeJson<GetAppScalingFeatureFlagResponse>(json);
        
            Assert.AreEqual("app_scaling", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("true", TestUtil.ToTestableString(obj.Enabled), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.ErrorMessage), true);
            Assert.AreEqual("/v2/config/feature_flags/app_scaling", TestUtil.ToTestableString(obj.Url), true);
        }

    }
}
