using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Extensions;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Graph.Extensions
{
    [TestClass]
    public class ComputeCentrality
    {
        // https://analytics-note.xyz/graph-theory/network-centrality/
        [TestMethod]
        public void TestComputeClosenessCentrality()
        {
            var idToNodes = Enumerable.Range(0, 7).ToDictionary(i => i, i => new StatsSharp.Graph.Node.Node(i.ToString()));
            var nodes = idToNodes.Values.ToList();

            var edges = new List<StatsSharp.Graph.Edge.Edge>()
            {
                new StatsSharp.Graph.Edge.Edge(idToNodes[0], idToNodes[1]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[1], idToNodes[2]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[2], idToNodes[3]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[3], idToNodes[0]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[1], idToNodes[3]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[0], idToNodes[4]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[4], idToNodes[5]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[5], idToNodes[0]),
                new StatsSharp.Graph.Edge.Edge(idToNodes[5], idToNodes[6]),
            };
            var graph = new StatsSharp.Graph.Graph.Graph(edges, idToNodes.Values);

            var expected = new Dictionary<INode, double>()
            {
                { nodes[0], 0.75},
                { nodes[1], 0.6},
                { nodes[2], 3.0/7.0},
                { nodes[3], 0.6},
                { nodes[4], 6.0 / 11.0},
                { nodes[5], 0.6},
                { nodes[6], 0.4},
            };

            foreach (var node in nodes)
            {
                var centrality = graph.ComputeClosenessCentrality(node);
                Assert.AreEqual(expected[node], centrality, 1.0e-10);
            }
        }
    }
}
