namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Interface for scanning an assembly for dependency location registrars.
    /// </summary>
    internal interface IDependencyLocationAssemblyScanner
    {
        /// <summary>
        /// Gets a value indicating whether the scanner has new assemblies that can be scanned.
        /// </summary>
        bool HasNewAssemblies { get; }

        /// <summary>
        /// Gets an enumerable collection of dependency location registrars.
        /// </summary>
        /// <returns>enumerable collection of dependency location registrars</returns>
        IEnumerable<IDependencyLocationRegistrar> GetRegistrars();

        /// <summary>
        /// Gets an enumeration of dependency registrars that have not been scanned before.
        /// </summary>
        /// <returns>an enumeration of dependency registrars.</returns>
        IEnumerable<IDependencyLocationRegistrar> GetNewRegistrars();

        /// <summary>
        /// Adds the target assembly to the scanners list of assemblies to scan.
        /// </summary>
        /// <param name="target">The target assembly.</param>
        void AddAssembly(Assembly target);
    }
}