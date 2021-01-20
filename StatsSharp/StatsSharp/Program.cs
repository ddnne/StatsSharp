using StatsSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CheckUnitaryMatrixGenerate();
            CheckOrthogonalMatrixGenerate();
        }

        static void CheckRejectionSampling()
        {
            var size = 10000;
            var rejectionSamplerConfig = new Probability.SamplerConfig.RejectionSamplerConfig
                <double, Probability.Parameter.Exponential, Probability.Parameter.Exponential>(new Probability.Distribution.Continuous.Scalar.Exponential(), new Probability.Parameter.Exponential(2),
                new Probability.Distribution.Continuous.Scalar.Exponential(), new Probability.Parameter.Exponential(4), size, 2);
            var sampler = new Probability.Sampler.RejectionSampler<double, Probability.Parameter.Exponential, Probability.Parameter.Exponential>();
            var sampleFromSampler = sampler.GetSamples(rejectionSamplerConfig);

            var nullHypothesis = new Statistics.StatisticalTest.NullHypothesis.TTestOneSampleNullHypothesis(sampleFromSampler, 0);
            var results = Statistics.StatisticalTest.TestMethod.Parametric.TTestOneSample(nullHypothesis);

            Console.WriteLine(results.Statistics);
            Console.WriteLine(results.PValue);
            Console.WriteLine(sampleFromSampler.Average());
            Console.WriteLine(sampleFromSampler.StandardDeviation());

            var gamma = new Probability.Distribution.Continuous.Scalar.Gamma();
            var gammaParam = new Probability.Parameter.Gamma(2.5, 2);
            var gammaSamples = gamma.GetSamples(gammaParam, size);
            Console.WriteLine(gammaSamples.Average());
            Console.WriteLine(gammaSamples.StandardDeviation());

            var poisson = new Probability.Distribution.Discrete.Poisson();
            var poissonParam = new Probability.Parameter.Poisson(1.5);
            var poissonSamples = poisson.GetSamples(poissonParam, size);
            Console.WriteLine(poissonSamples.Average());
            Console.WriteLine(Math.Pow(poissonSamples.StandardDeviation(), 2));
        }

        static void CheckStationaryPoissonProcess()
        {
            int size = 10000;
            Console.WriteLine("Stationary");
            var pp = new StochasticProcess.PointProcess.StationaryPoissonProcess();
            var ppConfig = new StochasticProcess.PointProcessConfig.StationaryPoissonProcessConfig(2, 0, 100);
            var ppCountSamples = pp.GetNumberOfEventSamples(ppConfig, size);
            Console.WriteLine(ppCountSamples.Average());
            Console.WriteLine(ppCountSamples.StandardDeviation());
            var ppTimeSamples = pp.GetEventSamples(ppConfig, size);
            Console.WriteLine(ppTimeSamples.Select(sample => sample.Count()).Average());
            Console.WriteLine(ppTimeSamples.Select(sample => sample.Count()).StandardDeviation());
            var ppTimeDiffs = ppTimeSamples.Select(samples => samples.Select(t=> t.EventTime).DiffFromPreviousElement());

            var ppConcated = new List<double>().Select(x => x);
            foreach (var tmp in ppTimeDiffs)
                ppConcated = ppConcated.Concat(tmp);
            Console.WriteLine(ppConcated.Average());
            Console.WriteLine(ppConcated.StandardDeviation());
        }

        static void CheckNonStationaryPoissonProess()
        {
            int size = 10000;
            Console.WriteLine("Non Stationary");
            var npp = new StochasticProcess.PointProcess.NonStationaryPoissonProcess();
            var nppStart = 0.0;
            var nppEnd = 1.0;
            Func<double, double> nppIntensity = (double t) => 0 * 100 / (nppEnd - nppStart) + 3.0 * Math.Pow(t - (nppEnd + nppStart) / 2, 2) / Math.Pow((nppEnd + nppStart) / 2, 3);
            var nppConfig = new StochasticProcess.PointProcessConfig.NonStationaryPoissonProcessConfig(nppIntensity, nppStart, nppEnd);
            var nppCountSamples = npp.GetNumberOfEventSamples(nppConfig, size);
            Console.WriteLine(nppCountSamples.Average());
            Console.WriteLine(nppCountSamples.StandardDeviation());
            var nppTimeSamples = npp.GetEventSamples(nppConfig, size).Select(t => t.ToList()).ToList();
            var nppTimeSamplesCount = nppTimeSamples.Select(t => t.ToList().Count()).ToList();
            Console.WriteLine(nppTimeSamplesCount.Average());
            Console.WriteLine(nppTimeSamplesCount.StandardDeviation());
            var nppTimeDiffs = nppTimeSamples.Select(samples => samples.Select(t => t.EventTime).DiffFromPreviousElement());

            var nppConcated = new List<double>().Select(x => x);
            foreach (var tmp in nppTimeDiffs)
                nppConcated = nppConcated.Concat(tmp);
            Console.WriteLine(nppConcated.Average());
            Console.WriteLine(nppConcated.StandardDeviation());
        }

        static void CheckCategorical()
        {
            int size = 10000;
            var probs = new List<double>() { 0.1, 0.3, 0.5, 0.1 };
            var cat = new Probability.Distribution.Discrete.Categorical();
            var catParam = new Probability.Parameter.Categorical(probs);
            var samples = cat.GetSamples(catParam, size);

            var groups = samples.GroupBy(i => i);

            foreach (var group in groups)
                Console.WriteLine(group.Key.ToString() + "\t" + group.Count().ToString());
        }

        static void CheckUnitaryMatrixGenerate()
        {
            var size = 10;
            var uMatrix = new Probability.Distribution.Continuous.Matrix.RandomUnitaryMatrix();
            var param = new Probability.Parameter.RandomUnitaryMatrix(2);

            var samples = uMatrix.GetSamples(param, size);
            foreach (var sample in samples)
            {
                var prod = sample.Conjugate().Transpose() * sample;
                Console.WriteLine(prod.ToString());
            }
        }

        static void CheckOrthogonalMatrixGenerate()
        {
            var size = 10;
            var uMatrix = new Probability.Distribution.Continuous.Matrix.RandomOrthogonalMatrix();
            var param = new Probability.Parameter.RandomOrthogonalMatrix(2);

            var samples = uMatrix.GetSamples(param, size);
            foreach (var sample in samples)
            {
                var prod = sample.Conjugate().Transpose() * sample;
                Console.WriteLine(prod.ToString());
            }
        }
    }
}
