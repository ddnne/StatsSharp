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

        public static double Product(this IEnumerable<double> values)
        {
            double ret = 1;
            foreach (var value in values)
                ret *= value;
            return ret;
        }

        public static int Product(this IEnumerable<int> values)
        {
            int ret = 1;
            foreach (var value in values)
                ret *= value;
            return ret;
        }

        public static IEnumerable<double> CumulativeProduct(this IEnumerable<double> values)
        {
            double sum = 1;
            foreach (var value in values)
            {
                sum *= value;
                yield return sum;
            }
        }

        public static IEnumerable<int> CumulativeProduct(this IEnumerable<int> values)
        {
            int sum = 1;
            foreach (var value in values)
            {
                sum *= value;
                yield return sum;
            }
        }

        public static IEnumerable<IEnumerable<T>> Combination<T>(this IEnumerable<T> values, int r)
        {
            var size = values.Count();
            if (size < r)
                throw new ArgumentException();
            for (int i = 0; i < size - r + 1; ++i)
            {
                var ret = new List<T>();
                ret.Add(values.ElementAt(i));
                if (r != 1)
                {
                    var combs = values.Skip(i + 1).Combination(r - 1);
                    foreach (var comb in combs)
                    {
                        yield return ret.Concat(comb);
                    }
                }
                else
                    yield return ret;
            }
        }

        public static IEnumerable<IEnumerable<T>> Permutation<T>(this IEnumerable<T> values, int r)
        {
            var size = values.Count();
            if (size < r)
                throw new ArgumentException();
            for (int i = 0; i < size - r; ++i)
            {
                var ret = new List<T>();
                ret.Add(values.ElementAt(i));
                if (r != 1)
                {
                    var combs = values.Take(i).Concat(values.Skip(i + 1)).Permutation(r - 1);
                    foreach (var comb in combs)
                    {
                        yield return ret.Concat(comb);
                    }
                }
                else
                    yield return ret;
            }
        }
    }
}
