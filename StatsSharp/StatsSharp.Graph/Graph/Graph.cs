using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Graph.Graph
{
    public class Graph : IGraph
    {
        public Graph(IEnumerable<Edge.Edge> edges, IEnumerable<Node.Node> nodes)
        {
            Edges = edges;
            Nodes = nodes;
        }

        public virtual IEnumerable<IEdge> Edges { get; }

        public virtual IEnumerable<INode> Nodes { get; }

        public virtual bool Equals([AllowNull] IGraph other)
        {
            if (other is null)
                return false;
            if (other.GetType() != typeof(Graph))
                return false;
            else
                return Edges.Equals(other.Edges) && Nodes.Equals(other.Nodes);
        }
    }
}
