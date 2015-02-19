using System;
using System.IO;
using System.Text;

namespace CloudFoundry.CloudController.Common
{
    /// <summary>
    /// Holds extension methods for common objects and tasks.
    /// </summary>
    public static class ObjectExtentions
    {
        /// <summary>
        /// Throws an argument exception if the given object is null.
        /// </summary>
        /// <typeparam name="T">Given Type of the object.</typeparam>
        /// <param name="input">The object.</param>
        /// <param name="paramName">A string that represents a name for the object.</param>
        public static void AssertIsNotNull<T>(this T input, string paramName)
        {
            if (ReferenceEquals(input, null))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Throws an argument exception if the given object is null.
        /// </summary>
        /// <typeparam name="T">Given Type of the object.</typeparam>
        /// <param name="input">The object.</param>
        /// <param name="paramName">A string that represents a name for the object.</param>
        /// <param name="message">A message to include in the thrown exception.</param>
        public static void AssertIsNotNull<T>(this T input, string paramName, string message)
        {
            if (ReferenceEquals(input, null))
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// Throws an argument exception if the given string is null or empty.
        /// </summary>
        /// <param name="input">The given string.</param>
        /// <param name="paramName">A string that represents a name for the object.</param>
        public static void AssertIsNotNullOrEmpty(this string input, string paramName)
        {
            if (ReferenceEquals(input, null))
            {
                throw new ArgumentNullException(paramName);
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(string.Empty, paramName);
            }
        }

        /// <summary>
        /// Throws an argument exception if the given string is null or empty.
        /// </summary>
        /// <param name="input">The given string.</param>
        /// <param name="paramName">A string that represents a name for the object.</param>
        /// <param name="message">A message to include in the thrown exception.</param>
        public static void AssertIsNotNullOrEmpty(this string input, string paramName, string message)
        {
            if (ReferenceEquals(input, null))
            {
                throw new ArgumentNullException(paramName, message);
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        /// Converts the given string to a stream.
        /// </summary>
        /// <param name="content">The string to convert.</param>
        /// <returns>A stream that includes the given string.</returns>
        public static Stream ConvertToStream(this string content)
        {
            var byteArray = Encoding.UTF8.GetBytes(content);
            return new MemoryStream(byteArray);
        }
    }
}
