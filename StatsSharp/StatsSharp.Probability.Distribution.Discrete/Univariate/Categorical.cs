using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatsSharp.Extensions;

namespace StatsSharp.Probability.Distribution.Discrete.Univariate
{
    public class Categorical : ADiscreteUnivariateDistribution<int, Parameter.Discrete.Univariate.Categorical>
    {
        public override Func<int, double> GetCumulativeDistributionFunction(Parameter.Discrete.Univariate.Categorical parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Discrete.Univariate.Categorical parameter)
        {
            return parameter.Probabilities.Max();
        }

        private int GetSample(Parameter.Discrete.Univariate.Categorical parameter)
        {
            var uniform = new Distribution.Continuous.Scalar.Uniform();
            var unifomParam = new Parameter.Continuous.Scalar.Uniform(0, 1);
            var uniformSample = uniform.GetSamples(unifomParam, 1).First();
            var cumSumProb = parameter.Probabilities.CumulativeSum();
            return cumSumProb.TakeWhile(csProb => csProb <= uniformSample).Count();
        }

        public override IEnumerable<int> GetSamples(Parameter.Discrete.Univariate.Categorical parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i=> GetSample(parameter));
        }

        public override double ProbabilityDensityFunction(int data, Parameter.Discrete.Univariate.Categorical parameter)
        {
            return parameter.Probabilities.ElementAt(data);
        }
    }
}
