using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatsSharp.Extensions;

namespace StatsSharp.Probability.Distribution.Discrete.Univariate
{
    public class Categorical : ADistribution<int, Parameter.Categorical>
    {
        public override Func<int, double> GetCumulativeDistributionFunction(Parameter.Categorical parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Categorical parameter)
        {
            return parameter.Probabilities.Max();
        }

        private int GetSample(Parameter.Categorical parameter)
        {
            var uniform = new Distribution.Continuous.Scalar.Uniform();
            var unifomParam = new Parameter.Uniform(0, 1);
            var uniformSample = uniform.GetSamples(unifomParam, 1).First();
            var cumSumProb = parameter.Probabilities.CumulativeSum();
            return cumSumProb.TakeWhile(csProb => csProb <= uniformSample).Count();
        }

        public override IEnumerable<int> GetSamples(Parameter.Categorical parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i=> GetSample(parameter));
        }

        protected override double ProbabilityDensityFunction(int data, Parameter.Categorical parameter)
        {
            return parameter.Probabilities.ElementAt(data);
        }
    }
}
