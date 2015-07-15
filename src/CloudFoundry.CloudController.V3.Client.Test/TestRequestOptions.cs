using CloudFoundry.UAA.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V3.Client.Test
{
    [TestClass]
    public class TestRequestOptions
    {
        [TestMethod]
        public void TestOptions()
        {
            RequestOptions options = new RequestOptions();
            options.Query.Add("names", new string[] { "name1", "name2" });
            options.Query.Add("space_guids", new string[] { "space_guid1", "space_guid2" });
            options.Query.Add("organization_guids", new string[] { "org_guid1", "org_guid2" });
            options.ResultsPerPage = 5;
            options.OrderDirection = "asc";
            options.Page = 1;
            options.OrderBy = "updated_at";

            string query = options.ToString();

            Assert.IsTrue(query.Contains("organization_guids[]=org_guid1&organization_guids[]=org_guid2"));
            Assert.IsTrue(query.Contains("space_guids[]=space_guid1&space_guids[]=space_guid2"));
            Assert.IsTrue(query.Contains("names[]=name1&names[]=name2"));
            Assert.IsTrue(query.Contains("per_page=5"));
            Assert.IsTrue(query.Contains("order_direction=asc"));
            Assert.IsTrue(query.Contains("order_by=updated_at"));
            Assert.IsTrue(query.Contains("page=1"));
        }
    }
}
