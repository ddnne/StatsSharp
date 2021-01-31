using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Discrete.Graph
{
    public class BernoulliGraph : IRandomGraph<StatsSharp.Graph.Graph.Graph, Parameter.Discrete.Graph.BernoulliGraph>
    {
        public IEnumerable<StatsSharp.Graph.Graph.Graph> GetSamples(Parameter.Discrete.Graph.BernoulliGraph parameter, int size)
        {
            var bernoulli = new Distribution.Discrete.Univariate.Categorical();
            var bernoulliParam = new Parameter.Discrete.Univariate.Categorical(new List<double>() {1-  parameter.EdgeConnectedProbability, parameter.EdgeConnectedProbability });

            var edgeCount = parameter.Edges.Count();
            var bernoulliSamples = Enumerable.Range(0, size).Select(i => bernoulli.GetSamples(bernoulliParam, edgeCount));

            return bernoulliSamples.Select(sample =>
            {
                return new StatsSharp.Graph.Graph.Graph(
                    parameter.Edges.Zip(sample, (edge, p) => new { edge, p }).Where(pair => pair.p == 1).Select(pair => pair.edge),
                    parameter.Nodes
                    );
            });
        }
    }
}
