using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.PointProcessConfig
{
    [TestClass]
    public class NonStationaryPoissonProcessConfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            Func<double, double> intensity = (double t) => t;
            var start = 0.0;
            var end = 1.0;

            var config = new StochasticProcess.PointProcessConfig.NonStationaryPoissonProcessConfig(intensity, start, end);

            var N = 10;
            foreach (var t in Enumerable.Range(0, N).Select(i => (end - start) / N))
                Assert.AreEqual(intensity(t), config.Intensity(t), 1.0e-10);
            Assert.AreEqual(start, config.Start, 1.0e-10);
            Assert.AreEqual(end, config.End, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EndSmallerThanStart()
        {
            Func<double, double> intensity = (double t) => t;
            var start = 10.0;
            var end = 1.0;

            var config = new StochasticProcess.PointProcessConfig.NonStationaryPoissonProcessConfig(intensity, start, end);
        }
    }
}
