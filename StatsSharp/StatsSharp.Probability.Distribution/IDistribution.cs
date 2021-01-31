using System;
using System.Collections.Generic;
using StatsSharp.Probability.Parameter;

namespace StatsSharp.Probability.Distribution
{
    public interface IDistribution<Data, Parameter> where Parameter : IParameter
    {
        IEnumerable<Data> GetSamples(Parameter parameter, int size);
    }
}
