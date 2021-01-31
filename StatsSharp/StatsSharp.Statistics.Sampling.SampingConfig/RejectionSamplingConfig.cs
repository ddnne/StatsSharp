using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using StatsSharp.Statistics.Sampling.SamplingConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    // https://en.wikipedia.org/wiki/Rejection_sampling
    // [ToDo]: if M == null then M = max(TargetDist) / max(ProposalDist)
    public class RejectionSamplingConfig<TargetDistributionInputDataType, TargetDistributionParameter, ProposalDistributionParameter>
        : SamplingConfigBase<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
        where ProposalDistributionParameter : IParameter
    {
        public RejectionSamplingConfig(
            IHasProbabilityDensityFunctionDistribution<TargetDistributionInputDataType, TargetDistributionParameter> targetDistribution, TargetDistributionParameter targetDistParameter,
            IHasProbabilityDensityFunctionDistribution<TargetDistributionInputDataType, ProposalDistributionParameter> proposalDistribution, ProposalDistributionParameter proposalDistParameter,
            double m)
            : base(targetDistribution, targetDistParameter)
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
