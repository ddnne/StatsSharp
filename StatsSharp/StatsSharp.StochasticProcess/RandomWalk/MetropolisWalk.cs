using StatsSharp.Graph.Extensions;
using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using StatsSharp.StochasticProcess.RandomWalkConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.RandomWalk
{
    public class MetropolisWalk : ARandomWalk<MetropolisWalkConfig>
    {
        public MetropolisWalk(IGraph graph, MetropolisWalkConfig config)
            : base(graph, config) { }

        public override void Walk()
        {
            // u to v
            var u = LocationHistory.Last();
            var vs = NodeToConnectedNodes[u];
            var degu = vs.Count();

            var vToDegv = vs.ToDictionary(v => v, v => NodeToConnectedNodes[v].Count());
            var transitionProbabilities = vToDegv.Keys.Select(v => (new double[]
            {
                1,
                degu * Config.NodeToStationaryProbability[u] / (vToDegv[v] * Config.NodeToStationaryProbability[v])
            }
                ).Min() / degu);

            var probs = (new double[] { 1 - transitionProbabilities.Sum() }).Concat(transitionProbabilities);

            var cat = new Probability.Distribution.Discrete.Univariate.Categorical();
            var catParam = new Probability.Parameter.Discrete.Univariate.Categorical(probs);
            var sample = cat.GetSamples(catParam, 1).First();

            var next = sample == 0 ? u : vs.ElementAt(sample - 1);
            LocationHistory = LocationHistory.Concat(new List<INode>() { next });
        }
    }
}
