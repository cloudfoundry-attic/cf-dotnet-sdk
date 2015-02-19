using System;
using System.Collections.Generic;

namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    /// <inheritdoc/>
    internal class RuntimeRegistrationManager : ServiceLocationManager
    {
        private IServiceLocator locator;

        /// <summary>
        /// Constructs a new instance of the RuntimeRegistrationManager class.
        /// </summary>
        /// <param name="locator">A reference to a service locator.</param>
        public RuntimeRegistrationManager(IServiceLocator locator)
        {
            this.locator = locator;
        }

        private readonly Dictionary<Type, object> _discovered = new Dictionary<Type, object>();

        /// <inheritdoc/>
        public override void RegisterServiceInstance(Type serviceType, object instance)
        {
            var registering = instance as IServiceLocationRegistrar;
            object discoveredInstance;
            if (this._discovered.TryGetValue(serviceType,
                                            out discoveredInstance))
            {
                if (!ReferenceEquals(discoveredInstance,
                                     instance) && !ReferenceEquals(registering,
                                                                   null))
                { 
                    this._discovered[serviceType] = instance;
                    registering.Register(this, this.locator);
                }
            }
            else
            {
                this._discovered[serviceType] = instance;
                if (!ReferenceEquals(registering,
                                     null))
                {
                    registering.Register(this, this.locator);
                }
            }
        }

        /// <summary>
        /// Gets a list of types and objects that have been discovered/registered.
        /// </summary>
        /// <returns>An enumerable list of types and instances.</returns>
        public IEnumerable<KeyValuePair<Type, object>> GetDiscovered()
        {
            return this._discovered;
        }
    }
}
