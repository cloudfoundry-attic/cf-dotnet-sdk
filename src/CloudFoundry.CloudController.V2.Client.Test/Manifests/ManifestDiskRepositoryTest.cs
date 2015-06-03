using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CloudFoundry.Manifests;

namespace CloudFoundry.CloudController.V2.Client.Test.Manifests
{
    [TestClass]
    public class ManifestDiskRepositoryTest
    {
        string testPath = Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ManifestDiskRepositoryTest)).Location);

        [TestMethod]
        public void TestReadManifest()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "manifest.yaml"));

            Assert.IsNotNull(man);
            Assert.IsNotNull(man.Data);
            Assert.IsNotNull(man.Path);
            Assert.IsNotNull(man.Applications());
        }

        [TestMethod]
        public void TestReadManifestDirPath()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests"));

            Assert.IsNotNull(man);
            Assert.IsNotNull(man.Data);
            Assert.IsNotNull(man.Path);
            Assert.IsNotNull(man.Applications());
        }

        [TestMethod]
        public void TestReadManifestFileDoesNotExist()
        {
            Exception exception = null;
            try
            {
                Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", Guid.NewGuid().ToString()));
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(FileNotFoundException));
            Assert.AreEqual("Error finding manifest", exception.Message);
        }

        [TestMethod]
        public void TestReadManifestInherit()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "inherit.yaml"));

            Assert.IsNotNull(man);
            Assert.IsNotNull(man.Data);
            Assert.IsNotNull(man.Path);
            Assert.IsNotNull(man.Applications());
        }
    }
}
