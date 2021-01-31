using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.NullHypothesis
{
    public interface INullHypothesis<DataType>
    {
        IEnumerable<DataType> Samples { get; }
    }
}
