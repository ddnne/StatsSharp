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
    public class UnitaryMatrixDistribution : ADistribution<Matrix<Complex>, UnitaryMatrixParameter>
    {
        public override Func<Matrix<Complex>, double> GetCumulativeDistributionFunction(UnitaryMatrixParameter parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(UnitaryMatrixParameter parameter)
        {
            throw new NotImplementedException();
        }

        private Matrix<Complex> GetSample(UnitaryMatrixParameter parameter)
        {
            var normal = new Distribution.Normal();
            var normalParam = new Parameter.Normal(0, 1);
            var twoSamples = normal.GetSamples(normalParam, 2);

            var matrix = MathNet.Numerics.LinearAlgebra.Complex.Matrix.Build
                .Dense(parameter.MatrixSize, parameter.MatrixSize, (i, j) => new Complex(twoSamples.First(), twoSamples.Last()));
            var qr = matrix.QR();

            var d = MathNet.Numerics.LinearAlgebra.Complex.Matrix.Build.DenseOfDiagonalVector(qr.R.Diagonal());
            var ph = d * d.PointwiseAbs().Inverse();
            var q = qr.Q * ph * qr.Q;
            return q;

        }

        public override IEnumerable<Matrix<Complex>> GetSamples(UnitaryMatrixParameter parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i => GetSample(parameter));
        }

        protected override double ProbabilityDensityFunction(Matrix<Complex> data, UnitaryMatrixParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}
