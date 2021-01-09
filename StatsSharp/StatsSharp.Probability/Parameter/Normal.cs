using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class Normal : IParameter
    {
        public Normal(double mean, double standardDeviation)
        {
            if (standardDeviation <= 0)
                throw new ArgumentException("");
            Mean = mean;
            StandardDeviation = standardDeviation;
        }

        public double Mean { get; }
        public double StandardDeviation { get; }
        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Normal))
                return false;
            else if (Double.Equals(this.Mean, ((Normal)other).Mean) && Double.Equals(this.StandardDeviation, ((Normal)other).StandardDeviation))
                return true;
            else
                return false;
        }
    }
}
