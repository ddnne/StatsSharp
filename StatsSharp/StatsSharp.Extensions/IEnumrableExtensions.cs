using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsSharp.Extensions
{
    public static class IEnumrableExtensions
    {
        public static double Variance(this IEnumerable<double> values)
        {
            if (values.Count() == 0)
                return Double.NaN;

            var mean = values.Average();
            return values.Select(v => Math.Pow(v - mean, 2)).Average();
        }

        public static double StandardDeviation(this IEnumerable<double> values)
        {
            return Math.Sqrt(values.Variance());
        }
        public static double Variance(this IEnumerable<int> values)
        {
            if (values.Count() == 0)
                return Double.NaN;

            var mean = values.Average();
            return values.Select(v => Math.Pow(v - mean, 2)).Average();
        }

        public static double StandardDeviation(this IEnumerable<int> values)
        {
            return Math.Sqrt(values.Variance());
        }
    }
}
