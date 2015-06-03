namespace CloudFoundry.Manifests
{
    using System;
    using System.Collections.Generic;

    internal class Util
    {
        internal static Dictionary<string, object> MergeDictionaries(Dictionary<string, object> resultVal, params Dictionary<string, object>[] collections)
        {
            foreach (Dictionary<string, object> collection in collections)
            {
                foreach (string key in collection.Keys)
                {
                    if (collection[key] == null)
                    {
                        continue;
                    }

                    resultVal = Merge(key, collection[key], resultVal);
                }
            }

            return resultVal;
        }

        private static Dictionary<string, object> Merge(string key, dynamic val, Dictionary<string, object> reduced)
        {
            if (reduced.ContainsKey(key) == false)
            {
                reduced.Add(key, val);
                return reduced;
            }

            var t = val.GetType();
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                return MergeDictionary(key, val, reduced);
            }

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>))
            {
                return MergeList(key, val, reduced);
            }

            reduced[key] = val;
            return reduced;
        }

        private static Dictionary<string, object> MergeList(string key, dynamic val, Dictionary<string, object> reduced)
        {
            Type listType = val[0].GetType();
            if (listType == typeof(string))
            {
                List<string> list = new List<string>();
                list.AddRange((List<string>)reduced[key]);
                list.AddRange((List<string>)val);
                reduced[key] = list;
            }

            if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list.AddRange((List<Dictionary<string, object>>)reduced[key]);
                list.AddRange((List<Dictionary<string, object>>)val);
                reduced[key] = list;
            }

            return reduced;
        }

        private static Dictionary<string, object> MergeDictionary(string key, dynamic val, Dictionary<string, object> reduced)
        {
            var maps = new List<Dictionary<string, object>>();
            maps.Add((Dictionary<string, object>)reduced[key]);
            maps.Add((Dictionary<string, object>)val);
            var mergedMap = MergeDictionaries(new Dictionary<string, object>(), maps.ToArray());
            reduced[key] = mergedMap;
            return reduced;
        }
    }
}