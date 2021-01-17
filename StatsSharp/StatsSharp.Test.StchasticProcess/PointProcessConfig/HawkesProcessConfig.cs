using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.PointProcessConfig
{
    [TestClass]
    public class HawkesProcessConfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            var start = 0;
            var end = 1;
            Func<double, double> bgRate = (double t) => t;
            Func<double, double> kernel = (double t) => Math.Exp(-t * t);
            var eventTime = 0.5;
            var pastEventTime = new List<double>() { eventTime };
            Func<double, double> intensity = (double t) =>
            {
                if (t < eventTime)
                    return bgRate(t);
                else
                    return bgRate(t) + kernel(t - eventTime);
            };

            var config = new StochasticProcess.PointProcessConfig.HawkesProcessConfig(bgRate, kernel, start, end);
            Assert.AreEqual(start, config.Start, 1.0e-10);
            Assert.AreEqual(end, config.End, 1.0e-10);

            int N = 100;
            foreach(double t in Enumerable.Range(0, N).Select(x => start + (end - start) * x / (double) N))
            {
                Assert.AreEqual(intensity(t), config.Intensity(t, pastEventTime), 1.0e-10);
            }
        }
    }
}
