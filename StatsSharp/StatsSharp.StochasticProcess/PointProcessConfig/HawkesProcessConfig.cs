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

        public double Intensity(double t, IEnumerable<double> pastEventTime)
        {
            return BackgroundRate(t) + pastEventTime.Where(ti => t >= ti).Select(ti => Kernel(t - ti)).Sum();
        }

        internal Func<double, double> BackgroundRate { get; }
        internal Func<double, double> Kernel { get; }
        public double Start { get; }
        public double End { get; }
    }
}
