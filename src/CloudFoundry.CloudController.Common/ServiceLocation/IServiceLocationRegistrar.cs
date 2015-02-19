namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    /// <summary>
    /// Represents an object that will register services for location.
    /// </summary>
    public interface IServiceLocationRegistrar
    {
        /// <summary>
        /// Registers services for location.
        /// </summary>
        /// <param name="manager">A service location manager to use for registering services.</param>
        /// <param name="locator">A reference to the service locator.</param>
        void Register(IServiceLocationManager manager, IServiceLocator locator);
    }
}
