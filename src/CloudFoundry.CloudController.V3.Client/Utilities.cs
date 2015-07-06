namespace CloudFoundry.CloudController.V3.Client
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CloudFoundry.CloudController.Common.Exceptions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal sealed class Utilities
    {
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None
        };

        private Utilities()
        {            
        }

        internal static T DeserializeJson<T>(string value)
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

        internal static T[] DeserializeJsonArray<T>(string value)
        {
            return JsonConvert.DeserializeObject<T[]>(value);
        }

        internal static T[] DeserializeJsonResources<T>(string value)
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

        internal static PagedResponseCollection<T> DeserializePage<T>(string value, CloudFoundryClient client)
        {
            PagedResponseCollection<T> page = new PagedResponseCollection<T>();
            page.Client = client;

            using (StringReader stringReader = new StringReader(value))
            {
                using (JsonReader reader = new JsonTextReader(stringReader))
                {
                    reader.DateParseHandling = DateParseHandling.None;
                    var obj = JObject.Load(reader);
                    if (obj["pagination"] == null)
                    {
                        throw new CloudFoundryException("Value contains no pagination info");
                    }

                    page.Pagination = JsonConvert.DeserializeObject<Pagination>(obj["pagination"].ToString(), jsonSettings);
                }
            }

            page.Resources = DeserializeJsonResources<T>(value).ToList<T>();
            return page;
        }

        internal static T Deserialize<T>(JToken value)
        {
            return JsonConvert.DeserializeObject<T>(value.ToString(), jsonSettings);
        }
    }
}