using CloudFoundry.CloudController.Common.Http;
using System;

namespace CloudFoundry.CloudController.V2.Exceptions
{
    public class CloudFoundryException : Exception
    {
        public IHttpResponseAbstraction Response { get; set; }

        public CloudFoundryExceptionObject ExceptionObject { get; set; }

        public CloudFoundryException()
        {
        }

        public CloudFoundryException(string message)
            : base(message)
        {
        }

        public CloudFoundryException(CloudFoundryExceptionObject exceptionObject)
            : base(ValidateExceptionObject(exceptionObject).Description)
        {
            this.ExceptionObject = exceptionObject;
        }

        public CloudFoundryException(string message,
            Exception innerException)
            : base(message, innerException)
        {
        }

        private static CloudFoundryExceptionObject ValidateExceptionObject(CloudFoundryExceptionObject exceptionObject)
        {
            if (exceptionObject == null)
            {
                throw new ArgumentNullException("exceptionObject");
            }

            return exceptionObject;
        }
    }
}