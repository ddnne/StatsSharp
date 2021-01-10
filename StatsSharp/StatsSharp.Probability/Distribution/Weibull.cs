using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public class Weibull : ADistribution<double, Parameter.Weibull>
    {
        protected override double ProbabilityDensityFunction(double data, Parameter.Weibull parameter)
        {
            if (data < 0)
                return 0;
            else
                return (parameter.Shape / parameter.Scale) * Math.Pow(data / parameter.Scale, parameter.Shape - 1)
                    * Math.Exp(-Math.Pow(data / parameter.Scale, parameter.Shape));
        }

        public override IEnumerable<double> GetSamples(Parameter.Weibull parameter, int size)
        {
            var uniform = new Distribution.Uniform();
            var uniformParam = new Probability.Parameter.Uniform(0, 1);
            return uniform.GetSamples(uniformParam, size).Select(u => parameter.Scale * Math.Pow(-Math.Log(u), 1 / parameter.Shape));
        }

        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Weibull parameter)
        {
            return (double data) =>
            {
                if (data < 0)
                    return 0;
                else
                    return 1 - Math.Exp(-Math.Pow(data / parameter.Scale, parameter.Shape));
            };
        }

        public override double GetMaxProbabilityDensityFunction(Parameter.Weibull parameter)
        {
            if (parameter.Shape > 1)
                return ProbabilityDensityFunction(parameter.Scale * Math.Pow((parameter.Shape - 1) / parameter.Shape, 1.0 / parameter.Shape), parameter);
            else
                return ProbabilityDensityFunction(0, parameter);
        }
    }
}
