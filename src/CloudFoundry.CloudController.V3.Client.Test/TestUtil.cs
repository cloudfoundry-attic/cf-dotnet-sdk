using CloudFoundry.UAA;
using CloudFoundry.UAA.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V3
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

        public static string ToUnformatedJsonString(string json)
        {
            Regex newline = new Regex(@"(\r\n\s*|\r\s*|\n\s*)");
            Regex value = new Regex(@":\s");
            string result = newline.Replace(json, "");
            return value.Replace(result, ":");
        }

        public static Dictionary<string, object> GetJsonDictonary(string json)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            using (StringReader stringReader = new StringReader(json))
            {
                using (JsonReader reader = new JsonTextReader(stringReader))
                {
                    reader.DateParseHandling = DateParseHandling.None;
                    var obj = JObject.Load(reader);
                    foreach (var x in obj)
                    {
                        if (x.Value is IDictionary)
                        {
                            result[x.Key] = GetJsonDictonary(x.Value.ToString());
                        }
                        else if (x.Value.GetType().IsArray)
                        {
                            result[x.Key] = GetJsonArray(x.Value.ToString());
                        }
                        else
                        {
                            result[x.Key] = x.Value;
                        }
                    }
                }
            }
            return result;
        }

        public static object[] GetJsonArray(string json)
        {
            List<object> results = new List<object>();

            List<object> obj = JsonConvert.DeserializeObject<List<object>>(json);
            foreach (var x in obj)
            {
                if (x is JObject)
                {
                    results.Add(GetJsonDictonary(x.ToString()));
                }
                else if (x is JArray)
                {
                    results.Add(GetJsonArray(x.ToString()));
                }
                else if (x is JValue)
                {
                    results.Add(x);
                }
            }

            return results.ToArray();
        }
    }
}
