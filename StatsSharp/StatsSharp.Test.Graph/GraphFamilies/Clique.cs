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
        public void Clique()
        {
            var cliqueSize = 3;

            var clique = StatsSharp.Graph.GraphFamilies.Clique(cliqueSize);

            Assert.IsTrue(clique.Nodes.Count() == 3);
            Assert.IsTrue(clique.Edges.Count() == 3);

            Assert.IsTrue(clique.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(clique.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));
            Assert.IsTrue(clique.Nodes.Contains(new StatsSharp.Graph.Node.Node("2")));

            Assert.IsTrue(clique.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
            Assert.IsTrue(clique.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("2"))));
            Assert.IsTrue(clique.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("1"), new StatsSharp.Graph.Node.Node("2"))));
        }
    }
}
