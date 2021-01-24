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
        public void Barbell()
        {
            var cliqueSize = 3;

            var lollipop = StatsSharp.Graph.GraphFamilies.Barbell(cliqueSize);

            Assert.IsTrue(lollipop.Nodes.Count() == 6);
            Assert.IsTrue(lollipop.Edges.Count() == 7);

            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("2")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("3")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("4")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("5")));

            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("1"), new StatsSharp.Graph.Node.Node("2"))));

            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("2"), new StatsSharp.Graph.Node.Node("3"))));

            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("3"), new StatsSharp.Graph.Node.Node("4"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("3"), new StatsSharp.Graph.Node.Node("5"))));
            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("4"), new StatsSharp.Graph.Node.Node("5"))));
        }
    }
}
