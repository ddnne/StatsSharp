using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public class Gamma : ADistribution<double, Parameter.Gamma>
    {
        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Gamma parameter)
        {
            return (double x) => SpecialFunctions.GammaLowerIncomplete(parameter.K, x / parameter.Theta) / SpecialFunctions.Gamma(parameter.K);
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Gamma parameter)
        {
            if (parameter.K >= 1)
                return this.ProbabilityDensityFunction((parameter.K - 1) * parameter.Theta, parameter);
            else
                return Double.PositiveInfinity;
        }

        public override IEnumerable<double> GetSamples(Parameter.Gamma parameter, int size)
        {
            int intK = (int)Math.Floor(parameter.K);
            double decK = parameter.K - intK;
            var exp = new Distribution.Exponential();
            var expParam = new Parameter.Exponential(parameter.Theta);
            var uniform = new Distribution.Uniform();
            var uniformParam = new Parameter.Uniform(0, 1);

            return Enumerable.Range(0, size).Select(i =>
            {
                double x = 0;
                double sumExp = exp.GetSamples(expParam, intK).Sum();
                while (true)
                {
                    var p = (decK + Math.E) / Math.E;
                    var q = p * uniform.GetSamples(uniformParam, 1).First();
                    if (q < 1)
                    {
                        x = Math.Pow(q, 1 / decK);
                        if (uniform.GetSamples(uniformParam, 1).First() < Math.Exp(-x))
                            break;
                    }
                    else
                    {
                        x = -Math.Log((p - q) / decK);
                        if (uniform.GetSamples(uniformParam, 1).First() < Math.Pow(x, decK - 1))
                            break;
                    }
                }
                double sample = (x * parameter.Theta);
                return sumExp + sample;
            });
        }

        protected override double ProbabilityDensityFunction(double data, Parameter.Gamma parameter)
        {
            return 1.0 / (SpecialFunctions.Gamma(parameter.K) * Math.Pow(parameter.Theta, parameter.K)) *
                Math.Pow(data, parameter.K - 1) * Math.Exp(-data / parameter.Theta);
        }
    }
}
