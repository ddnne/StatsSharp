using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathNet.Numerics;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class T
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var t = new StatsSharp.Probability.Distribution.T();

            var mean = 0;
            var scale = 2;
            double dof = 1.0;
            var at = 1.59;

            var likelihood = t.GetLikelihoodFunction(at);
            var parameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
            var actual = likelihood(parameter);

            var expected = SpecialFunctions.Gamma((dof + 1) / 2) / (SpecialFunctions.Gamma(dof / 2) * Math.Sqrt(dof * Math.PI * scale))
                * Math.Pow(1 + Math.Pow((at - mean) / scale, 2) / dof, -(dof + 1) / 2);
            Assert.AreEqual(expected, actual, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var t = new StatsSharp.Probability.Distribution.T();

            var mean = 0;
            var scale = 2;
            double dof = 1;
            var at = 1.59;

            var parameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
            var density = t.GetProbabilityDensityFunction(parameter);
            var actual = density(at);

            var expected = SpecialFunctions.Gamma((dof + 1) / 2) / (SpecialFunctions.Gamma(dof / 2) * Math.Sqrt(dof * Math.PI * scale))
                * Math.Pow(1 + Math.Pow((at - mean) / scale, 2) / dof, -(dof + 1) / 2);
            Assert.AreEqual(expected, actual, 1.0e-10);
        }

        // https://keisan.casio.com/exec/system/1180573203
        [TestMethod]
        public void TestCumulativeDistributionFunction()
        {
            var t = new StatsSharp.Probability.Distribution.T();

            var mean = 0;
            var scale = 1;
            double dof = 2;
            var stat = 5;
            var expected = 0.981125224324688137091;

            var parameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
            var cdf = t.GetCumulativeDistributionFunction(parameter);
            var actual = cdf(stat);

            Assert.AreEqual(expected, actual, 1.0e-10);
        }

        [TestMethod]
        public void TestMaxProbabilityDensityFunction()
        {
            var t = new StatsSharp.Probability.Distribution.T();

            var mean = 0;
            var scale = 1;
            double dof = 2;
            var parameter = new StatsSharp.Probability.Parameter.T(mean, scale, dof);
            Assert.AreEqual(1/(2*Math.Sqrt(2)), t.GetMaxProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
