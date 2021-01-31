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
    public class MultivariateHawkesProcess : IPointProcess<MultivariateHawkesProcessConfig, MultivariatePointProcessEvent, Func<double, IEnumerable<double>, double>>
    {
        private IEnumerable<MultivariatePointProcessEvent> GetEventSample(MultivariateHawkesProcessConfig config)
        {
            var events = new List<MultivariatePointProcessEvent>();
            var maxIntensity = config.Intensities(PointProcessExtentions.FindIntensityMaximumTime(config, events), events).Sum();
            var t = config.Start;
            var proposalTime = config.Start;

            var uniform = new Probability.Distribution.Continuous.Scalar.Uniform();
            var uniformParam = new Probability.Parameter.Continuous.Scalar.Uniform(0, 1);
            var exp = new Probability.Distribution.Continuous.Scalar.Exponential();
            var cat = new Probability.Distribution.Discrete.Univariate.Categorical();

            while (true)
            {
                if (proposalTime > config.End)
                    break;
                var expParam = new Probability.Parameter.Continuous.Scalar.Exponential(1.0 / maxIntensity);
                proposalTime += exp.GetSamples(expParam, 1).First();
                var targetIntensities = config.Intensities(proposalTime, events);
                var sumTargetIntensity = targetIntensities.Sum();
                if (sumTargetIntensity / maxIntensity >= uniform.GetSamples(uniformParam, 1).First())
                {
                    t = proposalTime;
                    var catParam = new Probability.Parameter.Discrete.Univariate.Categorical(targetIntensities.Select(intenity => intenity / sumTargetIntensity));
                    var newEventId = cat.GetSamples(catParam, 1).First();
                    events.Add(new MultivariatePointProcessEvent(newEventId, t));

                    var maxIntensityTime = PointProcessExtentions.FindIntensityMaximumTime(config, events);
                    maxIntensity = config.Intensities(maxIntensityTime, events).Sum();
                }
            }

            return events;
        }

        public IEnumerable<IEnumerable<MultivariatePointProcessEvent>> GetEventSamples(MultivariateHawkesProcessConfig config, int size)
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
