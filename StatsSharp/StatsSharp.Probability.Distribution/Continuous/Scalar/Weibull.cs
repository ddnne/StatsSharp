using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Scalar
{
    public class Weibull : AScalarContinuousDistribution<double, Parameter.Continuous.Scalar.Weibull>
    {
        public override double ProbabilityDensityFunction(double data, Parameter.Continuous.Scalar.Weibull parameter)
        {
            if (data < 0)
                return 0;
            else
                return (parameter.Shape / parameter.Scale) * Math.Pow(data / parameter.Scale, parameter.Shape - 1)
                    * Math.Exp(-Math.Pow(data / parameter.Scale, parameter.Shape));
        }

        public override IEnumerable<double> GetSamples(Parameter.Continuous.Scalar.Weibull parameter, int size)
        {
            var uniform = new Distribution.Continuous.Scalar.Uniform();
            var uniformParam = new Probability.Parameter.Continuous.Scalar.Uniform(0, 1);
            return uniform.GetSamples(uniformParam, size).Select(u => parameter.Scale * Math.Pow(-Math.Log(u), 1 / parameter.Shape));
        }

        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Continuous.Scalar.Weibull parameter)
        {
            return (double data) =>
            {
                if (data < 0)
                    return 0;
                else
                    return 1 - Math.Exp(-Math.Pow(data / parameter.Scale, parameter.Shape));
            };
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Continuous.Scalar.Weibull parameter)
        {
            if (parameter.Shape > 1)
                return ProbabilityDensityFunction(parameter.Scale * Math.Pow((parameter.Shape - 1) / parameter.Shape, 1.0 / parameter.Shape), parameter);
            else
                return ProbabilityDensityFunction(0, parameter);
        }
    }
}
