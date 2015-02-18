using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.CloudController.V2;

namespace CloudFoundry.CloudController.V2.Test.Deserialization
{
    [TestClass]
    public class ServiceBrokersTest
    {

    
        [TestMethod]
        public void TestListAllServiceBrokersResponse()
        {
            string json = @"{
  ""total_results"": 3,
  ""total_pages"": 1,
  ""prev_url"": null,
  ""next_url"": null,
  ""resources"": [
    {
      ""metadata"": {
        ""guid"": ""53710b84-7647-469e-8e2d-be4a6e45399c"",
        ""url"": ""/v2/service_brokers/53710b84-7647-469e-8e2d-be4a6e45399c"",
        ""created_at"": ""2014-11-12T12:59:37+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-761"",
        ""broker_url"": ""https://foo.com/url-49"",
        ""auth_username"": ""auth_username-11""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""08e0e071-bca6-4ce0-a089-f5e775307109"",
        ""url"": ""/v2/service_brokers/08e0e071-bca6-4ce0-a089-f5e775307109"",
        ""created_at"": ""2014-11-12T12:59:37+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-762"",
        ""broker_url"": ""https://foo.com/url-50"",
        ""auth_username"": ""auth_username-12""
      }
    },
    {
      ""metadata"": {
        ""guid"": ""717b082b-7c1c-4796-acc3-2b25713106b2"",
        ""url"": ""/v2/service_brokers/717b082b-7c1c-4796-acc3-2b25713106b2"",
        ""created_at"": ""2014-11-12T12:59:37+02:00"",
        ""updated_at"": null
      },
      ""entity"": {
        ""name"": ""name-763"",
        ""broker_url"": ""https://foo.com/url-51"",
        ""auth_username"": ""auth_username-13""
      }
    }
  ]
}";
    
            PagedResponse<ListAllServiceBrokersResponse> page = Util.DeserializePage<ListAllServiceBrokersResponse>(json);
        
            Assert.AreEqual("3", TestUtil.ToTestableString(page.Properties.TotalResults), true);
        
            Assert.AreEqual("1", TestUtil.ToTestableString(page.Properties.TotalPages), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.PrevUrl), true);
        
            Assert.AreEqual("", TestUtil.ToTestableString(page.Properties.NextUrl), true);
        
            
        
            
            
