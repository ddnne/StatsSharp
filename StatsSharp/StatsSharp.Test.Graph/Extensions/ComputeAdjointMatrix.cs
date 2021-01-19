using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Graph.Extensions
{
    [TestClass]
    public class ComputeAdjointMatrix
    {
        [TestMethod]
        public void TestComputeAdjointMatrixGraph()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.Graph(edges, nodes);

            var matrix = graph.ComputeAdjointMatrix();
            var expected = MathNet.Numerics.LinearAlgebra.Double.Matrix.Build.DenseOfColumnArrays(
                new double[][] { new double[] { 0, 1 }, new double[] { 1, 0 } });
            CollectionAssert.AreEqual(expected.ToArray(), matrix.ToArray());
        }

        [TestMethod]
        public void TestComputeAdjointMatrixDirectedGraph()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var edge = new StatsSharp.Graph.Edge.Edge(from, to);

            var edges = new List<StatsSharp.Graph.Edge.Edge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.DirectedGraph(edges, nodes);

            var matrix = graph.ComputeAdjointMatrix();
            var expected = MathNet.Numerics.LinearAlgebra.Double.Matrix.Build.DenseOfColumnArrays(
                new double[][] { new double[] { 0, 0 }, new double[] { 1, 0 } });
            CollectionAssert.AreEqual(expected.ToArray(), matrix.ToArray());
        }

        [TestMethod]
        public void TestComputeAdjointMatrixWeightedGraph()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var weight = 1.5;
            var edge = new StatsSharp.Graph.Edge.WeightedEdge(from, to, weight);

            var edges = new List<StatsSharp.Graph.Edge.WeightedEdge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.WeightedGraph(edges, nodes);

            var matrix = graph.ComputeAdjointMatrix();
            var expected = MathNet.Numerics.LinearAlgebra.Double.Matrix.Build.DenseOfColumnArrays(
                new double[][] { new double[] { 0, weight }, new double[] { weight, 0 } });
            CollectionAssert.AreEqual(expected.ToArray(), matrix.ToArray());
        }

        [TestMethod]
        public void TestComputeAdjointMatrixWeightedDirectedGraph()
        {
            var from = new StatsSharp.Graph.Node.Node("Node1");
            var to = new StatsSharp.Graph.Node.Node("Node2");
            var weight = 1.5;
            var edge = new StatsSharp.Graph.Edge.WeightedEdge(from, to, weight);

            var edges = new List<StatsSharp.Graph.Edge.WeightedEdge>() { edge };
            var nodes = new List<StatsSharp.Graph.Node.Node>() { from, to };
            var graph = new StatsSharp.Graph.Graph.WeightedDirectedGraph(edges, nodes);

            var matrix = graph.ComputeAdjointMatrix();
            var expected = MathNet.Numerics.LinearAlgebra.Double.Matrix.Build.DenseOfColumnArrays(
                new double[][] { new double[] { 0, 0 }, new double[] { weight, 0 } });
            CollectionAssert.AreEqual(expected.ToArray(), matrix.ToArray());
        }
    }
}
