using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    public class SamplingConfigBase<TargetDistributionInputDataType, TargetDistributionParameter>
        : ISamplingConfig<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
    {
        public SamplingConfigBase(
            IDistribution<TargetDistributionInputDataType, TargetDistributionParameter> targetDistribution,
            TargetDistributionParameter targetDistParameter)
        {
            TargetDistribution = targetDistribution;
            TargetDistParameter = targetDistParameter;
        }

        public IDistribution<TargetDistributionInputDataType, TargetDistributionParameter> TargetDistribution { get; }
        public TargetDistributionParameter TargetDistParameter { get; }
    }
}
