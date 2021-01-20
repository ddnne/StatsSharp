using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class Gamma
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var Gamma = new StatsSharp.Probability.Distribution.Continuous.Scalar.Gamma();

            var k = 1;
            var theta = 2;
            var at = 1.1;

            var likelihood = Gamma.GetLikelihoodFunction(at);
            var parameter = new StatsSharp.Probability.Parameter.Gamma(k, theta);
            var actual = likelihood(parameter);
            Assert.AreEqual(Math.Exp(-at / 2) / 2, actual, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var Gamma = new StatsSharp.Probability.Distribution.Continuous.Scalar.Gamma();

            var k = 1;
            var theta = 2;
            var at = 1.1;

            var parameter = new StatsSharp.Probability.Parameter.Gamma(k, theta);
            var density = Gamma.GetProbabilityDensityFunction(parameter);
            var actual = density(at);
            Assert.AreEqual(Math.Exp(-at / 2) / 2, actual, 1.0e-10);
        }

        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var Gamma = new StatsSharp.Probability.Distribution.Continuous.Scalar.Gamma();

            var k = 1;
            var theta = 2;

            var parameter = new StatsSharp.Probability.Parameter.Gamma(k, theta);
            var cdf = Gamma.GetCumulativeDistributionFunction(parameter);
            Assert.AreEqual(1 - Math.Exp(-1), cdf(2), 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var Gamma = new StatsSharp.Probability.Distribution.Continuous.Scalar.Gamma();

            var k = 2;
            var theta = 1;
            var kGt1Case = new StatsSharp.Probability.Parameter.Gamma(k, theta);
            Assert.AreEqual(Math.Exp(-1.0), Gamma.GetMaxValueProbabilityDensityFunction(kGt1Case), 1.0e-10);

            var kLt1Case = new StatsSharp.Probability.Parameter.Gamma(0.5, theta);
            Assert.IsTrue(Double.IsPositiveInfinity(Gamma.GetMaxValueProbabilityDensityFunction(kLt1Case)));
        }
    }
}
