using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.StochasticProcess.PointProcessEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Test.StchasticProcess.PointProcessConfig
{
    [TestClass]
    public class MultivariateHawkesProcessConfig
    {
        [TestMethod]
        public void TestConstructor()
        {
            var start = 0;
            var end = 1;
            List<Func<double, double>> bgRate = new List<Func<double, double>>() { (double t) => t, (double t) => t * t };
            List<List<Func<double, double>>> kernel = new List<List<Func<double, double>>>()
            {
                new List<Func<double, double>>(){ (double t) => Math.Exp(-t * t), (double t) => Math.Exp(-2 * t * t) },
                new List<Func<double, double>>(){ (double t) => Math.Exp(-2 * t * t), (double t) => Math.Exp(-t * t) },
            };

            var dim = bgRate.Count();
            var actEventIndex = 0;
            var eventTime = 0.5;
            var events = new List<MultivariatePointProcessEvent>() { new MultivariatePointProcessEvent(actEventIndex, eventTime) };
            Func<double, IEnumerable<double>> intensity = (double t) =>
            {
                if (t < eventTime)
                    return bgRate.Select(r => r(t));
                else
                {
                    return Enumerable.Range(0, dim).Select(i => bgRate.ElementAt(i)(t) + events.Select(p =>
                    kernel.ElementAt(i).ElementAt(p.EventKind)(t - p.EventTime)).Sum());
                }
            };

            var config = new StochasticProcess.PointProcessConfig.MultivariateHawkesProcessConfig(bgRate, kernel, start, end);
            Assert.AreEqual(start, config.Start, 1.0e-10);
            Assert.AreEqual(end, config.End, 1.0e-10);

            int N = 100;
            foreach (double t in Enumerable.Range(0, N).Select(x => start + (end - start) * x / (double)N))
            {
                var expected = intensity(t);
                var actual = config.Intensities(t, events);
                foreach (var pair in expected.Zip(actual, (exp, act) => new { exp, act }))
                    Assert.AreEqual(pair.exp, pair.act, 1.0e-10);
            }
        }
    }
}
