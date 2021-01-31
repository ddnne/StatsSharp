using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter.Continuous.Vector
{
    public class MultivariateNormal : IParameter
    {
        public MultivariateNormal(
            MathNet.Numerics.LinearAlgebra.Vector<double>  mean,
            MathNet.Numerics.LinearAlgebra.Matrix<double>  sigma)
        {
            if (sigma.Svd().S.Minimum() <= 0 || !sigma.IsHermitian())
                throw new ArgumentException("");
            Mean = mean;
            Sigma = sigma;
            SigmaInverse = Sigma.Inverse();
            SigmaDeterminant = Sigma.Determinant();
        }

        public MathNet.Numerics.LinearAlgebra.Vector<double> Mean { get; }
        public MathNet.Numerics.LinearAlgebra.Matrix<double> Sigma { get; }
        public MathNet.Numerics.LinearAlgebra.Matrix<double> SigmaInverse { get; }
        public double SigmaDeterminant { get; }
        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Continuous.Vector.MultivariateNormal))
                return false;
            else if(Mean.Equals(((MultivariateNormal)other).Mean) && Sigma.Equals(((MultivariateNormal)other).Sigma))
                return true;
            else
                return false;
        }
    }
}
