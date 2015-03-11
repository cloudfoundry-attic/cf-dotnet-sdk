namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PCLStorage;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Util", Justification = "Util shortened from utility")]
    internal static class ZipUtil
    {
        private static string basePath = string.Empty;

        internal static async Task ZipFolder(string currentFolder, string zipName)
        {
            basePath = currentFolder;
            IFile zipFile = await PCLStorage.FileSystem.Current.RoamingStorage.CreateFileAsync(zipName, CreationCollisionOption.ReplaceExisting);
            using (Stream zipStream = await zipFile.OpenAsync(FileAccess.ReadAndWrite))
            {
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    await AddToZip(currentFolder, archive);
                }
            }
        }

        internal static async Task UnzipToFolder(string extractionFolder, string zipName)
        {
            ExistenceCheckResult zipFileExists = await PCLStorage.FileSystem.Current.RoamingStorage.CheckExistsAsync(zipName);

            if (zipFileExists == ExistenceCheckResult.FileExists)
            {
                IFile zipFile = await PCLStorage.FileSystem.Current.RoamingStorage.GetFileAsync(zipName);
                Stream zipStream = await zipFile.OpenAsync(FileAccess.ReadAndWrite);

                if (PCLStorage.FileSystem.Current.RoamingStorage.CheckExistsAsync(extractionFolder).Result != ExistenceCheckResult.FolderExists)
                {
                    PCLStorage.FileSystem.Current.RoamingStorage.CreateFolderAsync(extractionFolder, CreationCollisionOption.ReplaceExisting).Wait();
                }

                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string folder = Path.GetDirectoryName(Path.Combine(extractionFolder, entry.FullName));

                        if (PCLStorage.FileSystem.Current.RoamingStorage.CheckExistsAsync(folder).Result != ExistenceCheckResult.FolderExists)
                        {
                            PCLStorage.FileSystem.Current.RoamingStorage.CreateFolderAsync(folder, CreationCollisionOption.ReplaceExisting).Wait();
                        }

                        IFile extractionFile = PCLStorage.FileSystem.Current.RoamingStorage.CreateFileAsync(Path.Combine(extractionFolder, entry.FullName), CreationCollisionOption.ReplaceExisting).Result;
                        using (Stream fs = await extractionFile.OpenAsync(FileAccess.ReadAndWrite))
                        {
                            using (StreamWriter writter = new StreamWriter(fs))
                            {
                                using (StreamReader reader = new StreamReader(entry.Open()))
                                {
                                    string content = reader.ReadToEnd();
                                    writter.Write(content);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static async Task AddToZip(string actualFolder, ZipArchive archive)
        {
            IFolder currentFolder = await PCLStorage.FileSystem.Current.GetFolderFromPathAsync(actualFolder);

            if (currentFolder == null)
            {
                return;
            }

            IList<IFolder> subFolders = await currentFolder.GetFoldersAsync();

            foreach (IFolder folder in subFolders)
            {
                await AddToZip(folder.Path, archive);
            }

            IList<IFile> files = await currentFolder.GetFilesAsync();

            foreach (IFile file in files)
            {
                ////Substring 1 removes first separator
                string relativePath = file.Path.Replace(basePath, string.Empty).Substring(1);
                ZipArchiveEntry entry = archive.CreateEntry(relativePath, CompressionLevel.Optimal);
                using (StreamWriter writer = new StreamWriter(entry.Open()))
                {
                    string content = await file.ReadAllTextAsync();
                    writer.Write(content);
                }
            }
        }
    }
}
