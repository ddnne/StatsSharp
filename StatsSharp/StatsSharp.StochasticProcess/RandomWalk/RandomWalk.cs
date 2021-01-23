using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using StatsSharp.Graph.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StatsSharp.StochasticProcess.RandomWalk
{
    public class RandomWalk : ARandomWalk<RandomWalkConfig.RandomWalkConfig>
    {
        public RandomWalk(IGraph graph, RandomWalkConfig.RandomWalkConfig config)
            : base(graph, config) { }

        public override void Walk()
        {
            var candidates = NodeToConnectedNodes[LocationHistory.Last()];
            var count = candidates.Count();
            var p = 1.0 / count;
            var probs = Enumerable.Range(0, count).Select(i => p);

            var cat = new Probability.Distribution.Discrete.Univariate.Categorical();
            var catParam = new Probability.Parameter.Discrete.Univariate.Categorical(probs);
            var sample = cat.GetSamples(catParam, 1).First();

            LocationHistory = LocationHistory.Concat(new List<INode>() { candidates.ElementAt(sample) });
        }
    }
}
