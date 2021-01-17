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

        public static IEnumerable<double> DiffFromPreviousElement(this IEnumerable<double> values)
        {
            var curr = values.Skip(1);
            var prev = values.SkipLast(1);
            return curr.Zip(prev, (c, p) => c - p);
        }

        public static IEnumerable<int> DiffFromPreviousElement(this IEnumerable<int> values)
        {
            var curr = values.Skip(1);
            var prev = values.SkipLast(1);
            return curr.Zip(prev, (c, p) => c - p);
        }

        public static T MinBy<T, U>(this IEnumerable<T> source, Func<T, U> selector)
        {
            var lookup = source.ToLookup(selector);
            return lookup[lookup.Min(a => a.Key)].First();
        }

        public static T MaxBy<T, U>(this IEnumerable<T> source, Func<T, U> selector)
        {
            var lookup = source.ToLookup(selector);
            return lookup[lookup.Max(a => a.Key)].Last();
        }

        public static IEnumerable<double> CumulativeSum(this IEnumerable<double> values)
        {
            double sum = 0;
            foreach (var value in values)
            {
                sum += value;
                yield return sum;
            }
        }

        public static IEnumerable<int> CumulativeSum(this IEnumerable<int> values)
        {
            int sum = 0;
            foreach (var value in values)
            {
                sum += value;
                yield return sum;
            }
        }
    }
}
