namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    using System;

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
        /// <typeparam name="TInterface">The interface of the service to be registered.</typeparam>
        /// <typeparam name="TClass">A concrete type of the service to be returned by the service locator.</typeparam>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is shorthand (no 'typeof') for RegisterServiceType(typeof(TInterface), typeof(TClass))")]
        void RegisterServiceType<TInterface, TClass>() where TClass : class, TInterface;

        /// <summary>
        /// Registers a type of a service with the service locator.
        /// </summary>
        /// <param name="type">The interface of the service to be registered.</param>
        /// <param name="registrationValue">A concrete type of the service to be returned by the service locator.</param>
        void RegisterServiceType(Type type, Type registrationValue);
    }
}