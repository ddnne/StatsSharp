using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Graph.Node
{
    public class Node : INode
    {
        public Node(string nodeName)
        {
            NodeName = nodeName;
        }

        public string NodeName { get; }

        public bool Equals([AllowNull] INode other)
        {
            if (other is null)
                return false;
            else if (other.GetType() != typeof(Node))
                return false;
            else
                return NodeName == other.NodeName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NodeName);
        }
    }
}
