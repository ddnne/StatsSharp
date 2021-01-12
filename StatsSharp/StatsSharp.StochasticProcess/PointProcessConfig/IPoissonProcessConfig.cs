using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public interface IPoissonProcessConfig<IntensityType> : IPointProcess
    {
        IntensityType Intensity { get; }
    }
}
