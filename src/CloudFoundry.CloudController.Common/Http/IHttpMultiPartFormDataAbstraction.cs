using System.IO;

namespace CloudFoundry.CloudController.Common.Http
{
    /// <summary>
    /// Abstraction for modeling mutlipart form data.
    /// </summary>
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