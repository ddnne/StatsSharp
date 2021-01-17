﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    // https://arxiv.org/abs/math-ph/0609050
    public class UnitaryMatrixParameter : IParameter
    {
        public UnitaryMatrixParameter(int matrixSize)
        {
            if (matrixSize <= 0)
                throw new ArgumentException();
            MatrixSize = matrixSize;
        }

        // Dim(U) = MatrixSize \time MatrixSize
        public int MatrixSize { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other.GetType() != typeof(UnitaryMatrixParameter))
                return false;
            else if (this.MatrixSize != ((UnitaryMatrixParameter)other).MatrixSize)
                return false;
            else
                return true;
        }
    }
}
