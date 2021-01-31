using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Scalar
{
    public class Exponential : AScalarContinuousDistribution<double, Parameter.Continuous.Scalar.Exponential>
    {
        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Continuous.Scalar.Exponential parameter)
        {
            return (double x) => x >= 0 ? 1 - Math.Exp(-x / parameter.Average) : 0;
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Continuous.Scalar.Exponential parameter)
        {
            return GetProbabilityDensityFunction(parameter)(0);
        }

        public override IEnumerable<double> GetSamples(Parameter.Continuous.Scalar.Exponential parameter, int size)
        {
            var uniformSamples = new Distribution.Continuous.Scalar.Uniform().GetSamples(new Parameter.Continuous.Scalar.Uniform(0, 1), size);
            return uniformSamples.Select(x => -parameter.Average * Math.Log(x));
        }

        public override double ProbabilityDensityFunction(double data, Parameter.Continuous.Scalar.Exponential parameter)
        {
            return data >= 0 ? Math.Exp(-data / parameter.Average) / parameter.Average : 0;
        }
    }
}
