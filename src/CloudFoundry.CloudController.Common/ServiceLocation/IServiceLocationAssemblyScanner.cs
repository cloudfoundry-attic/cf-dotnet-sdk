using System.Collections.Generic;
using System.Reflection;

namespace CloudFoundry.CloudController.Common.ServiceLocation
{
    /// <summary>
    /// Interface for scanning an assembly for service location registrars.
    /// </summary>
    internal interface IServiceLocationAssemblyScanner
    {
        /// <summary>
        /// Gets a value indicating if the scanner has new assemblies that can be scanned.
        /// </summary>
        bool HasNewAssemblies { get; }

        /// <summary>
        /// Gets an enumerable collection of service location registrars.
        /// </summary>
        /// <returns>enumerable collection of service location registrars</returns>
        IEnumerable<IServiceLocationRegistrar> GetRegistrars();

        /// <summary>
        /// Gets an enumeration of service registrars that have not been scanned before.
        /// </summary>
        /// <returns>an enumeration of service registrars.</returns>
        IEnumerable<IServiceLocationRegistrar> GetNewRegistrars();

        /// <summary>
        /// Adds the target assembly to the scanners list of assemblies to scan.
        /// </summary>
        /// <param name="target">The target assembly.</param>
        void AddAssembly(Assembly target);
    }
}
