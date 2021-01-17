using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessEvent
{
    public interface IPointProcessEvent
    {
        double EventTime { get; }
    }
}
