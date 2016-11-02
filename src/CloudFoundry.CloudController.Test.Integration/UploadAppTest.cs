using CloudFoundry.CloudController.Common.Exceptions;
using CloudFoundry.CloudController.Common.PushTools;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using CloudFoundry.UAA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class UploadAppTest
    {
        private static string tempAppPath = Path.Combine(System.IO.Path.GetTempPath(), Path.GetRandomFileName());
        private static CloudFoundryClient client;
        private static CreateAppRequest apprequest;

        [TestInitialize]
        public void TestInit()
        {
            Directory.CreateDirectory(tempAppPath);

            client = TestUtil.GetClient();
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = TestUtil.User;
            credentials.Password = TestUtil.Password;
            try
            {
                client.Login(credentials).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Error while logging in" + ex.ToString());
            }

            PagedResponseCollection<ListAllSpacesResponse> spaces = client.Spaces.ListAllSpaces().Result;

            Guid spaceGuid = Guid.Empty;

            foreach (ListAllSpacesResponse space in spaces)
            {
                spaceGuid = space.EntityMetadata.Guid;
                break;
            }

            if (spaceGuid == Guid.Empty)
            {
                throw new Exception("No spaces found");
            }

            PagedResponseCollection<ListAllAppsResponse> apps = client.Apps.ListAllApps().Result;

            foreach (ListAllAppsResponse app in apps)
            {
                if (app.Name.StartsWith("uploadTest"))
                {
                    client.Apps.DeleteApp(app.EntityMetadata.Guid).Wait();
                    break;
                }
            }

            apprequest = new CreateAppRequest();
            apprequest.Name = "uploadTest" + Guid.NewGuid().ToString();
            apprequest.SpaceGuid = spaceGuid;

            client.Apps.PushProgress += Apps_PushProgress;
        }

        static void Apps_PushProgress(object sender, PushProgressEventArgs e)
        {
            Console.WriteLine(e.Message + " " + e.Percent);
        }

        [TestMethod]
        [TestCategory("RequiresPackageDownloadSupport")]
        public void UploadTest()
        {
            var staticContent = "dummy content";
            var content1 = Guid.NewGuid().ToString();
            var content2 = Guid.NewGuid().ToString();

            Directory.CreateDirectory(Path.Combine(tempAppPath, "f1"));
            Directory.CreateDirectory(Path.Combine(tempAppPath, "f1", "f2"));
            File.WriteAllText(Path.Combine(tempAppPath, "content.txt"), staticContent);
            File.WriteAllText(Path.Combine(tempAppPath, "content-clone.txt"), staticContent);
            File.WriteAllText(Path.Combine(tempAppPath, "f1\\content.txt"), staticContent);
            File.WriteAllText(Path.Combine(tempAppPath, "f1\\f2\\content-in-folder.txt"), staticContent);
            File.WriteAllText(Path.Combine(tempAppPath, "content-Unique.txt"), content1);
            File.WriteAllText(Path.Combine(tempAppPath, "content-unique-clone.txt"), content1);
            File.WriteAllText(Path.Combine(tempAppPath, "content-unique2.txt"), content2);
            File.WriteAllText(Path.Combine(tempAppPath, "zero.txt"), "");
            File.WriteAllText(Path.Combine(tempAppPath, "zero2.txt"), "");

            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;

            Guid appGuid = app.EntityMetadata.Guid;

            client.Apps.Push(appGuid, tempAppPath, false).Wait();

            var zipFromServerPath = Path.GetTempFileName();
            DownloadAppZip(appGuid.ToString(), zipFromServerPath);
            if (new FileInfo(zipFromServerPath).Length == 0)
            {
                Assert.Inconclusive("API endpoint doesn't support package downloads");
            }

            using (var fs = File.OpenRead(zipFromServerPath))
            {
                using (var arch = new ZipArchive(fs, ZipArchiveMode.Read, true))
                {
                    Assert.AreEqual(9, arch.Entries.Count());

                    Assert.IsTrue(arch.Entries.First(a => a.FullName == "content.txt").Length == staticContent.Length);
                    Assert.IsTrue(arch.Entries.First(a => a.FullName == "zero.txt").Length == 0);
                    Assert.IsTrue(arch.Entries.First(a => a.Name == "content-in-folder.txt").FullName == "f1/f2/content-in-folder.txt");

                    var contentSStream = new StreamReader(arch.Entries.First(a => a.Name == "content-Unique.txt").Open());
                    Assert.IsTrue(contentSStream.ReadToEnd() == content1);
                }
            }

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }

        [TestMethod]
        [TestCategory("RequiresPackageDownloadSupport")]
        public void UploadTwiceTest()
        {
            var staticContent = "alabala";
            var contentPath = Path.Combine(tempAppPath, "content.zip");

            using (var fs = File.OpenWrite(contentPath))
            {
                using (var za = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    var ze = za.CreateEntry("content.txt", CompressionLevel.NoCompression);
                    using (var sw = new StreamWriter(ze.Open()))
                    {
                        sw.Write(staticContent);
                    }
                }
            }


            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;
            Guid appGuid = app.EntityMetadata.Guid;

            using (var fs = File.OpenRead(contentPath))
            {
                client.Apps.UploadBits(appGuid, fs, new List<FileFingerprint>() { }).Wait();
            }

            using (var fs = File.OpenRead(contentPath))
            {
                client.Apps.UploadBits(appGuid, fs, new List<FileFingerprint>() { }).Wait();
            }

            var zipFromServerPath = Path.GetTempFileName();
            DownloadAppZip(appGuid.ToString(), zipFromServerPath);
            if (new FileInfo(zipFromServerPath).Length == 0)
            {
                Assert.Inconclusive("API endpoint doesn't support package downloads");
            }

            using (var fs = File.OpenRead(zipFromServerPath))
            {
                using (var arch = new ZipArchive(fs, ZipArchiveMode.Read, true))
                {
                    Assert.IsTrue(arch.Entries.Count() == 1);
                    Assert.IsTrue(arch.Entries.First(a => a.Name == "content.txt").Length == staticContent.Length);
                }
            }

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }

        [TestMethod]
        [TestCategory("RequiresPackageDownloadSupport")]
        public void UploadTestWithCache()
        {
            var staticContent = "dummy content";
            var content1 = Guid.NewGuid().ToString();

            Directory.CreateDirectory(Path.Combine(tempAppPath, "f1"));
            Directory.CreateDirectory(Path.Combine(tempAppPath, "c1"));

            File.WriteAllText(Path.Combine(tempAppPath, "f1\\content.txt"), staticContent);

            // https://github.com/cloudfoundry/cf-release/blob/master/jobs/cloud_controller_ng/spec#L242
            long binContentSize = 65536 * 3;
            using (FileStream stream = new FileStream(Path.Combine(tempAppPath, "c1\\bigcontent.bin"), FileMode.Create))
            {
                var rng = new Random();
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    while (writer.BaseStream.Length < binContentSize)
                    {
                        writer.Write((byte)rng.Next(256));
                    }
                    writer.Close();
                }
            }

            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;

            Guid appGuid = app.EntityMetadata.Guid;

            client.Apps.Push(appGuid, tempAppPath, false).Wait();
            // Push twice to use the cache
            client.Apps.Push(appGuid, tempAppPath, false).Wait();

            var zipFromServerPath = Path.GetTempFileName();
            DownloadAppZip(appGuid.ToString(), zipFromServerPath);
            if (new FileInfo(zipFromServerPath).Length == 0)
            {
                Assert.Inconclusive("API endpoint doesn't support package downloads");
            }

            using (var fs = File.OpenRead(zipFromServerPath))
            {
                using (var arch = new ZipArchive(fs, ZipArchiveMode.Read, true))
                {
                    Assert.IsTrue(arch.Entries.First(a => a.FullName == "f1/content.txt").Length == staticContent.Length);
                    Assert.IsTrue(arch.Entries.First(a => a.FullName == "c1/bigcontent.bin").Length == binContentSize);
                }
            }

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }

        [TestMethod]
        [TestCategory("RequiresPackageDownloadSupport")]
        public void UploadInvalidZipTest()
        {
            // TODO: use zip with invalid file paths
            // ref: https://github.com/cloudfoundry/cloud_controller_ng/blob/5b8655ade3ca1b4000a5086101d321c6cfd81ce6/lib/cloud_controller/blobstore/client.rb#L33

            var staticContent = "alabala";
            var contentPath = Path.Combine(tempAppPath, "content.zip");
            File.WriteAllText(contentPath, staticContent);

            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;

            Guid appGuid = app.EntityMetadata.Guid;

            bool exceptionThrown = false;
            try
            {
                using (var fs = File.OpenRead(contentPath))
                {
                    client.Apps.UploadBits(appGuid, fs, new List<Common.PushTools.FileFingerprint>()).Wait();
                }
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.IsInstanceOfType(ex.InnerException, typeof(CloudFoundryException));
                Assert.IsTrue(ex.InnerException.Message.Contains("uploading bits"));
            }

            Assert.IsTrue(exceptionThrown);
            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }


        [TestMethod]
        [TestCategory("RequiresPackageDownloadSupport")]
        public void UploadValidFingerprintsTest()
        {

            var binContentFileName = "content.bin";
            var binContentFilePath = Path.Combine(tempAppPath, binContentFileName);
            string binContentSha1 = null;

            // https://github.com/cloudfoundry/cf-release/blob/master/jobs/cloud_controller_ng/spec#L242
            long binContentSize = 65536 * 3;
            using (FileStream stream = new FileStream(binContentFilePath, FileMode.Create))
            {
                var rng = new Random();
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    while (writer.BaseStream.Length < binContentSize)
                    {
                        writer.Write((byte)rng.Next(256));
                    }
                    writer.Close();
                }
            }

            using (FileStream stream = File.OpenRead(binContentFilePath))
            {
                SHA1Managed sha = new SHA1Managed();
                binContentSha1 = BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
            }

            var contentPath = Path.Combine(tempAppPath, "content.zip");

            using (FileStream contentStream = File.OpenRead(binContentFilePath))
            {
                using (var fs = File.OpenWrite(contentPath))
                {
                    using (var za = new ZipArchive(fs, ZipArchiveMode.Create, true))
                    {
                        var ze = za.CreateEntry("content.bin", CompressionLevel.NoCompression);

                        using (var s = ze.Open())
                        {
                            contentStream.CopyTo(s);
                        }
                    }
                }
            }


            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;
            Guid appGuid = app.EntityMetadata.Guid;

            using (var fs = File.OpenRead(contentPath))
            {
                var efpl = new List<FileFingerprint>() { };
                client.Apps.UploadBits(appGuid, fs, efpl).Wait();
            }


            using (var fs = File.Open(contentPath, FileMode.Truncate, FileAccess.Write))
            {
                using (var za = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    var ze = za.CreateEntry(@"d1\dummy-backslash.txt", CompressionLevel.NoCompression);
                    using (var sw = new StreamWriter(ze.Open()))
                    {
                        sw.Write("dummy");
                    }
                    ze = za.CreateEntry(@"d2/dummy-slash.txt", CompressionLevel.NoCompression);
                    using (var sw = new StreamWriter(ze.Open()))
                    {
                        sw.Write("dummy");
                    }
                }
            }

            var fpl = new List<FileFingerprint>() { };
            using (var fs = File.OpenRead(contentPath))
            {
                fpl.Add(new FileFingerprint() { FileName = @"content.bin", SHA1 = binContentSha1, Size = binContentSize });
                fpl.Add(new FileFingerprint() { FileName = @"f2/content.bin", SHA1 = binContentSha1, Size = binContentSize });
                fpl.Add(new FileFingerprint() { FileName = @"f3\content.bin", SHA1 = binContentSha1, Size = binContentSize });

                client.Apps.UploadBits(appGuid, fs, fpl).Wait();
            }

            var zipFromServerPath = Path.GetTempFileName();
            DownloadAppZip(appGuid.ToString(), zipFromServerPath);
            if (new FileInfo(zipFromServerPath).Length == 0)
            {
                Assert.Inconclusive("API endpoint doesn't support package downloads");
            }

            string serverBinContentSha1 = null;

            using (var fs = File.OpenRead(zipFromServerPath))
            {
                using (var arch = new ZipArchive(fs, ZipArchiveMode.Read, true))
                {
                    Assert.IsTrue(arch.Entries.Any(x => x.FullName == @"content.bin" && x.Name == "content.bin"));
                    Assert.IsTrue(arch.Entries.Any(x => x.FullName == @"f2/content.bin" && x.Name == "content.bin"));
                    Assert.IsTrue(arch.Entries.Any(x => x.FullName == @"f3\content.bin" && x.Name == "content.bin"));

                    Assert.IsTrue(arch.Entries.Any(x => x.FullName == @"d2/dummy-slash.txt" && x.Name == "dummy-slash.txt"));
                    Assert.IsTrue(arch.Entries.Any(x => x.FullName == @"d1/dummy-backslash.txt" && x.Name == "dummy-backslash.txt"));

                    foreach (var e in arch.Entries)
                    {
                        if (e.Name == "content.bin")
                        {
                            using (var stream = e.Open())
                            {
                                SHA1Managed sha = new SHA1Managed();
                                serverBinContentSha1 = BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
                            }

                            if (e.Length == 0)
                            {
                                Assert.Inconclusive("Content was not added from cache.");
                            }

                            Assert.AreEqual(binContentSize, e.Length);
                            Assert.AreEqual(binContentSha1, serverBinContentSha1);
                        }
                    }
                }
            }

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }

        [TestMethod, Ignore] // ignore because it only works with nfs
        [TestCategory("RequiresPackageDownloadSupport")]
        public void UploadInvalidFingerprintsTest()
        {
            var staticContent = "alabala";
            var contentPath = Path.Combine(tempAppPath, "content.zip");

            using (var fs = File.OpenWrite(contentPath))
            {
                using (var za = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    var ze = za.CreateEntry("content.txt", CompressionLevel.NoCompression);
                    using (var sw = new StreamWriter(ze.Open()))
                    {
                        sw.Write(staticContent);
                    }
                }
            }


            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;
            Guid appGuid = app.EntityMetadata.Guid;

            using (var fs = File.OpenRead(contentPath))
            {
                var fp1 = new FileFingerprint() { FileName = "file1", SHA1 = "xxxxxxxxxxx", Size = -1 };
                var fp2 = new FileFingerprint() { FileName = "file2", SHA1 = "yyyyyyyyyyyyy", Size = 1024 * 1024 * 100 };
                var fpl = new List<FileFingerprint>() { fp1, fp2 };

                client.Apps.UploadBits(appGuid, fs, fpl).Wait();
            }

            var zipFromServerPath = Path.GetTempFileName();
            DownloadAppZip(appGuid.ToString(), zipFromServerPath);
            if (new FileInfo(zipFromServerPath).Length == 0)
            {
                Assert.Inconclusive("API endpoint doesn't support package downloads");
            }

            using (var fs = File.OpenRead(zipFromServerPath))
            {
                using (var arch = new ZipArchive(fs, ZipArchiveMode.Read, true))
                {
                    // Indeed, this is very strange. Even if the SHA is not found in the cache the files will still be packed.
                    // The contents of the file differ based on CC's cache store. If the store is backed on local file system (or NFS)
                    // it will be an empty file. If the store is backed on S3, it will contain the HTTP response error.
                    Assert.IsTrue(arch.Entries.Count() == 3);
                }
            }


            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }

        [TestMethod]
        public void UploadInvalidAppGuidTest()
        {
            var staticContent = "alabala";
            var contentPath = Path.Combine(tempAppPath, "content.zip");

            using (var fs = File.OpenWrite(contentPath))
            {
                using (var za = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    var ze = za.CreateEntry("content.txt", CompressionLevel.NoCompression);
                    using (var sw = new StreamWriter(ze.Open()))
                    {
                        sw.Write(staticContent);
                    }
                }
            }


            bool exceptionThrown = false;
            try
            {
                using (var fs = File.OpenRead(contentPath))
                {
                    client.Apps.UploadBits(Guid.NewGuid(), fs, new List<Common.PushTools.FileFingerprint>()).Wait();
                }
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.IsInstanceOfType(ex.InnerException, typeof(CloudFoundryException));
                Assert.IsTrue(ex.InnerException.Message.Contains("uploading bits"));
            }

            Assert.IsTrue(exceptionThrown);
            Directory.Delete(tempAppPath, true);
        }


        private void DownloadAppZip(string appGuid, string fileDestination)
        {
            var wc = new WebClient();

            wc.Headers.Set(HttpRequestHeader.Authorization, "bearer " + client.AuthorizationToken);

            // TODO: get TestUtil.ServerUrl from client
            // TODO: use SDK for download when ready
            // http://apidocs.cloudfoundry.org/210/apps/downloads_the_bits_for_an_app.html
            var downloadUri = new Uri(TestUtil.ServerUrl + String.Format("/v2/apps/{0}/download", appGuid));

            wc.DownloadFile(downloadUri, fileDestination);
        }

    }
}
