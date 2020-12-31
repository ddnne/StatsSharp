﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class Normal
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var normal = new StatsSharp.Probability.Distribution.Normal();

            var mean = 0;
            var sigma = 2;
            var at = 1.1;

            var likelihood = normal.GetLikelihoodFunction(at);
            var parameter = new StatsSharp.Probability.Parameter.Normal(mean, sigma);
            var actual = likelihood(parameter);
            Assert.AreEqual(Math.Exp(-Math.Pow((at - mean) / sigma, 2) / 2) / Math.Sqrt(2 * Math.Pow(sigma, 2)), actual, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var normal = new StatsSharp.Probability.Distribution.Normal();

            var mean = 0;
            var sigma = 2;
            var at = 1.1;

            var parameter = new StatsSharp.Probability.Parameter.Normal(mean, sigma);
            var density = normal.GetProbabilityDensityFunction(parameter);
            var actual = density(at);
            Assert.AreEqual(Math.Exp(-Math.Pow((at - mean) / sigma, 2) / 2) / Math.Sqrt(2 * Math.Pow(sigma, 2)), actual, 1.0e-10);
        }
    }
}