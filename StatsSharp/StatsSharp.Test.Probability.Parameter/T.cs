using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    public class T
    {
        [TestMethod]
        public void TestConstructor()
        {
            var mean = 0;
            var scale = 1;
            var dof = 1;

            var tParameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
            Assert.AreEqual(mean, tParameter.Mean, 1.0e-10);
            Assert.AreEqual(scale, tParameter.Scale, 1.0e-10);
            Assert.AreEqual(dof, tParameter.DegreeOfFreedom, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusScale()
        {
            var mean = 0;
            var scale = -1;
            var dof = 1;

            var tParameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusDegreeOfFreedom()
        {
            var mean = 0;
            var scale = 1;
            var dof = -1;

            var tParameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
        }
    }
}
