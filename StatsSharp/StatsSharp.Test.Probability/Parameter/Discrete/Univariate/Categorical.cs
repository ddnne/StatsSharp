using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter.Discrete.Univariate
{
    [TestClass]
    class Categorical
    {
        [TestMethod]
        public void TestConstructor()
        {
            var probability = new List<double>() { 0.5, 0.5 };

            var catParameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Categorical(probability);
            CollectionAssert.AreEqual(probability, catParameter.Probabilities.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusProbability()
        {
            var probability = new List<double>() { -1 };
            var catParameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Categorical(probability);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOverOneProbability()
        {
            var probability = new List<double>() { 2 };
            var catParameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Categorical(probability);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSumOverOneProbability()
        {
            var probability = new List<double>() { 0.5, 0.5, 0.5 };
            var catParameter = new StatsSharp.Probability.Parameter.Discrete.Univariate.Categorical(probability);
        }
    }
}
