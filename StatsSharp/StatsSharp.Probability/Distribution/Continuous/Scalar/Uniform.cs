using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Scalar
{
    public class Uniform : ADistribution<double, Parameter.Continuous.Scalar.Uniform>
    {
        protected override double ProbabilityDensityFunction(double data, Parameter.Continuous.Scalar.Uniform parameter)
        {
            if (data > parameter.End || data < parameter.Start)
                return 0;
            else
                return 1.0 / (parameter.End - parameter.Start);
        }

        public override IEnumerable<double> GetSamples(Parameter.Continuous.Scalar.Uniform parameter, int size)
        {
            var rand = new Random();
            return Enumerable.Range(0, size).Select(x => parameter.Start + rand.NextDouble() * (parameter.End - parameter.Start));
        }

        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Continuous.Scalar.Uniform parameter)
        {
            return (double data) =>
            {
                if (data >= parameter.End)
                    return 1.0;
                else if (data <= parameter.Start)
                    return 0;
                else
                    return (parameter.End - data) / (parameter.End - parameter.Start);
            };
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Continuous.Scalar.Uniform parameter)
        {
            return 1.0 / (parameter.End - parameter.Start);
        }
    }
}
