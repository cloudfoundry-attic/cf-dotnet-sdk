// /* ============================================================================
// Copyright 2014 Hewlett Packard
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ============================================================================ */

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
