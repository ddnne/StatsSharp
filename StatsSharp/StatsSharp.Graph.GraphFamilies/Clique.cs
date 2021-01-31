using StatsSharp.Extensions;
using StatsSharp.Graph.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph
{
    public partial class GraphFamilies
    {
        // if rename == null
        // node name = i.ToString()
        public static IGraph Clique(int cliqueNodeNum, int nodeIndexStartWith = 0, Func<int, string> renameNodes = null)
        {
            var nodes = renameNodes is null ?
                Enumerable.Range(nodeIndexStartWith, cliqueNodeNum).Select(i => new Node.Node(i.ToString())) :
                Enumerable.Range(nodeIndexStartWith, cliqueNodeNum).Select(i => new Node.Node(renameNodes(i)));

            var edges = nodes.Combination(2).Select(pair => new Edge.Edge(pair.First(), pair.Last()));
            return new Graph.Graph(edges, nodes);
        }
    }
}
