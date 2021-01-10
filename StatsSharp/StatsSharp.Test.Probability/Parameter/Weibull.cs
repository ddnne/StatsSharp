using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    class Weibull
    {
        [TestMethod]
        public void TestConstructor()
        {
            var shape = 1;
            var Scale = 2;

            var weibullParameter = new StatsSharp.Probability.Parameter.Weibull(shape, Scale);
            Assert.AreEqual(shape, weibullParameter.Shape, 1.0e-10);
            Assert.AreEqual(Scale, weibullParameter.Shape, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusShape()
        {
            var shape = -1;
            var Scale = 2;

            var weibullParameter = new StatsSharp.Probability.Parameter.Weibull(shape, Scale);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusScale()
        {
            var shape = 1;
            var Scale = -2;

            var weibullParameter = new StatsSharp.Probability.Parameter.Weibull(shape, Scale);
        }
    }
}
