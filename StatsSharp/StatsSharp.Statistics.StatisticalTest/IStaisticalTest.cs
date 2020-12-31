using System;
using System.Collections.Generic;

namespace StatsSharp.Statistics.StatisticalTest
{
    public interface IStaisticalTest<NullHypothesis> where NullHypothesis : INullHypothesis
    {
        StatisticalTestResult Calculate(NullHypothesis nullHypothesis);
    }
}
