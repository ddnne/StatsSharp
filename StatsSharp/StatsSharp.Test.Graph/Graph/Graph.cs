using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Graph.Graph
{
    [TestClass]
    public class Graph
    {
        [TestMethod]
        public void TestConstructor()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);
            var graph = new StatsSharp.Graph.Graph.Graph(new List<StatsSharp.Graph.Edge.Edge>() { edge }, new List<StatsSharp.Graph.Node.Node>() { from, to });

            Assert.IsTrue(graph.Edges.Count() == 1);
            Assert.IsTrue(graph.Nodes.Count() == 2);
            Assert.AreEqual("Node1", graph.Nodes.First().NodeName);
            Assert.AreEqual("Node2", graph.Nodes.Last().NodeName);
            Assert.AreEqual("Node1", graph.Edges.First().From.NodeName);
            Assert.AreEqual("Node2", graph.Edges.First().To.NodeName);
        }
    }
}
