using cf_net_sdk_pcl.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk_test.Exceptions
{
     [TestClass]
    public class Test_CloudFoundryException
    {
         [TestMethod]
         public void TestException()
         {
             CloudFoundryExceptionObject exceptionObject = new CloudFoundryExceptionObject();
             exceptionObject.Code = "object";
             exceptionObject.Description = "this is an exception";
             exceptionObject.ErrorCode = "errorCode";

             CloudFoundryException exception = new CloudFoundryException(exceptionObject);

             Assert.AreEqual(exception.Message, "this is an exception");
         }

    }
}
