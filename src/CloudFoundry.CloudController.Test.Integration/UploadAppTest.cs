using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using System.Threading;
using CloudFoundry.UAA;
using System.IO;
using CloudFoundry.Logyard.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO.Compression;
using CloudFoundry.CloudController.Common.Exceptions;
using CloudFoundry.CloudController.Common.PushTools;


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

            File.WriteAllText(Path.Combine(tempAppPath, "content.txt"), staticContent);
            File.WriteAllText(Path.Combine(tempAppPath, "content-clone.txt"), staticContent);
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
                    Assert.IsTrue(arch.Entries.Count() == 7);

                    Assert.IsTrue(arch.Entries.First(a => a.Name == "content.txt").Length == staticContent.Length);
                    Assert.IsTrue(arch.Entries.First(a => a.Name == "zero.txt").Length == 0);

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
                client.Apps.UploadBits(appGuid, fs, new List<FileFingerprint>() {  }).Wait();
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
