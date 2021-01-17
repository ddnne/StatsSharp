using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter
{
    public class Multinomial : Categorical
    {
        public Multinomial(IEnumerable<double> probabilities, int numberOfTrials) : base(probabilities)
        {
            if (numberOfTrials < 0)
                throw new ArgumentException();
            NumberOfTrials = numberOfTrials;
        }

        public int NumberOfTrials { get; }

        public override bool Equals([AllowNull] IParameter other)
        {
            if (!base.Equals(other))
                return false;
            if (other.GetType() != typeof(Multinomial))
                return false;
            if (NumberOfTrials != ((Multinomial)other).NumberOfTrials)
                return false;

            return true;
            
        }
    }
}
