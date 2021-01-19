using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Graph.Node
{
    [TestClass]
    public class Node
    {
        [TestMethod]
        public void TestConstructor()
        {
            var node = new StatsSharp.Graph.Node.Node("Test");
            Assert.AreEqual("Test", node.NodeName);
        }
    }
}
