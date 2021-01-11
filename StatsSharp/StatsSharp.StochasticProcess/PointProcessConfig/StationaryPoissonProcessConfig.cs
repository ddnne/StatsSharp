using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public class StationaryPoissonProcessConfig : IPoissonProcessConfig
    {
        public StationaryPoissonProcessConfig(double intensity, double start, double end)
        {
            IntensityFunction = (double x) => intensity;
            Start = start;
            End = end;
        }

        public Func<double, double> IntensityFunction { get; }
        public double Start { get; }
        public double End { get; }
    }
}
