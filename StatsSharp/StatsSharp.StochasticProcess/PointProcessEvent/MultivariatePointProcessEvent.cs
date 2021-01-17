using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcessEvent
{
    public class MultivariatePointProcessEvent : IPointProcessEvent
    {
        public MultivariatePointProcessEvent(int eventKind, double eventTime)
        {
            EventKind = eventKind;
            EventTime = eventTime;
        }

        public int EventKind { get; }
        public double EventTime { get; }
    }
}
