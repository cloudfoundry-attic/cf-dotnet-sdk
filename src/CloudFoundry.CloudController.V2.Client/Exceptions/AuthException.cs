using System;

namespace CloudFoundry.CloudController.V2.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message)
            : base(message)
        {
        }

        public AuthenticationException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}