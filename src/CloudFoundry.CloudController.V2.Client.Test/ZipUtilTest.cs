using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading;

namespace CloudFoundry.CloudController.V2.Client.Test
{
    [TestClass]
    public class ZipUtilTest
    {
        private string folderPath = Path.Combine( Path.GetTempPath(), "TestZip");
        private string extractPath = Path.Combine(Path.GetTempPath(), "TestUnzip");

        [TestInitialize]
        public void Init()
        {
            Directory.CreateDirectory(folderPath);
            Directory.CreateDirectory(Path.Combine(folderPath, "subfolder1"));

            using (StreamWriter ws = new StreamWriter(Path.Combine(folderPath, "subfolder1", "test1.txt")))
            {
                ws.Write("Test file 1");
            }
            using (StreamWriter ws = new StreamWriter(Path.Combine(folderPath, "test.txt")))
            {
                ws.Write("Test file root");
            }
        }

        [TestMethod]
        public void TestZip()
        {
            ZipUtil.ZipFolder(folderPath,Path.Combine(Path.GetTempPath(),"test.zip")).Wait();
            if (File.Exists(Path.Combine(Path.GetTempPath(), "test.zip")))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("Zip file test.zip was not created");
                return;
            }
        
            bool testResult = true;
            ZipUtil.UnzipToFolder(extractPath, Path.Combine(Path.GetTempPath(), "test.zip")).Wait();
            if (!Directory.Exists(extractPath))
            {
                testResult = false;
                Assert.Fail("Extraction path folder does not exist");
            }
            if (!Directory.Exists(Path.Combine(extractPath, "subfolder1")))
            {
                testResult = false;
                Assert.Fail("Extraction path subfolder1 does not exist");
            }
            if (!File.Exists(Path.Combine(extractPath, "subfolder1","test1.txt")))
            {
                testResult = false;
                Assert.Fail("Extraction failed for subfolder1 file");
            }
            else
            {
                using (StreamReader rs = new StreamReader(Path.Combine(extractPath, "subfolder1", "test1.txt")))
                {
                    string content = rs.ReadToEnd();
                    Assert.AreEqual("Test file 1", content);
                }
            }
            if (!File.Exists(Path.Combine(extractPath, "test.txt")))
            {
                testResult = false;
                Assert.Fail("Extraction failed for root folder file");
            }
            else
            {
                using (StreamReader rs = new StreamReader(Path.Combine(extractPath, "test.txt")))
                {
                    string content = rs.ReadToEnd();
                    Assert.AreEqual("Test file root", content);
                }
            }
            Assert.IsTrue(testResult);

            Directory.Delete(folderPath, true);
            Directory.Delete(extractPath, true);
            File.Delete(Path.Combine(Path.GetTempPath(), "test.zip"));
        
        }
    }
}
