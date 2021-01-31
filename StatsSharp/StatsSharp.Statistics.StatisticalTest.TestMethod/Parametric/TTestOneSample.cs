using StatsSharp.Extensions;
using StatsSharp.Statistics.StatisticalTest.NullHypothesis;
using StatsSharp.Statistics.StatisticalTest.TestMethod;
using StatsSharp.Statistics.StatisticalTest.StatisticalTestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.TestMethod.Parametric
{
    public class TTestOneSample : IStatisticalTest<TTestOneSampleNullHypothesis, double>
    {
        public ITestResult Test(TTestOneSampleNullHypothesis nullHypothesis)
        {
            var n = nullHypothesis.Samples.Count();
            var sampleMean = nullHypothesis.Samples.Average();
            var sampleStandardDeviation = nullHypothesis.Samples.StandardDeviation() * Math.Sqrt(n / (n - 1.0));

            var statistics = (sampleMean - nullHypothesis.PopulationMean) / (sampleStandardDeviation / Math.Sqrt(n));

            var tDist = new StatsSharp.Probability.Distribution.Continuous.Scalar.T();
            var tCdf = tDist.GetCumulativeDistributionFunction(new StatsSharp.Probability.Parameter.Continuous.Scalar.T(0, 1, n - 1));
            var pValue = 1 - Math.Abs(tCdf(statistics) - 0.5) * 2;

            return new TestResultBase(statistics: statistics, pValue: pValue);
        }
    }
}
