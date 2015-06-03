namespace CloudFoundry.Manifests
{
    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;

    /// <summary>
    /// Manifest Repository class
    /// </summary>
    public static class ManifestDiskRepository
    {
        /// <summary>
        /// Reads and parses a manifest file
        /// </summary>
        /// <param name="inputPath">Path to a manifest yaml or a directoy containing a manifest.yaml</param>
        /// <returns>An instance of a Manifest class</returns>
        public static Manifest ReadManifest(string inputPath)
        {
            Manifest manifest = new Manifest();
            string manifestPath = GetManifestPath(inputPath);
            if (manifestPath == null)
            {
                throw new FileNotFoundException("Error finding manifest", inputPath);
            }

            manifest.Path = manifestPath;

            var dict = ReadAllYamlFiles(manifestPath);
            manifest.Data = dict;
            return manifest;
        }

        private static Dictionary<string, object> ReadAllYamlFiles(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            Dictionary<string, object> mapp = ParseManifest(path);
            if (!mapp.ContainsKey("inherit"))
            {
                return mapp;
            }

            string inheritedPath = mapp["inherit"].ToString();
            if (!Path.IsPathRooted(inheritedPath))
            {
                inheritedPath = Path.Combine(Path.GetDirectoryName(path), inheritedPath);
            }

            Dictionary<string, object> inheritedMap = ReadAllYamlFiles(inheritedPath);

            return Util.MergeDictionaries(mapp, inheritedMap);
        }

        private static Dictionary<string, object> ParseManifest(string file)
        {
            string content = File.ReadAllText(file);
            using (var input = new StringReader(content))
            {
                Deserializer deserializer = new Deserializer();
                return deserializer.Deserialize<Dictionary<string, object>>(input);
            }
        }

        private static string GetManifestPath(string userSpecifiedPath)
        {
            FileAttributes attr;
            try
            {
                attr = File.GetAttributes(userSpecifiedPath);
            }
            catch (Exception ex)
            {
                if
                (ex is UnauthorizedAccessException
                    || ex is PathTooLongException
                    || ex is DirectoryNotFoundException
                    || ex is NotSupportedException
                    || ex is ArgumentException
                    || ex is FileNotFoundException
                    || ex is IOException)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            if (attr.HasFlag(FileAttributes.Directory))
            {
                return Directory.GetFiles(userSpecifiedPath, "manifest.y*ml").FirstOrDefault();
            }
            else
            {
                return userSpecifiedPath;
            }
        }
    }
}