using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public class StationaryPoissonProcessConfig : IPoissonProcessConfig<double>
    {
        public StationaryPoissonProcessConfig(double intensity, double start, double end)
        {
            if (intensity <= 0 || end < start)
                throw new ArgumentException();
            Intensity = intensity;
            Start = start;
            End = end;
        }

        public double Intensity { get; }
        public double Start { get; }
        public double End { get; }
    }
}
