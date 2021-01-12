using StatsSharp.StochasticProcess.PointProcessConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public interface IPointProcess<PointProcessConfig, IntensityType>
        where PointProcessConfig : IPoissonProcessConfig<IntensityType>
    {
        public IEnumerable<IEnumerable<double>> GetEventSamples(PointProcessConfig config, int size);

        public IEnumerable<int> GetNumberOfEventSamples(PointProcessConfig config, int size);
    }
}
