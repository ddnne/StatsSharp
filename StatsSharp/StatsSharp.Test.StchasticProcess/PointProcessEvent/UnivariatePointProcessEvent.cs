using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.StchasticProcess.PointProcessEvent
{
    [TestClass]
    public class UnivariatePointProcessEvent
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var t = 1.5;
            var obj = new StatsSharp.StochasticProcess.PointProcessEvent.UnivariatePointProcessEvent(t);
            Assert.AreEqual(t, obj.EventTime, 1.0e-10);
        }
    }
}
