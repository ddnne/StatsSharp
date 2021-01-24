using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Graph
{
    public partial class GraphFamilies
    {
        [TestMethod]
        public void Cycle()
        {
            var cycleNodeSize = 3;

            var cycle = StatsSharp.Graph.GraphFamilies.Cycle(cycleNodeSize);

            Assert.IsTrue(cycle.Edges.Count() == 3);

            Assert.IsTrue(cycle.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(cycle.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));
            Assert.IsTrue(cycle.Nodes.Contains(new StatsSharp.Graph.Node.Node("2")));

            Assert.IsTrue(cycle.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
            Assert.IsTrue(cycle.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("1"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(cycle.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("2"), new StatsSharp.Graph.Node.Node("0"))));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SmallNodeNum()
        {
            var cycleNodeSize = 2;

            var cycle = StatsSharp.Graph.GraphFamilies.Cycle(cycleNodeSize);
        }
    }
}
