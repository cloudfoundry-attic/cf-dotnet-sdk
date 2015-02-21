namespace CloudFoundry.CloudController.V2.Exceptions
{
    using System;
    using CloudFoundry.CloudController.Common.Http;

    public class CloudFoundryException : Exception
    {
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

        public CloudFoundryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CloudFoundryExceptionObject ExceptionObject { get; set; }

        public IHttpResponseAbstraction Response { get; set; }

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