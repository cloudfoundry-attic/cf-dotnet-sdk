namespace CloudFoundry.CloudController.Common.PushTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper tools for application push
    /// </summary>
    public class AppPushTools : IAppPushTools
    {
        /// <summary>
        /// Gets the file fingerprints from the application folder
        /// As the sha1 is calculated based on the content of the file, 
        /// there is a possibility that one key can have multiple fingerprints (duplicate files)
        /// </summary>
        /// <param name="appPath">The path to the application folder or the path to a zip file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Return a dictionary of file fingerprints, with sha1 as key and a list of file fingerprints as value.</returns>
        public async Task<Dictionary<string, List<FileFingerprint>>> GetFileFingerprints(string appPath, System.Threading.CancellationToken cancellationToken)
        {
            Dictionary<string, List<FileFingerprint>> fingerprints = new Dictionary<string, List<FileFingerprint>>();

            if (File.Exists(appPath))
            {
                var extractedPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

                if (!Directory.Exists(extractedPath))
                {
                    Directory.CreateDirectory(extractedPath);
                }

                System.IO.Compression.ZipFile.ExtractToDirectory(appPath, extractedPath);
                appPath = extractedPath;
            }

            appPath = Path.GetFullPath(appPath);

            foreach (string file in Directory.GetFiles(appPath, "*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(file);
                FileFingerprint print = new FileFingerprint();
                print.Size = fileInfo.Length;
                print.FileName = fileInfo.FullName.Substring(appPath.Length).TrimStart('\\');

                if (Path.DirectorySeparatorChar == '\\')
                {
                    print.FileName = print.FileName.Replace(Path.DirectorySeparatorChar, '/');
                }

                print.SHA1 = await this.CalculateSHA1(fileInfo.FullName, cancellationToken);

                if (fingerprints.ContainsKey(print.SHA1))
                {
                    fingerprints[print.SHA1].Add(print);
                }
                else
                {
                    fingerprints.Add(print.SHA1, new List<FileFingerprint>() { print });
                }
            }

            return fingerprints;
        }

        /// <summary>
        /// Creates a zip archive containing specific files from the application folder
        /// </summary>
        /// <param name="appPath">The path to the application folder</param>
        /// <param name="files">The files that will be added to the archive.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        public async Task<System.IO.Stream> GetZippedPayload(string appPath, IEnumerable<string> files, System.Threading.CancellationToken cancellationToken)
        {
            string zipFile = Path.Combine(Path.GetTempPath(), "payload.zip");

            //// If no files need to be uploaded we create a dummy file
            using (var enumerator = files.GetEnumerator())
            {
                //// equivalent to ( files.Count == 0 ) 
                if (enumerator.MoveNext() == false)
                {
                    string emptyFile = "_empty_";
                    File.WriteAllText(Path.Combine(appPath, emptyFile), Guid.NewGuid().ToString());
                    files = new string[] { emptyFile };
                }
            }

            using (Stream zipStream = new FileStream(zipFile, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    foreach (string file in files)
                    {
                        if (file.Length > 0)
                        {
                            await Task.Factory.StartNew(new Action(() =>
                            {
                                using (FileStream fs = new FileStream(Path.Combine(appPath, file), FileMode.Open, FileAccess.Read))
                                {
                                    using (BufferedStream bs = new BufferedStream(fs))
                                    {
                                        ZipArchiveEntry entry = archive.CreateEntry(file, CompressionLevel.Optimal);
                                        using (BufferedStream writer = new BufferedStream(entry.Open()))
                                        {
                                            bs.CopyTo(writer);
                                        }
                                    }
                                }
                            }));
                        }
                    }
                }
            }

            Stream fileStream = new FileStream(zipFile, FileMode.Open);
            return fileStream;
        }

        /// <summary>
        /// Creates a zip archive containing the all files from the application folder <see cref="AppPushTools"/>
        /// </summary>
        /// <param name="appPath">The path to the application folder</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An open stream of the zip file</returns>
        public Task<Stream> GetZippedPayload(string appPath, System.Threading.CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(appPath, "*", SearchOption.AllDirectories).Select(f => new FileInfo(f).FullName.Replace(appPath, string.Empty).TrimStart('\\'));
            return this.GetZippedPayload(appPath, files, cancellationToken);
        }

        private async Task<string> CalculateSHA1(string filePath, System.Threading.CancellationToken cancellationToken)
        {
            string formattedSHA1 = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (SHA1CryptoServiceProvider cryptoProvider = new SHA1CryptoServiceProvider())
                    {
                        formattedSHA1 = await Task.Factory.StartNew<string>(
                         new Func<string>(() =>
                          {
                              if (cancellationToken.IsCancellationRequested)
                              {
                                  return null;
                              }

                              return BitConverter.ToString(cryptoProvider.ComputeHash(bs)).Replace("-", string.Empty);
                          }));
                    }
                }
            }

            return formattedSHA1.ToLower();
        }
    }
}
