namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using CloudFoundry.CloudController.Common.Http;

    /// <inheritdoc/>
    public class DependencyLocator : IDependencyLocator
    {
        private readonly Dictionary<Type, object> overrideDependencies = new Dictionary<Type, object>();
        private readonly DependencyLocationManager runtimeManager;
        private readonly IDependencyLocationAssemblyScanner scanner = new DependencyLocationAssemblyScanner();
        private readonly Dictionary<Type, object> dependencies = new Dictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyLocator"/> class.
        /// </summary>
        public DependencyLocator()
        {
            this.runtimeManager = new DependencyLocationRuntimeManager(this);
            this.dependencies.Add(typeof(IDependencyLocationRuntimeManager), this.runtimeManager);
            this.dependencies.Add(typeof(IDependencyLocationOverrideManager), new DependencyLocationOverrideManager(this));
            this.dependencies.Add(typeof(IHttpAbstractionClientFactory), new HttpAbstractionClientFactory());
            this.scanner.AddAssembly(this.GetType().GetAssembly());
            this.RegisterDependencies();
        }

        /// <summary>
        /// Ensures that the given assembly has been registered with the DependencyLocator for dependency location.
        /// </summary>
        /// <param name="target">The target assembly.</param>
        public void EnsureAssemblyRegistration(Assembly target)
        {
            this.scanner.AddAssembly(target);
            var registrars = this.scanner.GetNewRegistrars();
            this.RegisterDependencies(registrars);
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
                this.RegisterDependencies();
                retval = this.InternalLocate(type);
            }

            if (retval != null)
            {
                return retval;
            }

            var message = string.Format(
                CultureInfo.InvariantCulture,
                "Dependency '{0}' has not been registered",
                type.FullName);
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Registers the dependencies.
        /// </summary>
        /// <param name="registrars">The registrars.</param>
        internal void RegisterDependencies(IEnumerable<IDependencyLocationRegistrar> registrars)
        {
            foreach (var dependencyLocationRegistrar in registrars)
            {
                dependencyLocationRegistrar.Register(this.runtimeManager, this);
            }
        }

        internal void RegisterDependencies()
        {
            var registrars = this.scanner.GetRegistrars().ToList();
            this.RegisterDependencies(registrars);
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
            if (!this.overrideDependencies.TryGetValue(type, out overrideVersion))
            {
                // if no override, then try to get the actual dependency.
                this.dependencies.TryGetValue(type, out runtimeVersion);
            }

            return overrideVersion ?? runtimeVersion;
        }

        /// <inheritdoc/>
        private class DependencyLocationOverrideManager : DependencyLocationManager, IDependencyLocationOverrideManager
        {
            private readonly DependencyLocator locator;

            /// <inheritdoc/>
            public DependencyLocationOverrideManager(DependencyLocator locator)
            {
                this.locator = locator;
            }

            /// <inheritdoc/>
            public override void RegisterDependencyInstance(Type type, object instance)
            {
                DependencyLocationManager.ThrowIfNullInstance(type, instance);
                DependencyLocationManager.ThrowIfInvalidRegistration(type, instance.GetType());

                this.locator.overrideDependencies[type] = instance;
            }
        }

        /// <inheritdoc/>
        private class DependencyLocationRuntimeManager : DependencyLocationManager, IDependencyLocationRuntimeManager
        {
            private readonly DependencyLocator locator;

            /// <inheritdoc/>
            public DependencyLocationRuntimeManager(DependencyLocator locator)
            {
                this.locator = locator;
            }

            /// <inheritdoc />
            public override void RegisterDependencyInstance(Type type, object instance)
            {
                DependencyLocationManager.ThrowIfNullInstance(type, instance);
                DependencyLocationManager.ThrowIfInvalidRegistration(type, instance.GetType());
                var internalManager = new RuntimeRegistrationManager(this.locator);
                internalManager.RegisterDependencyInstance(type, instance);
                foreach (KeyValuePair<Type, object> keyValuePair in internalManager.GetDiscovered())
                {
                    this.locator.dependencies[keyValuePair.Key] = keyValuePair.Value;
                }
            }
        }
    }
}
