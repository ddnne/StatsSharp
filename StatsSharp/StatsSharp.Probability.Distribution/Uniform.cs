using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public class Uniform : ADistribution<double, Parameter.Uniform>
    {
        protected override double ProbabilityDensityFunction(double data, Parameter.Uniform parameter)
        {
            if (data > parameter.End || data < parameter.Start)
                return 0;
            else
                return 1.0 / (parameter.End - parameter.Start);
        }

        public override IEnumerable<double> GetSamples(Parameter.Uniform parameter, int size)
        {
            var rand = new Random();
            return Enumerable.Range(0, size).Select(x => parameter.Start + rand.NextDouble() * (parameter.End - parameter.Start));
        }
    }
}
