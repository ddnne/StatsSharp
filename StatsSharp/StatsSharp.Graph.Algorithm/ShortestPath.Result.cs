using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Graph.Algorithm
{
    public partial class ShortestPath
    {
        public class Result
        {
            public INode Source { get; internal set; }
            public IEnumerable<INode> Targets { get; internal set; }
            public IDictionary<INode, double> TargetToDistance { get; internal set; }
            public IDictionary<INode, List<INode>> TargetToPredecessor { get; internal set; }
        }
    }
}
