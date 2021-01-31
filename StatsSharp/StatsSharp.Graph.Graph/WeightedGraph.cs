using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Graph.Graph
{
    public class WeightedGraph : Graph
    {
        public WeightedGraph(IEnumerable<Edge.WeightedEdge> edges, IEnumerable<Node.Node> nodes) : base(edges, nodes) { }

        public override bool Equals([AllowNull] IGraph other)
        {
            if (other is null)
                return false;
            if (other.GetType() != typeof(WeightedGraph))
                return false;
            else
                return Edges.Equals(other.Edges) && Nodes.Equals(other.Nodes);
        }
    }
}
