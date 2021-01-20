using MathNet.Numerics.Optimization;
using StatsSharp.Extensions;
using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.StochasticProcess.PointProcessEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public class HawkesProcess : IPointProcess<HawkesProcessConfig, UnivariatePointProcessEvent, Func<double, IEnumerable<double>, double>>
    {
        private IEnumerable<UnivariatePointProcessEvent> GetEventSample(HawkesProcessConfig config)
        {
            var events = new List<UnivariatePointProcessEvent>();
            var intensity = config.Intensity(Extentions.FindIntensityMaximumTime(config, events), events);
            var t = config.Start;
            var proposalTime = config.Start;

            var uniform = new Probability.Distribution.Continuous.Scalar.Uniform();
            var uniformParam = new Probability.Parameter.Uniform(0, 1);
            var exp = new Probability.Distribution.Continuous.Scalar.Exponential();

            while (true)
            {
                if (proposalTime > config.End)
                    break;
                var expParam = new Probability.Parameter.Exponential(1.0 / intensity);
                proposalTime += exp.GetSamples(expParam, 1).First();
                if (config.Intensity(t, events) / intensity >= uniform.GetSamples(uniformParam, 1).First())
                {
                    t = proposalTime;
                    events.Add(new UnivariatePointProcessEvent(t));

                    var maxIntensityTime = Extentions.FindIntensityMaximumTime(config, events);
                    intensity = config.Intensity(maxIntensityTime, events);
                }
            }

            return events;
        }

        public IEnumerable<IEnumerable<UnivariatePointProcessEvent>> GetEventSamples(HawkesProcessConfig config, int size)
        {
            return Enumerable.Range(0, size).Select(i => GetEventSample(config));
        }

        public IEnumerable<int> GetNumberOfEventSamples(HawkesProcessConfig config, int size)
        {
            var nppTimeSamples = GetEventSamples(config, size).Select(t => t.ToList()).ToList();
            var nppTimeSamplesCount = nppTimeSamples.Select(t => t.Count());
            return nppTimeSamplesCount;
        }
    }
}
