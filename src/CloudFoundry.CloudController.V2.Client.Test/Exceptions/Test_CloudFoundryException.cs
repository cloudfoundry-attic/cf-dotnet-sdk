using CloudFoundry.CloudController.V2.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Exceptions
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
