using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    class Multinomial
    {
        [TestMethod]
        public void TestConstructor()
        {
            var probability = new List<double>() { 0.5, 0.5 };
            var numberOfTrials = 10;

            var mulParameter = new StatsSharp.Probability.Parameter.Multinomial(probability, numberOfTrials);
            CollectionAssert.AreEqual(probability, mulParameter.Probabilities.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusProbability()
        {
            var probability = new List<double>() { -1 };
            var numberOfTrials = 10;
            var mulParameter = new StatsSharp.Probability.Parameter.Multinomial(probability, numberOfTrials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOverOneProbability()
        {
            var probability = new List<double>() { 2 };
            var numberOfTrials = 10;
            var mulParameter = new StatsSharp.Probability.Parameter.Multinomial(probability, numberOfTrials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSumOverOneProbability()
        {
            var probability = new List<double>() { 0.5, 0.5, 0.5 };
            var numberOfTrials = 10;
            var mulParameter = new StatsSharp.Probability.Parameter.Multinomial(probability, numberOfTrials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusTrialsy()
        {
            var probability = new List<double>() { 0.5, 0.5};
            var numberOfTrials = -10;
            var mulParameter = new StatsSharp.Probability.Parameter.Multinomial(probability, numberOfTrials);
        }
    }
}
