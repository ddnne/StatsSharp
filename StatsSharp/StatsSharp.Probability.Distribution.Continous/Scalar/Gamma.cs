using MathNet.Numerics;
using StatsSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Scalar
{
    public class Gamma : AScalarContinuousDistribution<double, Parameter.Continuous.Scalar.Gamma>
    {
        public override Func<double, double> GetCumulativeDistributionFunction(Parameter.Continuous.Scalar.Gamma parameter)
        {
            return (double x) => SpecialFunctions.GammaLowerIncomplete(parameter.K, x / parameter.Theta) / SpecialFunctions.Gamma(parameter.K);
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Continuous.Scalar.Gamma parameter)
        {
            if (parameter.K >= 1)
                return this.ProbabilityDensityFunction((parameter.K - 1) * parameter.Theta, parameter);
            else
                return Double.PositiveInfinity;
        }

        internal IEnumerable<double> GetIntKPartsFromExpSamples(IEnumerable<double> expSamples, Parameter.Continuous.Scalar.Gamma parameter)
        {
            int intK = (int)Math.Floor(parameter.K);
            return expSamples.Chunk(intK).Select(samples => samples.Sum());
        }

        private IEnumerable<double> GenerateSamplesIntKPart(Parameter.Continuous.Scalar.Gamma parameter, int size)
        {
            int intK = (int)Math.Floor(parameter.K);
            var exp = new Distribution.Continuous.Scalar.Exponential();
            var expParam = new Parameter.Continuous.Scalar.Exponential(parameter.Theta);
            var expSamples = exp.GetSamples(expParam, size * intK);
            return GetIntKPartsFromExpSamples(expSamples, parameter);
        }

        internal (double x, bool isAccepted) GenerateSampleDecKPartFromUnifomSamples(double decK, double unifSample1, double unifSample2)
        {
            var p = (decK + Math.E) / Math.E;
            var q = p * unifSample1;
            if (q < 1)
            {
                var x = Math.Pow(q, 1 / decK);
                if (unifSample2 < Math.Exp(-x))
                    return (x, true);
            }
            else
            {
                var x = -Math.Log((p - q) / decK);
                if (unifSample2 < Math.Pow(x, decK - 1))
                    return (x, true);
            }

            return (Double.NaN, false);
        }

        internal double GenerateSampleDecKPart(Parameter.Continuous.Scalar.Gamma parameter)
        {
            int intK = (int)Math.Floor(parameter.K);
            double decK = parameter.K - intK;
            var uniform = new Distribution.Continuous.Scalar.Uniform();
            var uniformParam = new Parameter.Continuous.Scalar.Uniform(0, 1);

            (double sample, bool isAccepted) = (0, true);
            while (isAccepted)
            {
                var unifSamples = uniform.GetSamples(uniformParam, 2);
                var unif1 = unifSamples.First();
                var unif2 = unifSamples.Last();
                (sample, isAccepted) = GenerateSampleDecKPartFromUnifomSamples(decK, unif1, unif2);
            };

            sample = sample * parameter.Theta;
            return sample;
        }

        private IEnumerable<double> GenerateSamplesDecKPart(Parameter.Continuous.Scalar.Gamma parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i => GenerateSampleDecKPart(parameter));
        }

        public override IEnumerable<double> GetSamples(Parameter.Continuous.Scalar.Gamma parameter, int size)
        {
            var intKParts = GenerateSamplesIntKPart(parameter, size);
            var decKParts = GenerateSamplesDecKPart(parameter, size);
            return intKParts.Zip(decKParts, (i, d) => i + d);
        }

        public override double ProbabilityDensityFunction(double data, Parameter.Continuous.Scalar.Gamma parameter)
        {
            return 1.0 / (SpecialFunctions.Gamma(parameter.K) * Math.Pow(parameter.Theta, parameter.K)) *
                Math.Pow(data, parameter.K - 1) * Math.Exp(-data / parameter.Theta);
        }
    }
}
