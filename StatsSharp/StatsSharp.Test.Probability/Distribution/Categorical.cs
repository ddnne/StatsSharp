using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class Categorical
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var cat = new StatsSharp.Probability.Distribution.Discrete.Categorical();
            var probs = new List<double>() { 0.3, 0.7 };

            foreach (var id in Enumerable.Range(0, probs.Count()))
            {
                var likelihood = cat.GetLikelihoodFunction(id);
                var parameter = new StatsSharp.Probability.Parameter.Categorical(probs);
                var actual = likelihood(parameter);
                Assert.AreEqual(probs[id], actual, 1.0e-10);
            }
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var cat = new StatsSharp.Probability.Distribution.Discrete.Categorical();
            var probs = new List<double>() { 0.3, 0.7 };

            foreach (var id in Enumerable.Range(0, probs.Count()))
            {
                var parameter = new StatsSharp.Probability.Parameter.Categorical(probs);
                var actual = cat.GetProbabilityDensityFunction(parameter)(id);
                Assert.AreEqual(probs[id], actual, 1.0e-10);
            }
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var cat = new StatsSharp.Probability.Distribution.Discrete.Categorical();

            var probs = new List<double>() { 0.3, 0.7 };
            var parameter = new StatsSharp.Probability.Parameter.Categorical(probs);
            Assert.AreEqual(0.7, cat.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
