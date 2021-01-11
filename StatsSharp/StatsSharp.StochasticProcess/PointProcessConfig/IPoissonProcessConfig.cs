using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public interface IPoissonProcessConfig
    {
        Func<double, double> IntensityFunction { get; }
        double Start { get; }
        double End { get; }
    }
}
