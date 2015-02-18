using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class InfoTest
    {

    
        [TestMethod]
        public void TestGetInfoResponse()
        {
            string json = @"{""name"":""vcap"",""build"":""2222"",""support"":""http://support.cloudfoundry.com"",""version"":2,""description"":""Cloud Foundry sponsored by Pivotal"",""authorization_endpoint"":""http://localhost:8080/uaa"",""token_endpoint"":""http://localhost:8080/uaa"",""api_version"":""2.17.0"",""logging_endpoint"":""ws://loggregator.vcap.me:80""}";
    
            GetInfoResponse obj = Util.DeserializeJson<GetInfoResponse>(json);
        
            Assert.AreEqual("vcap", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("2222", TestUtil.ToTestableString(obj.Build), true);
            Assert.AreEqual("http://support.cloudfoundry.com", TestUtil.ToTestableString(obj.Support), true);
            Assert.AreEqual("2", TestUtil.ToTestableString(obj.Version), true);
            Assert.AreEqual("Cloud Foundry sponsored by Pivotal", TestUtil.ToTestableString(obj.Description), true);
            Assert.AreEqual("http://localhost:8080/uaa", TestUtil.ToTestableString(obj.AuthorizationEndpoint), true);
            Assert.AreEqual("http://localhost:8080/uaa", TestUtil.ToTestableString(obj.TokenEndpoint), true);
            Assert.AreEqual("2.17.0", TestUtil.ToTestableString(obj.ApiVersion), true);
            Assert.AreEqual("ws://loggregator.vcap.me:80", TestUtil.ToTestableString(obj.LoggingEndpoint), true);
        }

    }
}
