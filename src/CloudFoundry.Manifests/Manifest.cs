namespace CloudFoundry.Manifests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using CloudFoundry.Manifests.Models;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Class that represents a CloudFoundry manifest
    /// </summary>
    public class Manifest
    {
        /// <summary>
        /// Path of the manifest file
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// Contains all values read from the manifest
        /// </summary>
        public Dictionary<string, object> Data { get; internal set; }

        /// <summary>
        /// Save a manifest to disk
        /// </summary>
        /// <param name="contents">Array containing applications to be saved in the manifest</param>
        /// <param name="path">Path to the manifest file</param>
        public static void Save(Application[] contents, string path)
        {
            if (contents == null)
            {
                throw new ArgumentNullException("contents");
            }

            Dictionary<string, object> yaml = new Dictionary<string, object>();
            List<Dictionary<string, object>> apps = new List<Dictionary<string, object>>();
            foreach (Application app in contents)
            {
                Dictionary<string, object> appDict = new Dictionary<string, object>();
                appDict.Add("name", app.Name);
                appDict.Add("memory", string.Format(CultureInfo.InvariantCulture, "{0}M", app.Memory.ToString()));
                appDict.Add("instances", app.InstanceCount);
                if (!string.IsNullOrWhiteSpace(app.BuildpackUrl))
                {
                    appDict.Add("buildpack", app.BuildpackUrl);
                }

                if (app.HealthCheckTimeout != null && app.HealthCheckTimeout > 0)
                {
                    appDict.Add("timeout", app.HealthCheckTimeout);
                }

                if (!string.IsNullOrWhiteSpace(app.Command))
                {
                    appDict.Add("command", app.Command);
                }

                if (app.Hosts != null && app.Hosts.Count > 0)
                {
                    appDict.Add("host", app.Hosts[0]);
                    if (app.Domains != null && app.Domains.Count > 0)
                    {
                        appDict.Add("domain", app.Domains[0]);
                    }
                }
                else
                {
                    appDict.Add("no-route", true);
                }

                if (app.Services != null && app.Services.Count > 0)
                {
                    appDict.Add("services", app.Services.Cast<string>().ToList<string>());
                }

                if (app.EnvironmentVariables != null && app.EnvironmentVariables.Count > 0)
                {
                    appDict.Add("env", app.EnvironmentVariables);
                }

                apps.Add(appDict);
            }

            yaml["applications"] = apps;
            using (TextWriter writer = File.CreateText(path))
            {
                Serializer serializer = new Serializer();
                serializer.Serialize(writer, yaml);
            }
        }

        /// <summary>
        /// Get all applications of the manifest
        /// </summary>
        /// <returns>Array containing applications</returns>
        public Application[] Applications()
        {
            List<Application> apps = new List<Application>();

            var rawData = this.ExpandProperties(this.Data) as Dictionary<string, object>;
            var appMaps = GetAppMaps(rawData);

            foreach (var appMap in appMaps)
            {
                apps.Add(MapToApp(System.IO.Path.GetDirectoryName(this.Path), appMap));
            }

            return apps.ToArray();
        }

        private static Dictionary<string, object>[] GetAppMaps(Dictionary<string, object> data)
        {
            List<Dictionary<string, object>> apps = new List<Dictionary<string, object>>();

            Dictionary<string, object> globalProperties = data.Where(x => x.Key != "applications").ToDictionary(x => x.Key, x => x.Value);

            if (data.Keys.Contains("applications"))
            {
                object appMaps = data["applications"];
                if (appMaps == null || !(appMaps.GetType().IsGenericType && appMaps.GetType().GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>)))
                {
                    throw new ArgumentException("Expected applications to be a list");
                }

                foreach (var appData in appMaps as List<object>)
                {
                    var t = appData.GetType();
                    if (!(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>)))
                    {
                        throw new ArgumentException("Expected application to be a list of key/value pairs");
                    }

                    Dictionary<string, object> appMap = new Dictionary<string, object>();
                    var app = new Dictionary<string, object>();

                    var appDataDictionary = appData as Dictionary<object, object>;

                    if (appDataDictionary != null)
                    {
                        app = appDataDictionary.ToDictionary(k => k.Key.ToString(), k => k.Value);
                    }
                    else
                    {
                        app = (Dictionary<string, object>)appData;
                    }

                    appMap = Util.MergeDictionaries(appMap, app, globalProperties);

                    apps.Add(appMap);
                }
            }
            else
            {
                apps.Add(globalProperties);
            }

            return apps.ToArray();
        }

        private static Application MapToApp(string basePath, Dictionary<string, object> yaml)
        {
            Application app = new Application();
            app.BuildpackUrl = StringValOrDefault(yaml, "buildpack");
            app.DiskQuota = BytesVal(yaml, "disk_quota");

            var domains = ListOrEmptyVal(yaml, "domains");
            string domain = StringVal(yaml, "domain");
            if (domain != null)
            {
                domains.Add(domain);
            }

            app.Domains.AddRange(domains.Distinct().ToArray());

            var hosts = ListOrEmptyVal(yaml, "hosts");
            string host = StringVal(yaml, "host");
            if (host != null)
            {
                hosts.Add(host);
            }

            app.Hosts.AddRange(hosts.Distinct().ToArray());
            app.Name = StringVal(yaml, "name");
            app.Path = StringVal(yaml, "path");
            app.StackName = StringVal(yaml, "stack");
            app.Command = StringValOrDefault(yaml, "command");
            app.Memory = BytesVal(yaml, "memory");
            app.InstanceCount = IntVal(yaml, "instances");
            app.HealthCheckTimeout = IntVal(yaml, "timeout");
            app.NoRoute = BoolVal(yaml, "no-route");
            app.NoHostName = BoolVal(yaml, "no-hostname");
            app.UseRandomHostName = BoolVal(yaml, "random-route");
            app.Services.AddRange(ListOrEmptyVal(yaml, "services").ToArray());
            app.EnvironmentVariables = EnvVarOrEmptyVal(yaml);

            if (app.Path != null)
            {
                if (!System.IO.Path.IsPathRooted(app.Path))
                {
                    app.Path = System.IO.Path.Combine(basePath, app.Path);
                }
            }

            return app;
        }

        private static string StringValOrDefault(Dictionary<string, object> yaml, string key)
        {
            if (!yaml.ContainsKey(key))
            {
                return null;
            }

            var value = yaml[key];
            if (value == null)
            {
                return string.Empty;
            }

            if (typeof(string) == value.GetType())
            {
                if (value.ToString() == "default")
                {
                    return string.Empty;
                }
                else
                {
                    return value.ToString();
                }
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} must be a string or null value", key));
        }

        private static long? BytesVal(Dictionary<string, object> yaml, string key)
        {
            if (!yaml.ContainsKey(key))
            {
                return null;
            }

            var value = yaml[key];
            if (value == null)
            {
                return null;
            }

            return Formatters.Bytes.ToMegabytes(value.ToString());
        }

        private static List<string> ListOrEmptyVal(Dictionary<string, object> yaml, string key)
        {
            if (!yaml.ContainsKey(key))
            {
                return new List<string>();
            }

            var value = yaml[key];
            List<string> result = new List<string>();
            var type = value.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>))
            {
                result.AddRange(((List<object>)value).Select(v => v.ToString()));
            }
            else
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expected {0} to be a list of strings.", key));
            }

            return result;
        }

        private static string StringVal(Dictionary<string, object> yaml, string key)
        {
            if (!yaml.ContainsKey(key))
            {
                return null;
            }

            var value = yaml[key];
            if (value == null)
            {
                return null;
            }

            if (typeof(string) == value.GetType())
            {
                return value.ToString();
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} must be a string value", key));
        }

        private static int? IntVal(Dictionary<string, object> yaml, string key)
        {
            if (!yaml.ContainsKey(key))
            {
                return null;
            }

            var value = yaml[key];
            if (value == null)
            {
                return null;
            }

            int result = 0;
            if (!int.TryParse(value.ToString(), out result))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expected {0} to be a number, but it was a {1}.", key, value.GetType().ToString()));
            }

            return result;
        }

        private static bool BoolVal(Dictionary<string, object> yaml, string key)
        {
            if (!yaml.ContainsKey(key))
            {
                return false;
            }

            var value = yaml[key];
            if (value == null)
            {
                return false;
            }

            if (typeof(bool) == value.GetType())
            {
                return (bool)value;
            }

            if (typeof(string) == value.GetType())
            {
                return value.ToString() == "true";
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expected {0} to be a boolean.", key));
        }

        private static Dictionary<string, string> EnvVarOrEmptyVal(Dictionary<string, object> yaml)
        {
            string key = "env";
            if (!yaml.ContainsKey(key))
            {
                return new Dictionary<string, string>();
            }

            var envVars = yaml[key];
            var t = envVars.GetType();
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var env = envVars as Dictionary<string, object>;
                if (env != null)
                {
                    ValidateEnvVars(env);
                    return env.ToDictionary(k => k.Key, k => k.Value.ToString());
                }
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expected {0} to be a set of key => value, but it was a {1}", key, envVars.GetType().ToString()));
        }

        private static void ValidateEnvVars(Dictionary<string, object> input)
        {
            input.Where(x => x.Value == null).FirstOrDefault();
            if (input.ContainsValue(null))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "env var '{0}' should not be null", input.Where(x => x.Value == null).FirstOrDefault().Key.ToString()));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Manifest uses lower case keys")]
        private object ExpandProperties(object input)
        {
            object output = null;
            Type type = input.GetType();
            if (type == typeof(string))
            {
                string value = (string)input;
                string[] match = Regex.Matches(value, @"\${[\w-]+}").Cast<Match>().Select(m => m.Value).ToArray();
                if (match.Length != 0)
                {
                    if (match[0] == "${random-word}")
                    {
                        output = value.Replace("${random-word}", Words.Generator.Babble().ToLower(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format(CultureInfo.InvariantCulture, "Property '{0}' found in manifest. This feature is no longer supported. Please remove it and try again.", match[0]));
                    }
                }
                else
                {
                    output = input;
                }
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>))
            {
                List<object> values = (List<object>)input;
                List<object> outputObjects = new List<object>();
                for (int i = 0; i < values.Count; i++)
                {
                    var itemOutput = this.ExpandProperties(values[i]);
                    outputObjects.Add(itemOutput);
                }

                output = outputObjects;
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                Dictionary<string, object> value;
                var inputDictionary = input as Dictionary<object, object>;
                if (inputDictionary != null)
                {
                    value = inputDictionary.ToDictionary(k => k.Key.ToString(), k => k.Value);
                }
                else
                {
                    value = (Dictionary<string, object>)input;
                }

                Dictionary<string, object> outputDict = new Dictionary<string, object>();

                foreach (KeyValuePair<string, object> pair in value)
                {
                    var itemOutput = this.ExpandProperties(pair.Value);
                    outputDict[pair.Key] = itemOutput;
                }

                output = outputDict;
            }
            else
            {
                output = input;
            }

            return output;
        }
    }
}