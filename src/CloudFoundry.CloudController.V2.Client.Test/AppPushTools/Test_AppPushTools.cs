using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Client.Test.AppPushTools
{
    [TestClass]
    public class Test_AppPushTools
    {

        [TestMethod]
        [DeploymentItem(@"Assets\hello-world-java-1.0.war")]
        public void TestFingerprintsFile()
        {
            //Arrange
            var appPath = "hello-world-java-1.0.war";
            Assert.IsTrue(File.Exists(appPath));
            CloudFoundry.CloudController.Common.PushTools.AppPushTools pushTools = new Common.PushTools.AppPushTools(appPath);

            //Act
            var result = pushTools.GetFileFingerprints(new System.Threading.CancellationToken()).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        [DeploymentItem(@"Assets\pushFolder\test.txt", "pushfolder")]
        public void TestFingerprintsFolder()
        {
            //Arrange
            var appPath = @"pushfolder";
            Assert.IsTrue(Directory.Exists(appPath));
            CloudFoundry.CloudController.Common.PushTools.AppPushTools pushTools = new Common.PushTools.AppPushTools(appPath);

            //Act
            var result = pushTools.GetFileFingerprints(new System.Threading.CancellationToken()).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
        }

    }
}
