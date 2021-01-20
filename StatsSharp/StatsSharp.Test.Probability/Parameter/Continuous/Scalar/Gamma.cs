using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter.Continuous.Scalar
{
    [TestClass]
    class Gamma
    {
        [TestMethod]
        public void TestConstructor()
        {
            var k = 1;
            var theta = 2;

            var gammaParameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Gamma(k, theta);
            Assert.AreEqual(k, gammaParameter.K, 1.0e-10);
            Assert.AreEqual(theta, gammaParameter.Theta, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusK()
        {
            var k = -1;
            var theta = 2;

            var gammaParameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Gamma(k, theta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusTheta()
        {
            var k = 1;
            var theta = -2;

            var gammaParameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Gamma(k, theta);
        }
    }
}
