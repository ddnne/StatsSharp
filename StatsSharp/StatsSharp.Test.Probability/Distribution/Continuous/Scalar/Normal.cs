using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Distribution.Continuous.Scalar
{
    [TestClass]
    public class Normal
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var normal = new StatsSharp.Probability.Distribution.Continuous.Scalar.Normal();

            var mean = 0;
            var sigma = 2;
            var at = 1.1;

            var likelihood = normal.GetLikelihoodFunction(at);
            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Normal(mean, sigma);
            var actual = likelihood(parameter);
            Assert.AreEqual(Math.Exp(-Math.Pow((at - mean) / sigma, 2) / 2) / Math.Sqrt(2 * Math.PI * Math.Pow(sigma, 2)), actual, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var normal = new StatsSharp.Probability.Distribution.Continuous.Scalar.Normal();

            var mean = 0;
            var sigma = 2;
            var at = 1.1;

            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Normal(mean, sigma);
            var density = normal.GetProbabilityDensityFunction(parameter);
            var actual = density(at);
            Assert.AreEqual(Math.Exp(-Math.Pow((at - mean) / sigma, 2) / 2) / Math.Sqrt(2 * Math.PI * Math.Pow(sigma, 2)), actual, 1.0e-10);
        }

        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var normal = new StatsSharp.Probability.Distribution.Continuous.Scalar.Normal();

            var mean = 0;
            var sigma = 2;

            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Normal(mean, sigma);
            var cdf = normal.GetCumulativeDistributionFunction(parameter);
            Assert.AreEqual(0.5, cdf(parameter.Mean), 1.0e-10);
            Assert.AreEqual(0, cdf(Double.NegativeInfinity), 1.0e-10);
            Assert.AreEqual(1, cdf(Double.PositiveInfinity), 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var normal = new StatsSharp.Probability.Distribution.Continuous.Scalar.Normal();

            var mean = 0;
            var sigma = 1;

            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Normal(mean, sigma);
            Assert.AreEqual(1 / Math.Sqrt(2 * Math.PI), normal.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
