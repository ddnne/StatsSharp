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
            var s = nullHypothesis.Samples.StadardDeviation() * Math.Sqrt(n / (n - 1.0));

            var statistics = (sampleMean - nullHypothesis.PopulationMean) / (s / Math.Sqrt(n));

            var normalDist = new Probability.Distribution.T();
            var normalCdf = normalDist.GetCumulativeDistributionFunction(new Probability.Parameter.T(0, 1, n - 1));
            var pValue = 1 - Math.Abs(normalCdf(statistics) - 0.5) * 2;

            return new StatisticalTestResult(statistics: statistics, pValue: pValue);
        }
    }
}
