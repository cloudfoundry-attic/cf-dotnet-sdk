using CloudFoundry.CloudController.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Exceptions
{
    public class CloudFoundryException : Exception
    {

        public IHttpResponseAbstraction Response { get; set; }

        public CloudFoundryExceptionObject ExceptionObject { get; set; }

        public CloudFoundryException()
        {

        }
        public CloudFoundryException(string message) : base(message)
        {
            
        }

        public CloudFoundryException(CloudFoundryExceptionObject exceptionObject)
            : base(exceptionObject.Description)
        {
            this.ExceptionObject = exceptionObject;
        }

        public CloudFoundryException(string message,
            Exception innerException)
            : base(message, innerException)
        {

        }



        
    }
}
