using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter.Continuous.Matrix
{
    // https://arxiv.org/abs/math-ph/0609050
    public class RandomOrthogonalMatrix : IParameter
    {
        public RandomOrthogonalMatrix(int matrixSize)
        {
            if (matrixSize <= 0)
                throw new ArgumentException();
            MatrixSize = matrixSize;
        }

        // Dim(U) = MatrixSize \time MatrixSize
        public int MatrixSize { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other.GetType() != typeof(RandomOrthogonalMatrix))
                return false;
            else if (this.MatrixSize != ((RandomOrthogonalMatrix)other).MatrixSize)
                return false;
            else
                return true;
        }
    }
}
