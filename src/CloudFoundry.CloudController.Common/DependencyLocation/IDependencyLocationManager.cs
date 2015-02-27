namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System;

    /// <summary>
    /// Represents an object that can manage dependency location registration.
    /// </summary>
    public interface IDependencyLocationManager
    {
        /// <summary>
        /// Registers an instance of a dependency with the dependency locator.
        /// </summary>
        /// <typeparam name="TDependency">The interface of the dependency to be registered.</typeparam>
        /// <param name="instance">An instance of the dependency to be returned by the dependency locator.</param>
        void RegisterDependencyInstance<TDependency>(TDependency instance);

        /// <summary>
        /// Registers an instance of a dependency with the dependency locator.
        /// </summary>
        /// <param name="type">The interface of the dependency to be registered.</param>
        /// <param name="instance">An instance of the dependency to be returned by the dependency locator.</param>
        void RegisterDependencyInstance(Type type, object instance);

        /// <summary>
        /// Registers a type of a dependency with the dependency locator.
        /// </summary>
        /// <typeparam name="TInterface">The interface of the dependency to be registered.</typeparam>
        /// <typeparam name="TClass">A concrete type of the dependency to be returned by the dependency locator.</typeparam>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is shorthand (no 'typeof') for RegisterDependencyType(typeof(TInterface), typeof(TClass))")]
        void RegisterDependencyType<TInterface, TClass>() where TClass : class, TInterface;

        /// <summary>
        /// Registers a type of a dependency with the dependency locator.
        /// </summary>
        /// <param name="type">The interface of the dependency to be registered.</param>
        /// <param name="registrationValue">A concrete type of the dependency to be returned by the dependency locator.</param>
        void RegisterDependencyType(Type type, Type registrationValue);
    }
}