namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System;

    /// <inheritdoc/>
    internal class DependencyLocationRegistrarFactory : IDependencyLocationRegistrarFactory
    {
        /// <inheritdoc/>
        public IDependencyLocationRegistrar Create(Type type)
        {
            return (IDependencyLocationRegistrar)Activator.CreateInstance(type);
        }
    }
}