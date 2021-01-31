using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    public class SamplingConfigBase<TargetDist, TargetDistributionInputDataType, TargetDistributionParameter>
        : ISamplingConfig<TargetDist, TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDist : 
            IDistribution<TargetDistributionInputDataType, TargetDistributionParameter>, 
            IHasProbabilityDensityFunction<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
    {
        public SamplingConfigBase(
            TargetDist targetDistribution,
            TargetDistributionParameter targetDistParameter,
            int count)
        {
            TargetDistribution = targetDistribution;
            TargetDistParameter = targetDistParameter;
            Count = count;
        }

        public TargetDist TargetDistribution { get; }
        public TargetDistributionParameter TargetDistParameter { get; }
        public int Count { get; }
    }
}
