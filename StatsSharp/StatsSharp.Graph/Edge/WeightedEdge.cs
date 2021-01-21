using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Graph.Edge
{
    public class WeightedEdge : Edge
    {
        public WeightedEdge(INode from, INode to, double weight)
        : base(from, to)
        {
            Weight = weight;
        }
        public virtual double Weight { get; }


        public override bool Equals([AllowNull] IEdge other)
        {
            if (other is null)
                return false;
            else if (other.GetType() != typeof(WeightedEdge))
                return false;
            else
                return From.NodeName == other.From.NodeName &&
                    To.NodeName == other.To.NodeName && 
                    Weight.Equals(((WeightedEdge)other).Weight);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To, Weight);
        }
    }
}
