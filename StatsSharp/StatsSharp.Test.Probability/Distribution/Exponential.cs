using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class Exponential
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var exp = new StatsSharp.Probability.Distribution.Continuous.Scalar.Exponential();

            var average = 1;
            // 0 <= data
            var likelihood = exp.GetLikelihoodFunction(0.5);
            var parameter = new StatsSharp.Probability.Parameter.Exponential(average);
            var actual = likelihood(parameter);
            Assert.AreEqual(Math.Exp(-0.5), actual, 1.0e-10);

            // data < 0
            var likelihoodAtDataSmallerThanStart = exp.GetLikelihoodFunction(-1);
            var actualAtDataSmallerThanStart = likelihoodAtDataSmallerThanStart(parameter);
            Assert.AreEqual(0, actualAtDataSmallerThanStart, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var exp = new StatsSharp.Probability.Distribution.Continuous.Scalar.Exponential();

            var average = 1;
            var parameter = new StatsSharp.Probability.Parameter.Exponential(average);
            var density = exp.GetProbabilityDensityFunction(parameter);

            Assert.AreEqual(Math.Exp(-0.5), density(0.5), 1.0e-10);
            Assert.AreEqual(0, density(-1), 1.0e-10);
        }

        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var exp = new StatsSharp.Probability.Distribution.Continuous.Scalar.Exponential();

            var average = 1;
            var parameter = new StatsSharp.Probability.Parameter.Exponential(average);
            var cdf = exp.GetCumulativeDistributionFunction(parameter);

            Assert.AreEqual(0, cdf(- 1), 1.0e-10);
            Assert.AreEqual(1 - Math.Exp(-1), cdf(1), 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var exp = new StatsSharp.Probability.Distribution.Continuous.Scalar.Exponential();

            var average = 1;
            var parameter = new StatsSharp.Probability.Parameter.Exponential(average);
            Assert.AreEqual(1.0, exp.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
