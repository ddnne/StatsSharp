using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Scalar
{
    public class Normal : ADistribution<double, Parameter.Normal>
    {
        protected override double ProbabilityDensityFunction(double data, Parameter.Normal parameter)
        {
            return Math.Exp(-Math.Pow((data - parameter.Mean) / parameter.StandardDeviation, 2) / 2)
                / Math.Sqrt(2 * Math.PI * Math.Pow(parameter.StandardDeviation, 2));
        }

        // Box-Muller's method
        public override IEnumerable<double> GetSamples(Parameter.Normal parameter, int size)
        {
            var u1s = (new Uniform()).GetSamples(new Parameter.Uniform(0, 1), size);
            var u2s = (new Uniform()).GetSamples(new Parameter.Uniform(0, 1), size);
            return u1s.Zip(u2s, (u1, u2) => new { u1, u2 }).Select(pair =>
                parameter.Mean + parameter.StandardDeviation * Math.Sqrt(-2 * Math.Log(pair.u1)) * Math.Cos(2 * Math.PI * pair.u2));
        }

        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Normal parameter)
        {
            return (double data) => (1 + MathNet.Numerics.SpecialFunctions.Erf(
                (data - parameter.Mean) / (Math.Sqrt(2 * Math.Pow(parameter.StandardDeviation, 2))))) / 2.0;
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Normal parameter)
        {
            return this.ProbabilityDensityFunction(parameter.Mean, parameter);
        }
    }
}
