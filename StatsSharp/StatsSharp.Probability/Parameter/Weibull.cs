using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class Weibull : IParameter
    {
        public Weibull(double shape, double scale)
        {
            if (shape <= 0 || scale <= 0)
                throw new ArgumentException();
            Shape = shape;
            Scale = scale;
        }

        public double Shape { get; }
        public double Scale { get; }

        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Weibull))
                return false;
            else if (Double.Equals(this.Shape, ((Weibull)other).Shape) && Double.Equals(this.Scale, ((Weibull)other).Scale))
                return true;
            else
                return false;
        }
    }
}
