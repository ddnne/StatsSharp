using MathNet.Numerics.Optimization;
using StatsSharp.Extensions;
using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.StochasticProcess.PointProcessEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess
{
    public static class PointProcessExtentions
    {
        public static double FindIntensityMaximumTime(NonStationaryPoissonProcessConfig config, int gridSize = 10000)
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

        public static double FindIntensityMaximumTime(HawkesProcessConfig config, IEnumerable<UnivariatePointProcessEvent> events, int gridSize = 10000)
        {
            try
            {
                var algorithm = new GoldenSectionMinimizer(1e-5, 1000);
                Func<double, double> f1 = (double t) => -config.Intensity(t, events);
                var obj = ObjectiveFunction.ScalarValue(f1);
                var r1 = GoldenSectionMinimizer.Minimum(obj, config.Start, config.End);
                return r1.MinimizingPoint;
            }
            catch (OptimizationException e)
            {
                var times = Enumerable.Range(0, gridSize + 1).Select(i => config.Start + i * (config.End - config.Start) / gridSize);
                return times.MaxBy(t => config.Intensity(t, events));
            }
        }

        public static double FindIntensityMaximumTime(MultivariateHawkesProcessConfig config, IEnumerable<MultivariatePointProcessEvent> events, int gridSize = 10000)
        {
            try
            {
                var algorithm = new GoldenSectionMinimizer(1e-5, 1000);
                Func<double, double> f1 = (double t) => -config.Intensities(t, events).Sum();
                var obj = ObjectiveFunction.ScalarValue(f1);
                var r1 = GoldenSectionMinimizer.Minimum(obj, config.Start, config.End);
                return r1.MinimizingPoint;
            }
            catch (OptimizationException e)
            {
                var times = Enumerable.Range(0, gridSize + 1).Select(i => config.Start + i * (config.End - config.Start) / gridSize);
                return times.MaxBy(t => config.Intensities(t, events).Sum());
            }
        }

    }
}
