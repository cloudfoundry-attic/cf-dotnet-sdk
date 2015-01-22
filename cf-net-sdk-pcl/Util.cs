using cf_net_sdk.Client.Data;
using cf_net_sdk.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_net_sdk
{
    public class Util
    {
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None            
        };

        public static PagedResponse<T> DeserializePage<T>(string value)
        {
            PagedResponse<T> page = new PagedResponse<T>();
            page.Properties = JsonConvert.DeserializeObject<PageProperties>(value, jsonSettings);
            page.Resources = DeserializeJsonArray<T>(value).ToList<T>();
            return page;
        }

        public static T[] DeserializeJsonArray<T>(string value)
        {
            using (StringReader stringReader = new StringReader(value))
            {
                using (JsonReader reader = new JsonTextReader(stringReader))
                {
                    reader.DateParseHandling = DateParseHandling.None;
                    var obj = JObject.Load(reader);
                    if (obj["resources"] == null)
                    {
                        throw new Exception("Value contains no resources");
                    }
                    return obj["resources"].Select(Deserialize<T>).ToArray();
                }
            }
        }

        public static T DeserializeJson<T>(string value)
        {
            using (StringReader stringReader = new StringReader(value))
            {
                using (JsonReader reader = new JsonTextReader(stringReader))
                {
                    reader.DateParseHandling = DateParseHandling.None;
                    var obj = JObject.Load(reader);
                    return Deserialize<T>(obj);
                }
            }
        }

        internal static T Deserialize<T>(JToken value)
        {
            if (value["entity"] != null)
            {
                var o = JsonConvert.DeserializeObject<T>(value["entity"].ToString());
                if (value["metadata"] != null)
                {
                    ((IResponse)o).EntityMetadata = JsonConvert.DeserializeObject<Metadata>(value["metadata"].ToString(), jsonSettings);
                }
                return (T)Convert.ChangeType(o, typeof(T));
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value.ToString(), jsonSettings);
            }
        }
    }
}
