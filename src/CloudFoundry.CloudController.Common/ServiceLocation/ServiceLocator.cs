namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using CloudFoundry.CloudController.Common.Http;

    /// <inheritdoc/>
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> overrideServices = new Dictionary<Type, object>();
        private readonly ServiceLocationManager runtimeManager;
        private readonly IServiceLocationAssemblyScanner scanner = new ServiceLocationAssemblyScanner();
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public ServiceLocator()
        {
            this.runtimeManager = new ServiceLocationRuntimeManager(this);
            this.services.Add(typeof(IServiceLocationRuntimeManager), this.runtimeManager);
            this.services.Add(typeof(IServiceLocationOverrideManager), new ServiceLocationOverrideManager(this));
            this.services.Add(typeof(IHttpAbstractionClientFactory), new HttpAbstractionClientFactory());
            this.scanner.AddAssembly(this.GetType().GetAssembly());
            this.RegisterServices();
        }

        public void EnsureAssemblyRegistration(Assembly target)
        {
            this.scanner.AddAssembly(target);
            var registrars = this.scanner.GetNewRegistrars();
            this.RegisterServices(registrars);
        }

        /// <inheritdoc/>
        public T Locate<T>()
        {
            return (T)this.Locate(typeof(T));
        }

        /// <summary>
        /// Locates an implementation of the given Type.
        /// </summary>
        /// <param name="type">The Type to locate.</param>
        /// <returns>The implementation of the given type that has been located.</returns>
        internal object Locate(Type type)
        {
            var retval = this.InternalLocate(type);
            if (retval != null)
            {
                return retval;
            }

            if (this.scanner.HasNewAssemblies)
            {
                this.RegisterServices();
                retval = this.InternalLocate(type);
            }

            if (retval != null)
            {
                return retval;
            }

            var message = string.Format(
                CultureInfo.InvariantCulture,
                "Service '{0}' has not been registered",
                type.FullName);
            throw new InvalidOperationException(message);
        }

        internal void RegisterServices(IEnumerable<IServiceLocationRegistrar> registrars)
        {
            foreach (var serviceLocationRegistrar in registrars)
            {
                serviceLocationRegistrar.Register(this.runtimeManager, this);
            }
        }

        internal void RegisterServices()
        {
            var registrars = this.scanner.GetRegistrars().ToList();
            this.RegisterServices(registrars);
        }

        /// <summary>
        /// Locates an implementation of the given Type.
        /// </summary>
        /// <param name="type">The Type to locate.</param>
        /// <returns>The implementation of the given type that has been located.</returns>
        private object InternalLocate(Type type)
        {
            if (ReferenceEquals(type, null))
            {
                throw new ArgumentNullException("type");
            }

            object runtimeVersion = null;
            object overrideVersion = null;

            // First try to get a an override
            if (!this.overrideServices.TryGetValue(type, out overrideVersion))
            {
                // if no override, then try to get the actual service.
                this.services.TryGetValue(type, out runtimeVersion);
            }

            return overrideVersion ?? runtimeVersion;
        }

        /// <inheritdoc/>
        private class ServiceLocationOverrideManager : ServiceLocationManager, IServiceLocationOverrideManager
        {
            private readonly ServiceLocator locator;

            /// <inheritdoc/>
            public ServiceLocationOverrideManager(ServiceLocator locator)
            {
                this.locator = locator;
            }

            /// <inheritdoc/>
            public override void RegisterServiceInstance(Type type, object instance)
            {
                ServiceLocationManager.ThrowIfNullInstance(type, instance);
                ServiceLocationManager.ThrowIfInvalidRegistration(type, instance.GetType());

                this.locator.overrideServices[type] = instance;
            }
        }

        /// <inheritdoc/>
        private class ServiceLocationRuntimeManager : ServiceLocationManager, IServiceLocationRuntimeManager
        {
            private readonly ServiceLocator locator;

            /// <inheritdoc/>
            public ServiceLocationRuntimeManager(ServiceLocator locator)
            {
                this.locator = locator;
            }

            /// <inheritdoc />
            public override void RegisterServiceInstance(Type type, object instance)
            {
                ServiceLocationManager.ThrowIfNullInstance(type, instance);
                ServiceLocationManager.ThrowIfInvalidRegistration(type, instance.GetType());
                var internalManager = new RuntimeRegistrationManager(this.locator);
                internalManager.RegisterServiceInstance(type, instance);
                foreach (KeyValuePair<Type, object> keyValuePair in internalManager.GetDiscovered())
                {
                    this.locator.services[keyValuePair.Key] = keyValuePair.Value;
                }
            }
        }
    }
}
