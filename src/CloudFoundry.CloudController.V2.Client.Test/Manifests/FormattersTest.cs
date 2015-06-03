using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudFoundry.CloudController.V2.Client.Test.Manifests
{
    [TestClass]
    public class FormattersTest
    {
        [TestMethod]
        public void TestToMegabytesKB()
        {
            string testValue = "128KB";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128 / 1024, value);
        }

        [TestMethod]
        public void TestToMegabytesKTest()
        {
            string testValue = "128K";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128 / 1024, value);
        }

        [TestMethod]
        public void TestToMegabytesMB()
        {
            string testValue = "128MB";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128, value);
        }

        [TestMethod]
        public void TestToMegabytesM()
        {
            string testValue = "128M";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128, value);
        }

        [TestMethod]
        public void TestToMegabytesGB()
        {
            string testValue = "128GB";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128 * 1024, value);
        }

        [TestMethod]
        public void TestToMegabytesGTest()
        {
            string testValue = "128G";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128 * 1024, value);
        }

        [TestMethod]
        public void TestToMegabytesTB()
        {
            string testValue = "128TB";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128 * 1024 * 1024, value);
        }

        [TestMethod]
        public void TestToMegabytesTTest()
        {
            string testValue = "128T";
            long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            Assert.AreEqual(128 * 1024 * 1024, value);
        }

        [TestMethod]
        public void TestToMegabytesRandomGuid()
        {
            string testValue = Guid.NewGuid().ToString();
            Exception exception = null;
            try
            {
                long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            }
            catch(Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Byte quantity must be an integer"));
        }

        [TestMethod]
        public void TestToMegabytesNumber()
        {
            string testValue = "1";
            Exception exception = null;
            try
            {
                long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Byte quantity must be an integer"));
        }

        [TestMethod]
        public void TestToMegabytesInvalidUnit()
        {
            string testValue = "128A";
            Exception exception = null;
            try
            {
                long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Byte quantity must be an integer"));
        }

        [TestMethod]
        public void TestToMegabytesInvalidNumber()
        {
            string testValue = "A12MB";
            Exception exception = null;
            try
            {
                long value = CloudFoundry.Manifests.Formatters.Bytes.ToMegabytes(testValue);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Byte quantity must be an integer"));
        }
    }
}
