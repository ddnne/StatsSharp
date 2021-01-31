using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public interface IHasCumulativeDistributionFunction<Data, Parameter> where Parameter : IParameter
    {
        Func<Data, double> GetCumulativeDistributionFunction(Parameter parameter);
    }
}
