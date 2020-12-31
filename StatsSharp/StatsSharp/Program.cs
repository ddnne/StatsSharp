using StatsSharp.Extensions;
using System;
using System.Linq;

namespace StatsSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var samples = (new Probability.Distribution.Normal()).GetSamples(new Probability.Parameter.Normal(Math.Exp(1), Math.PI), 10000);
            Console.WriteLine(samples.Average());
            Console.WriteLine(samples.StadardDeviation());

        }
    }
}
