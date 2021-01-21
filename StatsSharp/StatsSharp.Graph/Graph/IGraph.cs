using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Graph.Graph
{
    public interface IGraph : IEquatable<IGraph>
    {
        IEnumerable<IEdge> Edges { get; }
        IEnumerable<INode> Nodes { get; }
    }
}
