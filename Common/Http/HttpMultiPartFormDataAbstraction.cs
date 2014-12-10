// /* ============================================================================
// Copyright 2014 Hewlett Packard
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ============================================================================ */

using System.IO;

namespace CloudFoundry.Common.Http
{
    /// <inheritdoc/>
    class HttpMultiPartFormDataAbstraction :IHttpMultiPartFormDataAbstraction
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
        public HttpMultiPartFormDataAbstraction(string name, string fileName, string contentType, Stream content)
        {
            this.Name = name;
            this.FileName = fileName;
            this.ContentType = contentType;
            this.Content = content;
        }
    }
}
