using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest.StatisticalTestResult
{
    public interface ITestResult
    {
        double Statistics { get; }
        double PValue { get; }

    }
}
