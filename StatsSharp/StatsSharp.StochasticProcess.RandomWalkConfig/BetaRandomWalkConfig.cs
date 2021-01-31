using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.RandomWalkConfig
{
    public class BetaRandomWalkConfig : IRandomWalkConfig
    {
        public BetaRandomWalkConfig(INode initial, double beta)
        {
            Initial = initial;
            Beta = beta;
        }

        public INode Initial { get; }
        public double Beta { get; }
    }
}
