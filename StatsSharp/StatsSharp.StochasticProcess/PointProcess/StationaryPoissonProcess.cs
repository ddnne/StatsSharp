using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.Probability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public class StationaryPoissonProcess : IPoissonProcess<StationaryPoissonProcessConfig, double>
    {
        private IEnumerable<double> GetEventSample(StationaryPoissonProcessConfig config)
        {
            var t = config.Start;
            var exp = new Probability.Distribution.Exponential();
            var expParam = new Probability.Parameter.Exponential(1.0 / config.Intensity);

            while (t <= config.End)
            {
                t = t + exp.GetSamples(expParam, 1).First();
                yield return t;
            }

        }

        public IEnumerable<IEnumerable<double>> GetEventSamples(StationaryPoissonProcessConfig config, int size)
        {
            return Enumerable.Range(0, size).AsParallel().Select(i => GetEventSample(config).ToList());
        }

        public IEnumerable<int> GetNumberOfEventSamples(StationaryPoissonProcessConfig config,int size)
        {
            double intensityOfPoissonDist = config.Intensity * (config.End - config.Start);

            var possionConfig = new Probability.Parameter.Poisson(intensityOfPoissonDist);
            var poisson = new Probability.Distribution.Poisson();
            return poisson.GetSamples(possionConfig, size);
        }
    }
}
