using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public interface IPointProcessConfig
    {
        double Start { get; }
        double End { get; }
    }
}
