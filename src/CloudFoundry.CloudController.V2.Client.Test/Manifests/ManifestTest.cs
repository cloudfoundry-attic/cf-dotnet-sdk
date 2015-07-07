using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CloudFoundry.Manifests.Models;
using CloudFoundry.Manifests;

namespace CloudFoundry.CloudController.V2.Client.Test.Manifests
{
    [TestClass]
    public class ManifestTest
    {
        string testPath = Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(ManifestTest)).Location);
        [TestMethod]
        public void TestLoadManifest()
        {
            
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "manifest.yaml"));

            Application[] apps = man.Applications();
            Assert.AreEqual(1, apps.Length);
            Assert.AreEqual("app-name", apps[0].Name);
            Assert.AreEqual(128, apps[0].Memory);
            Assert.AreEqual(1, apps[0].InstanceCount);
            Assert.AreEqual(1, apps[0].Hosts.Count);
            Assert.AreEqual(1, apps[0].Domains.Count);
            Assert.AreEqual("home", apps[0].Hosts[0]);
            Assert.AreEqual("app.example.com", apps[0].Domains[0]);
            Assert.AreEqual(@"c:\path\to\app", apps[0].Path);
            Assert.AreEqual(2, apps[0].EnvironmentVariables.Count);
            Assert.AreEqual("first", apps[0].EnvironmentVariables["env1"]);
            Assert.AreEqual("test-bp", apps[0].BuildpackUrl);
            Assert.AreEqual(500, apps[0].HealthCheckTimeout);
            Assert.AreEqual("cmd", apps[0].Command);
            Assert.AreEqual(2, apps[0].Services.Count);
            Assert.AreEqual(1024, apps[0].DiskQuota);
            Assert.AreNotEqual(-1, apps[0].Services.IndexOf("mysql"));
        }

        [TestMethod]
        public void TestInheritManifest()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "inherit.yaml"));

            Application[] apps = man.Applications();
            Assert.AreEqual(1, apps.Length);
            Assert.AreEqual("app-name", apps[0].Name);
            Assert.AreEqual(128, apps[0].Memory);
            Assert.AreEqual(1, apps[0].InstanceCount);
            Assert.AreEqual(1, apps[0].Hosts.Count);
            Assert.AreEqual(1, apps[0].Domains.Count);
            Assert.AreEqual("home", apps[0].Hosts[0]);
            Assert.AreEqual("app.example.com", apps[0].Domains[0]);
            Assert.AreEqual(@"c:\path\to\app", apps[0].Path);
            Assert.AreEqual(2, apps[0].EnvironmentVariables.Count);
            Assert.AreEqual("first", apps[0].EnvironmentVariables["env1"]);
        }

        [TestMethod]
        public void TestRandomWord()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "random.yaml"));

            Application[] apps = man.Applications();
            Assert.AreEqual(1, apps.Length);
            Assert.AreNotEqual("${random-word}", apps[0].Name);
        }

        [TestMethod]
        public void TestSave()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "manifest.yaml"));

            string tempFile = Path.GetTempFileName();
            Manifest.Save(man.Applications(), tempFile);

            Manifest tempManifest = ManifestDiskRepository.ReadManifest(tempFile);

            Application[] apps = tempManifest.Applications();
            Assert.AreEqual(1, apps.Length);
            Assert.AreEqual("app-name", apps[0].Name);
            Assert.AreEqual(128, apps[0].Memory);
            Assert.AreEqual(1, apps[0].InstanceCount);
            Assert.AreEqual(1, apps[0].Hosts.Count);
            Assert.AreEqual(1, apps[0].Domains.Count);
            Assert.AreEqual("home", apps[0].Hosts[0]);
            Assert.AreEqual("app.example.com", apps[0].Domains[0]);
            Assert.AreEqual(2, apps[0].EnvironmentVariables.Count);
            Assert.AreEqual("first", apps[0].EnvironmentVariables["env1"]);
            Assert.AreEqual("test-bp", apps[0].BuildpackUrl);
            Assert.AreEqual(2, apps[0].Services.Count);
            Assert.AreEqual(@"c:\path\to\app", apps[0].Path);
            Assert.AreEqual("win2012r2", apps[0].StackName);
            Assert.AreEqual(1024, apps[0].DiskQuota);
            Assert.IsFalse(apps[0].NoHostName);
            Assert.IsFalse(apps[0].NoRoute);
            Assert.IsFalse(apps[0].UseRandomHostName);
            Assert.AreNotEqual(-1, apps[0].Services.IndexOf("mysql"));

            File.Delete(tempFile);
        }

        [TestMethod]
        public void TestNoRoute()
        {
            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "no_route.yaml"));

            Application[] apps = man.Applications();
            Assert.AreEqual(1, apps.Length);
            Assert.IsTrue(apps[0].NoRoute);
        }

        [TestMethod]
        public void TestNullValues()
        {

            Manifest man = ManifestDiskRepository.ReadManifest(Path.Combine(testPath, "Manifests", "manifest_null_value.yaml"));

            Application[] apps = man.Applications();
            Assert.AreEqual(1, apps.Length);
            Assert.AreEqual("app-name", apps[0].Name);
            Assert.AreEqual(128, apps[0].Memory);
            Assert.AreEqual(1, apps[0].InstanceCount);
            Assert.AreEqual(1, apps[0].Hosts.Count);
            Assert.AreEqual(1, apps[0].Domains.Count);
            Assert.AreEqual("home", apps[0].Hosts[0]);
            Assert.AreEqual("app.example.com", apps[0].Domains[0]);
            Assert.AreEqual(@"c:\path\to\app", apps[0].Path);
            Assert.AreEqual(2, apps[0].EnvironmentVariables.Count);
            Assert.AreEqual("first", apps[0].EnvironmentVariables["env1"]);
            Assert.IsNull(apps[0].BuildpackUrl);
            Assert.IsNull(apps[0].StackName);
            Assert.AreEqual(500, apps[0].HealthCheckTimeout);
            Assert.AreEqual("cmd", apps[0].Command);
            Assert.AreEqual(2, apps[0].Services.Count);
            Assert.AreEqual(1024, apps[0].DiskQuota);
            Assert.AreNotEqual(-1, apps[0].Services.IndexOf("mysql"));
        }
    }
}
