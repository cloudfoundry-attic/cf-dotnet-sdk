using System;

namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    /// <summary>
    /// Interface for an object that knows how to create service registrars.
    /// </summary>
    interface IServiceLocationRegistrarFactory
    {
        /// <summary>
        /// Creates a service registrar.
        /// </summary>
        /// <param name="type">The type of the service registrar to create.</param>
        /// <returns>An instance of the given registrar type.</returns>
        IServiceLocationRegistrar Create(Type type);
    }
}
