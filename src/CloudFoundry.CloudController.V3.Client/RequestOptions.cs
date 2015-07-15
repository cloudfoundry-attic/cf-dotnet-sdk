namespace CloudFoundry.CloudController.V3.Client
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// The request options for a paged response.
    /// </summary>
    public class RequestOptions
    {
        private readonly string orderFormat = "order_direction={0}";

        private readonly string pageFormat = "page={0}";

        private readonly string resultsFormat = "per_page={0}";

        private readonly string orderByFormat = "order_by={0}";

        /// <summary>
        /// Instantiates a new RequestOptions class
        /// </summary>
        public RequestOptions()
        {
            this.Query = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Gets or sets the order of the results: asc (default) or desc
        /// </summary>
        public string OrderDirection { get; set; }

        /// <summary>
        /// Gets or sets the value to sort by: created_at or updated_at
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the page of results to fetch
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the parameters used to filter the result set.
        /// </summary>
        public Dictionary<string, string[]> Query { get; internal set; }

        /// <summary>
        /// Gets or sets the number of results per page
        /// </summary>
        public int? ResultsPerPage { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            List<string> args = new List<string>();
            if (this.Page != null)
            {
                args.Add(string.Format(CultureInfo.InvariantCulture, this.pageFormat, this.Page));
            }

            if (this.Query != null)
            {
                args.Add(this.FormatQuery());
            }

            if (this.ResultsPerPage != null)
            {
                args.Add(string.Format(CultureInfo.InvariantCulture, this.resultsFormat, this.ResultsPerPage));
            }

            if (this.OrderDirection != null)
            {
                args.Add(string.Format(CultureInfo.InvariantCulture, this.orderFormat, this.OrderDirection));
            }

            if (this.OrderBy != null)
            {
                args.Add(string.Format(CultureInfo.InvariantCulture, this.orderByFormat, this.OrderBy));
            }

            if (args.Count > 0)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}", string.Join("&", args));
            }

            return string.Empty;
        }

        private string FormatQuery()
        {
            if (this.Query == null || this.Query.Count == 0)
            {
                return string.Empty;
            }

            Collection<string> filters = new Collection<string>();

            foreach (KeyValuePair<string, string[]> pair in this.Query)
            {
                foreach (string value in pair.Value)
                {
                    filters.Add(string.Format(CultureInfo.InvariantCulture, "{0}[]={1}", pair.Key, value));
                }
            }

            return string.Join("&", filters);
        }
    }
}