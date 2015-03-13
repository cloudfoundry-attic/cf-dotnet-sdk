namespace CloudFoundry.CloudController.Common.Exceptions
{
    using System;
    using CloudFoundry.CloudController.Common.Http;

    /// <summary>
    /// Exception class raised when something goes wrong in calling the Cloud Foundry endpoints.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "Compatibility with PCL"), 
    System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "Compatibility with PCL")]
    public class CloudFoundryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryException"/> class.
        /// </summary>
        public CloudFoundryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CloudFoundryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CloudFoundryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryException"/> class.
        /// </summary>
        /// <param name="exceptionObject">The exception object.</param>
        public CloudFoundryException(CloudFoundryExceptionObject exceptionObject)
            : base(ValidateExceptionObject(exceptionObject).Description)
        {
            this.ExceptionObject = exceptionObject;
        }

        /// <summary>
        /// Gets or sets the exception object.
        /// </summary>
        /// <value>
        /// The exception object.
        /// </value>
        public CloudFoundryExceptionObject ExceptionObject { get; private set; }

        /// <summary>
        /// Gets or sets the http response.
        /// </summary>
        /// <value>
        /// The http response.
        /// </value>
        public SimpleHttpResponse Response { get; set; }

        /// <summary>
        /// Validates the exception object.
        /// </summary>
        /// <param name="exceptionObject">The exception object.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">exceptionObject</exception>
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