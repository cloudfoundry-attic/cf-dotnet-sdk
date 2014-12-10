using cf_net_sdk.Client.Data;
using cf_net_sdk.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk
{
    public class Util
    {
        public static PagedResponse<T> DeserializePage<T>(string value)
        {
            PagedResponse<T> page = new PagedResponse<T>();
            page.Properties = JsonConvert.DeserializeObject<PageProperties>(value);
            page.Resources = DeserializeJsonArray<T>(value).ToList<T>();
            return page;
        }

        public static T[] DeserializeJsonArray<T>(string value)
        {
            var obj = JObject.Parse(value);

            if (obj["resources"] == null)
            {
                throw new Exception("Value contains no resources");
            }
            return obj["resources"].Select(Deserialize<T>).ToArray();
        }

        public static T DeserializeJson<T>(string value)
        {
            var obj = JObject.Parse(value);
            return Deserialize<T>(obj);
        }

        internal static T Deserialize<T>(JToken value)
        {
            if (value["entity"] != null)
            {
                var o = JsonConvert.DeserializeObject<T>(value["entity"].ToString());
                if (value["metadata"] != null)
                {
                    ((IResponse)o).EntityMetadata = JsonConvert.DeserializeObject<Metadata>(value["metadata"].ToString());
                }
                return (T)Convert.ChangeType(o, typeof(T));
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value.ToString());
            }
        }
    }
}
