namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc/>
    internal class RuntimeRegistrationManager : DependencyLocationManager
    {
        private readonly Dictionary<Type, object> discovered = new Dictionary<Type, object>();
        private IDependencyLocator locator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeRegistrationManager"/> class.
        /// </summary>
        /// <param name="locator">A reference to a dependency locator.</param>
        public RuntimeRegistrationManager(IDependencyLocator locator)
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
        public override void RegisterDependencyInstance(Type dependencyType, object instance)
        {
            var registering = instance as IDependencyLocationRegistrar;
            object discoveredInstance;
            if (this.discovered.TryGetValue(dependencyType, out discoveredInstance))
            {
                if (!object.ReferenceEquals(discoveredInstance, instance) && !object.ReferenceEquals(registering, null))
                {
                    this.discovered[dependencyType] = instance;
                    registering.Register(this, this.locator);
                }
            }
            else
            {
                this.discovered[dependencyType] = instance;
                if (!object.ReferenceEquals(registering, null))
                {
                    registering.Register(this, this.locator);
                }
            }
        }
    }
}