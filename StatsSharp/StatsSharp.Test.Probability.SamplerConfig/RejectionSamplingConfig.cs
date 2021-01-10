using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsSharp.Probability.SamplerConfig
{
    [TestClass]
    public class RejectionSamplingConfig
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var norm = new Probability.Distribution.Normal();
            var normParam = new Probability.Parameter.Normal(0, 1);
            var t = new Probability.Distribution.T();
            var tParam = new Probability.Parameter.T(0, 1, 2);
            var count = 100;
            var m = 1.2;

            var rejectionSamplerConfig = new StatsSharp.Probability.SamplerConfig.RejectionSamplerConfig
                <double, Probability.Parameter.Normal, Probability.Parameter.T>(norm, normParam, t, tParam, count, m: m);

            Assert.IsTrue(rejectionSamplerConfig.TargetDistribution.GetType() == typeof(Probability.Distribution.Normal));
            Assert.IsTrue(rejectionSamplerConfig.TargetDistParameter.GetType() == typeof(Probability.Parameter.Normal));
            Assert.IsTrue(rejectionSamplerConfig.ProposalDistribution.GetType() == typeof(Probability.Distribution.T));
            Assert.IsTrue(rejectionSamplerConfig.ProposalDistParameter.GetType() == typeof(Probability.Parameter.T));
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
