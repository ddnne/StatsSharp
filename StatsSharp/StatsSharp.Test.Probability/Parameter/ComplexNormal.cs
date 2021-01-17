using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    public class ComplexNormal
    {
        [TestMethod]
        public void TestConstructor()
        {
            var mean = new Complex(1, 2);
            var sd = 1;

            var normalParameter = new StatsSharp.Probability.Parameter.ComplexNormal(mean, sd);
            Assert.AreEqual(mean.Real, normalParameter.Mean.Real, 1.0e-10);

            Assert.AreEqual(mean.Imaginary, normalParameter.Mean.Imaginary, 1.0e-10);
            Assert.AreEqual(sd, normalParameter.StandardDeviation, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusStandardDeviation()
        {
            var mean = new Complex(1, 1);
            var sd = -1;

            var unifParameter = new StatsSharp.Probability.Parameter.ComplexNormal(mean, sd);
        }
    }
}
