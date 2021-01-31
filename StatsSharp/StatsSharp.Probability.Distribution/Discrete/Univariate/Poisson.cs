using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Discrete.Univariate
{
    public class Poisson : ADistribution<int, Parameter.Discrete.Univariate.Poisson>
    {
        public override Func<int, double> GetCumulativeDistributionFunction(Parameter.Discrete.Univariate.Poisson parameter)
        {

            return (int k) => k >= 0 ? Enumerable.Range(0, k + 1).Select(_k => ProbabilityDensityFunction(k, parameter)).Sum() : 0;
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Discrete.Univariate.Poisson parameter)
        {
            var intensityFloor = (int)Math.Floor(parameter.Intensity);
            return ProbabilityDensityFunction(intensityFloor, parameter);
        }

        public override IEnumerable<int> GetSamples(Parameter.Discrete.Univariate.Poisson parameter, int size)
        {
            var uniform = new Distribution.Continuous.Scalar.Uniform();
            var uniformParam = new Parameter.Continuous.Scalar.Uniform(0, 1);
            return Enumerable.Range(0, size).Select(_ =>
            {
                var L = Math.Exp(-parameter.Intensity);
                var k = 0;
                var p = 1.0;
                do
                {
                    k++;
                    p = p * uniform.GetSamples(uniformParam, 1).First();
                } while (p > L);
                return k - 1;
            });
        }

        protected override double ProbabilityDensityFunction(int k, Parameter.Discrete.Univariate.Poisson parameter)
        {
            return k >= 0 ? Math.Pow(parameter.Intensity, k) * Math.Exp(-parameter.Intensity) / MathNet.Numerics.SpecialFunctions.Gamma(k + 1) : 0;
        }
    }
}
