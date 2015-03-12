namespace CloudFoundry.Loggregator.Client
{
    /// <summary>
    /// Enumeration of Application log message types
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "Loggregator only returns 1 or 2")]
    public enum ApplicationLogMessageType
    {
        /// <summary>
        /// Application log message is output
        /// </summary>
        Output = 1,

        /// <summary>
        /// Application log message is error
        /// </summary>
        Error = 2
    }
}
