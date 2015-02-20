using System.IO;

namespace CloudFoundry.CloudController.Common.Http
{
    /// <inheritdoc/>
    public class HttpMultipartFormDataAbstraction : IHttpMultipartFormDataAbstraction
    {
        /// <inheritdoc/>
        public string Name { get; private set; }

        /// <inheritdoc/>
        public string FileName { get; private set; }

        /// <inheritdoc/>
        public string ContentType { get; private set; }

        /// <inheritdoc/>
        public Stream Content { get; private set; }

        /// <summary>
        /// Creates a new instance of the HttpMultiPartFormDataAbstraction class.
        /// </summary>
        /// <param name="name">The name of the form field.</param>
        /// <param name="fileName">The file name of the form field.</param>
        /// <param name="contentType">The content type of the form field.</param>
        /// <param name="content">The content for the field.</param>
        public HttpMultipartFormDataAbstraction(string name, string fileName, string contentType, Stream content)
        {
            this.Name = name;
            this.FileName = fileName;
            this.ContentType = contentType;
            this.Content = content;
        }
    }
}