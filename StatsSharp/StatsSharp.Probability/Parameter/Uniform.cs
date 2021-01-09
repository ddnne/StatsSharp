using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class Uniform : IParameter
    {
        public Uniform(double start, double end)
        {
            if (start > end)
                throw new ArgumentException("");
            Start = start;
            End = end;
        }

        public double Start { get; }

        public double End { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if(other is null)
                return false;
            else if (!(other is Uniform))
                return false;
            else if (Double.Equals(this.Start, ((Uniform)other).Start) && Double.Equals(this.End, ((Uniform)other).End))
                return true;
            else
                return false;
        }
    }
}
