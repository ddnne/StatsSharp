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
        private double FindIntensityMaximumTime(NonStationaryPoissonProcessConfig config, int gridSize = 10000)
        {
            try
            {
                var algorithm = new GoldenSectionMinimizer(1e-5, 1000);
                Func<double, double> f1 = (double t) => -config.Intensity(t);
                var obj = ObjectiveFunction.ScalarValue(f1);
                var r1 = GoldenSectionMinimizer.Minimum(obj, config.Start, config.End);
                return r1.MinimizingPoint;
            }
            catch (OptimizationException e)
            {
                var times = Enumerable.Range(0, gridSize + 1).Select(i => config.Start + i * (config.End - config.Start) / gridSize);
                return times.MaxBy(config.Intensity);
            }
        }
        private IEnumerable<double> GetEventSample(NonStationaryPoissonProcessConfig config)
        {
            var t = config.Start;
            var proposalNextTime = config.Start;
            var exp = new Probability.Distribution.Exponential();
            var uniform = new Probability.Distribution.Uniform();
            var uniformParam = new Probability.Parameter.Uniform(0, 1);
            var intensity = config.Intensity(FindIntensityMaximumTime(config));

            while (t <= config.End)
            {
                var expParam = new Probability.Parameter.Exponential(1.0 / intensity);
                proposalNextTime = proposalNextTime + exp.GetSamples(expParam, 1).First();
                if (proposalNextTime <= config.End)
                {
                    var u = uniform.GetSamples(uniformParam, 1).First();
                    if (config.Intensity(proposalNextTime) / intensity >= u)
                    {
                        t = proposalNextTime;
                        yield return t;
                    }
                }
                else
                    break;
            }

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
