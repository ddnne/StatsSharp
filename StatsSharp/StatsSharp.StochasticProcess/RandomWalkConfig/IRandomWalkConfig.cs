using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.RandomWalkConfig
{
    public interface IRandomWalkConfig
    {
        INode Initial { get; }
    }
}
