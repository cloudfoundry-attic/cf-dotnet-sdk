using System;
using System.Reflection;

namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    /// <summary>
    /// Represents an object that can locate services.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Locates an instance of the requested service.
        /// </summary>
        /// <typeparam name="T">The type of the service to locate.</typeparam>
        /// <returns>An instance of the service.</returns>
        T Locate<T>();

        /// <summary>
        /// Ensures that the given assembly has been registered with the ServiceLocator for service location.
        /// </summary>
        /// <param name="target">The target assembly.</param>
        void EnsureAssemblyRegistration(Assembly target);
    }
}
