using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.StochasticProcess.PointProcessEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public interface IPointProcess<PointProcessConfig, PointProcessEvent, IntensityType>
        where PointProcessConfig : IPointProcessConfig
        where PointProcessEvent : IPointProcessEvent
    {
        public IEnumerable<IEnumerable<PointProcessEvent>> GetEventSamples(PointProcessConfig config, int size);

        public IEnumerable<int> GetNumberOfEventSamples(PointProcessConfig config, int size);
    }
}
