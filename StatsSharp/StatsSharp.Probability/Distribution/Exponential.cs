using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public class Exponential : ADistribution<double, Parameter.Exponential>
    {
        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Exponential parameter)
        {
            return (double x) => x >= 0 ? 1 - Math.Exp(-x / parameter.Average) : 0;
        }

        public override double GetMaxProbabilityDensityFunction(Parameter.Exponential parameter)
        {
            return GetProbabilityDensityFunction(parameter)(0);
        }

        public override IEnumerable<double> GetSamples(Parameter.Exponential parameter, int size)
        {
            var uniformSamples = new Distribution.Uniform().GetSamples(new Parameter.Uniform(0, 1), size);
            return uniformSamples.Select(x => -parameter.Average * Math.Log(x));
        }

        protected override double ProbabilityDensityFunction(double data, Parameter.Exponential parameter)
        {
            return data >= 0 ? Math.Exp(-data / parameter.Average) / parameter.Average : 0;
        }
    }
}
