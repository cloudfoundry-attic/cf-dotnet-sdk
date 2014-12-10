using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk.Interfaces
{
    public interface IResponse
    {
        Metadata EntityMetadata { get; set; }
    }
}
