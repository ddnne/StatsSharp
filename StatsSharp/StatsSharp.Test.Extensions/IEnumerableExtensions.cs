using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsSharp.Test.Extensions
{
    [TestClass]
    public class IEnumerableExtensions
    {
        [TestMethod]
        public void VarianceTest()
        {
            var doubleList = new List<double>() { 0, 1.0 };
            Assert.AreEqual(0.25, doubleList.Variance(), 1.0e-10);
            Assert.AreEqual(Math.Sqrt(0.25), doubleList.StandardDeviation(), 1.0e-10);

            var intList = new List<int>() { 0, 1 };
            Assert.AreEqual(0.25, intList.Variance(), 1.0e-10);
            Assert.AreEqual(Math.Sqrt(0.25), intList.StandardDeviation(), 1.0e-10);
        }

        [TestMethod]
        public void DiffFromPreviousElementTest()
        {
            var doubleList = new List<double>() { 0, 1.0 };
            var doubleResult = doubleList.DiffFromPreviousElement();
            CollectionAssert.AreEqual(new List<double>() { 1.0 }, doubleResult.ToList());

            var intList = new List<int>() { 0, 1 };
            var intResult = intList.DiffFromPreviousElement();
            CollectionAssert.AreEqual(new List<int>() { 1 }, intResult.ToList());
        }

        [TestMethod]
        public void MinByTest()
        {
            var data = new List<double>() { 0, 1.0 };
            Assert.AreEqual(1, data.MinBy(x => -x), 1.0e-10);
        }

        [TestMethod]
        public void MaxByTest()
        {
            var data = new List<double>() { 0, 1.0 };
            Assert.AreEqual(0, data.MaxBy(x => -x), 1.0e-10);
        }

        [TestMethod]
        public void CumulativeSumTest()
        {
            var doubleList = new List<double>() { 0, 1, 2 };
            var doubleResult = doubleList.CumulativeSum();
            CollectionAssert.AreEqual(new List<double>() { 0, 1, 3 }, doubleResult.ToList());

            var intList = new List<int>() { 0, 1, 2 };
            var intResult = intList.CumulativeSum();
            CollectionAssert.AreEqual(new List<int>() { 0, 1, 3 }, intResult.ToList());
        }

        [TestMethod]
        public void ProductTest()
        {
            var doubleList = new List<double>() { 1, 2 };
            var doubleResult = doubleList.Product();
            Assert.AreEqual(2, doubleResult, 1.0e-10);

            var intList = new List<int>() { 1, 2 };
            var intResult = intList.Product();
            Assert.AreEqual(2, intResult, 1.0e-10);
        }

        [TestMethod]
        public void CumulativeProductTest()
        {
            var doubleList = new List<double>() { 1, 2, 3 };
            var doubleResult = doubleList.CumulativeProduct();
            CollectionAssert.AreEqual(new List<double>() { 1, 2, 6 }, doubleResult.ToList());

            var intList = new List<int>() { 1, 2, 5 };
            var intResult = intList.CumulativeProduct();
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 10 }, intResult.ToList());
        }

        [TestMethod]
        public void CombinationTest()
        {
            var elems = new int[] { 1, 2 };
            var results__ = elems.Combination(1);

            Assert.AreEqual(2, results__.Count());
            foreach (var result in results__)
                Assert.AreEqual(1, result.Count());

            var results = results__.Select(i => i.First()).OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(new int[] { 1, 2 }, results.ToArray());

            var results_ = elems.Combination(2);

            Assert.AreEqual(1, results_.Count());
            foreach (var result in results_)
                Assert.AreEqual(2, result.Count());

            results = results_.First().ToList();
            CollectionAssert.AreEqual(new int[] { 1, 2 }, results.ToArray());
        }

        [TestMethod]
        public void PermutationTest()
        {
            var elems = new int[] { 1, 2 };
            var results__ = elems.Permutation(1);

            Assert.AreEqual(2, results__.Count());
            foreach (var result in results__)
                Assert.AreEqual(1, result.Count());

            var results = results__.Select(i => i.First()).OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(new int[] { 1, 2 }, results.ToArray());

            var results_ = elems.Permutation(2).OrderBy(x => x.First());

            Assert.AreEqual(2, results_.Count());
            foreach (var result in results_)
                Assert.AreEqual(2, result.Count());

            CollectionAssert.AreEqual(new int[] { 1, 2 }, results_.First().ToList());
            CollectionAssert.AreEqual(new int[] { 2, 1 }, results_.Last().ToList());
        }
    }
}
