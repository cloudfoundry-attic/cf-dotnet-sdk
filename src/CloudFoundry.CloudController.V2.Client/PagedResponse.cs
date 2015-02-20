using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2
{
    public class PageProperties
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalPages { get; internal set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("total_results", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalResults { get; internal set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("prev_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousUrl { get; internal set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Populated through deserialization."),
        JsonProperty("next_url", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUrl { get; internal set; }
    }

    public class PagedResponseCollection<T> : BaseEndpoint, IEnumerable<T>
    {
        internal List<T> Resources { get; set; }

        public PageProperties Properties { get; set; }

        public bool IsLastPage()
        {
            return this.Properties.NextUrl != null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method makes an http request to get the previous page of results.")]
        public async Task<PagedResponseCollection<T>> GetNextPage()
        {
            if (this.Properties.NextUrl != null)
                return await Get(this.Properties.NextUrl);
            else return null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method makes an http request to get the previous page of results.")]
        public async Task<PagedResponseCollection<T>> GetPreviousPage()
        {
            if (this.Properties.PreviousUrl != null)
                return await Get(this.Properties.PreviousUrl);
            else return null;
        }

        private async Task<PagedResponseCollection<T>> Get(string url)
        {
            var client = this.GetHttpClient();
            client.Uri = new Uri(url);
            client.Method = HttpMethod.Get;
            client.Headers.Add(BuildAuthenticationHeader());
            var response = await client.SendAsync();
            return Utilities.DeserializePage<T>(await response.ReadContentAsStringAsync());
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