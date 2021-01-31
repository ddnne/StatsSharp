using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Vector
{
    public abstract class AVectorContinuousDistribution<Data, Parameter> :
        IHasProbabilityDensityFunctionDistribution<Data, Parameter>, 
        IHasMaxOfValueProbabilityDensityFunction<Data, Parameter>
        where Parameter : IParameter
    {
        public abstract double ProbabilityDensityFunction(Data data, Parameter parameter);

        public Func<Parameter, double> GetLikelihoodFunction(Data data) => (Parameter parameter) => this.ProbabilityDensityFunction(data, parameter);

        public Func<Data, double> GetProbabilityDensityFunction(Parameter parameter) => (Data data) => this.ProbabilityDensityFunction(data, parameter);

        abstract public IEnumerable<Data> GetSamples(Parameter parameter, int size);

        public abstract double GetMaxValueProbabilityDensityFunction(Parameter parameter);
    }
}
