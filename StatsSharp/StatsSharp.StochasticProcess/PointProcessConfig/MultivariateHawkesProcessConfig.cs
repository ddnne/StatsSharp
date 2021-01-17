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

        public IEnumerable<double> Intensities(double t, IEnumerable<double> pastEventTime, IEnumerable<int> pastEventId)
        {
            var eventInfo = pastEventId.Zip(pastEventTime, (eventId, eventTime) => new { eventId, eventTime });
            return Enumerable.Range(0, Kind).Select(intensityId =>
            {
                var bgRate = BackgroundRates.ElementAt(intensityId);
                var kernels = Kernels.ElementAt(intensityId);
                return bgRate(t) + eventInfo.Where(ev => ev.eventTime <= t).Select(ev => kernels.ElementAt(ev.eventId)(t - ev.eventTime)).Sum();
            });
        }

        internal int Kind { get; }
        internal IEnumerable<Func<double, double>> BackgroundRates { get; }
        internal IEnumerable<IEnumerable<Func<double, double>>> Kernels { get; }
        public double Start { get; }
        public double End { get; }
    }
}
