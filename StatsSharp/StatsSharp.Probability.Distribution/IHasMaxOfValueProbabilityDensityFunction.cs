using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public interface IHasMaxOfValueProbabilityDensityFunction<Data, Parameter> where Parameter : IParameter
    {
        public abstract double GetMaxValueProbabilityDensityFunction(Parameter parameter);
    }
}
