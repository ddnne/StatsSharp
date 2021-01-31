using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.RandomWalkConfig
{
    [TestClass]
    public class BetaRandomWalkConfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            var node = new StatsSharp.Graph.Node.Node("node");
            var beta = 0.5;
            var config = new StatsSharp.StochasticProcess.RandomWalkConfig.BetaRandomWalkConfig(node, beta);

            Assert.IsTrue(node.Equals(config.Initial));
            Assert.AreEqual(beta, config.Beta, 1.0e-10);
        }
    }
}
