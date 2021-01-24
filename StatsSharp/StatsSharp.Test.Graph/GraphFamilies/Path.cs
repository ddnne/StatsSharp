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
        public void Path()
        {
            var pathSize = 2;

            var lollipop = StatsSharp.Graph.GraphFamilies.Path(pathSize);

            Assert.IsTrue(lollipop.Edges.Count() == 1);

            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("0")));
            Assert.IsTrue(lollipop.Nodes.Contains(new StatsSharp.Graph.Node.Node("1")));

            Assert.IsTrue(lollipop.Edges.Contains(new StatsSharp.Graph.Edge.Edge(new StatsSharp.Graph.Node.Node("0"), new StatsSharp.Graph.Node.Node("1"))));
        }
    }
}
