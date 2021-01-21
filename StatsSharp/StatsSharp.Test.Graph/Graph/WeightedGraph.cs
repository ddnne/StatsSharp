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
    public class WeightedGraph
    {
        [TestMethod]
        public void TestConstructor()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var weight = 1.5;
            var edge = new StatsSharp.Graph.Edge.WeightedEdge(from, to, weight);
            var graph = new StatsSharp.Graph.Graph.WeightedGraph(new List<StatsSharp.Graph.Edge.WeightedEdge>() { edge }, new List<StatsSharp.Graph.Node.Node>() { from, to });

            Assert.IsTrue(graph.Edges.Count() == 1);
            Assert.IsTrue(graph.Nodes.Count() == 2);
            Assert.AreEqual("Node1", graph.Nodes.First().NodeName);
            Assert.AreEqual("Node2", graph.Nodes.Last().NodeName);
            Assert.AreEqual("Node1", graph.Edges.First().From.NodeName);
            Assert.AreEqual("Node2", graph.Edges.First().To.NodeName);
            Assert.AreEqual(weight, ((StatsSharp.Graph.Edge.WeightedEdge)graph.Edges.First()).Weight, 1.0e-10);
        }
    }
}
