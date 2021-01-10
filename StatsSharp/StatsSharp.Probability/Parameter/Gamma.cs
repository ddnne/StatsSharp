using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class Gamma: IParameter
    {
        public Gamma(double k, double theta)
        {
            if (k <= 0 || theta <= 0)
                throw new ArgumentException();
            K = k;
            Theta = theta;
        }

        public double K { get; }
        public double Theta { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Gamma))
                return false;
            else if (Double.Equals(this.K, ((Gamma)other).K) && Double.Equals(this.Theta, ((Gamma)other).Theta))
                return true;
            else
                return false;
        }
    }
}
