using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.StatisticalTest
{
    [TestClass]
    public class Parametric
    {
        [TestMethod]
        public void TTestOneSample()
        {
            // following data from https://tanuhack.com/ttest-one-sample/
            var samples = new double[] { 210.9, 195.4, 202.1 , 211.3, 195.5, 212.9, 210.9, 198.3, 202.1, 215.6,204.7, 212.2, 200.7, 206.1, 195.8};
            var popMean = 200;
            var expectedStatistics = 2.751076959309973;
            var expectedPValue = 0.015611934395473872;

            var result = StatsSharp.Statistics.StatisticalTest.TestMethod.Parametric.TTestOneSample(new StatsSharp.Statistics.StatisticalTest.NullHypothesis.TTestOneSampleNullHypothesis(samples, popMean));
            Assert.AreEqual(expectedStatistics, result.Statistics, 1.0e-10);
            Assert.AreEqual(expectedPValue, result.PValue, 1.0e-10);
        }
    }
}
