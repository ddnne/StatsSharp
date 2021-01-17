using MathNet.Numerics.Optimization;
using StatsSharp.Extensions;
using StatsSharp.StochasticProcess.PointProcessConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public class MultivariateHawkesProcess : IPointProcess<MultivariateHawkesProcessConfig, Func<double, IEnumerable<double>, double>>
    {
        public IEnumerable<double> GetEventSample(MultivariateHawkesProcessConfig config)
        {
            var pastEventId = new List<int>();
            var pastEventTime = new List<double>();
            var maxIntensity = config.Intensities(Extentions.FindIntensityMaximumTime(config, pastEventTime, pastEventId), pastEventTime, pastEventId).Sum();
            var t = config.Start;
            var proposalTime = config.Start;

            var uniform = new Probability.Distribution.Uniform();
            var uniformParam = new Probability.Parameter.Uniform(0, 1);
            var exp = new Probability.Distribution.Exponential();

            var cat = new Probability.Distribution.Categorical();

            while (true)
            {
                if (proposalTime > config.End)
                    break;
                var expParam = new Probability.Parameter.Exponential(1.0 / maxIntensity);
                proposalTime += exp.GetSamples(expParam, 1).First();
                var targetIntensities = config.Intensities(proposalTime, pastEventTime, pastEventId);
                var sumTargetIntensity = targetIntensities.Sum();
                if (sumTargetIntensity / maxIntensity >= uniform.GetSamples(uniformParam, 1).First())
                {
                    t = proposalTime;
                    var catParam = new Probability.Parameter.Categorical(targetIntensities.Select(intenity => intenity / sumTargetIntensity));
                    var newEventId = cat.GetSamples(catParam, 1).First();
                    pastEventId.Add(newEventId);
                    pastEventTime.Add(t);
                    maxIntensity = config.Intensities(Extentions.FindIntensityMaximumTime(config, pastEventTime, pastEventId), pastEventTime, pastEventId).Sum();
                    yield return t;
                }

            }
        }

        public IEnumerable<IEnumerable<double>> GetEventSamples(MultivariateHawkesProcessConfig config, int size)
        {
            return Enumerable.Range(0, size).Select(i => GetEventSample(config));
        }

        public IEnumerable<int> GetNumberOfEventSamples(MultivariateHawkesProcessConfig config, int size)
        {
            var nppTimeSamples = GetEventSamples(config, size).Select(t => t.ToList()).ToList();
            var nppTimeSamplesCount = nppTimeSamples.Select(t => t.Count());
            return nppTimeSamplesCount;
        }
    }
}
