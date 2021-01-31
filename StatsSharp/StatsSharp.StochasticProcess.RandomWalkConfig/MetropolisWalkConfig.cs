using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.RandomWalkConfig
{
    public class MetropolisWalkConfig : IRandomWalkConfig
    {
        public MetropolisWalkConfig(INode initial, Dictionary<INode, double> nodeToStationaryProbability)
        {
            if (nodeToStationaryProbability.Values.Where(p => p < 0).Any())
                throw new ArgumentException();
            Initial = initial;
            NodeToStationaryProbability = nodeToStationaryProbability;
        }

        public INode Initial { get; }
        public Dictionary<INode, double> NodeToStationaryProbability { get; }
    }
}
