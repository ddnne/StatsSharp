using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.StchasticProcess.PointProcessEvent
{
    [TestClass]
    public class MultivariatePointProcessEvent
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var kind = 3;
            var t = 1.5;
            var obj = new StatsSharp.StochasticProcess.PointProcessEvent.MultivariatePointProcessEvent(kind, t);
            Assert.AreEqual(kind, obj.EventKind, 1.0e-10);
            Assert.AreEqual(t, obj.EventTime, 1.0e-10);
        }
    }
}
