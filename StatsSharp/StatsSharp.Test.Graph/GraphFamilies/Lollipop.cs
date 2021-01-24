using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Graph
{
    [TestClass]
    public partial class GraphFamilies
    {
        [TestMethod]
        public void Lollipop()
        {
            var cliqueSize = 3;
            var pathSize = 2;

            var lollipop = StatsSharp.Graph.GraphFamilies.Lollipop(cliqueSize, pathSize);

            Assert.IsTrue(lollipop.Nodes.Count() == 5);
            Assert.IsTrue(lollipop.Edges.Count() == 5);

            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("2")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("3")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("4")));

            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("1"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("2"), new StatsSharp.Graph.Node.Node("3"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("3"), new StatsSharp.Graph.Node.Node("4"))));
        }
    }
}
