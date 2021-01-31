using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter.Continuous.Scalar
{
    public class T : IParameter
    {
        public T(double mean, double scale, double degreeOfFreedom)
        {
            if (scale <= 0 || degreeOfFreedom <= 0)
                throw new ArgumentException("");
            Mean = mean;
            Scale = scale;
            DegreeOfFreedom = degreeOfFreedom;
        }

        public double Mean { get; }
        public double Scale { get; }
        public double DegreeOfFreedom { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is T))
                return false;
            else if (Double.Equals(this.Mean, ((T)other).Mean) && Double.Equals(this.Scale, ((T)other).Scale)
                 && Double.Equals(this.DegreeOfFreedom, ((T)other).DegreeOfFreedom))
                return true;
            else
                return false;
        }
    }
}
