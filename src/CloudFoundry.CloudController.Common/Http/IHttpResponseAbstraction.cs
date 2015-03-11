namespace CloudFoundry.CloudController.Common.Http
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The http response abstraction class
    /// </summary>
    public interface IHttpResponseAbstraction
    {
        /// <summary>
        /// Gets the http content.
        /// </summary>
        /// <value>
        /// The http content.
        /// </value>
        HttpContent Content { get; }

        /// <summary>
        /// Gets the http headers of the response.
        /// </summary>
        /// <value>
        /// The http headers.
        /// </value>
        IHttpHeadersCollection Headers { get; }

        /// <summary>
        /// Gets a value indicating whether this response has a successful status code.
        /// </summary>
        /// <value>
        /// <c>true</c> if this response has a successful status code; otherwise, <c>false</c>.
        /// </value>
        bool IsSuccessStatusCode { get; }

        /// <summary>
        /// Gets or sets the http request message.
        /// </summary>
        /// <value>
        /// The http request message.
        /// </value>
        HttpRequestMessage RequestMessage { get; set; }

        /// <summary>
        /// Gets the http status code.
        /// </summary>
        /// <value>
        /// The http status code.
        /// </value>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Reads the content as string asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<string> ReadContentAsStringAsync();
    }
}