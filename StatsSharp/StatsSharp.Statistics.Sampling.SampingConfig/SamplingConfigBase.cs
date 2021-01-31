using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    public class SamplingConfigBase<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
    {
        public SamplingConfigBase(
            IDistribution<TargetDistributionInputDataType, TargetDistributionParameter> targetDistribution,
            TargetDistributionParameter targetDistParameter,
            int count)
        {
            TargetDistribution = targetDistribution;
            TargetDistParameter = targetDistParameter;
            Count = count;
        }

        public IDistribution<TargetDistributionInputDataType, TargetDistributionParameter> TargetDistribution { get; }
        public TargetDistributionParameter TargetDistParameter { get; }
        public int Count { get; }
    }
}
