using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using StatsSharp.Statistics.Sampling.SamplingConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingMethod
{
    public class RejectionSampling<TargetDistributionDataType, TargetDistributionParameter, ProposalDistributionParameter>
        : ISamplingMethod<RejectionSamplingConfig<TargetDistributionDataType, TargetDistributionParameter, ProposalDistributionParameter>, TargetDistributionDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
        where ProposalDistributionParameter : IParameter
    {
        public IEnumerable<TargetDistributionDataType> GetSamples(RejectionSamplingConfig<TargetDistributionDataType, TargetDistributionParameter, ProposalDistributionParameter> samplerConfig, int size)
        {
            return Enumerable.Range(0, size).Select(i =>
            {
                var uniformParam = new Probability.Parameter.Continuous.Scalar.Uniform(0, 1);
                var uniform = new Probability.Distribution.Continuous.Scalar.Uniform();

                var targetProbabilityDensityFunction = ((IHasProbabilityDensityFunctionDistribution<TargetDistributionDataType, TargetDistributionParameter>)samplerConfig.TargetDistribution).GetProbabilityDensityFunction(samplerConfig.TargetDistParameter);
                var proposalProbabilityDensityFunction = ((IHasProbabilityDensityFunctionDistribution<TargetDistributionDataType, ProposalDistributionParameter>)samplerConfig.ProposalDistribution).GetProbabilityDensityFunction(samplerConfig.ProposalDistParameter);

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
