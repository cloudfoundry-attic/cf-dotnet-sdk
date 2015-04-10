namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CloudFoundry.CloudController.Common.Exceptions;
    using CloudFoundry.CloudController.V2.Client.Interfaces;
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
            page.Properties = JsonConvert.DeserializeObject<PageProperties>(value, jsonSettings);
            page.Resources = DeserializeJsonResources<T>(value).ToList<T>();
            return page;
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