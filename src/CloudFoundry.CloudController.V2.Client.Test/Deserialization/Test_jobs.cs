using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class JobsTest
    {

    
        [TestMethod]
        public void TestRetrieveJobWithKnownFailureResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""70c60f01-faab-43ca-b0e6-8040332624a4"",
    ""created_at"": ""2014-11-12T12:59:43+02:00"",
    ""url"": ""/v2/jobs/70c60f01-faab-43ca-b0e6-8040332624a4""
  },
  ""entity"": {
    ""guid"": ""70c60f01-faab-43ca-b0e6-8040332624a4"",
    ""status"": ""failed"",
    ""error"": ""Use of entity>error is deprecated in favor of entity>error_details."",
    ""error_details"": {
      ""code"": 1001,
      ""description"": ""Request invalid due to parse error: arbitrary string"",
      ""error_code"": ""CF-MessageParseError""
    }
  }
}";
    
            RetrieveJobWithKnownFailureResponse obj = Util.DeserializeJson<RetrieveJobWithKnownFailureResponse>(json);
        
            Assert.AreEqual("70c60f01-faab-43ca-b0e6-8040332624a4", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:43+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("/v2/jobs/70c60f01-faab-43ca-b0e6-8040332624a4", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("70c60f01-faab-43ca-b0e6-8040332624a4", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("failed", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("Use of entity>error is deprecated in favor of entity>error_details.", TestUtil.ToTestableString(obj.Error), true);
            
            
            
        }

    
        [TestMethod]
        public void TestRetrieveJobThatIsQueuedResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""b68a5673-99f4-4d4a-95f9-412ca255e9d2"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""url"": ""/v2/jobs/b68a5673-99f4-4d4a-95f9-412ca255e9d2""
  },
  ""entity"": {
    ""guid"": ""b68a5673-99f4-4d4a-95f9-412ca255e9d2"",
    ""status"": ""queued""
  }
}";
    
            RetrieveJobThatIsQueuedResponse obj = Util.DeserializeJson<RetrieveJobThatIsQueuedResponse>(json);
        
            Assert.AreEqual("b68a5673-99f4-4d4a-95f9-412ca255e9d2", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("/v2/jobs/b68a5673-99f4-4d4a-95f9-412ca255e9d2", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("b68a5673-99f4-4d4a-95f9-412ca255e9d2", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("queued", TestUtil.ToTestableString(obj.Status), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveJobThatWasSuccessfulResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""0"",
    ""created_at"": ""1970-01-01T02:00:00+02:00"",
    ""url"": ""/v2/jobs/0""
  },
  ""entity"": {
    ""guid"": ""0"",
    ""status"": ""finished""
  }
}";
    
            RetrieveJobThatWasSuccessfulResponse obj = Util.DeserializeJson<RetrieveJobThatWasSuccessfulResponse>(json);
        
            Assert.AreEqual("0", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("1970-01-01T02:00:00+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("/v2/jobs/0", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("0", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("finished", TestUtil.ToTestableString(obj.Status), true);
            
            
        }

    
        [TestMethod]
        public void TestRetrieveJobWithUnknownFailureResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""217b2e50-8b5c-482e-8e34-ff6f53c9eb26"",
    ""created_at"": ""2014-11-12T12:59:44+02:00"",
    ""url"": ""/v2/jobs/217b2e50-8b5c-482e-8e34-ff6f53c9eb26""
  },
  ""entity"": {
    ""guid"": ""217b2e50-8b5c-482e-8e34-ff6f53c9eb26"",
    ""status"": ""failed"",
    ""error"": ""Use of entity>error is deprecated in favor of entity>error_details."",
    ""error_details"": {
      ""error_code"": ""UnknownError"",
      ""description"": ""An unknown error occurred."",
      ""code"": 10001
    }
  }
}";
    
            RetrieveJobWithUnknownFailureResponse obj = Util.DeserializeJson<RetrieveJobWithUnknownFailureResponse>(json);
        
            Assert.AreEqual("217b2e50-8b5c-482e-8e34-ff6f53c9eb26", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:44+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("/v2/jobs/217b2e50-8b5c-482e-8e34-ff6f53c9eb26", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("217b2e50-8b5c-482e-8e34-ff6f53c9eb26", TestUtil.ToTestableString(obj.Guid), true);
            Assert.AreEqual("failed", TestUtil.ToTestableString(obj.Status), true);
            Assert.AreEqual("Use of entity>error is deprecated in favor of entity>error_details.", TestUtil.ToTestableString(obj.Error), true);
            
            
            
        }

    }
}
