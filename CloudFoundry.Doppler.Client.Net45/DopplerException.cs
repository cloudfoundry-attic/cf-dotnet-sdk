namespace CloudFoundry.Doppler.Client
{
    using System;

    /// <summary>
    /// Exception class raised when something goes wrong while trying to communicate with Loggregator.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "PCL compatibilty"),
    System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "PCL compatibilty")]
    public class DopplerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggregatorException"/> class.
        /// </summary>
        public DopplerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggregatorException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DopplerException(string message)
            : base(message)
        {
        }
    }
}