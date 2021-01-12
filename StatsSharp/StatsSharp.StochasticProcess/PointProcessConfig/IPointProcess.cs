using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessConfig
{
    public interface IPointProcess
    {
        double Start { get; }
        double End { get; }
    }
}
