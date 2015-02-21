namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    using System;

    /// <inheritdoc/>
    internal class ServiceLocationRegistrarFactory : IServiceLocationRegistrarFactory
    {
        /// <inheritdoc/>
        public IServiceLocationRegistrar Create(Type type)
        {
            return (IServiceLocationRegistrar)Activator.CreateInstance(type);
        }
    }
}