using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudFoundry.CloudController.V2.Client.Test.Manifests
{
    [TestClass]
    public class WordsTest
    {
        [TestMethod]
        public void TestBabble()
        {
            string babble = CloudFoundry.Manifests.Words.Generator.Babble();
            Assert.IsNotNull(babble);
            
            string[] parts = babble.Split('-');
            Assert.AreEqual(2, parts.Length);
        }
    }
}
