using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class Weibull
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var weibull = new StatsSharp.Probability.Distribution.Weibull();

            var shape = 1;
            var scale = 2;
            var at = 1.1;

            var likelihood = weibull.GetLikelihoodFunction(at);
            var parameter = new StatsSharp.Probability.Parameter.Weibull(shape, scale);
            var actual = likelihood(parameter);
            Assert.AreEqual(Math.Exp(-at / 2) / 2, actual, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var weibull = new StatsSharp.Probability.Distribution.Weibull();

            var shape = 1;
            var scale = 2;
            var at = 1.1;

            var parameter = new StatsSharp.Probability.Parameter.Weibull(shape, scale);
            var density = weibull.GetProbabilityDensityFunction(parameter);
            var actual = density(at);
            Assert.AreEqual(Math.Exp(-at / 2) / 2, actual, 1.0e-10);
            Assert.AreEqual(0, density(-1), 1.0e-10);
        }

        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var weibull = new StatsSharp.Probability.Distribution.Weibull();

            var shape = 1;
            var scale = 2;
            var at = 1.1;

            var parameter = new StatsSharp.Probability.Parameter.Weibull(shape, scale);
            var cdf = weibull.GetCumulativeDistributionFunction(parameter);
            Assert.AreEqual(1 - Math.Exp(-at / 2), cdf(at), 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var weibull = new StatsSharp.Probability.Distribution.Weibull();

            var shape = 1;
            var scale = 2;

            var parameter = new StatsSharp.Probability.Parameter.Weibull(shape, scale);
            Assert.AreEqual(1.0 / 2.0, weibull.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);

            var largeShape = 2;

            var largeShapeParameter = new StatsSharp.Probability.Parameter.Weibull(largeShape, scale);
            Assert.AreEqual(Math.Exp(-1.0 / 2.0) / Math.Sqrt(2), weibull.GetMaxValueProbabilityDensityFunction(largeShapeParameter), 1.0e-10);
        }
    }
}
