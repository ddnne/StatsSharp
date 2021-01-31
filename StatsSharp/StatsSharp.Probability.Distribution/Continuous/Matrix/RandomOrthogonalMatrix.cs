using MathNet.Numerics.LinearAlgebra;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Matrix
{
    // https://arxiv.org/abs/math-ph/0609050
    public class RandomOrthogonalMatrix : AMatrixContinuousDistribution<Matrix<double>, Parameter.Continuous.Matrix.RandomOrthogonalMatrix>
    {
        private Matrix<double> GetSample(Parameter.Continuous.Matrix.RandomOrthogonalMatrix parameter)
        {
            var normal = new Distribution.Continuous.Scalar.Normal();
            var normalParam = new Parameter.Continuous.Scalar.Normal(0, 1);

            var matrix = MathNet.Numerics.LinearAlgebra.Double.Matrix.Build
                .Dense(parameter.MatrixSize, parameter.MatrixSize, (i, j) => normal.GetSamples(normalParam, 1).First());
            var qr = matrix.QR();

            return qr.Q;

        }

        public override IEnumerable<Matrix<double>> GetSamples(Parameter.Continuous.Matrix.RandomOrthogonalMatrix parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i => GetSample(parameter));
        }
    }
}
