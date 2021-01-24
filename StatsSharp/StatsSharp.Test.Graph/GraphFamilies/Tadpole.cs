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
        public void Tadpole()
        {
            var cycle = 3;
            var pathSize = 2;

            var tadpole = StatsSharp.Graph.GraphFamilies.Tadpole(cycle, pathSize);

            Assert.IsTrue(tadpole.Nodes.Count() == 5);
            Assert.IsTrue(tadpole.Edges.Count() == 5);

            Assert.IsTrue(tadpole.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(tadpole.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));
            Assert.IsTrue(tadpole.Nodes.Contains(new StatsSharp.Graph.Node.Node("2")));
            Assert.IsTrue(tadpole.Nodes.Contains(new StatsSharp.Graph.Node.Node("3")));
            Assert.IsTrue(tadpole.Nodes.Contains(new StatsSharp.Graph.Node.Node("4")));

            Assert.IsTrue(tadpole.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
            Assert.IsTrue(tadpole.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("1"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(tadpole.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("2"), new StatsSharp.Graph.Node.Node("0"))));
            Assert.IsTrue(tadpole.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("2"), new StatsSharp.Graph.Node.Node("3"))));
            Assert.IsTrue(tadpole.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("3"), new StatsSharp.Graph.Node.Node("4"))));
        }
    }
}
