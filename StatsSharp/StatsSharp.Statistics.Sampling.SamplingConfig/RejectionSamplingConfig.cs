using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using StatsSharp.Statistics.Sampling.SamplingConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    // https://en.wikipedia.org/wiki/Rejection_sampling
    // if M == null then M = max(TargetDist) / max(ProposalDist)
    public class RejectionSamplingConfig<TargetDist, TargetDistributionInputDataType, TargetDistributionParameter, 
                                        ProposalDist, ProposalDistributionParameter>
        : SamplingConfigBase<TargetDist, TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDist :
            IDistribution<TargetDistributionInputDataType, TargetDistributionParameter>,
            IHasProbabilityDensityFunction<TargetDistributionInputDataType, TargetDistributionParameter>
        where ProposalDist :
            IDistribution<TargetDistributionInputDataType, ProposalDistributionParameter>,
            IHasProbabilityDensityFunction<TargetDistributionInputDataType, ProposalDistributionParameter>

        where TargetDistributionParameter : IParameter
        where ProposalDistributionParameter : IParameter
    {
        public RejectionSamplingConfig(
            TargetDist targetDistribution,
            TargetDistributionParameter targetDistParameter, 
            ProposalDist proposalDistribution,
            ProposalDistributionParameter proposalDistParameter,
            int count, double m)
            : base(targetDistribution, targetDistParameter, count)
        {
            ProposalDistribution = proposalDistribution;
            ProposalDistParameter = proposalDistParameter;
            M = m;
        }
        public ProposalDist ProposalDistribution { get; }
        public ProposalDistributionParameter ProposalDistParameter { get; }
        public double M { get; }
    }
}
