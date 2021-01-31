using StatsSharp.Graph.Graph;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public interface IRandomGraph<Graph, Parameter>
        where Graph : IGraph
        where Parameter : IParameter
    {
        IEnumerable<Graph> GetSamples(Parameter parameter, int size);
    }
}
