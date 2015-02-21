namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpAbstractionClient : IDisposable
    {
        HttpMethod Method { get; set; }

        Uri Uri { get; set; }

        Stream Content { get; set; }

        IDictionary<string, string> Headers { get; }

        string ContentType { get; set; }

        TimeSpan Timeout { get; set; }

        Task<IHttpResponseAbstraction> SendAsync();

        Task<IHttpResponseAbstraction> SendAsync(IEnumerable<IHttpMultipartFormDataAbstraction> multipartData);
    }
}