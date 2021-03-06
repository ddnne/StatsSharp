using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.Probability.Distribution.Continuous.Scalar
{
    [TestClass]
    public class Uniform
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var uniform = new StatsSharp.Probability.Distribution.Continuous.Scalar.Uniform();

            var start = 0;
            var end = 2;
            // start < data < end
            var likelihood = uniform.GetLikelihoodFunction(0.5);
            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Uniform(start, end);
            var actual = likelihood(parameter);
            Assert.AreEqual(1.0 / (end - start), actual, 1.0e-10);

            // data < start
            var likelihoodAtDataSmallerThanStart = uniform.GetLikelihoodFunction(start - 1);
            var actualAtDataSmallerThanStart = likelihoodAtDataSmallerThanStart(parameter);
            Assert.AreEqual(0, actualAtDataSmallerThanStart, 1.0e-10);

            // data > end
            var likelihoodAtDataLargerThanEnd = uniform.GetLikelihoodFunction(end + 1);
            var actualAtDataLargerThanEnd = likelihoodAtDataLargerThanEnd(parameter);
            Assert.AreEqual(0, actualAtDataLargerThanEnd, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var uniform = new StatsSharp.Probability.Distribution.Continuous.Scalar.Uniform();

            var start = 0;
            var end = 2;
            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Uniform(start, end);
            var density = uniform.GetProbabilityDensityFunction(parameter);

            Assert.AreEqual(1.0/(end - start), density(0.5), 1.0e-10);
            Assert.AreEqual(0, density(start - 1), 1.0e-10);
            Assert.AreEqual(0, density(end + 1), 1.0e-10);
        }

        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var uniform = new StatsSharp.Probability.Distribution.Continuous.Scalar.Uniform();

            var start = 0;
            var end = 2;
            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Uniform(start, end);
            var cdf = uniform.GetCumulativeDistributionFunction(parameter);

            Assert.AreEqual(0, cdf(start - 1), 1.0e-10);
            Assert.AreEqual(1, cdf(end + 1), 1.0e-10);
            Assert.AreEqual(0.5, cdf(start + (end - start) / 2), 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var uniform = new StatsSharp.Probability.Distribution.Continuous.Scalar.Uniform();

            var start = 0;
            var end = 2;
            var parameter = new StatsSharp.Probability.Parameter.Continuous.Scalar.Uniform(start, end);
            Assert.AreEqual(1.0/(end - start), uniform.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
