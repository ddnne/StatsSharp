using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public abstract class ADistribution<Data, Parameter> : IDistribution<Data, Parameter> where Parameter : IParameter
    {
        abstract protected double ProbabilityDensityFunction(Data data, Parameter parameter);

        public Func<Parameter, double> GetLikelihoodFunction(Data data) => (Parameter parameter) => this.ProbabilityDensityFunction(data, parameter);

        public Func<Data, double> GetProbabilityDensityFunction(Parameter parameter) => (Data data) => this.ProbabilityDensityFunction(data, parameter);

        abstract public IEnumerable<Data> GetSamples(Parameter parameter, int size);

        abstract public Func<Data, double> GetCumulativeDistributionFunction(Parameter parameter);
    }
}
