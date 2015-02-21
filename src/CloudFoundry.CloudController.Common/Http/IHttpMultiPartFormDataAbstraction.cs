namespace CloudFoundry.CloudController.Common.Http
{
    using System.IO;

    /// <summary>
    /// Abstraction for modeling multipart form data.
    /// </summary>s
    public interface IHttpMultipartFormDataAbstraction
    {
        /// <summary>
        /// Gets the name of the form field.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the file name for the form data.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the content type of the form data.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the content stream for the form data.
        /// </summary>
        Stream Content { get; }
    }
}