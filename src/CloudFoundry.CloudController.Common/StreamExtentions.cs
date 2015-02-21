namespace CloudFoundry.CloudController.Common
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Static class for extending the Stream class.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Copies the given stream into another stream asynchronously.
        /// </summary>
        /// <param name="input">The given stream.</param>
        /// <param name="output">The stream that will be copied into.</param>
        /// <returns>An asynchronous task.</returns>
        public static Task CopyAsync(this Stream input, Stream output)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return input.CopyToAsync(output);
        }
    }
}