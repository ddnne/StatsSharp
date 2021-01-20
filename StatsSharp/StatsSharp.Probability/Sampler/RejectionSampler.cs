using StatsSharp.Probability.Parameter;
using StatsSharp.Probability.SamplerConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Probability.Sampler
{
    public class RejectionSampler<TargetDistributionDataType, TargetDistributionParameter, ProposalDistributionParameter>
        : ISamper<RejectionSamplerConfig<TargetDistributionDataType, TargetDistributionParameter, ProposalDistributionParameter>, TargetDistributionDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
        where ProposalDistributionParameter : IParameter
    {
        public IEnumerable<TargetDistributionDataType> GetSamples(RejectionSamplerConfig<TargetDistributionDataType, TargetDistributionParameter, ProposalDistributionParameter> samplerConfig)
        {
            return Enumerable.Range(0, samplerConfig.Count).Select(i =>
            {
                var uniformParam = new Probability.Parameter.Continuous.Scalar.Uniform(0, 1);
                var uniform = new Probability.Distribution.Continuous.Scalar.Uniform();

                var targetProbabilityDensityFunction = samplerConfig.TargetDistribution.GetProbabilityDensityFunction(samplerConfig.TargetDistParameter);
                var proposalProbabilityDensityFunction = samplerConfig.ProposalDistribution.GetProbabilityDensityFunction(samplerConfig.ProposalDistParameter);

                while (true)
                {
                    var sampleFromProposal = samplerConfig.ProposalDistribution.GetSamples(samplerConfig.ProposalDistParameter, 1).First();
                    var acceptProbability = targetProbabilityDensityFunction(sampleFromProposal) / (proposalProbabilityDensityFunction(sampleFromProposal) * samplerConfig.M);

                    var sampleFromUniform = uniform.GetSamples(uniformParam, 1).First();
                    if (sampleFromUniform < acceptProbability)
                        return sampleFromProposal;
                }
            });
        }
    }
}
