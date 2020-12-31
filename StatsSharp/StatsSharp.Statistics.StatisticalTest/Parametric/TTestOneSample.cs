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
            var s = nullHypothesis.Samples.StadardDeviation() * n / (n - 1);

            var stat = (sampleMean - nullHypothesis.PopulationMean) / (s / Math.Sqrt(n));

            var normalDist = new Probability.Distribution.Normal();
            var normalCdf = normalDist.GetCumulativeDistributionFunction(new Probability.Parameter.Normal(0, 1));
            var pValue = normalCdf(stat);

            return new StatisticalTestResult(statistics: stat, pValue: pValue);
        }
    }
}
