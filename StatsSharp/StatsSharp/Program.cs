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
            var rejectionSamplerConfig = new Probability.SamplerConfig.RejectionSamplerConfig
                <double, Probability.Parameter.Exponential, Probability.Parameter.Exponential>(new Probability.Distribution.Exponential(), new Probability.Parameter.Exponential(2),
                new Probability.Distribution.Exponential(), new Probability.Parameter.Exponential(4), size, 2);
            var sampler = new Probability.Sampler.RejectionSampler<double, Probability.Parameter.Exponential, Probability.Parameter.Exponential>();
            var sampleFromSampler = sampler.GetSamples(rejectionSamplerConfig);

            var nullHypothesis = new Statistics.StatisticalTest.NullHypothesis.TTestOneSampleNullHypothesis(sampleFromSampler, 0);
            var results = Statistics.StatisticalTest.TestMethod.Parametric.TTestOneSample(nullHypothesis);

            Console.WriteLine(results.Statistics);
            Console.WriteLine(results.PValue);
            Console.WriteLine(sampleFromSampler.Average());
            Console.WriteLine(sampleFromSampler.StadardDeviation());

            var gamma = new Probability.Distribution.Gamma();
            var gammaParam = new Probability.Parameter.Gamma(2.5, 2);
            var samples = gamma.GetSamples(gammaParam, size);
            Console.WriteLine(samples.Average());
            Console.WriteLine(samples.StadardDeviation());
        }
    }
}
