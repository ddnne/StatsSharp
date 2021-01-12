using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public class NonStationaryPoissonProcessConfig : IPoissonProcessConfig<Func<double, double>>
    {
        public NonStationaryPoissonProcessConfig(Func<double, double> intensity, double start, double end)
        {
            if (end < start)
                throw new ArgumentException();
            Intensity =  intensity;
            Start = start;
            End = end;
        }

        public Func<double, double> Intensity { get; }
        public double Start { get; }
        public double End { get; }
    }
}
