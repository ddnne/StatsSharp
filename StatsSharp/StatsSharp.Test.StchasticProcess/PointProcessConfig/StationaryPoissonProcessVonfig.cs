using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.PointProcessConfig
{
    [TestClass]
    public class StationaryPoissonProcessVonfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            var intensity = 1;
            var start = 0;
            var end = 1;

            var config = new StochasticProcess.PointProcessConfig.StationaryPoissonProcessConfig(intensity, start, end);
            Assert.AreEqual(intensity, config.Intensity, 1.0e-10);
            Assert.AreEqual(start, config.Start, 1.0e-10);
            Assert.AreEqual(end, config.End, 1.0e-10);
        }
    }
}
