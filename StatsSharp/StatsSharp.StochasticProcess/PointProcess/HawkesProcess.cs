using MathNet.Numerics.Optimization;
using StatsSharp.Extensions;
using StatsSharp.StochasticProcess.PointProcessConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public class HawkesProcess : IPointProcess<HawkesProcessConfig, Func<double, IEnumerable<double>, double>>
    {
        public IEnumerable<double> GetEventSample(HawkesProcessConfig config)
        {
            var pastEventTime = new List<double>();
            var intensity = config.Intensity(StochasticProcess.Extentions.FindIntensityMaximumTime(config, pastEventTime), pastEventTime);
            var t = config.Start;
            var proposalTime = config.Start;

            var uniform = new Probability.Distribution.Uniform();
            var uniformParam = new Probability.Parameter.Uniform(0, 1);
            var exp = new Probability.Distribution.Exponential();

            while (true)
            {
                if (proposalTime > config.End)
                    break;
                var expParam = new Probability.Parameter.Exponential(1.0 / intensity);
                proposalTime += exp.GetSamples(expParam, 1).First();
                if (config.Intensity(t, pastEventTime) / intensity >= uniform.GetSamples(uniformParam, 1).First())
                {
                    t = proposalTime;
                    pastEventTime.Add(t);
                    intensity = config.Intensity(StochasticProcess.Extentions.FindIntensityMaximumTime(new HawkesProcessConfig(config.BackgroundRate, config.Kernel, t, config.End), pastEventTime), pastEventTime);
                    yield return t;
                }

            }
        }

        public IEnumerable<IEnumerable<double>> GetEventSamples(HawkesProcessConfig config, int size)
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
