using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Graph.Node
{
    public interface INode : IEquatable<INode>
    {
        string NodeName { get; }
    }
}
