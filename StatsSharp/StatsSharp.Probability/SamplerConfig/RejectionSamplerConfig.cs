using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.SamplerConfig
{
    // https://en.wikipedia.org/wiki/Rejection_sampling
    // if M == null then M = max(TargetDist) / max(ProposalDist)
    public class RejectionSamplerConfig<TargetDistributionInputDataType, TargetDistributionParameter, ProposalDistributionParameter>
        : SamplerConfigBase<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
        where ProposalDistributionParameter : IParameter
    {
        public RejectionSamplerConfig(
            IDistribution<TargetDistributionInputDataType, TargetDistributionParameter> targetDistribution,
            TargetDistributionParameter targetDistParameter, 
            IDistribution<TargetDistributionInputDataType, ProposalDistributionParameter> proposalDistribution,
            ProposalDistributionParameter proposalDistParameter,
            int count, double m)
            : base(targetDistribution, targetDistParameter, count)
        {
            ProposalDistribution = proposalDistribution;
            ProposalDistParameter = proposalDistParameter;
            M = m;
        }
        public IDistribution<TargetDistributionInputDataType, ProposalDistributionParameter> ProposalDistribution { get; }
        public ProposalDistributionParameter ProposalDistParameter { get; }
        public double M { get; }
    }
}
