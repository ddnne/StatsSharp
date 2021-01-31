using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessEvent
{
    public class UnivariatePointProcessEvent : IPointProcessEvent
    {
        public UnivariatePointProcessEvent(double eventTime)
        {
            EventTime = eventTime;
        }

        public double EventTime { get; }
    }
}
