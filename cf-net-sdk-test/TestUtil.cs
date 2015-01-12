using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk_test
{
    internal static class TestUtil
    {
        public static string ToTestableString(object obj)
        {
            string result = string.Empty;
            if (obj != null)
            {
                result = Convert.ToString(obj);
            }

            return result;
        }
    }
}
