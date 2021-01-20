using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.Probability.SamplerConfig
{
    [TestClass]
    public class SamplerConfigBase
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var norm = new StatsSharp.Probability.Distribution.Continuous.Scalar.Normal();
            var normParam = new StatsSharp.Probability.Parameter.Normal(0, 1);
            var count = 100;

            var samplingConfigBase = new StatsSharp.Probability.SamplerConfig.SamplerConfigBase
                <double, StatsSharp.Probability.Parameter.Normal>(norm, normParam, count);

            Assert.IsTrue(samplingConfigBase.TargetDistribution.GetType() == typeof(StatsSharp.Probability.Distribution.Continuous.Scalar.Normal));
            Assert.IsTrue(samplingConfigBase.TargetDistParameter.GetType() == typeof(StatsSharp.Probability.Parameter.Normal));
            Assert.AreEqual(normParam.Mean, samplingConfigBase.TargetDistParameter.Mean, 1.0e-10);
            Assert.AreEqual(normParam.StandardDeviation, samplingConfigBase.TargetDistParameter.StandardDeviation, 1.0e-10);
            Assert.AreEqual(count, samplingConfigBase.Count);
        }
    }
}
