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
    }
}
