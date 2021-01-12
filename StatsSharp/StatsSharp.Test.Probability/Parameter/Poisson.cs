using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    class Poisson
    {
        [TestMethod]
        public void TestConstructor()
        {
            var intensity = 1;

            var expParameter = new StatsSharp.Probability.Parameter.Poisson(intensity);
            Assert.AreEqual(intensity, expParameter.Intensity, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusIntensity()
        {
            var intensity = -1;
            var expParameter = new StatsSharp.Probability.Parameter.Poisson(intensity);
        }
    }
}
