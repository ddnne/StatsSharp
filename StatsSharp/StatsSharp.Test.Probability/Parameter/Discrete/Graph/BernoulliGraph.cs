using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter.Graph
{
    [TestClass]
    public class BernoulliGraph
    {
        [TestMethod]
        public void TestConstructor()
        {
            var p = 0.5;
            var nodes = new List<Node>();
            var edges = new List<Edge>();
            
            var bernoulliGraph = new StatsSharp.Probability.Parameter.Discrete.Graph.BernoulliGraph(p, edges, nodes);
            Assert.AreEqual(p, bernoulliGraph.EdgeConnectedProbability, 1.0e-10);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestMinusProb()
        {
            double p = -0.1;
            var nodes = new List<Node>();
            var edges = new List<Edge>();

            var bernoulliGraph = new StatsSharp.Probability.Parameter.Discrete.Graph.BernoulliGraph(p, edges, nodes);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestOverOneProb()
        {
            double p = 1111;
            var nodes = new List<Node>();
            var edges = new List<Edge>();

            var bernoulliGraph = new StatsSharp.Probability.Parameter.Discrete.Graph.BernoulliGraph(p, edges, nodes);
        }
    }
}
