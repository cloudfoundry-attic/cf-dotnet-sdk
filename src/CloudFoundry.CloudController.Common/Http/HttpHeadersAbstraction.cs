namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public class HttpHeadersCollection : IHttpHeadersCollection
    {
        private readonly Dictionary<string, IEnumerable<string>> headers = new Dictionary<string, IEnumerable<string>>();

        public HttpHeadersCollection()
        {
        }

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

        public IEnumerable<string> this[string name]
        {
            get { return this.headers[name]; }
            set { this.headers[name] = value; }
        }

        public void Add(string name, IEnumerable<string> values)
        {
            this.headers.Add(name, values);
        }

        public void Add(string name, string value)
        {
            this.headers.Add(name, new List<string>() { value });
        }

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

        public void Clear()
        {
            this.headers.Clear();
        }

        public bool Contains(string name)
        {
            return this.headers.ContainsKey(name);
        }

        public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        public IEnumerable<string> GetValues(string name)
        {
            return this.headers[name];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        public void Remove(string name)
        {
            this.headers.Remove(name);
        }

        public bool TryGetValue(string name, out IEnumerable<string> values)
        {
            return this.headers.TryGetValue(name, out values);
        }
    }
}