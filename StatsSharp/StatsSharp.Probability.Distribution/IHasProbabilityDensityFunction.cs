using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public interface IHasProbabilityDensityFunction<Data, Parameter> where Parameter : IParameter
    {
        double ProbabilityDensityFunction(Data data, Parameter parameter);

        Func<Parameter, double> GetLikelihoodFunction(Data data);

        Func<Data, double> GetProbabilityDensityFunction(Parameter parameter);
    }
}
