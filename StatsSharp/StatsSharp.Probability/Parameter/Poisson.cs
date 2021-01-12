using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class Poisson : IParameter
    {
        public Poisson(double intensity)
        {
            if (intensity <= 0)
                throw new ArgumentException("");
            Intensity = intensity;
        }

        public double Intensity { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Poisson))
                return false;
            else if (Double.Equals(this.Intensity, ((Poisson)other).Intensity))
                return true;
            else
                return false;
        }
    }
}
