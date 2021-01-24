using StatsSharp.Extensions;
using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph
{
    public partial class GraphFamilies
    {
        // https://en.wikipedia.org/wiki/Lollipop_graph
        public static IGraph Tadpole(int cycleNodeNum, int pathNodeNum, int nodeIndexStartWith = 0, Func<int, string> renameNodes = null)
        {
            var cycle = Cycle(cycleNodeNum, nodeIndexStartWith, renameNodes);
            var path = Path(pathNodeNum, nodeIndexStartWith + cycleNodeNum, renameNodes);

            var nodes = cycle.Nodes.Concat(path.Nodes).Select(node => (Node.Node)node);
            var edges = cycle.Edges.Concat(new Edge.Edge[] { new Edge.Edge(cycle.Nodes.Last(), path.Nodes.First()) })
                .Concat(path.Edges).Select(edge => (Edge.Edge)edge);

            return new Graph.Graph(edges, nodes);
        }
    }
}
