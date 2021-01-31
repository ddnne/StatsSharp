using StatsSharp.Graph.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph
{
    public partial class GraphFamilies
    {
        public static IGraph Cycle(int cycleNodeNum, int nodeIndexStartWith = 0, Func<int, string> renameNodes = null)
        {
            if (cycleNodeNum < 3)
                throw new ArgumentException();

            var nodes = renameNodes is null ?
                Enumerable.Range(nodeIndexStartWith, cycleNodeNum).Select(i => new Node.Node(i.ToString())) :
                Enumerable.Range(nodeIndexStartWith, cycleNodeNum).Select(i => new Node.Node(renameNodes(i)));
            var pathEdges = nodes.SkipLast(1).Zip(nodes.Skip(1), (from, to) => new Edge.Edge(from, to));
            var edges = pathEdges.Concat(new Edge.Edge[] { new Edge.Edge(nodes.Last(), nodes.First()) });

            return new Graph.Graph(edges, nodes);
        }
    }
}
