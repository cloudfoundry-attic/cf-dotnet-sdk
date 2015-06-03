namespace CloudFoundry.Manifests.Formatters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal static class Bytes
    {
        private const long BYTE = 1;
        private const long KILOBYTE = 1024 * BYTE;
        private const long MEGABYTE = 1024 * KILOBYTE;
        private const long GIGABYTE = 1024 * MEGABYTE;
        private const long TERABYTE = 1024 * GIGABYTE;

        internal static long ToMegabytes(string s)
        {
            string[] parts = Regex.Matches(s, @"\d+|[a-zA-Z]").Cast<Match>().Select(m => m.Value).ToArray();

            if (parts.Length < 2)
            {
                throw new ArgumentException("Byte quantity must be an integer with a unit of measurement like M, MB, G, or G");
            }

            int value;
            if (!int.TryParse(parts[0], out value))
            {
                throw new ArgumentException("Byte quantity must be an integer with a unit of measurement like M, MB, G, or G");
            }

            long bytes;
            string unit = parts[1].ToUpper(CultureInfo.InvariantCulture);
            switch (unit)
            {
                case "T":
                    {
                        bytes = value * TERABYTE;
                        break;
                    }

                case "G":
                    {
                        bytes = value * GIGABYTE;
                        break;
                    }

                case "M":
                    {
                        bytes = value * MEGABYTE;
                        break;
                    }

                case "K":
                    {
                        bytes = value * KILOBYTE;
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Byte quantity must be an integer with a unit of measurement like M, MB, G, or G");
                    }
            }

            return bytes / MEGABYTE;
        }
    }
}