using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CloudFoundry.Manifests;

namespace CloudFoundry.CloudController.V2.Client.Test.Manifests
{
    [TestClass]
    public class ManifestDiskRepositoryTest
    {

        [TestMethod]
        [DeploymentItem(@"Assets\manifests\manifest.yaml", "manifests")]
        public void TestReadManifest()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine("manifests", "manifest.yaml"));

            Assert.IsNotNull(man);
            Assert.IsNotNull(man.Data);
            Assert.IsNotNull(man.Path);
            Assert.IsNotNull(man.Applications());
        }

        [TestMethod]
        [DeploymentItem(@"Assets\manifests\manifest.yaml", "manifests")]
        public void TestReadManifestDirPath()
        {
            Manifest man = ManifestDiskRepository.ReadManifest("manifests");

            Assert.IsNotNull(man);
            Assert.IsNotNull(man.Data);
            Assert.IsNotNull(man.Path);
            Assert.IsNotNull(man.Applications());
        }

        [TestMethod]
        [DeploymentItem(@"Assets\manifests\manifest.yaml", "manifests")]
        public void TestReadManifestFileDoesNotExist()
        {
            Exception exception = null;
            try
            {
                Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine("manifests", Guid.NewGuid().ToString()));
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(FileNotFoundException));
            Assert.AreEqual("Error finding manifest", exception.Message);
        }

        [TestMethod]
        [DeploymentItem(@"Assets\manifests\inherit.yaml", "manifests")]
        [DeploymentItem(@"Assets\manifests\inherited.yaml", "manifests")]
        public void TestReadManifestInherit()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine("manifests", "inherit.yaml"));

            Assert.IsNotNull(man);
            Assert.IsNotNull(man.Data);
            Assert.IsNotNull(man.Path);
            Assert.IsNotNull(man.Applications());
        }
    }
}
