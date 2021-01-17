﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    public class MultivariateNormal : ADistribution<MathNet.Numerics.LinearAlgebra.Vector<double>, Parameter.MultivariateNormal>
    {
        protected override double ProbabilityDensityFunction(MathNet.Numerics.LinearAlgebra.Vector<double> data, Parameter.MultivariateNormal parameter)
        {
            var dim = parameter.Mean.Count();
            return Math.Exp(-parameter.SigmaInverse.Multiply(data - parameter.Mean).DotProduct(data - parameter.Mean) / 2.0)
                / Math.Sqrt(Math.Pow(2 * Math.PI, dim) * parameter.SigmaDeterminant);
        }

        public override IEnumerable<MathNet.Numerics.LinearAlgebra.Vector<double>> GetSamples(Parameter.MultivariateNormal parameter, int size)
        {
            var dim = parameter.Mean.Count();
            var choleskyFactor = parameter.Sigma.Cholesky().Factor;
            var normal = new Distribution.Normal();
            var normalParam = new Parameter.Normal(0, 1);

            return Enumerable.Range(0, size).Select(i =>
            {
                var samples = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(normal.GetSamples(normalParam, dim));
                return choleskyFactor * samples + parameter.Mean;
            });
        }

        public override Func<MathNet.Numerics.LinearAlgebra.Vector<double>, double> GetCumulativeDistributionFunction(Parameter.MultivariateNormal parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.MultivariateNormal parameter)
        {
            return this.ProbabilityDensityFunction(parameter.Mean, parameter);
        }
    }
}
