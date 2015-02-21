namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc/>
    internal class RuntimeRegistrationManager : ServiceLocationManager
    {
        private readonly Dictionary<Type, object> discovered = new Dictionary<Type, object>();
        private IServiceLocator locator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeRegistrationManager"/> class.
        /// </summary>
        /// <param name="locator">A reference to a service locator.</param>
        public RuntimeRegistrationManager(IServiceLocator locator)
        {
            this.locator = locator;
        }

        /// <summary>
        /// Gets a list of types and objects that have been discovered/registered.
        /// </summary>
        /// <returns>An enumerable list of types and instances.</returns>
        public IEnumerable<KeyValuePair<Type, object>> GetDiscovered()
        {
            return this.discovered;
        }

        /// <inheritdoc/>
        public override void RegisterServiceInstance(Type serviceType, object instance)
        {
            var registering = instance as IServiceLocationRegistrar;
            object discoveredInstance;
            if (this.discovered.TryGetValue(serviceType, out discoveredInstance))
            {
                if (!object.ReferenceEquals(discoveredInstance, instance) && !object.ReferenceEquals(registering, null))
                {
                    this.discovered[serviceType] = instance;
                    registering.Register(this, this.locator);
                }
            }
            else
            {
                this.discovered[serviceType] = instance;
                if (!object.ReferenceEquals(registering, null))
                {
                    registering.Register(this, this.locator);
                }
            }
        }
    }
}