using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Distribution.Discrete.Univariate
{
    [TestClass]
    public class Poisson
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var poisson = new StatsSharp.Probability.Distribution.Discrete.Univariate.Poisson();

            var intensity = 1;
            // 0 <= data
            var likelihood = poisson.GetLikelihoodFunction(1);
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Poisson(intensity);
            var actual = likelihood(parameter);
            Assert.AreEqual(Math.Exp(-1), actual, 1.0e-10);

            // data < 0
            var likelihoodAtDataSmallerThanStart = poisson.GetLikelihoodFunction(-1);
            var actualAtDataSmallerThanStart = likelihoodAtDataSmallerThanStart(parameter);
            Assert.AreEqual(0, actualAtDataSmallerThanStart, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var poisson = new StatsSharp.Probability.Distribution.Discrete.Univariate.Poisson();

            var intensity = 1;
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Poisson(intensity);
            var density = poisson.GetProbabilityDensityFunction(parameter);

            Assert.AreEqual(Math.Exp(-1), density(1), 1.0e-10);
            Assert.AreEqual(0, density(-1), 1.0e-10);
        }

        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var poisson = new StatsSharp.Probability.Distribution.Discrete.Univariate.Poisson();

            var intensity = 1;
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Poisson(intensity);
            var cdf = poisson.GetCumulativeDistributionFunction(parameter);

            Assert.AreEqual(0, cdf(- 1), 1.0e-10);
            Assert.AreEqual(Math.Exp(-1) + Math.Exp(-1), cdf(1), 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var poisson = new StatsSharp.Probability.Distribution.Discrete.Univariate.Poisson();

            var intensity = 1.5;
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Poisson(intensity);
            Assert.AreEqual(Math.Exp(-intensity) * intensity, poisson.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
