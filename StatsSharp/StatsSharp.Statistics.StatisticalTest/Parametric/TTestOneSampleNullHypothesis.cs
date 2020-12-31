using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.Parametric
{
    public class TTestOneSampleNullHypothesis : INullHypothesis
    {
        public TTestOneSampleNullHypothesis(IEnumerable<double> samples, double populationMean)
        {
            Samples = samples;
            PopulationMean = populationMean;
        }

        public IEnumerable<double> Samples { get; }
        public double PopulationMean { get; }
    }
}
