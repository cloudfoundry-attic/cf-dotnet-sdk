namespace CloudFoundry.CloudController.Common.Http
{
    using System.Collections.Generic;

    public interface IHttpHeadersCollection : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
    {
        IEnumerable<string> this[string name] { get; set; }

        void Add(string name, IEnumerable<string> values);

        void Add(string name, string value);

        void Clear();

        bool Contains(string name);

        IEnumerable<string> GetValues(string name);

        void Remove(string name);

        bool TryGetValue(string name, out IEnumerable<string> values);
    }
}