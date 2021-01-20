using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter.Continuous.Scalar
{
    public class Exponential : IParameter
    {
        public Exponential(double average)
        {
            if (average <= 0)
                throw new ArgumentException("");
            Average = average;
        }

        public double Average { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Exponential))
                return false;
            else if (Double.Equals(this.Average, ((Exponential)other).Average))
                return true;
            else
                return false;
        }
    }
}
