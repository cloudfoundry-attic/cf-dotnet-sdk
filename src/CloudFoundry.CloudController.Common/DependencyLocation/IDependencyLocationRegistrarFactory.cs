namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System;

    /// <summary>
    /// Interface for an object that knows how to create dependency registrars.
    /// </summary>
    internal interface IDependencyLocationRegistrarFactory
    {
        /// <summary>
        /// Creates a dependency registrar.
        /// </summary>
        /// <param name="type">The type of the dependency registrar to create.</param>
        /// <returns>An instance of the given registrar type.</returns>
        IDependencyLocationRegistrar Create(Type type);
    }
}