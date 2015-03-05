namespace CloudFoundry.Logyard.Client
{
    using System;

    /// <summary>
    /// Exception class raised when something goes wrong while trying to communicate with Logyard.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "PCL compatibilty"),
    System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "PCL compatibilty")]
    public class LogyardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogyardException"/> class.
        /// </summary>
        public LogyardException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogyardException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LogyardException(string message)
            : base(message)
        {
        }
    }
}