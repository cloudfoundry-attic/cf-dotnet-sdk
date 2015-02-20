using System;

namespace CloudFoundry.CloudController.Common.ServiceLocation
{
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