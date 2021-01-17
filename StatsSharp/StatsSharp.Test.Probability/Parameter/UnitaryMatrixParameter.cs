﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Test.Probability.Parameter
{
    [TestClass]
    class UnitaryMatrixParameter
    {
        [TestMethod]
        public void TestConstructor()
        {
            var size = 1;

            var uParameter = new StatsSharp.Probability.Parameter.UnitaryMatrixParameter(size);
            Assert.AreEqual(size, uParameter.MatrixSize, 1.0e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinusAverage()
        {
            var size = -1;
            var expParameter = new StatsSharp.Probability.Parameter.UnitaryMatrixParameter(size);
        }
    }
}
