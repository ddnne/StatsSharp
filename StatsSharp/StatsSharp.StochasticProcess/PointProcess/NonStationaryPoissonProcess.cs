using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.Probability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.Optimization;
using StatsSharp.Extensions;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public class NonStationaryPoissonProcess : IPoissonProcess<NonStationaryPoissonProcessConfig, Func<double, double>>
    {
        private IEnumerable<double> GetEventSample(NonStationaryPoissonProcessConfig config)
        {
            var intensity = config.Intensity(StochasticProcess.Extentions.FindIntensityMaximumTime(config));
            var uniform = new Probability.Distribution.Uniform();
            var uniformParam = new Probability.Parameter.Uniform(0, 1);

            var stPoissonProc = new StochasticProcess.PointProcess.StationaryPoissonProcess();
            var sample = stPoissonProc.GetEventSamples(new StationaryPoissonProcessConfig(intensity, config.Start, config.End), 1).First();

            return sample.Where(t => config.Intensity(t) / intensity >= uniform.GetSamples(uniformParam, 1).First());
        }

        public IEnumerable<IEnumerable<double>> GetEventSamples(NonStationaryPoissonProcessConfig config, int size)
        {
            return Enumerable.Range(0, size).AsParallel().Select(i => GetEventSample(config).ToList());
        }

        public IEnumerable<int> GetNumberOfEventSamples(NonStationaryPoissonProcessConfig config, int size)
        {
            double intensityOfPoissonDist = MathNet.Numerics.Integration.GaussLegendreRule.Integrate(config.Intensity, config.Start, config.End, 1024);
            var possionConfig = new Probability.Parameter.Poisson(intensityOfPoissonDist);
            var poisson = new Probability.Distribution.Poisson();
            return poisson.GetSamples(possionConfig, size);
        }
    }
}
