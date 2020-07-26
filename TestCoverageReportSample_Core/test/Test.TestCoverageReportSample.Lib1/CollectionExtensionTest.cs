using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCoverageReportSample.Lib1;

namespace Test.TestCoverageReportSample.Lib1
{
    [TestClass]
    public class CollectionExtension
    {
        [TestMethod]
        public void Join_EmptyList()
        {
            List<string> list = new List<string>();
            var actual = list.TextJoin(",");
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Join_SingleItem()
        {
            List<string> list = new List<string> { "item1" };
            var actual = list.TextJoin(",");
            Assert.AreEqual("item1", actual);
        }

        [TestMethod]
        public void Join_MultipleItems()
        {
            List<string> list = new List<string> { "item1", "item2" };
            var actual = list.TextJoin(",");
            Assert.AreEqual("item1,item2", actual);
        }
    }
}
