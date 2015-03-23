namespace CloudFoundry.CloudController.V2.Client
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// The request options for a paged response.
    /// </summary>
    public class RequestOptions
    {
        private readonly string orderFormat = "order-direction={0}";

        private readonly string pageFormat = "page={0}";

        private readonly string qeryFormat = "q={0}";

        private readonly string resultsFormat = "results-per-page={0}";

        /// <summary>
        /// Gets or sets the order of the results: asc (default) or desc
        /// </summary>
        public string OrderDirection { get; set; }

        /// <summary>
        /// Gets or sets the page of results to fetch
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the parameters used to filter the result set.
        /// </summary>
        public string Query { get; set; }

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
                args.Add(string.Format(CultureInfo.InvariantCulture, this.qeryFormat, this.Query));
            }

            if (this.ResultsPerPage != null)
            {
                args.Add(string.Format(CultureInfo.InvariantCulture, this.resultsFormat, this.ResultsPerPage));
            }

            if (this.OrderDirection != null)
            {
                args.Add(string.Format(CultureInfo.InvariantCulture, this.orderFormat, this.OrderDirection));
            }

            if (args.Count > 0)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}", string.Join("&", args));
            }

            return string.Empty;
        }
    }
}