using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using StatsSharp.StochasticProcess.RandomWalkConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.RandomWalk
{
    public interface IRandomWalk<RandomWalkConfig>
        where RandomWalkConfig : IRandomWalkConfig
    {
        IEnumerable<INode> LocationHistory { get; set; }
        IGraph Graph { get; }
        RandomWalkConfig Config { get; }
        void Walk();
    }
}
