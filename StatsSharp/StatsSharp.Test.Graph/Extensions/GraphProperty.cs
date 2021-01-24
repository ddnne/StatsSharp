using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Graph.Extensions
{
    [TestClass]
    public class GraphProperty
    {
        [TestMethod]
        public void TestGetConnectedNodes()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.Graph(edges, nodes);

            var connectedFrom = graph.GetConnectedNodes(from);
            Assert.AreEqual(1, connectedFrom.Count());
            Assert.IsTrue(to.Equals(connectedFrom.First()));

            var connectedTo = graph.GetConnectedNodes(to);
            Assert.AreEqual(1, connectedTo.Count());
            Assert.IsTrue(from.Equals(connectedTo.First()));
        }

        [TestMethod]
        public void TestGetConnectedNodesFrom()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.DirectedGraph(edges, nodes);

            var connectedFromFrom = graph.GetConnectedNodesFrom(from);
            Assert.AreEqual(1, connectedFromFrom.Count());
            Assert.IsTrue(to.Equals(connectedFromFrom.First()));

            var connectedFromTo = graph.GetConnectedNodesFrom(to);
            Assert.AreEqual(0, connectedFromTo.Count());

            var connectedToFrom = graph.GetConnectedNodesTo(from);
            Assert.AreEqual(0, connectedToFrom.Count());

            var connectedToTo = graph.GetConnectedNodesTo(to);
            Assert.AreEqual(1, connectedToTo.Count());
            Assert.IsTrue(from.Equals(connectedToTo.First()));
        }
    }
}
