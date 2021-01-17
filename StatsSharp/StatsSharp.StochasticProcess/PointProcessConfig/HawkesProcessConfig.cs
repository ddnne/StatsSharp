using StatsSharp.StochasticProcess.PointProcessEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public class HawkesProcessConfig : IPointProcessConfig
    {
        public HawkesProcessConfig(Func<double, double> backgroundRate, Func<double, double> kernel, double start, double end)
        {
            BackgroundRate = backgroundRate;
            Kernel = kernel;
            Start = start;
            End = end;
        }

        public double Intensity(double t, IEnumerable<UnivariatePointProcessEvent> events)
        {
            return BackgroundRate(t) + events.Where(ti => t >= ti.EventTime).Select(ti => Kernel(t - ti.EventTime)).Sum();
        }

        internal Func<double, double> BackgroundRate { get; }
        internal Func<double, double> Kernel { get; }
        public double Start { get; }
        public double End { get; }
    }
}
