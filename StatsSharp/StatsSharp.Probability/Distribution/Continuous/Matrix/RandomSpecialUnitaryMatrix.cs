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
    public class RandomSpecialUnitaryMatrix : RandomUnitaryMatrix
    {
        protected override Matrix<Complex> GetSample(Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter)
        {
            var sample = base.GetSample(parameter);
            var det = sample.Determinant();


            return sample / Complex.Pow(det, 1.0 / parameter.MatrixSize);
        }

        public override IEnumerable<Matrix<Complex>> GetSamples(Parameter.Continuous.Matrix.RandomUnitaryMatrix parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i => this.GetSample(parameter));
        }
    }
}
