using System.Collections.Generic;

namespace CloudFoundry.CloudController.Common.Http
{
    public interface IHttpHeadersAbstraction : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
    {
        void Add(string name, IEnumerable<string> values);

        void Add(string name, string value);

        void Clear();

        bool Contains(string name);

        IEnumerable<string> GetValues(string name);

        void Remove(string name);

        bool TryGetValue(string name, out IEnumerable<string> values);

        IEnumerable<string> this[string name] { get; set; }
    }
}
