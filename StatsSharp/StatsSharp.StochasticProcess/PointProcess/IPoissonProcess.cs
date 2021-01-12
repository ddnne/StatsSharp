using StatsSharp.StochasticProcess.PointProcessConfig;
using StatsSharp.Probability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.StochasticProcess.PointProcess
{
    public interface IPoissonProcess<PoissonProcessConfig, IntensityType>
        where PoissonProcessConfig : IPoissonProcessConfig<IntensityType>
    {
        public IEnumerable<IEnumerable<double>> GetEventSamples(PoissonProcessConfig config, int size);

        public IEnumerable<int> GetNumberOfEventSamples(PoissonProcessConfig config, int size);
    }
}
