using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Matrix
{
    public abstract class AMatrixContinuousDistribution<Data, Parameter> :
        IDistribution<Data, Parameter> where Parameter : IParameter
    {
        abstract public IEnumerable<Data> GetSamples(Parameter parameter, int size);
    }
}
