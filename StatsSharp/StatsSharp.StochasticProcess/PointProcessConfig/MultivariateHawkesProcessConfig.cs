using StatsSharp.StochasticProcess.PointProcessEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public class MultivariateHawkesProcessConfig : IPointProcessConfig
    {
        public MultivariateHawkesProcessConfig(IEnumerable<Func<double, double>> backgroundRate, IEnumerable<IEnumerable<Func<double, double>>> kernels, double start, double end)
        {
            
            if (backgroundRate.Count() != kernels.Count())
                throw new ArgumentException();
            foreach(var kernel in kernels)
            {
                if (backgroundRate.Count() != kernel.Count())
                    throw new ArgumentException();
            }
            BackgroundRates = backgroundRate;
            Kernels = kernels;
            Start = start;
            End = end;
            Kind = backgroundRate.Count();
        }

        public IEnumerable<double> Intensities(double t, IEnumerable<MultivariatePointProcessEvent> events)
        {
            return Enumerable.Range(0, Kind).Select(intensityId =>
            {
                var bgRate = BackgroundRates.ElementAt(intensityId);
                var kernels = Kernels.ElementAt(intensityId);
                return bgRate(t) + events.Where(ev => ev.EventTime <= t).Select(ev => kernels.ElementAt(ev.EventKind)(t - ev.EventTime)).Sum();
            });
        }

        internal int Kind { get; }
        internal IEnumerable<Func<double, double>> BackgroundRates { get; }
        internal IEnumerable<IEnumerable<Func<double, double>>> Kernels { get; }
        public double Start { get; }
        public double End { get; }
    }
}
