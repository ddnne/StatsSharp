using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Test.Probability.SamplerConfig
{
    [TestClass]
    public class RejectionSamplerConfig
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var norm = new StatsSharp.Probability.Distribution.Continuous.Scalar.Normal();
            var normParam = new StatsSharp.Probability.Parameter.Normal(0, 1);
            var t = new StatsSharp.Probability.Distribution.Continuous.Scalar.T();
            var tParam = new StatsSharp.Probability.Parameter.T(0, 1, 2);
            var count = 100;
            var m = 1.2;

            var rejectionSamplerConfig = new StatsSharp.Probability.SamplerConfig.RejectionSamplerConfig
                <double, StatsSharp.Probability.Parameter.Normal, StatsSharp.Probability.Parameter.T>(norm, normParam, t, tParam, count, m: m);

            Assert.IsTrue(rejectionSamplerConfig.TargetDistribution.GetType() == typeof(StatsSharp.Probability.Distribution.Continuous.Scalar.Normal));
            Assert.IsTrue(rejectionSamplerConfig.TargetDistParameter.GetType() == typeof(StatsSharp.Probability.Parameter.Normal));
            Assert.IsTrue(rejectionSamplerConfig.ProposalDistribution.GetType() == typeof(StatsSharp.Probability.Distribution.Continuous.Scalar.T));
            Assert.IsTrue(rejectionSamplerConfig.ProposalDistParameter.GetType() == typeof(StatsSharp.Probability.Parameter.T));
            Assert.AreEqual(normParam.Mean, rejectionSamplerConfig.TargetDistParameter.Mean, 1.0e-10);
            Assert.AreEqual(normParam.StandardDeviation, rejectionSamplerConfig.TargetDistParameter.StandardDeviation, 1.0e-10);
            Assert.AreEqual(tParam.Mean, rejectionSamplerConfig.ProposalDistParameter.Mean, 1.0e-10);
            Assert.AreEqual(tParam.Scale, rejectionSamplerConfig.ProposalDistParameter.Scale, 1.0e-10);
            Assert.AreEqual(tParam.DegreeOfFreedom, rejectionSamplerConfig.ProposalDistParameter.DegreeOfFreedom, 1.0e-10);
            Assert.AreEqual(count, rejectionSamplerConfig.Count);
            Assert.AreEqual(m, rejectionSamplerConfig.M, 1.0e-10);
        }
    }
}
