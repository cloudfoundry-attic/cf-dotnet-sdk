using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.Manifests.Models;
using System.Collections.Generic;
using System.Linq;
using CloudFoundry.Manifests;

namespace CloudFoundry.CloudController.V2.Client.Test.Manifests
{
    [TestClass]
    public class UtilTest
    {
        [TestMethod]
        public void TestMergeDictionaries()
        {
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>()
            {
                { "stack", "win2012r2"},
                {
                    "applications", new List<Dictionary<string, object>>(){
                    new Dictionary<string, object>(){
                        {"name", "test1"},
                        {"services", new List<string>(){ "service1", "service2" } },
                        {"instances", 1},
                        {"memory", "128MB"}
                        }
                    }
                },
                {"env", new Dictionary<string, object>() {
                    {"env1", "val1"}
                }},
                { "domains", new List<string>(){"mydomain.com"} }
            };

            Dictionary<string, object> dictionary2 = new Dictionary<string, object>()
            {
                {
                    "applications", new List<Dictionary<string, object>>(){
                    new Dictionary<string, object>(){
                        {"name", "test2"},
                        {"services", new List<string>(){ "service3", "service4" } },
                        {"instances", 1},
                        {"memory", "512MB"}
                        }
                    }
                        
                },
                {"env", new Dictionary<string, object>() {
                    {"env2", "val2"}
                }},
                { "domains", new List<string>(){"myotherdomain.com"} }
            };

            Dictionary<string, object> merged = Util.MergeDictionaries(dictionary1, dictionary2);
            Assert.IsNotNull(merged);
            Assert.AreEqual("win2012r2", merged["stack"]);
            Assert.AreEqual(2, ((List<Dictionary<string, object>>)merged["applications"]).Count);
            Assert.AreEqual("512MB", ((List<Dictionary<string, object>>)merged["applications"]).Where(x => x["name"].ToString() == "test2").FirstOrDefault()["memory"]);
        }
    }
}
