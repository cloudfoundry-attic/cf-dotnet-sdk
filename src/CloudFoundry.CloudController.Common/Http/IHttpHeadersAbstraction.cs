namespace CloudFoundry.CloudController.Common.Http
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of http headers
    /// </summary>
    public interface IHttpHeadersCollection : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
    {
        /// <summary>
        /// Gets or sets the IHttpHeadersCollection with the specified name.
        /// </summary>
        /// <param name="name">The name of the header..</param>
        /// <returns>A IEnumerable of headers</returns>
        IEnumerable<string> this[string name] { get; set; }

        /// <summary>
        /// Adds the specified header.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="values">A collection of header values.</param>
        void Add(string name, IEnumerable<string> values);

        /// <summary>
        /// Adds the specified header.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        void Add(string name, string value);

        /// <summary>
        /// Clears the headers.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether this collection contains the specified header name.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if it contains the header, <c>false</c> if it does not contain</returns>
        bool Contains(string name);

        /// <summary>
        /// Gets the values of a header.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <returns>A collection of values.</returns>
        IEnumerable<string> GetValues(string name);

        /// <summary>
        /// Removes the specified header.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        void Remove(string name);

        /// <summary>
        /// Tries the get value.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="values">The values of the header.</param>
        /// <returns><c>true</c>  if it succeeded, <c>false</c> if not</returns>
        bool TryGetValue(string name, out IEnumerable<string> values);
    }
}