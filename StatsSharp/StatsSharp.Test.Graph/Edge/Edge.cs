using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Graph.Edge
{
    [TestClass]
    public class Edge
    {
        [TestMethod]
        public void TestConstructor()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            Assert.AreEqual("Node1", edge.From.NodeName);
            Assert.AreEqual("Node2", edge.To.NodeName);
        }
    }
}
