namespace CloudFoundry.Logyard.Client
{
    using System;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "PCL compatibilty"),
    System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "PCL compatibilty")]
    public class LogyardException : Exception
    {
        public LogyardException()
        {
        }

        public LogyardException(string message)
            : base(message)
        {
        }
    }
}