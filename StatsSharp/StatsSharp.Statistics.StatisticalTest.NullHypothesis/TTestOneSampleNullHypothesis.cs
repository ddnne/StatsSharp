using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.NullHypothesis
{
    public class TTestOneSampleNullHypothesis : INullHypothesis<double>
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
