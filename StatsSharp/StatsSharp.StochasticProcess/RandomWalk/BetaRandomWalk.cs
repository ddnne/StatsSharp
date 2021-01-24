using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using StatsSharp.Graph.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StatsSharp.StochasticProcess.RandomWalk
{
    public class BetaRandomWalk : ARandomWalk<RandomWalkConfig.BetaRandomWalkConfig>
    {
        public BetaRandomWalk(IGraph graph, RandomWalkConfig.BetaRandomWalkConfig config)
            : base(graph, config) { }

        public override void Walk()
        {
            // u to v
            var u = LocationHistory.Last();
            var vs = NodeToConnectedNodes[u];

            var vToDegvPowBeta = vs.ToDictionary(v => v, v => Math.Pow(NodeToConnectedNodes[v].Count(), -Config.Beta));
            var degvPowBetaSum = vToDegvPowBeta.Values.Sum();
            var transitionProbabilities = vToDegvPowBeta.Keys.Select(v => vToDegvPowBeta[v] / degvPowBetaSum);

            var cat = new Probability.Distribution.Discrete.Univariate.Categorical();
            var catParam = new Probability.Parameter.Discrete.Univariate.Categorical(transitionProbabilities);
            var sample = cat.GetSamples(catParam, 1).First();

            var next = vs.ElementAt(sample);
            LocationHistory = LocationHistory.Concat(new List<INode>() { next });
        }
    }
}
