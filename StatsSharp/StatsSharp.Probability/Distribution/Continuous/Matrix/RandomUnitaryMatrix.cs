﻿using MathNet.Numerics.LinearAlgebra;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace StatsSharp.Probability.Distribution.Continuous.Matrix
{
    // https://arxiv.org/abs/math-ph/0609050
    public class RandomUnitaryMatrix : ADistribution<Matrix<Complex>, Parameter.Continuous.Matrix.RandomUnitaryMatrix>
    {
        public override Func<Matrix<Complex>, double> GetCumulativeDistributionFunction(Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter)
        {
            throw new NotImplementedException();
        }

        protected virtual Matrix<Complex> GetSample(Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter)
        {
            var normal = new Distribution.Continuous.Scalar.Normal();
            var normalParam = new Parameter.Continuous.Scalar.Normal(0, 1);

            var matrix = MathNet.Numerics.LinearAlgebra.Complex.Matrix.Build
                .Dense(parameter.MatrixSize, parameter.MatrixSize, (i, j) => new Complex(normal.GetSamples(normalParam,1).First(), normal.GetSamples(normalParam, 1).First()));
            var qr = matrix.QR();

            var d = MathNet.Numerics.LinearAlgebra.Complex.Matrix.Build.DenseOfDiagonalVector(qr.R.Diagonal());
            var ph = d * d.PointwiseAbs().Inverse();
            var q = qr.Q * ph * qr.Q;
            return q;

        }

        public override IEnumerable<Matrix<Complex>> GetSamples(Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i => GetSample(parameter));
        }

        protected override double ProbabilityDensityFunction(Matrix<Complex> data, Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter)
        {
            throw new NotImplementedException();
        }
    }
}
