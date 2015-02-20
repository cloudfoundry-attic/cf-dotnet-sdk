using CloudFoundry.CloudController.V2.Exceptions;
using CloudFoundry.CloudController.V2.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CloudFoundry.CloudController.V2
{
    public sealed class Utilities
    {
        private Utilities()
        {
        }

        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None
        };

        public static PagedResponseCollection<T> DeserializePage<T>(string value)
        {
            PagedResponseCollection<T> page = new PagedResponseCollection<T>();
            page.Properties = JsonConvert.DeserializeObject<PageProperties>(value, jsonSettings);
            page.Resources = DeserializeJsonResources<T>(value).ToList<T>();
            return page;
        }

        public static T[] DeserializeJsonResources<T>(string value)
        {
            using (StringReader stringReader = new StringReader(value))
            {
                using (JsonReader reader = new JsonTextReader(stringReader))
                {
                    reader.DateParseHandling = DateParseHandling.None;
                    var obj = JObject.Load(reader);
                    if (obj["resources"] == null)
                    {
                        throw new CloudFoundryException("Value contains no resources");
                    }

                    return obj["resources"].Select(Deserialize<T>).ToArray();
                }
            }
        }

        public static T[] DeserializeJsonArray<T>(string value)
        {
            return JsonConvert.DeserializeObject<T[]>(value);
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
                return (T)Convert.ChangeType(o, typeof(T), CultureInfo.InvariantCulture);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value.ToString(), jsonSettings);
            }
        }
    }
}