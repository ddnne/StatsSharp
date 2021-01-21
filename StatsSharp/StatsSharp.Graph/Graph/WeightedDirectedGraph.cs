using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Graph.Graph
{
    public class WeightedDirectedGraph : DirectedGraph
    {
        public WeightedDirectedGraph(IEnumerable<Edge.WeightedEdge> edges, IEnumerable<Node.Node> nodes)
        :base(edges, nodes){ }

        public override bool Equals([AllowNull] IGraph other)
        {
            if (other is null)
                return false;
            if (other.GetType() != typeof(WeightedDirectedGraph))
                return false;
            else
                return Edges.Equals(other.Edges) && Nodes.Equals(other.Nodes);
        }
    }
}
