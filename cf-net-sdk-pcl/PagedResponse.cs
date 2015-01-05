using cf_net_sdk.Client.Data;
using cf_net_sdk.Interfaces;
using CloudFoundry.Common;
using CloudFoundry.Common.Http;
using CloudFoundry.Common.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk
{
    public class PageProperties
    {
        [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalPages { get; internal set; }

        [JsonProperty("total_results", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalResults { get; internal set; }

        [JsonProperty("prev_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PrevUrl { get; internal set; }

        [JsonProperty("next_url", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUrl { get; internal set; }
    }

    public class PagedResponse<T>: BaseEndpoint, IEnumerable<T>
    {
        internal List<T> Resources { get; set; }

        public PageProperties Properties { get; set; }

        public bool IsLastPage() { return this.Properties.NextUrl != null; } 

        public async Task<PagedResponse<T>> GetNextPage()
        {
            if (this.Properties.NextUrl != null)
                return await Get(this.Properties.NextUrl);
            else return null;
        }

        public async Task<PagedResponse<T>> GetPreviousPage()
        {
            if (this.Properties.PrevUrl != null)
                return await Get(this.Properties.PrevUrl);
            else return null;
        }

        private async Task<PagedResponse<T>> Get(string url)
        {
            var client = this.GetHttpClient();
            client.Uri = new Uri(url);
            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
            var response = await client.SendAsync();
            return Util.DeserializePage<T>(await response.ReadContentAsStringAsync());
        }

        public T this[int index]
        {
            get { return this.Resources[index]; }            
        } 

        public IEnumerator<T> GetEnumerator()
        {
            return this.Resources.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
