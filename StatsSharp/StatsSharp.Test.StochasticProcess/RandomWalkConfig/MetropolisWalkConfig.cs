using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.RandomWalkConfig
{
    [TestClass]
    public class MetropolisWalkConfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            var node = new StatsSharp.Graph.Node.Node("node1");
            var nodeSub = new StatsSharp.Graph.Node.Node("node2");
            var p = new Dictionary<INode, double>()
            {
                {node, 0.5 },
                {nodeSub, 0.5 }
            };
            var config = new StatsSharp.StochasticProcess.RandomWalkConfig.MetropolisWalkConfig(node, p);

            Assert.IsTrue(node.Equals(config.Initial));
            CollectionAssert.AreEqual(p, config.NodeToStationaryProbability);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinusVectorElement()
        {
            var node = new StatsSharp.Graph.Node.Node("node1");
            var nodeSub = new StatsSharp.Graph.Node.Node("node2");
            var p = new Dictionary<INode, double>()
            {
                {node, 0.5 },
                {nodeSub, -1 }
            };
            var config = new StatsSharp.StochasticProcess.RandomWalkConfig.MetropolisWalkConfig(node, p);
        }
    }
}
