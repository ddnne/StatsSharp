using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    public class Normal
    {
        [TestMethod]
        public void TestConstructor()
        {
            var mean = 0;
            var sd = 1;

            var normalParameter = new StatsSharp.Probability.Parameter.Normal(mean, sd);
            Assert.AreEqual(mean, normalParameter.Mean, 1.0e-10);
            Assert.AreEqual(sd, normalParameter.StandardDeviation, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusStandardDeviation()
        {
            var mean = 0;
            var sd = -1;

            var unifParameter = new StatsSharp.Probability.Parameter.Normal(mean, sd);
        }
    }
}
