using StatsSharp.Extensions;
using StatsSharp.Graph.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph.ParametricGraphFamilies
{
    public partial class ParametricGraphFamilies
    {
        // https://en.wikipedia.org/wiki/Lollipop_graph
        public static IGraph Lollipop(int cliqueSize, int pathSize)
        {
            var nodes = Enumerable.Range(0, cliqueSize + pathSize).Select(i => new Node.Node(i.ToString()));
            
            var cliqueEdges = nodes.Take(cliqueSize).Combination(2).Select(pair => new Edge.Edge(pair.First(), pair.Last()));
            var pathNodes = nodes.Skip(cliqueSize - 1);
            var pathEdges = pathNodes.SkipLast(1).Zip(pathNodes.Skip(1), (from, to) => new Edge.Edge(from, to));
            var edges = cliqueEdges.Concat(pathEdges);
            return new Graph.Graph(edges, nodes);
        }
    }
}
