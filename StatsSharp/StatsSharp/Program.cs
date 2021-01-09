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

            var size = 1000000;
            var rejectionSamplerConfig = new StatsSharp.Probability.SamplerConfig.RejectionSamplerConfig
                <double, Probability.Parameter.Normal, Probability.Parameter.Normal>(new Probability.Distribution.Normal(), new Probability.Parameter.Normal(0, 1),
                new Probability.Distribution.Normal(), new Probability.Parameter.Normal(0, 1), size, 1);
            var sampler = new Probability.Sampler.RejectionSampler<double, Probability.Parameter.Normal, Probability.Parameter.Normal>();
            var sampleFromSampler = sampler.GetSamples(rejectionSamplerConfig);

            var nullHypothesis = new Statistics.StatisticalTest.NullHypothesis.TTestOneSampleNullHypothesis(sampleFromSampler, 0);
            var results = Statistics.StatisticalTest.Parametric.TTestOneSample(nullHypothesis);

            Console.WriteLine(results.Statistics);
            Console.WriteLine(results.PValue);
            Console.WriteLine(sampleFromSampler.Average());
            Console.WriteLine(sampleFromSampler.StadardDeviation());
        }
    }
}
