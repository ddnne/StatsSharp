using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.RandomWalkConfig
{
    [TestClass]
    public class RandomWalkConfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            var node = new StatsSharp.Graph.Node.Node("node");
            var config = new StatsSharp.StochasticProcess.RandomWalkConfig.RandomWalkConfig(node);

            Assert.IsTrue(node.Equals(config.Initial));
        }
    }
}
