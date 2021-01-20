using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace StatsSharp.Test.Probability.Distribution
{
    [TestClass]
    public class MultivariateNormal
    {
        [TestMethod]
        public void TestLikelihoodFunction()
        {
            var mNormal = new StatsSharp.Probability.Distribution.Continuous.Vector.MultivariateNormal();

            var mean = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(new List<double>(){0, 1});
            var sigma = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.DenseOfColumnArrays(new double[][] { new double[] { 1, 0 }, new double[] { 0, 2 } });
            var at = mean;

            var likelihood = mNormal.GetLikelihoodFunction(at);
            var parameter = new StatsSharp.Probability.Parameter.MultivariateNormal(mean, sigma);
            var actual = likelihood(parameter);
            Assert.AreEqual(1/Math.Sqrt(Math.Pow(2 * Math.PI, 2) * 2), actual, 1.0e-10);
        }

        [TestMethod]
        public void TestProbabilityDensityFunction()
        {
            var mNormal = new StatsSharp.Probability.Distribution.Continuous.Vector.MultivariateNormal();

            var mean = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(new List<double>(){0, 1});
            var sigma = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.DenseOfColumnArrays(new double[][] { new double[] { 1, 0 }, new double[] { 0, 2 } });
            var at = mean;

            var parameter = new StatsSharp.Probability.Parameter.MultivariateNormal(mean, sigma);
            var density = mNormal.GetProbabilityDensityFunction(parameter);
            var actual = density(at);
            Assert.AreEqual(1 / Math.Sqrt(Math.Pow(2 * Math.PI, 2) * 2), actual, 1.0e-10);
        }

        [TestMethod]
        public void TestMaxValueProbabilityDensityFunction()
        {
            var dim = 2;
            var mNormal = new StatsSharp.Probability.Distribution.Continuous.Vector.MultivariateNormal();

            var mean = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(new List<double>(){0, 1});
            var sigma = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.DenseOfColumnArrays(new double[][] { new double[] { 1, 0 }, new double[] { 0, 2 } });

            var parameter = new StatsSharp.Probability.Parameter.MultivariateNormal(mean, sigma);
            Assert.AreEqual(1 / Math.Sqrt(Math.Pow(2 * Math.PI, dim) * 2), mNormal.GetMaxValueProbabilityDensityFunction(parameter), 1.0e-10);
        }
    }
}
