using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]  
    public class InfoTest
    {
        [TestMethod]
        public void GetInfo_test()
        {
            var client = TestUtil.GetClient();

            var clientResponse = client.Info.GetInfo().Result;

            Assert.IsNotNull(clientResponse.ApiVersion);
        }
    }
}
