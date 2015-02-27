namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <inheritdoc/>
    internal class DependencyLocationAssemblyScanner : IDependencyLocationAssemblyScanner
    {
        private readonly List<Assembly> assemblies = new List<Assembly>();

        private readonly List<Type> registrars = new List<Type>();

        private Func<IEnumerable<Type>> getRegistrarTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyLocationAssemblyScanner"/> class.
        /// </summary>
        public DependencyLocationAssemblyScanner()
        {
            this.getRegistrarTypes = this.InternalGetRegistrarTypes;
            this.DependencyRegistrarFactory = new DependencyLocationRegistrarFactory();
        }

        /// <inheritdoc/>
        public bool HasNewAssemblies { get; internal set; }

        internal IDependencyLocationRegistrarFactory DependencyRegistrarFactory { get; set; }

        /// <inheritdoc/>
        public void AddAssembly(Assembly target)
        {
            if (!this.assemblies.Contains(target))
            {
                this.assemblies.Add(target);
                this.HasNewAssemblies = true;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<IDependencyLocationRegistrar> GetNewRegistrars()
        {
            var newRegistrars = this.GetNewRegistrarTypes().ToList();
            this.registrars.All(newRegistrars.Remove);
            this.registrars.AddRange(newRegistrars);
            this.HasNewAssemblies = false;

            return this.GetRegistrars(newRegistrars);
        }

        /// <inheritdoc/>
        public IEnumerable<IDependencyLocationRegistrar> GetRegistrars()
        {
            var newRegistrars = this.GetNewRegistrarTypes().ToList();

            this.registrars.All(newRegistrars.Remove);
            this.registrars.AddRange(newRegistrars);
            this.HasNewAssemblies = false;

            return this.GetRegistrars(this.registrars);
        }

        /// <inheritdoc/>
        internal IEnumerable<Type> GetNewRegistrarTypes()
        {
            var newRegistrars = new List<Type>();
            if (this.HasNewAssemblies)
            {
                newRegistrars = this.getRegistrarTypes().ToList();
            }

            return newRegistrars;
        }

        /// <summary>
        /// Gets an enumeration of dependency registrar objects from the given enumeration of types.
        /// </summary>
        /// <param name="registrarTypes">An enumeration of Type objects.</param>
        /// <returns>An enumeration of dependency location registrars.</returns>
        internal IEnumerable<IDependencyLocationRegistrar> GetRegistrars(IEnumerable<Type> registrarTypes)
        {
            return (from t in registrarTypes
                    select this.DependencyRegistrarFactory.Create(t)).ToList();
        }

        /// <summary>
        /// Gets a list of types for any dependency registrars in the current application domain.
        /// </summary>
        /// <returns>A list of types.</returns>
        internal IEnumerable<Type> InternalGetRegistrarTypes()
        {
            var rawTypes = new List<Type>();
            var dependencyRegistrarType = typeof(IDependencyLocationRegistrar);

            foreach (var assembly in this.assemblies)
            {
                try
                {
                    rawTypes.AddRange(assembly.GetDefinedTypes());
                }
                catch (ReflectionTypeLoadException loadEx)
                {
                    var foundTypes = (from t in loadEx.Types where t != null select t).ToList();
                    rawTypes.AddRange(foundTypes);
                }
            }

            var rawRegistrarTypes = new List<Type>();
            foreach (var type in rawTypes)
            {
                if (type.IsInterface())
                {
                    continue;
                }

                if (dependencyRegistrarType.IsAssignableFrom(type) && type.GetDefinedConstructors().Any(c => !c.GetParameters().Any()))
                {
                    rawRegistrarTypes.Add(type);
                }
            }

            return rawRegistrarTypes;
        }
    }
}