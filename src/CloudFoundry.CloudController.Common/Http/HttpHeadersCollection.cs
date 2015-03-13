namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    /// <inheritdoc/>
    public class HttpHeadersCollection : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
    {
        private readonly Dictionary<string, IEnumerable<string>> headers = new Dictionary<string, IEnumerable<string>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeadersCollection"/> class.
        /// </summary>
        public HttpHeadersCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeadersCollection"/> class.
        /// </summary>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="System.ArgumentNullException">responseHeaders</exception>
        public HttpHeadersCollection(HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders == null)
            {
                throw new ArgumentNullException("responseHeaders");
            }

            foreach (var header in responseHeaders)
            {
                this.headers.Add(header.Key, header.Value);
            }
        }

        /// <inheritdoc/>
        public IEnumerable<string> this[string name]
        {
            get { return this.headers[name]; }
            set { this.headers[name] = value; }
        }

        /// <inheritdoc/>
        public void Add(string name, IEnumerable<string> values)
        {
            this.headers.Add(name, values);
        }

        /// <inheritdoc/>
        public void Add(string name, string value)
        {
            this.headers.Add(name, new List<string>() { value });
        }

        /// <inheritdoc/>
        public void AddRange(HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders == null)
            {
                throw new ArgumentNullException("responseHeaders");
            }

            foreach (var header in responseHeaders)
            {
                this.headers.Add(header.Key, header.Value);
            }
        }

        /// <inheritdoc/>
        public void AddRange(HttpContentHeaders responseHeaders)
        {
            if (responseHeaders == null)
            {
                throw new ArgumentNullException("responseHeaders");
            }

            foreach (var header in responseHeaders)
            {
                this.headers.Add(header.Key, header.Value);
            }
        }

        /// <inheritdoc/>
        public void Clear()
        {
            this.headers.Clear();
        }

        /// <inheritdoc/>
        public bool Contains(string name)
        {
            return this.headers.ContainsKey(name);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetValues(string name)
        {
            return this.headers[name];
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        /// <inheritdoc/>
        public void Remove(string name)
        {
            this.headers.Remove(name);
        }

        /// <inheritdoc/>
        public bool TryGetValue(string name, out IEnumerable<string> values)
        {
            return this.headers.TryGetValue(name, out values);
        }
    }
}