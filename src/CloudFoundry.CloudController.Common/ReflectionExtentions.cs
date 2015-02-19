using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CloudFoundry.CloudController.Common
{
    /// <summary>
    /// Static class for extending reflection classes.
    /// </summary>
    internal static class ReflectionExtentions
    {
        /// <summary>
        /// Gets the assembly that contains the extended type.
        /// </summary>
        /// <param name="input">The given Type</param>
        /// <returns>The assembly that contains the given type.</returns>
        public static Assembly GetAssembly(this Type input)
        {
            return input.GetTypeInfo().Assembly;
        }

        /// <summary>
        /// Determines if a type is assignable from the given type.
        /// </summary>
        /// <param name="input">The given type.</param>
        /// <param name="target">The type to evaluate.</param>
        /// <returns>A value indicating if the target is assignable from the given type.</returns>
        public static bool IsAssignableFrom(this Type input, Type target)
        {
            return input.GetTypeInfo().IsAssignableFrom(target.GetTypeInfo());
        }

        /// <summary>
        /// Determines if the given type is an interface.
        /// </summary>
        /// <param name="input">The given type.</param>
        /// <returns>A value indicating if the given type is an interface.</returns>
        public static bool IsInterface(this Type input)
        {
            return input.GetTypeInfo().IsInterface;
        }

        /// <summary>
        /// Gets a list of types that are defined in the given assembly.
        /// </summary>
        /// <param name="input">The given assembly.</param>
        /// <returns>A list of types defined in the given assembly.</returns>
        public static IEnumerable<Type> GetDefinedTypes(this Assembly input)
        {
            return input.DefinedTypes.Select(ti => ti.AsType());
        }

        /// <summary>
        /// Gets a list of defined constructors for the given type.
        /// </summary>
        /// <param name="input">The given type.</param>
        /// <returns>A list of constructors for the given type.</returns>
        public static IEnumerable<ConstructorInfo> GetDefinedConstructors(this Type input)
        {
            return input.GetTypeInfo().DeclaredConstructors;
        }
    }
}
