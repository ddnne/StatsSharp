using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    public class Uniform
    {
        [TestMethod]
        public void TestConstructor()
        {
            var start = 0;
            var end = 1;

            var unifParameter = new StatsSharp.Probability.Parameter.Uniform(start, end);
            Assert.AreEqual(start, unifParameter.Start, 1.0e-10);
            Assert.AreEqual(end, unifParameter.End, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStartLargerThanEnd()
        {
            var start = 1;
            var end = 0;

            var unifParameter = new StatsSharp.Probability.Parameter.Uniform(start, end);
        }
    }
}
