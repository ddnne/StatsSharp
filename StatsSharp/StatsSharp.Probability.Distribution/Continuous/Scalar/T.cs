using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics;

namespace StatsSharp.Probability.Distribution.Continuous.Scalar
{
    public class T : ADistribution<double, Parameter.Continuous.Scalar.T>
    {
        // https://mathworld.wolfram.com/Studentst-Distribution.html
        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Continuous.Scalar.T parameter)
        {
            var r = parameter.DegreeOfFreedom;
            Func<double, double> t = (double data) => (data - parameter.Mean) / parameter.Scale;
            return (double data) => 1.0 / 2.0 + 
                (SpecialFunctions.BetaRegularized(r / 2.0, 0.5, 1.0) - SpecialFunctions.BetaRegularized(r / 2.0, 0.5, r / (r + Math.Pow(t(data), 2)))) * Math.Sign(t(data)) / 2.0;
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Continuous.Scalar.T parameter)
        {
            return this.ProbabilityDensityFunction(parameter.Mean, parameter);
        }

        public override IEnumerable<double> GetSamples(Parameter.Continuous.Scalar.T parameter, int size)
        {
            throw new NotImplementedException();
        }

        protected override double ProbabilityDensityFunction(double data, Parameter.Continuous.Scalar.T parameter)
        {
            return MathNet.Numerics.SpecialFunctions.Gamma((parameter.DegreeOfFreedom + 1) / 2) /
                (Math.Sqrt(Math.PI * parameter.DegreeOfFreedom * parameter.Scale) * MathNet.Numerics.SpecialFunctions.Gamma(parameter.DegreeOfFreedom / 2)) *
                Math.Pow(1 + Math.Pow((data - parameter.Mean) / parameter.Scale, 2) / parameter.DegreeOfFreedom, -(parameter.DegreeOfFreedom + 1) / 2);
        }
    }
}
