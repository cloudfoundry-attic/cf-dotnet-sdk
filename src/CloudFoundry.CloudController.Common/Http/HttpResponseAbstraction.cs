using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Common.Http
{
    public class HttpResponseAbstraction : IHttpResponseAbstraction
    {
        public HttpResponseAbstraction(HttpContent content, IHttpHeadersAbstraction headers, HttpStatusCode status)
        {
            this.Headers = headers ?? new HttpHeadersAbstraction();
            this.StatusCode = status;
            this.Content = content;
        }

        public HttpContent Content { get; internal set; }

        public IHttpHeadersAbstraction Headers { get; internal set; }

        public bool IsSuccessStatusCode { get { return this.StatusCode == HttpStatusCode.OK; } }
        public HttpRequestMessage RequestMessage { get; set; }
        public HttpStatusCode StatusCode { get; internal set; }

        public async Task<string> ReadContentAsStringAsync()
        {
            return await this.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
