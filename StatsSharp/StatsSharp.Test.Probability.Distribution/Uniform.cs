using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class Uniform
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var uniform = new StatsSharp.Probability.Distribution.Uniform();

            var start = 0;
            var end = 2;
            // start < data < end
            var likelihood = uniform.GetLikelihoodFunction(0.5);
            var parameter = new StatsSharp.Probability.Parameter.Uniform(start, end);
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
            var uniform = new StatsSharp.Probability.Distribution.Uniform();

            var start = 0;
            var end = 2;
            var parameter = new StatsSharp.Probability.Parameter.Uniform(start, end);
            var density = uniform.GetProbabilityDensityFunction(parameter);

            Assert.AreEqual(1.0/(end - start), density(0.5), 1.0e-10);
            Assert.AreEqual(0, density(start - 1), 1.0e-10);
            Assert.AreEqual(0, density(end + 1), 1.0e-10);
        }
    }
}
