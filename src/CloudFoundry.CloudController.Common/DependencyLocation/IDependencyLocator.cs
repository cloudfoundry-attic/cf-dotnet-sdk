namespace CloudFoundry.CloudController.Common.DependencyLocation
{
    using System.Reflection;

    /// <summary>
    /// Represents an object that can locate dependencies.
    /// </summary>
    public interface IDependencyLocator
    {
        /// <summary>
        /// Locates an instance of the requested dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency to locate.</typeparam>
        /// <returns>An instance of the dependency.</returns>
        T Locate<T>();

        /// <summary>
        /// Ensures that the given assembly has been registered with the DependencyLocator for dependency location.
        /// </summary>
        /// <param name="target">The target assembly.</param>
        void EnsureAssemblyRegistration(Assembly target);
    }
}