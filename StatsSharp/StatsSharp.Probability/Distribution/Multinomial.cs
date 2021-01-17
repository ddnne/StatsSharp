﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatsSharp.Extensions;

namespace StatsSharp.Probability.Distribution
{
    public class Multinomial : ADistribution<IEnumerable<int>, Parameter.Multinomial>
    {
        public Multinomial()
        {
            CategoricalDist = new Categorical();
        }

        private Categorical CategoricalDist { get; }

        public override Func<IEnumerable<int>, double> GetCumulativeDistributionFunction(Parameter.Multinomial parameter)
        {
            throw new NotSupportedException();
        }

        public override double GetMaxValueProbabilityDensityFunction(Parameter.Multinomial parameter)
        {
            return Math.Pow(parameter.Probabilities.Max(), parameter.NumberOfTrials);
        }

        private IEnumerable<int> GetSample(Parameter.Multinomial parameter)
        {
            var catParameter = (Parameter.Categorical)parameter;
            var catSamples = CategoricalDist.GetSamples(catParameter, parameter.NumberOfTrials);
            return catSamples.GroupBy(i => i).Select(g => g.Count());
        }

        public override IEnumerable<IEnumerable<int>> GetSamples(Parameter.Multinomial parameter, int size)
        {
            return Enumerable.Range(0, size).Select(i=> GetSample(parameter));
        }

        protected override double ProbabilityDensityFunction(IEnumerable<int> data, Parameter.Multinomial parameter)
        {
            if (data.Sum() != parameter.NumberOfTrials)
                throw new ArgumentException();

            return data.Zip(parameter.Probabilities, (ni, prob) => new { ni, prob })
                .Select(pair => Math.Pow(pair.prob, pair.ni)).Product() / data.Select(ni => MathNet.Numerics.SpecialFunctions.Factorial(ni)).Product()
                * MathNet.Numerics.SpecialFunctions.Factorial(parameter.NumberOfTrials);
        }
    }
}
