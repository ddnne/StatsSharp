using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.RandomWalkConfig
{
    public class RandomWalkConfig : IRandomWalkConfig
    {
        public RandomWalkConfig(INode initial)
        {
            Initial = initial;
        }

        public INode Initial { get; }
    }
}
