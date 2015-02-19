using System;

namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    /// <summary>
    /// Represents an object that can manage service location registration.
    /// </summary>
    public interface IServiceLocationManager
    {
        /// <summary>
        /// Registers an instance of a service with the service locator.
        /// </summary>
        /// <typeparam name="TService">The interface of the service to be registered.</typeparam>
        /// <param name="instance">An instance of the service to be returned by the service locator.</param>
        void RegisterServiceInstance<TService>(TService instance);

        /// <summary>
        /// Registers an instance of a service with the service locator.
        /// </summary>
        /// <param name="type">The interface of the service to be registered.</param>
        /// <param name="instance">An instance of the service to be returned by the service locator.</param>
        void RegisterServiceInstance(Type type, object instance);

        /// <summary>
        /// Registers a type of a service with the service locator.
        /// </summary>
        /// <typeparam name="T">The interface of the service to be registered.</typeparam>
        /// <param name="type">A concrete type of the service to be returned by the service locator.</param>
        void RegisterServiceType<T>(Type type);

        /// <summary>
        /// Registers a type of a service with the service locator.
        /// </summary>
        /// <typeparam name="TInterface">The interface of the service to be registered.</typeparam>
        /// <typeparam name="TConcretion">A concrete type of the service to be returned by the service locator.</typeparam>
        void RegisterServiceType<TInterface, TConcretion>() where TConcretion : class, TInterface;

        /// <summary>
        /// Registers a type of a service with the service locator.
        /// </summary>
        /// <param name="type">The interface of the service to be registered.</param>
        /// <param name="registrationValue">A concrete type of the service to be returned by the service locator.</param>
        void RegisterServiceType(Type type, Type registrationValue);
    }
}
