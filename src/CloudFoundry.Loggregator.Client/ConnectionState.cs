namespace CloudFoundry.Loggregator.Client
{
    /// <summary>
    /// Enumeration of possible connection states.
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        /// Websocket has no connection.
        /// </summary>
        None,

        /// <summary>
        /// Websocket is currently connecting.
        /// </summary>
        Connecting,
        
        /// <summary>
        /// Websocket is open.
        /// </summary>
        Open,
        
        /// <summary>
        /// Websocket is currently closing.
        /// </summary>
        Closing,
        
        /// <summary>
        /// Websocket is closed.
        /// </summary>
        Closed
    }
}