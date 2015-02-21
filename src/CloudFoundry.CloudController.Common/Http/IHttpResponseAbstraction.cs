namespace CloudFoundry.CloudController.Common.Http
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpResponseAbstraction
    {
        HttpContent Content { get; }

        IHttpHeadersCollection Headers { get; }

        bool IsSuccessStatusCode { get; }

        HttpRequestMessage RequestMessage { get; set; }

        HttpStatusCode StatusCode { get; }

        Task<string> ReadContentAsStringAsync();
    }
}