using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    class Exponential
    {
        [TestMethod]
        public void TestConstructor()
        {
            var average = 1;

            var expParameter = new StatsSharp.Probability.Parameter.Exponential(average);
            Assert.AreEqual(average, expParameter.Average, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusAverage()
        {
            var average = -1;
            var expParameter = new StatsSharp.Probability.Parameter.Exponential(average);
        }
    }
}
