using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.StatisticalTest
{
    public class StatisticalTestResult
    {
        public StatisticalTestResult(double statistics, double pValue)
        {
            Statistics = statistics;
            PValue = pValue;
        }

        public double Statistics { get; }
        public double PValue { get; }

    }
}
