namespace CloudFoundry.Manifests.Words
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    internal static class Generator
    {
        internal static string Babble()
        {
            List<string> nouns = new List<string>();
            List<string> adjectives = new List<string>();

            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("CloudFoundry.Manifests.Words.nouns.txt")))
            {
                while (!reader.EndOfStream)
                {
                    nouns.Add(reader.ReadLine());
                }
            }

            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("CloudFoundry.Manifests.Words.adjectives.txt")))
            {
                while (!reader.EndOfStream)
                {
                    adjectives.Add(reader.ReadLine());
                }
            }

            Random rnd = new Random();

            string noun = nouns[rnd.Next(nouns.Count)];
            string adjective = adjectives[rnd.Next(adjectives.Count)];

            return string.Format(CultureInfo.InvariantCulture, "{0}-{1}", adjective, noun);
        }
    }
}