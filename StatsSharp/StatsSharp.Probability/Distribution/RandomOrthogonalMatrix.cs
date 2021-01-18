using MathNet.Numerics.LinearAlgebra;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace StatsSharp.Probability.Distribution
{
    // https://arxiv.org/abs/math-ph/0609050
    public class RandomOrthogonalMatrix : ADistribution<Matrix<double>, Parameter.RandomOrthogonalMatrix>
    {
        public override Func<Matrix<double>, double> GetCumulativeDistributionFunction(Parameter.RandomOrthogonalMatrix parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.RandomOrthogonalMatrix parameter)
        {
            throw new NotImplementedException();
        }

        private Matrix<double> GetSample(Parameter.RandomOrthogonalMatrix parameter)
        {
            var normal = new Distribution.Normal();
            var normalParam = new Parameter.Normal(0, 1);

            var matrix = MathNet.Numerics.LinearAlgebra.Double.Matrix.Build
                .Dense(parameter.MatrixSize, parameter.MatrixSize, (i, j) => normal.GetSamples(normalParam, 1).First());
            var qr = matrix.QR();

            return qr.Q;

        }

        public override IEnumerable<Matrix<double>> GetSamples(Parameter.RandomOrthogonalMatrix parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i => GetSample(parameter));
        }

        protected override double ProbabilityDensityFunction(Matrix<double> data, Parameter.RandomOrthogonalMatrix parameter)
        {
            throw new NotImplementedException();
        }
    }
}