                Assert.AreEqual("53710b84-7647-469e-8e2d-be4a6e45399c", TestUtil.ToTestableString(page[0].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_brokers/53710b84-7647-469e-8e2d-be4a6e45399c", TestUtil.ToTestableString(page[0].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(page[0].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[0].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-761", TestUtil.ToTestableString(page[0].Name), true);
                  Assert.AreEqual("https://foo.com/url-49", TestUtil.ToTestableString(page[0].BrokerUrl), true);
                  Assert.AreEqual("auth_username-11", TestUtil.ToTestableString(page[0].AuthUsername), true);
               
               
            
            
                Assert.AreEqual("08e0e071-bca6-4ce0-a089-f5e775307109", TestUtil.ToTestableString(page[1].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_brokers/08e0e071-bca6-4ce0-a089-f5e775307109", TestUtil.ToTestableString(page[1].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(page[1].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[1].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-762", TestUtil.ToTestableString(page[1].Name), true);
                  Assert.AreEqual("https://foo.com/url-50", TestUtil.ToTestableString(page[1].BrokerUrl), true);
                  Assert.AreEqual("auth_username-12", TestUtil.ToTestableString(page[1].AuthUsername), true);
               
               
            
            
                Assert.AreEqual("717b082b-7c1c-4796-acc3-2b25713106b2", TestUtil.ToTestableString(page[2].EntityMetadata.Guid), true);
                Assert.AreEqual("/v2/service_brokers/717b082b-7c1c-4796-acc3-2b25713106b2", TestUtil.ToTestableString(page[2].EntityMetadata.Url), true);
                Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(page[2].EntityMetadata.CreatedAt), true);
                Assert.AreEqual("", TestUtil.ToTestableString(page[2].EntityMetadata.UpdatedAt), true);
                  Assert.AreEqual("name-763", TestUtil.ToTestableString(page[2].Name), true);
                  Assert.AreEqual("https://foo.com/url-51", TestUtil.ToTestableString(page[2].BrokerUrl), true);
                  Assert.AreEqual("auth_username-13", TestUtil.ToTestableString(page[2].AuthUsername), true);
               
               
            
    
        }

    
        [TestMethod]
        public void TestRetrieveServiceBrokerResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""943410ce-8e01-4917-ab91-2feeaea54ca2"",
    ""url"": ""/v2/service_brokers/943410ce-8e01-4917-ab91-2feeaea54ca2"",
    ""created_at"": ""2014-11-12T12:59:37+02:00"",
    ""updated_at"": null
  },
  ""entity"": {
    ""name"": ""name-770"",
    ""broker_url"": ""https://foo.com/url-58"",
    ""auth_username"": ""auth_username-20""
  }
}";
    
            RetrieveServiceBrokerResponse obj = Util.DeserializeJson<RetrieveServiceBrokerResponse>(json);
        
            Assert.AreEqual("943410ce-8e01-4917-ab91-2feeaea54ca2", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("/v2/service_brokers/943410ce-8e01-4917-ab91-2feeaea54ca2", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("name-770", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("https://foo.com/url-58", TestUtil.ToTestableString(obj.BrokerUrl), true);
            Assert.AreEqual("auth_username-20", TestUtil.ToTestableString(obj.AuthUsername), true);
            
            
        }

    
        [TestMethod]
        public void TestCreateServiceBrokerResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""6705c804-a226-47b5-9304-a36e46ceb3b1"",
    ""created_at"": ""2014-11-12T12:59:37+02:00"",
    ""updated_at"": null,
    ""url"": ""/v2/service_brokers/6705c804-a226-47b5-9304-a36e46ceb3b1""
  },
  ""entity"": {
    ""name"": ""service-broker-name"",
    ""broker_url"": ""https://broker.example.com"",
    ""auth_username"": ""admin""
  }
}";
    
            CreateServiceBrokerResponse obj = Util.DeserializeJson<CreateServiceBrokerResponse>(json);
        
            Assert.AreEqual("6705c804-a226-47b5-9304-a36e46ceb3b1", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("/v2/service_brokers/6705c804-a226-47b5-9304-a36e46ceb3b1", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("service-broker-name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("https://broker.example.com", TestUtil.ToTestableString(obj.BrokerUrl), true);
            Assert.AreEqual("admin", TestUtil.ToTestableString(obj.AuthUsername), true);
            
            
        }

    
        [TestMethod]
        public void TestUpdateServiceBrokerResponse()
        {
            string json = @"{
  ""metadata"": {
    ""guid"": ""f8f9189f-8598-46ea-a17c-b95a666d408a"",
    ""created_at"": ""2014-11-12T12:59:37+02:00"",
    ""updated_at"": ""2014-11-12T12:59:37+02:00"",
    ""url"": ""/v2/service_brokers/f8f9189f-8598-46ea-a17c-b95a666d408a""
  },
  ""entity"": {
    ""name"": ""service-broker-name"",
    ""broker_url"": ""https://broker.example.com"",
    ""auth_username"": ""admin""
  }
}";
    
            UpdateServiceBrokerResponse obj = Util.DeserializeJson<UpdateServiceBrokerResponse>(json);
        
            Assert.AreEqual("f8f9189f-8598-46ea-a17c-b95a666d408a", TestUtil.ToTestableString(obj.EntityMetadata.Guid), true);
            Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(obj.EntityMetadata.CreatedAt), true);
            Assert.AreEqual("2014-11-12T12:59:37+02:00", TestUtil.ToTestableString(obj.EntityMetadata.UpdatedAt), true);
            Assert.AreEqual("/v2/service_brokers/f8f9189f-8598-46ea-a17c-b95a666d408a", TestUtil.ToTestableString(obj.EntityMetadata.Url), true);
            Assert.AreEqual("service-broker-name", TestUtil.ToTestableString(obj.Name), true);
            Assert.AreEqual("https://broker.example.com", TestUtil.ToTestableString(obj.BrokerUrl), true);
            Assert.AreEqual("admin", TestUtil.ToTestableString(obj.AuthUsername), true);
            
            
        }

    }
}
