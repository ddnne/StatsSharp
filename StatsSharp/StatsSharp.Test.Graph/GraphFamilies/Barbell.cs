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

            var barbell = StatsSharp.Graph.GraphFamilies.Barbell(cliqueSize);

            Assert.IsTrue(barbell.Nodes.Count() == 6);
            Assert.IsTrue(barbell.Edges.Count() == 7);

            Assert.IsTrue(barbell.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(barbell.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));
            Assert.IsTrue(barbell.Nodes.Contains(new StatsSharp.Graph.Node.Node("2")));
            Assert.IsTrue(barbell.Nodes.Contains(new StatsSharp.Graph.Node.Node("3")));
            Assert.IsTrue(barbell.Nodes.Contains(new StatsSharp.Graph.Node.Node("4")));
            Assert.IsTrue(barbell.Nodes.Contains(new StatsSharp.Graph.Node.Node("5")));

            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("1"), new StatsSharp.Graph.Node.Node("2"))));

            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("2"), new StatsSharp.Graph.Node.Node("3"))));

            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("3"), new StatsSharp.Graph.Node.Node("4"))));
            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("3"), new StatsSharp.Graph.Node.Node("5"))));
            Assert.IsTrue(barbell.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("4"), new StatsSharp.Graph.Node.Node("5"))));
        }
    }
}
