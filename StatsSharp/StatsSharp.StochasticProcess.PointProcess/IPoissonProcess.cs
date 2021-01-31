using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.Probability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatsSharp.StochasticProcess.PointProcessEvent;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public interface IPoissonProcess<PoissonProcessConfig, PointProcessEvent, IntensityType>
        where PoissonProcessConfig : IPoissonProcessConfig<IntensityType>
        where PointProcessEvent : IPointProcessEvent
    {
        public IEnumerable<IEnumerable<PointProcessEvent>> GetEventSamples(PoissonProcessConfig config, int size);

        public IEnumerable<int> GetNumberOfEventSamples(PoissonProcessConfig config, int size);
    }
}
