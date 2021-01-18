using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.Statistics.StatisticalTest.NullHypothesis
{
    [TestClass]
    public class TTestOneSampleNullHypothesis
    {
        [TestMethod]
        public void TestConstructor()
        {
            var samples = new double[] { 1, 2, 3 };
            var popMean = 1.23456;
            var nullHypothesis = new StatsSharp.Statistics.StatisticalTest.NullHypothesis.TTestOneSampleNullHypothesis(samples, popMean);

            CollectionAssert.AreEqual(samples, nullHypothesis.Samples.ToArray());
            Assert.AreEqual(popMean, nullHypothesis.PopulationMean, 1.0e-10);
        }
    }
}
