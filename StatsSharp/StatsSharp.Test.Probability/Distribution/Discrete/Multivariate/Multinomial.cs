using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Probability.Distribution.Discrete.Multivarite
{
    [TestClass]
    public class Multinomial
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var multi = new StatsSharp.Probability.Distribution.Discrete.Multivariate.Multinomial();
            var probs = new List<double>() { 0.3, 0.7 };

            var sample = new List<int>() { 1, 3 };
            var likelihood = multi.GetLikelihoodFunction(sample);
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Multivariate.Multinomial(probs, sample.Sum());
            var actual = likelihood(parameter);
            Assert.AreEqual(0.3 * 0.7 * 0.7 * 0.7 *4, actual, 1.0e-10);

        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var multi = new StatsSharp.Probability.Distribution.Discrete.Multivariate.Multinomial();
            var probs = new List<double>() { 0.3, 0.7 };

            var sample = new List<int>() { 1, 3 };
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Multivariate.Multinomial(probs, sample.Sum());
            var density = multi.GetProbabilityDensityFunction(parameter);
            var actual = density(sample);
            Assert.AreEqual(0.3 * 0.7 * 0.7 * 0.7 * 4, actual, 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var multi = new StatsSharp.Probability.Distribution.Discrete.Multivariate.Multinomial();

            var probs = new List<double>() { 0.3, 0.7 };
            var numOfTrials = 10;
            var parameter = new StatsSharp.Probability.Parameter.Discrete.Multivariate.Multinomial(probs, numOfTrials);
            Assert.AreEqual(Math.Pow(0.7, numOfTrials), multi.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
