namespace CloudFoundry.CloudController.Common.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the Http Abstraction client.
    /// </summary>
    public interface IHttpAbstractionClient : IDisposable
    {
        /// <summary>
        /// Gets or sets the http method.
        /// </summary>
        /// <value>
        /// The http method.
        /// </value>
        HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The steam content.
        /// </value>
        Stream Content { get; set; }

        /// <summary>
        /// Gets the http headers.
        /// </summary>
        /// <value>
        /// The http headers.
        /// </value>
        IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the http timeout.
        /// </summary>
        /// <value>
        /// The http timeout.
        /// </value>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Sends the http content asynchronously.
        /// </summary>
        /// <returns>The http response </returns>
        Task<IHttpResponseAbstraction> SendAsync();

        /// <summary>
        /// Sends the http content asynchronously.
        /// </summary>
        /// <param name="multipartData">The multipart data.</param>
        /// <returns>The http response </returns>
        Task<IHttpResponseAbstraction> SendAsync(IEnumerable<IHttpMultipartFormDataAbstraction> multipartData);
    }
}