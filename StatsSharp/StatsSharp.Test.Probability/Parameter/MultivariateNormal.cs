using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    public class MultivariateNormal
    {
        [TestMethod]
        public void TestConstructor()
        {
            var mean = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(new List<double>() { 1, 2 });
            var sd = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.DenseOfColumnArrays(new double[][] { new double[] { 1, 0 }, new double[] { 0, 2 } });
            var normalParameter = new StatsSharp.Probability.Parameter.MultivariateNormal(mean, sd);

            Assert.IsTrue(mean.Equals(normalParameter.Mean));
            Assert.IsTrue(sd.Equals(normalParameter.Sigma));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSingularSigma()
        {
            var mean = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(new List<double>() { 1, 2 });
            var sd = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.DenseOfColumnArrays(new double[][] { new double[] { 1, 0 }, new double[] { 0, 0 } });
            var normalParameter = new StatsSharp.Probability.Parameter.MultivariateNormal(mean, sd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNotSymmetric()
        {
            var mean = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(new List<double>() { 1, 2 });
            var sd = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.DenseOfColumnArrays(new double[][] { new double[] { 1, 0 }, new double[] { 1, 1 } });
            var normalParameter = new StatsSharp.Probability.Parameter.MultivariateNormal(mean, sd);
        }
    }
}
