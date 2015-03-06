namespace CloudFoundry.CloudController.V2
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class PagedResponseCollection<T> : BaseEndpoint, IEnumerable<T>
    {
        public PageProperties Properties { get; set; }

        internal List<T> Resources { get; set; }

        public T this[int index]
        {
            get { return this.Resources[index]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Resources.GetEnumerator();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method makes an http request to get the previous page of results.")]
        public async Task<PagedResponseCollection<T>> GetNextPage()
        {
            if (this.Properties.NextUrl != null)
            {
                return await this.Get(this.Properties.NextUrl);
            }
            else
            {
                return null;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method makes an http request to get the previous page of results.")]
        public async Task<PagedResponseCollection<T>> GetPreviousPage()
        {
            if (this.Properties.PreviousUrl != null)
            {
                return await this.Get(this.Properties.PreviousUrl);
            }
            else
            {
                return null;
            }
        }

        public bool IsLastPage()
        {
            return this.Properties.NextUrl != null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private async Task<PagedResponseCollection<T>> Get(string url)
        {
            var client = this.GetHttpClient();
            client.Uri = new Uri(url);
            client.Method = HttpMethod.Get;
            client.Headers.Add(await this.BuildAuthenticationHeader());
            var response = await client.SendAsync();
            return Utilities.DeserializePage<T>(await response.ReadContentAsStringAsync());
        }
    }
}