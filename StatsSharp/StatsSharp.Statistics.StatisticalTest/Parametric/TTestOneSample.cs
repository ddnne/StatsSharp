using StatsSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.Parametric
{
    public class TTestOneSample : IStaisticalTest<TTestOneSampleNullHypothesis>
    {
        public StatisticalTestResult Calculate(TTestOneSampleNullHypothesis nullHypothesis)
        {
            var n = nullHypothesis.Samples.Count();
            var sampleMean = nullHypothesis.Samples.Average();
            var sampleStandardDeviation = nullHypothesis.Samples.StadardDeviation() * Math.Sqrt(n / (n - 1.0));

            var statistics = (sampleMean - nullHypothesis.PopulationMean) / (sampleStandardDeviation / Math.Sqrt(n));

            var tDist = new Probability.Distribution.T();
            var tCdf = tDist.GetCumulativeDistributionFunction(new Probability.Parameter.T(0, 1, n - 1));
            var pValue = 1 - Math.Abs(tCdf(statistics) - 0.5) * 2;

            return new StatisticalTestResult(statistics: statistics, pValue: pValue);
        }
    }
}
