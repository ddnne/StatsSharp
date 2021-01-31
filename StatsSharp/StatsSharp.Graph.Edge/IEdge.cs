using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Graph.Edge
{
    public interface IEdge : IEquatable<IEdge>
    {
        INode From { get; }
        INode To { get; }
    }
}
