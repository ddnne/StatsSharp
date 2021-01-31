using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Parameter.Discrete.Univariate
{
    public class Categorical : IParameter
    {
        public Categorical(IEnumerable<double> probabilities)
        {
            if (probabilities.Where(p => p< 0 || p > 1).Count() > 0 || Math.Abs(probabilities.Sum() - 1) > 1.0e-10)
                throw new ArgumentException("");
            Probabilities = probabilities;
        }

        public IEnumerable<double> Probabilities { get; }

        public virtual bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is Categorical))
                return false;
            else if (Enumerable.Equals(Probabilities, ((Categorical)other).Probabilities))
                return true;
            else
                return false;
        }
    }
}
