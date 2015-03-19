using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.CloudController.V2.Client.Test
{
    [TestClass]
    public class TestEntityGuid
    {
        [TestMethod]
        public void TestNull()
        {
            EntityGuid guid = null;
            Assert.AreEqual(null, guid);
        }

        [TestMethod]
        public void TestFromStringToString()
        {
            EntityGuid guid = "0001";
            string stringGuid = guid;
            Assert.AreEqual("0001", stringGuid);
        }

        [TestMethod]
        public void TestFromStringToGuid()
        {
            Guid value = Guid.NewGuid();

            EntityGuid guid = value.ToString();
            Guid realGuid = guid;
            Assert.AreEqual(value, realGuid);
        }

        [TestMethod]
        public void TestFromGuidToGuid()
        {
            Guid value = Guid.NewGuid();

            EntityGuid guid = value;
            Guid realGuid = guid;
            Assert.AreEqual(value, realGuid);
        }

        [TestMethod]
        public void TestFromGuidToString()
        {
            Guid value = Guid.NewGuid();

            EntityGuid guid = value;
            string stringGuid = guid;
            Assert.AreEqual(value.ToString(), stringGuid);
        }

        [TestMethod]
        public void TestFromNullableGuidToString()
        {
            Guid? value = null;

            EntityGuid guid = value;
            string stringGuid = guid;
            Assert.AreEqual(null, stringGuid);
        }

        [TestMethod]
        public void TestFromStringToNullableGuid()
        {
            Guid value = Guid.NewGuid();

            EntityGuid guid = value.ToString();
            Guid? realGuid = guid;
            Assert.AreEqual(value, realGuid);
        }

        [TestMethod]
        public void TestNullableGuid()
        {
            EntityGuid guid = null;
            Guid? realGuid = guid;
            Assert.AreEqual(null, realGuid);
        }

        [TestMethod]
        public void TestDefaultValueNullableGuid()
        {
            EntityGuid guid = new EntityGuid();
            Guid? realGuid = guid;
            Assert.AreEqual(null, realGuid);
        }

        [TestMethod]
        public void TestDefaultValueString()
        {
            EntityGuid guid = new EntityGuid();
            string stringGuid = guid;
            Assert.AreEqual(null, stringGuid);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestDefaultValueGuid()
        {
            EntityGuid guid = new EntityGuid();
            Guid stringGuid = guid;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNullToGuid()
        {
            Guid realGuid = (EntityGuid)null;
        }

        [TestMethod]
        public void TestNullToString()
        {
            string stringGuid = (EntityGuid)null;
            Assert.AreEqual(null, stringGuid);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidStringGuid()
        {
            string value = "0123";
            EntityGuid guid = value;
            Guid realGuid = guid;
        }
    }
}
