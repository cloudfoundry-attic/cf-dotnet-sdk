using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Interfaces
{
    public interface IResponse
    {
        Metadata EntityMetadata { get; set; }
    }
}
