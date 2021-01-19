using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Graph.Algorithm
{
    public partial class ShortestPath
    {
        [TestClass]
        public class Result
        {
            [TestMethod]
            public void TestConstructor()
            {
                var source = new StatsSharp.Graph.Node.Node("Source");
                var target = new StatsSharp.Graph.Node.Node("Target");
                var edge = new StatsSharp.Graph.Edge.Edge(source, target);
                var graph = new StatsSharp.Graph.Graph.Graph(new List<StatsSharp.Graph.Edge.Edge> { edge }, new List<StatsSharp.Graph.Node.Node>() { source, target });
                var targetToDistance = new Dictionary<INode, double>()
                {
                    {source, 0 },
                    {target, 1 }
                };
                var targetToPredecessor = new Dictionary<INode, List<INode>>();

                var result = StatsSharp.Graph.Algorithm.ShortestPath.BellmanFord(graph, source);

                Assert.IsTrue(source.Equals(result.Source));
                Assert.AreEqual(2, result.Targets.Count());
                Assert.IsTrue(result.Targets.Contains(source));
                Assert.IsTrue(result.Targets.Contains(target));
                Assert.AreEqual(0, result.TargetToDistance[source]);
                Assert.AreEqual(1, result.TargetToDistance[target]);
                Assert.IsFalse(result.TargetToPredecessor[source].Any());
                Assert.AreEqual(1, result.TargetToPredecessor[target].Count());
                Assert.IsTrue(result.TargetToPredecessor[target].Contains(source));
            }
        }
    }
}
