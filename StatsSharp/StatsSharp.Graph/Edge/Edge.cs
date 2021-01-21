using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Graph.Edge
{
    public class Edge : IEdge
    {
        public Edge(INode from, INode to)
        {
            From = from;
            To = to;
        }

        public INode From { get; }

        public INode To { get; }

        public virtual bool Equals([AllowNull] IEdge other)
        {
            if (other is null)
                return false;
            else if (other.GetType() != typeof(Edge))
                return false;
            else
                return From.Equals(other.From) && To.Equals(other.To);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }
    }
}
