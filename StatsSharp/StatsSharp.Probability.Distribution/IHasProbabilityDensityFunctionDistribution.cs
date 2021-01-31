using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public interface IHasProbabilityDensityFunctionDistribution<Data, Parameter>
        : IDistribution<Data, Parameter>, IHasProbabilityDensityFunction<Data, Parameter>
        where Parameter : IParameter
    {
    }
}
