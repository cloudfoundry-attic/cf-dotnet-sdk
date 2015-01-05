using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk
{
    public class RequestOptions
    {
        /// <summary>
        /// Page of results to fetch
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Parameters used to filter the result set.
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// Number of results per page
        /// </summary>
        public int? ResultsPerPage { get; set; }

        /// <summary>
        /// Order of the results: asc (default) or desc
        /// </summary>
        public string OrderDirection { get; set; }

        private readonly string qeryFormat = "q={0}";
        private readonly string pageFormat = "page={0}";
        private readonly string resultsFormat = "results-per-page={0}";
        private readonly string orderFormat = "order-direction={0}";

        public string ToString()
        {
            List<string> args = new List<string>();            
            if(this.Page != null)
            {
                args.Add(string.Format(this.pageFormat, this.Page));
            }
            if(this.Q != null)
            {
                args.Add(string.Format(this.qeryFormat, this.Q));
            }
            if(this.ResultsPerPage != null)
            {
                args.Add(string.Format(this.resultsFormat, this.ResultsPerPage));
            }
            if(this.OrderDirection != null)
            {
                args.Add(string.Format(this.orderFormat, this.OrderDirection));
            }
            if(args.Count > 0)
            {
                return string.Format("?{0}", string.Join("&", args));
            }
            return string.Empty;
        }
    }
}
