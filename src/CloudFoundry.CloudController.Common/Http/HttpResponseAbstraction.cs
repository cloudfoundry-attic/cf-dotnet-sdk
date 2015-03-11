namespace CloudFoundry.CloudController.Common.Http
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public class HttpResponseAbstraction : IHttpResponseAbstraction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseAbstraction"/> class.
        /// </summary>
        /// <param name="content">The http content.</param>
        /// <param name="headers">The http headers.</param>
        /// <param name="status">The http status.</param>
        public HttpResponseAbstraction(HttpContent content, IHttpHeadersCollection headers, HttpStatusCode status)
        {
            this.Headers = headers ?? new HttpHeadersCollection();
            this.StatusCode = status;
            this.Content = content;
        }

        /// <inheritdoc/>
        public HttpContent Content { get; internal set; }

        /// <inheritdoc/>
        public IHttpHeadersCollection Headers { get; internal set; }

        /// <inheritdoc/>
        public bool IsSuccessStatusCode
        {
            get
            {
                return this.StatusCode == HttpStatusCode.OK;
            }
        }

        /// <inheritdoc/>
        public HttpRequestMessage RequestMessage { get; set; }

        /// <inheritdoc/>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <inheritdoc/>
        public async Task<string> ReadContentAsStringAsync()
        {
            return await this.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}