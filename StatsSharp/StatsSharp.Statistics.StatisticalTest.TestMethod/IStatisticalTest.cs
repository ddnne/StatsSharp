using StatsSharp.Statistics.StatisticalTest.NullHypothesis;
using StatsSharp.Statistics.StatisticalTest;
using StatsSharp.Statistics.StatisticalTest.StatisticalTestResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.TestMethod
{
    public interface IStatisticalTest<NullHypothesis, DataType>
        where NullHypothesis : INullHypothesis<DataType>
    {
        ITestResult Test(NullHypothesis nullHypothesis);
    }
}
