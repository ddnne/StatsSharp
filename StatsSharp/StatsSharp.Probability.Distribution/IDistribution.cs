using System;
using System.Collections.Generic;
using StatsSharp.Probability.Parameter;

namespace StatsSharp.Probability.Distribution
{
    public interface IDistribution<Data, Parameter> where Parameter : IParameter
    {
        Func<Parameter, double> GetLikelihoodFunction(Data data);
        Func<Data, double> GetProbabilityDensityFunction(Parameter parameter);
        Func<Data, double> GetCumulativeDistributionFunction(Parameter parameter);
        IEnumerable<Data> GetSamples(Parameter parameter, int size);
    }
}
