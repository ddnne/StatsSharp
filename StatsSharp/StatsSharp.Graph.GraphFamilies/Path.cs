using StatsSharp.Graph.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph
{
    public partial class GraphFamilies
    {
        public static IGraph Path(int pathNodeNum, int nodeIndexStartWith = 0, Func<int, string> renameNodes = null)
        {
            var nodes = renameNodes is null ?
                Enumerable.Range(nodeIndexStartWith, pathNodeNum).Select(i => new Node.Node(i.ToString())) :
                Enumerable.Range(nodeIndexStartWith, pathNodeNum).Select(i => new Node.Node(renameNodes(i)));
            var pathEdges = nodes.SkipLast(1).Zip(nodes.Skip(1), (from, to) => new Edge.Edge(from, to));

            return new Graph.Graph(pathEdges, nodes);
        }
    }
}
