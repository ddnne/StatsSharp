using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph
{
    public partial class GraphFamilies
    {
        public static Graph.IGraph Barbell(int eachCliqueNodeNum, int nodeIndexStartWith = 0, Func<int, string> renameNodes = null)
        {
            var leftClique = Clique(eachCliqueNodeNum, nodeIndexStartWith, renameNodes);
            var rightClique = Clique(eachCliqueNodeNum, nodeIndexStartWith + eachCliqueNodeNum, renameNodes);

            var nodes = leftClique.Nodes.Concat(rightClique.Nodes).Select(node => (Node.Node)node);
            var edges = leftClique.Edges.Concat(new Edge.Edge[] { new Edge.Edge(leftClique.Nodes.Last(), rightClique.Nodes.First()) })
                .Concat(rightClique.Edges).Select(edge => (Edge.Edge)edge);
            return new Graph.Graph(edges, nodes);
        }
    }
}
