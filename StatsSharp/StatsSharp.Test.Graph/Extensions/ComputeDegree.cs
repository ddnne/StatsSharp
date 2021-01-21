using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Graph.Extensions
{
    [TestClass]
    public class ComputeDegree
    {
        [TestMethod]
        public void TestComputeDegree()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.Graph(edges, nodes);

            Assert.AreEqual(1, graph.ComputeDegree(from));
            Assert.AreEqual(1, graph.ComputeDegree(to));
        }

        [TestMethod]
        public void TestComputeInDegree()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.DirectedGraph(edges, nodes);

            Assert.AreEqual(0, graph.ComputeInDegree(from));
            Assert.AreEqual(1, graph.ComputeInDegree(to));
        }

        [TestMethod]
        public void TestComputeOutDegree()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.DirectedGraph(edges, nodes);

            Assert.AreEqual(1, graph.ComputeOutDegree(from));
            Assert.AreEqual(0, graph.ComputeOutDegree(to));
        }

        [TestMethod]
        public void TestComputeWeightedDegree()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var weight = 1.5;
            var edge = new StatsSharp.Graph.Edge.WeightedEdge(from, to, weight);

            var edges = new List<StatsSharp.Graph.Edge.WeightedEdge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.WeightedGraph(edges, nodes);

            Assert.AreEqual(weight, graph.ComputeWeightedDegree(from), 1.0e-10);
            Assert.AreEqual(weight, graph.ComputeWeightedDegree(to), 1.0e-10);
            Assert.AreEqual(1, graph.ComputeDegree(from));
            Assert.AreEqual(1, graph.ComputeDegree(to));
        }

        [TestMethod]
        public void TestComputeWeightedInDegree()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var weight = 1.5;
            var edge = new StatsSharp.Graph.Edge.WeightedEdge(from, to, weight);

            var edges = new List<StatsSharp.Graph.Edge.WeightedEdge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.WeightedDirectedGraph(edges, nodes);

            Assert.AreEqual(0, graph.ComputeWeightedInDegree(from), 1.0e-10);
            Assert.AreEqual(weight, graph.ComputeWeightedInDegree(to), 1.0e-10);
            Assert.AreEqual(0, graph.ComputeInDegree(from));
            Assert.AreEqual(1, graph.ComputeInDegree(to));
        }

        [TestMethod]
        public void TestComputeWeightedOutDegree()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var weight = 1.5;
            var edge = new StatsSharp.Graph.Edge.WeightedEdge(from, to, weight);

            var edges = new List<StatsSharp.Graph.Edge.WeightedEdge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.WeightedDirectedGraph(edges, nodes);

            Assert.AreEqual(weight, graph.ComputeWeightedOutDegree(from), 1.0e-10);
            Assert.AreEqual(0, graph.ComputeWeightedOutDegree(to), 1.0e-10);
            Assert.AreEqual(1, graph.ComputeOutDegree(from));
            Assert.AreEqual(0, graph.ComputeOutDegree(to));
        }
    }
}
