namespace CloudFoundry.CloudController.V3.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that handles the Cloud Foundry responses that are paged.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResponseCollection<T> : BaseEndpoint, IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets the page properties.
        /// </summary>
        /// <value>
        /// The page properties.
        /// </value>
        public Pagination Pagination { get; set; }

        internal List<T> Resources { get; set; }

        /// <summary>
        /// Gets the resource at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.Resources[index]; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Resources.GetEnumerator();
        }

        /// <summary>
        /// Gets the next page.
        /// </summary>
        /// <returns>A paged collection</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method makes an http request to get the previous page of results.")]
        public async Task<PagedResponseCollection<T>> GetNextPage()
        {
            if (this.Pagination.Next != null)
            {
                return await this.Get(
                    new Uri(
                        string.Format(
                        CultureInfo.InvariantCulture, 
                        "{0}{1}", 
                        this.Client.CloudTarget,
                        this.Pagination.Next.Href)));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the previous page.
        /// </summary>
        /// <returns>A paged collection</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method makes an http request to get the previous page of results.")]
        public async Task<PagedResponseCollection<T>> GetPreviousPage()
        {
            if (this.Pagination.Previous != null)
            {
                return await this.Get(
                    new Uri(
                        string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}{1}",
                        this.Client.CloudTarget,
                        this.Pagination.Previous.Href)));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether [is last page].
        /// </summary>
        /// <returns>A paged collection</returns>
        public bool IsLastPage()
        {
            return this.Pagination.Next != null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private async Task<PagedResponseCollection<T>> Get(Uri url)
        {
            var client = this.GetHttpClient();
            client.Uri = url;
            client.Method = HttpMethod.Get;
            client.Headers.Add(await this.BuildAuthenticationHeader());
            var response = await client.SendAsync();
            return Utilities.DeserializePage<T>(await response.ReadContentAsStringAsync(), this.Client);
        }
    }
}