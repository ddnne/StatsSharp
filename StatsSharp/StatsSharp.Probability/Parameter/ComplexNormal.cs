using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class ComplexNormal : IParameter
    {
        public ComplexNormal(Complex mean, double standardDeviation)
        {
            if (standardDeviation <= 0)
                throw new ArgumentException("");
            Mean = mean;
            StandardDeviation = standardDeviation;
        }

        public Complex Mean { get; }
        public double StandardDeviation { get; }
        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is ComplexNormal))
                return false;
            else if (Complex.Equals(this.Mean, ((Normal)other).Mean) && Double.Equals(this.StandardDeviation, ((Normal)other).StandardDeviation))
                return true;
            else
                return false;
        }
    }
}
