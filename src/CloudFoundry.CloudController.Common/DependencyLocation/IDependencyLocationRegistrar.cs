namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    /// <summary>
    /// Represents an object that will register dependencies for location.
    /// </summary>
    public interface IDependencyLocationRegistrar
    {
        /// <summary>
        /// Registers dependencies for location.
        /// </summary>
        /// <param name="manager">A dependency location manager to use for registering dependencies.</param>
        /// <param name="locator">A reference to the dependency locator.</param>
        void Register(IDependencyLocationManager manager, IDependencyLocator locator);
    }
}